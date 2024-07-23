using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Business.Service.Mail;
using Hris.Data.DTO;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Leave;
using Hris.Data.Models.Notification;
using Hris.Data.UnitOfWork;
using Hris.Resource.Responses;
using ImageMagick.Formats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Configuration;
using QuestPDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.Graph.Constants;

namespace Hris.Business.Service.v1.Notification
{
    public interface INotificationServices
    {
        Task<PagedResult_<NotificationDtoResponse>?> GetNotificationListPagedByObjectId(Guid objId, NotificationFilter_ filter);
        Task<IEnumerable<NotificationDtoResponse>?> GetNotificationListByObjectId(Guid objId);
        Task<IEnumerable<NotificationDtoResponse>> GetNotificationsListByEmployeeId(Guid employeeId);
        Task<NotificationDtoResponse> GetNotificationByEmployeeId(Guid employeeId);
        Task<PagedResult_<NotificationDtoResponse>> GetAll(NotificationFiltes filters);
        Task<NotificationDtoResponse> GetNotificationById(Guid Id);

        Task<NotificationDtoResponse?> AddNotification(NotificationDtoRequest req, Guid objId);
        Task<NotificationDtoResponse?> UpdateNotification(NotificationDtoRequest req, Guid objId);
        Task<bool> Delete(Guid id, Guid objId);
        Task<IEnumerable<NotificationDtoResponse>?> AddLeaveNotification(LeaveTypeEnum type, LeaveApplication app, Guid objId, bool isManagerTeamLead = false);
        Task<(List<NotificationDtoResponse> notificationList, List<MailDtoRequest> mailList)?> AddTrackNotification(TrackDtoResponse trak, int trackType, Guid objId);
        Task<(List<NotificationDtoResponse> notificationList, List<MailDtoRequest> mailList)?> NotifyPayrollRun(Guid EmployeeId, Guid objId, PayrollRunTypeNotification Type);

