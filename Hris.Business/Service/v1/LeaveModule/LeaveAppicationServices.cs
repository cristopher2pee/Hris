using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Business.Service.Common;
using Hris.Business.Service.Mail;
using Hris.Business.Service.v1.Notification;
using Hris.Data.DTO;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Leave;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Drives.Item.List.ContentTypes.AddCopyFromContentTypeHub;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.LeaveModule
{
    public interface ILeaveApplicationServices
    {
        Task<IEnumerable<LeaveEntitlementDtoResponse>> GetEntitlementListByEmployeeId(Guid empId);
        Task<PagedResult_<LeaveApplicationDtoResponse>> GetLeaveApplicationByEmployee(LeaveApplicationFilter_ filter, Guid emp);
        Task<int> ComputeDays(DateTime from, DateTime to);
        Task<bool> UpdateApplication(LeaveApplicationDtoRequest data, Guid userId);
        Task<IEnumerable<NotificationDtoResponse>?> AddLeaveApplication(LeaveApplicationDtoRequest request, Guid userId);
        Task<IEnumerable<NotificationDtoResponse>?> LeaveWithdrawApplication(Guid id, Guid userId); 
        Task<IEnumerable<LeaveApplicationDtoResponse>> GetLeaveApplication(Expression<Func<LeaveApplication, bool>> whereExp, string timezone);
        Task<LeaveApplication?> GetById(Guid id);
    }
    internal class LeaveAppicationServices : ILeaveApplicationServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SmtpService _smtpService;
        private readonly IMailkitServices _mailkitServices;
        private readonly INotificationServices _notificationServices;
        public LeaveAppicationServices(IUnitOfWork unitOfWork,
            SmtpService smtpService,
            IMailkitServices mailkitServices,
            INotificationServices services
            )
        {
            _unitOfWork = unitOfWork;
            _smtpService = smtpService;
            _mailkitServices = mailkitServices;
            _notificationServices = services;

        }

        public async Task<IEnumerable<NotificationDtoResponse>?> AddLeaveApplication(LeaveApplicationDtoRequest request, Guid userId)
        {
            try
            {
                var emp = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(userId));

                var result = await _unitOfWork._LeaveApplication.AddAsync(new LeaveApplication
                {
                    EmployeeId = emp.Id,
                    LeaveTypeId = request.LeaveTypeId,
                    From = request.From,
                    To = request.To,
                    Days = request.Days,
                    Reason = request.Reason,
                    DateApplied = DateTime.UtcNow,
                    Status = LeaveStatus.Applied
                });

                await _unitOfWork.SaveChangeAsync(userId);

                //await _smtpService.ManageLeaveRequest(1, result);
                await _mailkitServices.LeaveRequest(LeaveTypeEnum.LeaveRequest, result, userId);
                var res = await _notificationServices.AddLeaveNotification(LeaveTypeEnum.LeaveRequest, result, userId);
                return res;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateApplication(LeaveApplicationDtoRequest data, Guid userId)
        {
            try
            {
                var emp = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(userId));
                var toUpdate = await _unitOfWork._LeaveApplication.GetByIdAsync(data.Id);
                toUpdate.EmployeeId = emp.Id;
                toUpdate.LeaveTypeId = data.LeaveTypeId;
                toUpdate.From = data.From;
                toUpdate.To = data.To;
                toUpdate.Days = data.Days;
                toUpdate.Reason = data.Reason;
                toUpdate.DateApplied = DateTime.UtcNow;
                toUpdate.Status = LeaveStatus.Applied;

                await _unitOfWork._LeaveApplication.UpdateAsync(toUpdate);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<NotificationDtoResponse>?> LeaveWithdrawApplication(Guid id, Guid userId)
        {
            try
            {
                IEnumerable<NotificationDtoResponse> notificationResponse = new List<NotificationDtoResponse>();
                var d = await _unitOfWork._LeaveApplication.GetByIdAsync(id);
                var current = DateTime.UtcNow;
                if ((d.Status == LeaveStatus.HeadApproved || d.Status == LeaveStatus.LeadApproved) && d.From.Year == current.Year)
                {
                    d.Status = d.Status == LeaveStatus.HeadApproved ? LeaveStatus.ApprovedCancelationRequest : LeaveStatus.NonApprovedCancelationRequest;
                    // await _smtpService.ManageLeaveRequest(6, d);
                    await _mailkitServices.LeaveRequest(LeaveTypeEnum.LeaveRequestCancelled, d, userId);
                    notificationResponse = await _notificationServices.AddLeaveNotification(LeaveTypeEnum.LeaveRequestCancelled, d, userId, isManagerTeamLead: true);
                }
                else
                {
                    // await _smtpService.ManageLeaveRequest(2, d);
                    await _mailkitServices.LeaveRequest(LeaveTypeEnum.LeaveRequestWithdraw, d, userId);
                    notificationResponse = await _notificationServices.AddLeaveNotification(LeaveTypeEnum.LeaveRequestWithdraw, d, userId);
                    d.Status = LeaveStatus.Withdrawn;
                }

                await _unitOfWork._LeaveApplication.UpdateAsync(d);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? notificationResponse : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<LeaveEntitlementDtoResponse>> GetEntitlementListByEmployeeId(Guid empId)
        {
            var result = await _unitOfWork._LeaveEntitlements.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Employee)
                .Include(f => f.LeaveType)
                .Where(f => f.EmployeeId.Equals(empId))
                .ToListAsync();

            return result.ToLeaveEntitlementDtoResponseList();
        }

        public async Task<PagedResult_<LeaveApplicationDtoResponse>> GetLeaveApplicationByEmployee(LeaveApplicationFilter_ filter, Guid empId)
        {
            var emp = await _unitOfWork._Employees.GetDbSet().AsNoTracking()
                .Include(f => f.Settings)
                .Where(f => f.Id.Equals(empId))
                .FirstOrDefaultAsync();

            var result = _unitOfWork._LeaveApplication.GetDbSet()
                .AsNoTracking()
                .Include(d => d.LeaveType)
                .Include(d => d.Employee)
                .Include(d => d.ApprovedByLead)
                .Include(d => d.ApprovedByManager)
                .AsEnumerable()
                .Where(d => d.EmployeeId == emp.Id
                && (filter.LeaveTypeIds != null && filter.LeaveTypeIds.Any() ? filter.LeaveTypeIds.Any(l => l.Equals(d.LeaveTypeId)) : true)
                && (filter.From != null && filter.To != null ? d.From >= filter.From.Value && d.DateApplied <= filter.To.Value : true)
                && (filter.Statuses != null && filter.Statuses.Any() ? filter.Statuses.Any(l => (LeaveStatus)l == d.Status) : true))
                .OrderBy(f => f.Status)
                .ToList();

            return result.ToLeaveApplicatinResponseList(emp.Settings.Timezone).ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<int> ComputeDays(DateTime from, DateTime to)
                => await CountWorkingDays(from, to);

        private async Task<int> CountWorkingDays(DateTime from, DateTime to)
        {
            var holidays = await _unitOfWork._CalendarEvents.GetDbSet()
                .Where(c => c.Date.Date >= from.Date && c.Date.Date <= to.Date && c.Type == HolidayType.Regular)
                .ToListAsync();

            int result = 0;
            for (DateTime i = from; i <= to; i = i.AddDays(1))
            {
                if ((i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday) && !holidays.Any(h => h.Date.Date.Equals(i.Date)))
                    result++;
            }
            return result;
        }

        public async Task<LeaveApplication?> GetById(Guid id)
        {
            var result = await _unitOfWork._LeaveApplication.GetByIdAsync(id);
            if (result is null) return null;
            return result;
        }

        public async Task<IEnumerable<LeaveApplicationDtoResponse>> GetLeaveApplication(Expression<Func<LeaveApplication, bool>> whereExp, string timezone)
        {
            var result = await _unitOfWork._LeaveApplication.GetDbSet()
                 .AsNoTracking()
                 .Where(whereExp)
                 .ToListAsync();

            return result.ToLeaveApplicatinResponseList(timezone);
        }
    }
}
