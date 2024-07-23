using Hris.Business.Extensions;
using Hris.Data.Models.Leave;
using Hris.Data.Models.Settings;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using Employee = Hris.Data.Models.Employee.Employee;
using TeamMember = Hris.Data.Models.Employee.TeamMember;

namespace Hris.Business.Service.Common
{
    public class SmtpService
    {
        private readonly IConfiguration configuration;
        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<LeaveType> leaveTypeRepository;
        private readonly IRepository<UserSettings> settingsRepository;
        private readonly IRepository<TeamMember> tmRepository;
        private readonly IRepository<LeaveApplication> applicationRepository;
        private readonly PdfService pdfService;

        public SmtpService(IConfiguration configuration,
            IRepository<Employee> employeeRepository,
            IRepository<LeaveType> leaveTypeRepository,
            IRepository<UserSettings> settingsRepository,
            IRepository<TeamMember> tmRepository,
            IRepository<LeaveApplication> applicationRepository)
        {
			this.configuration = configuration;
			this.employeeRepository = employeeRepository;
			this.leaveTypeRepository = leaveTypeRepository;
            this.settingsRepository = settingsRepository;
            this.tmRepository = tmRepository;
            this.applicationRepository = applicationRepository;

            this.pdfService = new PdfService();
        }

        public async Task<bool> SendScheduledLeaveReport(DateTime start, DateTime end)
        {
            try
            {
                var d = (await applicationRepository.GetDbSet())
                    .AsNoTracking()
                    .Include(d => d.Employee)
                        .ThenInclude(e => e.Settings)
                    .Include(d => d.LeaveType)
                    .AsEnumerable()
                    .Where(d => d.Status == Data.Models.Enum.LeaveStatus.HeadApproved
                        && d.From.ConvertToTimezone() >= start
                        && d.From.ConvertToTimezone() <= end)
                    .GroupBy(d => d.EmployeeId);

                var title = $"Leave Report for { start.ConvertToTimezone().ToShortDateString() } to { end.ConvertToTimezone().ToShortDateString() }";

                byte[]? file = null;

                if(d.Any())
                    file = pdfService.GenerateLeaveReportPdf(title, d);

                var message = new MailMessage();
                message.Subject = title;
                
                foreach(var email in configuration.GetSection("Leave:report").AsEnumerable())
                {
                    if (email.Value == null)
                        continue;
                    message.To.Add(new MailAddress(email.Value));
                }

                if (file == null)
                    message.Body = $"No Approved Leave Application(s) found for the current cut-off.";
                else
                    message.Attachments.Add(new Attachment(new MemoryStream(file), $"LeaveReport_{ start.ToShortDateString() }_{ end.ToShortDateString() }.pdf"));
                await this.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> ManageLeaveRequest(int req, LeaveApplication application) {
			try
			{
				var employee = (await employeeRepository.GetDbSet())
					.Where(d => d.Id.Equals(application.EmployeeId))
					.FirstOrDefault();

                var team = (await tmRepository.GetDbSet())
                    .Where(d => d.Active && d.EmployeeId.Equals(application.EmployeeId))
                    .Include(d => d.Team)
                        .ThenInclude(t => t.Department)
                            .ThenInclude(d => d.Manager)
                    .AsNoTracking();

                var settings = (await settingsRepository.GetDbSet())
                    .Where(d => d.EmployeeId.Equals(application.EmployeeId))
                    .FirstOrDefault();

				if (employee == null)
					throw new Exception("Employee does not exist.");

				var type = await leaveTypeRepository.GetByIdAsync(application.LeaveTypeId);

                if (type == null)
                    throw new Exception("Leave type does not exist.");

                var message = new MailMessage();
                message.IsBodyHtml = true;

				var employeeName = $"{employee.Firstname} {employee.Lastname}";

                switch (req)
				{ 
					case 1: message.Subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST.Replace("<name>", employeeName).Replace("<type>", type.Name); break;
                    case 2: message.Subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST_WITHDRAW.Replace("<name>", employeeName).Replace("<type>", type.Name); break;
                    case 3: message.Subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST_LEAD_APPROVED.Replace("<type>", type.Name); break;
                    case 4: message.Subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST_MANAGER_APPROVED.Replace("<type>", type.Name); break;
                    case 5: message.Subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST_REJECTED.Replace("<type>", type.Name); break;
                    case 6: message.Subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST_CANCELLED.Replace("<type>", type.Name); break;
                    case 7: message.Subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST_CANCELLED.Replace("<type>", type.Name); break;
                }

                using (var sr = new StreamReader(@"EmailTemplates\LeaveTemplate\LeaveTemplate.html"))
                {
                    var content = await sr.ReadToEndAsync();

                    message.Body = content.Replace("[emailBodyHeaderVar]", message.Subject)
                        .Replace("[employeeVar]", employeeName)
                        .Replace("[leaveTypeVar]", type.Name)
                        .Replace("[fromVar]", (settings == null ? $"{application.From} (UTC)" : $"{application.From.ConvertToTimezone(settings.Timezone).ToString("d")} ({settings.Timezone})"))
                        .Replace("[toVar]", (settings == null ? $"{application.To} (UTC)" : $"{application.To.ConvertToTimezone(settings.Timezone).ToString("d")} ({settings.Timezone})"))
                        .Replace("[daysVar]", application.Days.ToString())
                        .Replace("[reasonVar]", application.Reason)
                        .Replace("[statusVar]", application.Status.ToString()); 

                }
                 
                // Default Email / Admin
                message.To.Add(new MailAddress(configuration["Smtp:email"]));


                // Team
                foreach (var tm in team)
                {
                    if (tm.Team == null)
                        continue;

                    if (tm.Team.Department != null && tm.Team.Department.Manager != null)
                    {
                        var managerEmail = tm.Team.Department.Manager.Email;
                        if (!message.CC.Any(m => m.Address.Equals(managerEmail)))
                            message.CC.Add(new MailAddress(managerEmail));
                    }

                    if (tm.Team.Lead != null)
                    {
                        var leadEmail = tm.Team.Lead.Email;
                        if (!message.CC.Any(m => m.Address.Equals(leadEmail)))
                            message.CC.Add(new MailAddress(leadEmail));
                    }
                }

                // Requestor/Employee

                message.CC.Add(new MailAddress(employee.Email));



                await this.Send(message);
                return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private async Task<bool> Send(MailMessage message)
		{
			try
			{
                string fromMail = configuration["Smtp:email"];
                string fromPassword = configuration["Smtp:password"];

                message.From = new MailAddress(fromMail);

                var smtp = new SmtpClient(configuration["Smtp:client"])
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true
                };

                await smtp.SendMailAsync(message);
                return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
    }
}
