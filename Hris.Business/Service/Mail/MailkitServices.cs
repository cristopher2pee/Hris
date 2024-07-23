using Hris.Data.Models.Leave;
using Hris.Data.UnitOfWork;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Hris.Business.Extensions;
using Hris.Data.DTO;



namespace Hris.Business.Service.Mail
{
    public interface IMailkitServices
    {
        Task<bool> InviteUser(string email,string token);
        Task<bool> ForgotPassword(string token, string email);
        Task<bool> LeaveRequest(LeaveTypeEnum type, LeaveApplication application, Guid objId);

        Task<bool> SendUserListEmail(List<MailDtoRequest> mail);

        Task<bool> SendAllEmail(string subject, string message, string images, string redirectUrl);
    }
    public class MailkitServices:IMailkitServices
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _fromClient = string.Empty;
        private readonly string _fromEmail = string.Empty;
        
        public MailkitServices(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _fromClient = _configuration["Smtp:client"]!;
            _fromEmail = _configuration["Smtp:email"]!;
        }



        #region Account Related Emails
        public async Task<bool> InviteUser(string email, string token)
        {
            try
            {

                var builder = new BodyBuilder();

                var content = await GetHtmlTemplate(EmailTemplateEnum.InviteUser);
                var url =  GetUrlTemplate(EmailTemplateEnum.InviteUser);

                url = string.Format(url,email,token);

                content = content.Replace("[email]", email);
                content = content.Replace("[url]", url);

                builder.HtmlBody = content;


                var message = new MimeMessage();

                message.To.Add(new MailboxAddress("", email));
                message.Subject = "Employease Invitation";

                message.Body = builder.ToMessageBody();

                return await Send(message);
            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> ForgotPassword(string token, string email)
        {
            try
            {
                var employee = await _unitOfWork._Employees.GetDbSet()
                             .AsNoTracking()
                             .Where(f => f.Email.ToLower().Trim().Equals(email.ToLower().Trim()))
                             .FirstOrDefaultAsync();

              

                var builder = new BodyBuilder();

                var content = await GetHtmlTemplate(EmailTemplateEnum.ForgotPassword);
                var url =  GetUrlTemplate(EmailTemplateEnum.ForgotPassword);

                url = string.Format(url, token,email);

                content = content.Replace("[url]", url);
                
                builder.HtmlBody = content;

                var message = new MimeMessage();

                message.To.Add(new MailboxAddress("", email));
                message.Subject = "Employease Forgot Password";
                message.Body = builder.ToMessageBody();

                return await Send(message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Leave Applications


        public async Task<bool> LeaveRequest(LeaveTypeEnum type, LeaveApplication application, Guid objId)
        {
            try
            {
                var employee = await _unitOfWork._Employees
                    .FindByConditionAsync(f => f.Id.Equals(application.EmployeeId));

                if (employee is null)
                    throw new Exception("Employee does not exist");

                var teamMember = await _unitOfWork._TeamMember
                    .GetDbSet()
                    .AsNoTracking()
                    .Include(e => e.Team).ThenInclude(f => f.Lead)
                    .Include(d => d.Team)
                        .ThenInclude(f => f.Department)
                            .ThenInclude(d => d.Manager)
                    .Where(d => d.Active && d.EmployeeId.Equals(application.EmployeeId))
                    .ToListAsync();

                var settings = await _unitOfWork._UserSettings
                    .FindByConditionAsync(f => f.EmployeeId.Equals(application.EmployeeId));

                var leaveType = await _unitOfWork._LeaveTypes.GetByIdAsync(application.LeaveTypeId);

                if (leaveType is null)
                    throw new Exception("Leave type does not exist.");

                var employeeName = $"{employee.Firstname} {employee.Lastname}";
                var emailSubject = GetLeaveEmailSubject(type, employeeName, leaveType.Name);


                var builder = new BodyBuilder();

                var content = await GetHtmlTemplate(EmailTemplateEnum.LeaveRequest);


                content = content.Replace("[emailBodyHeaderVar]", emailSubject);
                content = content.Replace("[employeeVar]", employeeName);
                content = content.Replace("[leaveTypeVar]", leaveType.Name);
                content = content.Replace("[fromVar]", (settings == null ? $"{application.From} (UTC)" : $"{application.From.ConvertToTimezone(settings.Timezone!).ToString("d")} ({settings.Timezone})"));
                content = content.Replace("[toVar]", (settings == null ? $"{application.To} (UTC)" : $"{application.To.ConvertToTimezone(settings.Timezone!).ToString("d")} ({settings.Timezone})"));
                content = content.Replace("[daysVar]", application.Days.ToString());
                content = content.Replace("[reasonVar]", application.Reason);
                content = content.Replace("[statusVar]", application.Status.ToString());

                builder.HtmlBody = content;


                var message = new MimeMessage();

                var member = teamMember.Where(t=>t!=null).FirstOrDefault();

                if(member != null)
                {
                    if (member.Team.Department != null && member.Team.Department.Manager != null)
                    {
                        var managerEmail = member.Team.Department.Manager.Email;
                        message.To.Add(new MailboxAddress("", managerEmail));
                    }

                    if (member.Team.Lead != null)
                    {
                        var leadEmail = member.Team.Lead.Email;
                        message.To.Add(new MailboxAddress("", leadEmail));

                    }
                }

                message.Cc.Add(new MailboxAddress("", employee.Email));

                message.Subject = emailSubject;

                message.Body = builder.ToMessageBody();

                if(message.To.Count>0)
                    return await Send(message);


                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #endregion


        public async Task<bool> SendUserListEmail(List<MailDtoRequest> mail)
        {
            try
            {
                var message = new MimeMessage();
                var builder = new BodyBuilder();

                var content = await GetHtmlTemplate(EmailTemplateEnum.None);
                var subject = string.Empty;

                foreach (var item in mail)
                {
                    if (!string.IsNullOrEmpty(item.Email))
                    {

                        subject = item.Subject;                       

                        content = content.Replace("[titleVar]", item.Subject)
                            .Replace("[descriptionVar]", item.Body);

                        message.Cc.Add(new MailboxAddress("", item.Email));
                    }

                }


                builder.HtmlBody = content;

                message.To.Add(new MailboxAddress("", _fromEmail));
                message.Subject = subject;

                message.Body = builder.ToMessageBody();

                return await Send(message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public async Task<bool> SendAllEmail(string sbjct, string msg, string images, string redirectUrl)
        {
            try
            {
                var message = new MimeMessage();
                var builder = new BodyBuilder();

                var content = await GetHtmlTemplate(EmailTemplateEnum.None);
                var subject = string.Empty;

                var employee = await _unitOfWork._Employees.GetAllAsync();

                foreach (var item in employee)
                {
                    if (!string.IsNullOrEmpty(item.Email))
                    {
                        message.Cc.Add(new MailboxAddress("", item.Email));
                    }

                };


                builder.HtmlBody = content;

                message.To.Add(new MailboxAddress("", _fromEmail));
                message.Subject = subject;

                message.Body = builder.ToMessageBody();

                return await Send(message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        private async Task<bool> Send(MimeMessage mail)
        {
            try
            {
               
                string fromPassword = _configuration["Smtp:password"]!;

                mail.From.Add(new MailboxAddress("Employease", _fromEmail));

                using (var client = new SmtpClient())
                {
                    client.Connect(_fromClient, 587, SecureSocketOptions.StartTls);
                    client.Authenticate(_fromEmail,fromPassword);
                    await client.SendAsync(mail);
                    client.Disconnect(true);
                }

            }
            catch (Exception ex) {

                return false;
            }
         

            return true;
        }



        #region Helpers

        private  string GetUrlTemplate(EmailTemplateEnum template)
        {
            string baseurl = _configuration["Security:AllowedHosts:0"]!;
            string urlLink = string.Empty;

            switch (template)
            {
                case EmailTemplateEnum.ForgotPassword:
                    urlLink = string.Format("{0}{1}", baseurl, "/reset-password?token={0}&email={1}");
                    break;
                case EmailTemplateEnum.InviteUser:
                    urlLink = string.Format("{0}{1}", baseurl, "/set-password?email={0}&token={1}");
                    break;


            }

            return urlLink;
        }
        private async Task<string> GetHtmlTemplate(EmailTemplateEnum template)
        {
            string streamReader = string.Empty;
            string content = string.Empty;


            switch (template)
            {
                case EmailTemplateEnum.None:
                    streamReader = @"EmailTemplates\NotificationsTemplate\DefaultTemplate.html";
                    break;
                case EmailTemplateEnum.LeaveRequest:
                    streamReader = @"EmailTemplates\LeaveTemplate\LeaveTemplate.html";
                    break;

                case EmailTemplateEnum.ForgotPassword:
                    streamReader = @"EmailTemplates\ForgotPasswordTemplate.html";
                    break;
                case EmailTemplateEnum.InviteUser:
                    streamReader = @"EmailTemplates\InviteTemplate.html";
                    break;


            }
            using (var sr = new StreamReader(streamReader))
            {
                content = await sr.ReadToEndAsync();
            }


            return content;
        }

        private string GetLeaveEmailSubject(LeaveTypeEnum type, string employeeName, string leaveTypeName)
        {
            string subject = string.Empty;
            switch (type)
            {
                case LeaveTypeEnum.LeaveRequest:
                    subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST
                        .Replace("<name>", employeeName)
                        .Replace("<type>", leaveTypeName);
                    break;
                case LeaveTypeEnum.LeaveRequestWithdraw:
                    subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST_WITHDRAW
                        .Replace("<name>", employeeName)
                        .Replace("<type>", leaveTypeName);
                    break;
                case LeaveTypeEnum.LeaveRequestLeadApproved:
                    subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST_LEAD_APPROVED
                        .Replace("<type>", leaveTypeName);
                    break;
                case LeaveTypeEnum.LeaveRequestManagerApproved:
                    subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST_MANAGER_APPROVED
                        .Replace("<type>", leaveTypeName);
                    break;
                case LeaveTypeEnum.LeaveRequestRejected:
                    subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST_REJECTED
                        .Replace("<type>", leaveTypeName);
                    break;
                case LeaveTypeEnum.LeaveRequestCancelled:
                    subject = Resource.Responses.LeaveEmailNotifications.LEAVE_REQUEST_CANCELLED
                        .Replace("<type>", leaveTypeName);
                    break;
            }

            return subject;
        }

        #endregion
    }

    public enum LeaveTypeEnum
    {
        None = 0,
        LeaveRequest = 1,
        LeaveRequestWithdraw = 2,
        LeaveRequestLeadApproved = 3,
        LeaveRequestManagerApproved = 4,
        LeaveRequestRejected = 5,
        LeaveRequestCancelled = 6,

    }

    public enum EmailTemplateEnum
    {
        None = 0,
        LeaveRequest = 1,
        Announcement = 2,
        ForgotPassword = 3,
        InviteUser=4
    }
}