        Task<bool> ManageNotification(ManageNotificationRequest req, Guid objId);

    }
    internal class NotificationServices : INotificationServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public NotificationServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }



        public async Task<PagedResult_<NotificationDtoResponse>> GetAll(NotificationFiltes filters)
        {
            var result = await _unitOfWork._Notification.GetDbSet()
                 .AsNoTracking()
                 .Where(f => (filters.EmployeeId != null &&
                     filters.EmployeeId.HasValue &&
                     filters.EmployeeId != Guid.Empty) ?
                         f.EmployeeId.Equals(filters.EmployeeId) : true
                     && filters.isRead.HasValue ? f.IsRead.Equals(filters.isRead.Value) : true)
                 .ToListAsync();

            return result.ToNotificationResponseList().ToPagedList_(filters.Page, filters.Limit);
        }

        public async Task<NotificationDtoResponse> GetNotificationByEmployeeId(Guid employeeId)
        {
            var result = await _unitOfWork._Notification
                .GetDbSet()
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.EmployeeId.Equals(employeeId));

            return result.ToNotificationResponse();
        }

        public async Task<NotificationDtoResponse> GetNotificationById(Guid Id)
        {
            var result = await _unitOfWork._Notification
             .GetDbSet()
             .AsNoTracking()
             .FirstOrDefaultAsync(f => f.Id.Equals(Id));

            return result.ToNotificationResponse();


        }

        public async Task<IEnumerable<NotificationDtoResponse>?> GetNotificationListByObjectId(Guid objId)
        {
            var employee = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(objId));
            if (employee is null) return null;

            var result = await _unitOfWork._Notification.GetDbSet()
                .AsNoTracking()
                .Where(f => f.EmployeeId.Equals(employee.Id))
                .ToListAsync();

            var globanNotif = await _unitOfWork._Notification.GetDbSet()
                .AsNoTracking()
                .Where(f => f.EmployeeId == null)
                 .Where(f => f.Expiration.Date >= DateTime.Now.Date)
                .ToListAsync();

            if (globanNotif.Any())
            {
                result.AddRange(globanNotif);
            }

            return result != null ? result.Where(f => f.IsRead.Equals(false)).OrderByDescending(f => f.Modified).ToNotificationResponseList()
                : Enumerable.Empty<NotificationDtoResponse>();
        }

        public async Task<IEnumerable<NotificationDtoResponse>> GetNotificationsListByEmployeeId(Guid employeeId)
        {

            //        var result = await _unitOfWork._Notification.GetDbSet()
            //.AsNoTracking()
            //.Where(f => filter.isRead.HasValue ? f.IsRead.Equals(filter.isRead) : true)
            //.Where(f => f.EmployeeId.Value.Equals(employee.Id))
            //.ToListAsync();

            //        var globanNotif = await _unitOfWork._Notification.GetDbSet()
            //            .AsNoTracking()
            //            .Where(f => filter.isRead.HasValue ? f.IsRead.Equals(filter.isRead) : true)
            //            .Where(f => f.EmployeeId == null)
            //            .Where(f => f.Expiration.Date >= DateTime.Now.Date)
            //            .ToListAsync();

            var result = await _unitOfWork._Notification.GetDbSet()
                 .AsNoTracking()
                 .Where(f => f.IsRead.Equals(false))
                 .Where(f => f.EmployeeId.Value.Equals(employeeId))
                 .ToListAsync();

            var globanNotif = await _unitOfWork._Notification.GetDbSet()
                .AsNoTracking()
                                 .Where(f => f.IsRead.Equals(false))
                .Where(f => f.EmployeeId == null)
                 .Where(f => f.Expiration.Date >= DateTime.Now.Date)
                .ToListAsync();

            if (globanNotif.Any())
            {
                result.AddRange(globanNotif);
            }

            return result != null ? result.ToNotificationResponseList() : Enumerable.Empty<NotificationDtoResponse>();
        }

        public async Task<NotificationDtoResponse?> UpdateNotification(NotificationDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._Notification.GetByIdAsync(req.Id);
                result.EmployeeId = req.EmployeeId;
                result.Title = req.Title;
                result.Description = req.Description;
                result.IsRead = req.IsRead;
                result.RedirectToUrl = req.RedirectToUrl;
                result.Expiration = req.Expiration;
                result.Meta = req.Meta;

                await _unitOfWork._Notification.UpdateAsync(result);

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToNotificationResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<NotificationDtoResponse?> AddNotification(NotificationDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._Notification.AddAsync(new Data.Models.Notification.Notification
                {
                    EmployeeId = req.EmployeeId,
                    Title = req.Title,
                    Description = req.Description,
                    IsRead = req.IsRead,
                    RedirectToUrl = req.RedirectToUrl,
                    Expiration = req.Expiration,
                    Meta = req.Meta,
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToNotificationResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Delete(Guid id, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._Notification.GetByIdAsync(id);
                await _unitOfWork._Notification.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResult_<NotificationDtoResponse>?> GetNotificationListPagedByObjectId(Guid objId, NotificationFilter_ filter)
        {
            var employee = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(objId));
            if (employee is null) return null;

            var result = await _unitOfWork._Notification.GetDbSet()
                .AsNoTracking()
                .Where(f => filter.isRead.HasValue ? f.IsRead.Equals(filter.isRead) : true)
                .Where(f => f.EmployeeId.Value.Equals(employee.Id))
                .ToListAsync();

            var globanNotif = await _unitOfWork._Notification.GetDbSet()
                .AsNoTracking()
                .Where(f => filter.isRead.HasValue ? f.IsRead.Equals(filter.isRead) : true)
                .Where(f => f.EmployeeId == null)
                .Where(f => f.Expiration.Date >= DateTime.Now.Date)
                .ToListAsync();

            if (globanNotif.Any())
            {
                result.AddRange(globanNotif);
            }

            return result.OrderByDescending(d => d.Modified).ToNotificationResponseList().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<IEnumerable<NotificationDtoResponse>?> AddLeaveNotification(LeaveTypeEnum type, LeaveApplication app, Guid objId, bool isManagerTeamLead = false)
        {
            try
            {
                List<Data.Models.Notification.Notification> listOfNotification = new();

                string title = string.Empty;
                var employee = await _unitOfWork._Employees
                        .FindByConditionAsync(f => f.Id.Equals(app.EmployeeId));
                string employeName = $"{employee.Firstname} {employee.Lastname}";
                var leaveType = await _unitOfWork._LeaveTypes.GetByIdAsync(app.LeaveTypeId);

                var teamMember = await _unitOfWork._TeamMember
                    .GetDbSet()
                    .AsNoTracking()
                    .Include(e => e.Team).ThenInclude(f => f.Lead)
                    .Include(d => d.Team)
                        .ThenInclude(f => f.Department)
                            .ThenInclude(d => d.Manager)
                    .Where(d => d.Active && d.EmployeeId.Equals(app.EmployeeId))
                    .ToListAsync();

                // string title = SubjectTitle(type, employeName, leaveType.Name);
                var url = _configuration["Security:AllowedHosts:0"];
                string redirectUrl = string.Empty;

                foreach (var tm in teamMember)
                {

                    //main/leave/leave-request
                    redirectUrl = $"{url}/main/leave/leave-request";
                    if (tm.Team == null)
                        continue;
                    if (tm.Team.Department != null && tm.Team.Department.Manager != null)
                    {
                        title = SubjectTitle(type, employeName, leaveType.Name, true);
                        listOfNotification.Add(await ProcessLeaveNotification(type, title, app, tm.Team.Department.Manager.Id, redirectUrl, true, isRequestCancelFromUser: isManagerTeamLead));
                    }

                    if (tm.Team.Lead != null)
                    {
                        title = SubjectTitle(type, employeName, leaveType.Name, true);
                        listOfNotification.Add(await ProcessLeaveNotification(type, title, app, tm.Team.Lead.Id, redirectUrl, true, isRequestCancelFromUser: isManagerTeamLead));
                    }

                }

                redirectUrl = $"{url}/main/leave/leave-application";
                title = SubjectTitle(type, employeName, leaveType.Name, false);
                listOfNotification.Add(await ProcessLeaveNotification(type, title, app, employee.Id, redirectUrl, false, isRequestCancelFromUser: isManagerTeamLead));
                foreach (var s in listOfNotification)
                {
                    await _unitOfWork._Notification.AddAsync(s);
                }
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? listOfNotification.ToNotificationResponseList() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private string SubjectTitle(LeaveTypeEnum type, string name, string leaveType, bool isManagerTeamLead = false)
        {

            string value = string.Empty;
            if (isManagerTeamLead)
            {
                value = NotificationMessage.LEAVE_REQUEST_TITLE_MANAGER_LEAD.Replace("<Name>", name)
                    .Replace("<LeaveType>", leaveType.ToUpper());
            }
            else
            {
                value = NotificationMessage.LEAVE_REQUEST_TITLE_USER.Replace("<LeaveType>", leaveType.ToUpper());
            }
            return value;
        }
        private async Task<Data.Models.Notification.Notification> ProcessLeaveNotification(LeaveTypeEnum type, string title, LeaveApplication leaveApp, Guid employeeId, string url = "", bool isManagerTeamLead = false, bool isRequestCancelFromUser = false)
        {
            var settings = await _unitOfWork._UserSettings
                  .FindByConditionAsync(f => f.EmployeeId.Equals(leaveApp.EmployeeId));

            var employee = await _unitOfWork._Employees.GetByIdAsync(leaveApp.EmployeeId);

            string description = string.Empty;
            string from = (settings == null ? $"{leaveApp.From} (UTC)" :
                    $"{leaveApp.From.ConvertToTimezone(settings.Timezone).ToString("d")}");
            string to = (settings == null ? $"{leaveApp.To} (UTC)" :
                    $"{leaveApp.To.ConvertToTimezone(settings.Timezone).ToString("d")}");
            string days = leaveApp.Days > 1 ? $"{leaveApp.Days} days" : $"{leaveApp.Days} day";
            string name = $"{employee.Firstname} {employee.Lastname}";
            string gender = employee.Gender == Gender.Male ? "his" : employee.Gender == Gender.Female ? "her" : "his/her";

            description = LeaveApplicationMessageContent(type, name, leaveApp.LeaveType.Name, from, to, days, leaveApp.Reason, isManagerTeamLead, gender, isRequestCancelFromUser);

            return new Data.Models.Notification.Notification
            {
                EmployeeId = employeeId,
                Title = title,
                Description = description,
                IsRead = false,
                RedirectToUrl = url,
                Expiration = DateTime.MinValue,
                Meta = string.Empty
            };
        }

        private string LeaveApplicationMessageContent(LeaveTypeEnum type, string name, string leaveName,
            string from, string to, string days, string reasons, bool isManager, string gender, bool isRequestCancelFromUser = false)
        {
            string value = string.Empty;
            switch (type)
            {
                case LeaveTypeEnum.LeaveRequest:
                    value = isManager ? NotificationMessage.LEAVE_REQUEST_MESSAGE_MANAGER_LEAD
                        .Replace("<NAME>", name)
                        .Replace("<LEAVETYPE>", leaveName.ToUpper())
                        .Replace("<FROM>", from)
                        .Replace("<TO>", to)
                        .Replace("<DAYS>", days)
                        .Replace("<REASONS>", reasons) :

                        NotificationMessage.LEAVE_REQUEST_MESSAGE_USER
                        .Replace("<LEAVETYPE>", leaveName.ToUpper())
                        .Replace("<FROM>", from)
                        .Replace("<TO>", to)
                        .Replace("<DAYS>", days)
                        .Replace("<REASONS>", reasons);
                    break;

                case LeaveTypeEnum.LeaveRequestWithdraw:
                    value = isManager ? NotificationMessage.LEAVE_WITHDRAW_MESSAGE_MANAGER_LEAD
                            .Replace("<NAME>", name)
                            .Replace("<GENDER>", gender)
                            .Replace("<LEAVETYPE>", leaveName.ToUpper())
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to)
                        : NotificationMessage.LEAVE_WITHDRAW_MESSAGE_USER
                            .Replace("<LEAVETYPE>", leaveName.ToUpper())
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to);
                    break;

                case LeaveTypeEnum.LeaveRequestLeadApproved:
                    value = isManager ? NotificationMessage.LEAVE_LEAD_APPROVED_TEAMLED_MANAGER
                            .Replace("<NAME>", name)
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to)
                            .Replace("<LEAVETYPE>", leaveName.ToUpper())
                        : NotificationMessage.LEAVE_LEAD_APPROVED_USER
                            .Replace("<LEAVETYPE>", leaveName.ToUpper())
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to)
                            .Replace("<APPROVEDUSER>", "Team Leader");
                    break;

                case LeaveTypeEnum.LeaveRequestManagerApproved:
                    value = isManager ? NotificationMessage.LEAVE_LEAD_APPROVED_TEAMLED_MANAGER
                            .Replace("<NAME>", name)
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to)
                            .Replace("<LEAVETYPE>", leaveName.ToUpper())
                            : NotificationMessage.LEAVE_LEAD_APPROVED_USER
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to)
                            .Replace("<LEAVETYPE>", leaveName.ToUpper())
                            .Replace("<APPROVEDUSER>", "Manager");
                    break;

                case LeaveTypeEnum.LeaveRequestRejected:
                    value = isManager ? NotificationMessage.LEAVE_REJECTED_MESSAGE_TEAMLEAD_MANAGER
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to)
                            .Replace("<NAME>", name)
                            .Replace("<LEAVETYPE>", leaveName.ToUpper())
                        : NotificationMessage.LEAVE_REJECTED_MESSAGE_USER
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to)
                            .Replace("<LEAVETYPE>", leaveName.ToUpper());
                    break;

                case LeaveTypeEnum.LeaveRequestCancelled:
                    if (isRequestCancelFromUser)
                    {
                        value = isManager ? NotificationMessage.LEAVE_CANCELLED_MESSAGE_MANAGER_TEAMLEAD
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to)
                            .Replace("<NAME>", name)
                            .Replace("<LEAVETYPE>", leaveName.ToUpper()) :
                            NotificationMessage.LEAVE_CANCELLED_MESSAGE_MANAGER_USER
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to)
                            .Replace("<LEAVETYPE>", leaveName.ToUpper());
                    }
                    else
                    {
                        value = isManager ? NotificationMessage.LEAVE_CANCELLED_APPROVAL_RESULT_MANAGER_TEAMLEAD
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to)
                            .Replace("<NAME>", name)
                            .Replace("<LEAVETYPE>", leaveName.ToUpper()) :
                            NotificationMessage.LEAVE_CANCELLED_APPROVAL_RESULT_MANAGER_USER
                            .Replace("<FROM>", from)
                            .Replace("<TO>", to)
                            .Replace("<LEAVETYPE>", leaveName.ToUpper());
                    }
                    break;

            };
            return value;
        }

        public async Task<(List<NotificationDtoResponse> notificationList, List<MailDtoRequest> mailList)?> AddTrackNotification(TrackDtoResponse track, int trackType, Guid objId)
        {
            var mailList = new List<MailDtoRequest>();
            var list = new List<Data.Models.Notification.Notification>();
            string url = string.Empty;
            var host = _configuration["Security:AllowedHosts:0"];
            var processData = new Data.Models.Notification.Notification();

            var teamMember = await _unitOfWork._TeamMember
                .GetDbSet()
                .AsNoTracking()
                .Include(e => e.Team).ThenInclude(f => f.Lead)
                .Include(d => d.Team)
                    .ThenInclude(f => f.Department)
                        .ThenInclude(d => d.Manager)
                .Where(d => d.Active && d.EmployeeId.Equals(track.EmployeeId))
                .ToListAsync();

            foreach (var tm in teamMember)
            {
                url = $"{host}/main/clock/change-request";
                if (tm.Team == null)
                    continue;
                if (tm.Team.Department != null && tm.Team.Department.Manager != null)
                {
                    processData = await processTrackNotification(track, trackType, tm.Team.Department.Manager.Id, url, true);
                    mailList.Add(new MailDtoRequest
                    {
                        Email = tm.Team.Department.Manager.Email,
                        Subject = processData.Title,
                        Body = processData.Description
                    });
                    list.Add(processData);
                }

                if (tm.Team.Lead != null)
                {
                    processData = await processTrackNotification(track, trackType, tm.Team.Lead.Id, url, true);
                    mailList.Add(new MailDtoRequest
                    {
                        Email = tm.Team.Lead.Email,
                        Subject = processData.Title,
                        Body = processData.Description
                    });
                    list.Add(processData);
                }
            }
            var employee = await _unitOfWork._Employees.GetByIdAsync(track.EmployeeId);
            processData = await processTrackNotification(track, trackType, track.EmployeeId, url);
            mailList.Add(new MailDtoRequest
            {
                Email = employee.Email,
                Subject = processData.Title,
                Body = processData.Description
            });
            url = $"{host}/main/clock/track";
            list.Add(processData);

            foreach (var s in list)
            {
                await _unitOfWork._Notification.AddAsync(s);
            }
            return await _unitOfWork.SaveChangeAsync(objId) > 0 ? (list.ToNotificationResponseList().ToList(), mailList) : null;
        }

        private string SubjectTrackTitle(ChangeStatus status, string name, bool isManagerLead = false)
        {
            string value = string.Empty;
            value = isManagerLead ? NotificationMessage.TRACK_TITLE_MANAGER_LEAD.Replace("<NAME>", name) :
                NotificationMessage.TRACK_TITLE_USER;
            return value;
        }

        private async Task<Data.Models.Notification.Notification> processTrackNotification(TrackDtoResponse track, int trackType, Guid employeeId, string url, bool isManager = false)
        {
            var title = string.Empty;
            string body = string.Empty;
            //var employee = await _unitOfWork._Employees
            //        .FindByConditionAsync(f => f.Id.Equals(track.EmployeeId));
            var employee = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Settings)
                .FirstOrDefaultAsync(f => f.Id.Equals(track.EmployeeId));

            var settings = await _unitOfWork._UserSettings
                .FindByConditionAsync(f => f.EmployeeId.Equals(track.EmployeeId));

            if (employee == null) return null;

            string employeName = $"{employee.Firstname} {employee.Lastname}";

            string date = (settings == null ? $"{track.Start} (UTC)" :
                    $"{track.Start.ConvertToTimezone(settings.Timezone).ToString("d")}");
            string gender = employee.Gender == Gender.Male ? "his" : employee.Gender == Gender.Female ? "her" : "his/her";

            if (track.ChangeStatus.HasValue)
                title = SubjectTrackTitle(track.ChangeStatus.Value, employeName, isManager);

            body = TrackBodyDetails(track.ChangeStatus.Value, trackType, employeName, gender, date, isManager);


            return new Data.Models.Notification.Notification
            {
                EmployeeId = employeeId,
                Title = title,
                Description = body,
                IsRead = false,
                RedirectToUrl = url,
                Expiration = DateTime.MinValue,
                Meta = string.Empty
            };
            //return null;
        }

        private string TrackBodyDetails(ChangeStatus status, int tracktype, string employeeName, string gender, string date, bool isManager = false)
        {
            string body = string.Empty;

            if (status == ChangeStatus.Pending)
            {
                switch (tracktype)
                {
                    case 1:
                        body = isManager ? NotificationMessage.TRACK_MESSAGE_MANUAL_INPUT_MANAGER
                            .Replace("<NAME>", employeeName)
                            .Replace("<GENDER>", gender)
                            .Replace("<DATE>", date)
                            .Replace("<STATUS>", "PENDING")
                            :
                            NotificationMessage.TRACK_MESSAGE_MANUAL_INPUT_USER
                            .Replace("<DATE>", date)
                            .Replace("<STATUS>", "PENDING");
                        break;
                    case 2:
                        body = isManager ? NotificationMessage.TRACK_MESSAGE_TIME_UPDATE_MANAGER
                            .Replace("<NAME>", employeeName)
                            .Replace("<GENDER>", gender)
                            .Replace("<DATE>", date)
                            .Replace("<STATUS>", "PENDING")
                            :
                            NotificationMessage.TRACK_MESSAGE_TIME_UPDATE_USER
                            .Replace("<DATE>", date)
                            .Replace("<STATUS>", "PENDING");
                        break;
                    case 3:
                        body = isManager ? NotificationMessage.TRACK_MESSAGE_DATE_UPDATE_MANAGER
                            .Replace("<NAME>", employeeName)
                            .Replace("<GENDER>", gender)
                            .Replace("<DATE>", date)
                            .Replace("<STATUS>", "PENDING")
                            :
                            NotificationMessage.TRACK_MESSAGE_DATE_UPDATE_USER
                            .Replace("<DATE>", date)
                            .Replace("<STATUS>", "PENDING");
                        break;
                }
            }
            else if (status == ChangeStatus.Approved)
            {
                body = isManager ? NotificationMessage.TRACK_MESSAGE_APPROVED_MANAGER
                 .Replace("<NAME>", employeeName)
                 .Replace("<DATE>", date)
                 :
                 NotificationMessage.TRACK_MESSAGE_APPROVED_USER
                 .Replace("<DATE>", date);
            }
            else if (status == ChangeStatus.Declined)
            {
                body = isManager ? NotificationMessage.TRACK_MESSAGE_DECLINED_MANAGER
                 .Replace("<NAME>", employeeName)
                 .Replace("<DATE>", date)
                 :
                 NotificationMessage.TRACK_MESSAGE_DECLINED_USER
                 .Replace("<DATE>", date);

            }

            return body;
        }

        public async Task<(List<NotificationDtoResponse> notificationList, List<MailDtoRequest> mailList)?>
            NotifyPayrollRun(Guid EmployeeId, Guid objId, PayrollRunTypeNotification Type)
        {
            try
            {
                var mailList = new List<MailDtoRequest>();
                var notificationList = new List<Data.Models.Notification.Notification>();
                string title = string.Empty;
                string body = string.Empty;
                string redirectUrl = string.Empty;
                var url = _configuration["Security:AllowedHosts:0"];

                var teamMember = await _unitOfWork._TeamMember
                    .GetDbSet()
                    .AsNoTracking()
                    .Include(e => e.Team).ThenInclude(f => f.Lead)
                    .Include(d => d.Team)
                        .ThenInclude(f => f.Department)
                            .ThenInclude(d => d.Manager)
                    .Where(d => d.Active && d.EmployeeId.Equals(EmployeeId))
                    .ToListAsync();

                var employee = await _unitOfWork._Employees.GetByIdAsync(EmployeeId);
                string employeeName = $"{employee.Firstname} {employee.Lastname}";
                redirectUrl = Type == PayrollRunTypeNotification.LeaveApplicationNotification ? $"{url}/main/leave/leave-request" : $"{url}/main/clock/change-request"; ;

                title = Type == PayrollRunTypeNotification.LeaveApplicationNotification ? NotificationMessage.NOTIFY_TITLE_LEAVEAPPLICATION : NotificationMessage.NOTIFY_TITLE_TRACKREQUEST;
                body = Type == PayrollRunTypeNotification.LeaveApplicationNotification ? NotificationMessage.NOTIFY_MESSAGE_LEAVEAPPLICATION
                        .Replace("<NAME>", employeeName) :
                        NotificationMessage.NOTIFY_MESSAGE_TRACKREQUEST
                        .Replace("<NAME>", employeeName);

                foreach (var tm in teamMember)
                {
                    if (tm.Team == null)
                        continue;
                    if (tm.Team.Department != null && tm.Team.Department.Manager != null)
                    {
                        notificationList.Add(new Data.Models.Notification.Notification
                        {
                            EmployeeId = tm.Team.Department.ManagerId,
                            Title = title,
                            Description = body,
                            RedirectToUrl = redirectUrl,
                            IsRead = false,
                            Expiration = DateTime.MinValue,
                            Active = true
                        });

                        mailList.Add(new MailDtoRequest
                        {
                            Body = body,
                            Email = tm.Team.Department.Manager.Email,
                            Subject = title,
                            Url = redirectUrl
                        });
                    }
                }

                foreach (var item in notificationList)
                {
                    await _unitOfWork._Notification.AddAsync(item);
                }
                await _unitOfWork.SaveChangeAsync(objId);
                return (notificationList.ToNotificationResponseList().ToList(), mailList.ToList());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> ManageNotification(ManageNotificationRequest req, Guid objId)
        {
            try
            {
                foreach (var item in req.Notifications)
                {
                    var notification = await _unitOfWork._Notification.GetDbSet()
                        .AsNoTracking()
                        .Where(f => f.Id.Equals(item.Id))
                        .FirstOrDefaultAsync();

                    if (notification != null)
                    {
                        notification.IsRead = item.IsRead;
                        await _unitOfWork._Notification.UpdateAsync(notification);
                    }
                }
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }


}
