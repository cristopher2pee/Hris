using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Business.Service.Common;
using Hris.Business.Service.Mail;
using Hris.Business.Service.v1.AdministratorModule;
using Hris.Business.Service.v1.ClockModule;
using Hris.Business.Service.v1.CommonModule;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Business.Service.v1.Notification;
using Hris.Data.DTO;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Leave;
using Hris.Data.UnitOfWork;
using Hris.Resource.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee = Hris.Data.Models.Employee.Employee;

namespace Hris.Business.Service.v1.LeaveModule
{
    public interface ILeaveServices
    {
        Task<PagedResult_<LeaveApplicationDtoResponse>> GetRequest(LeaveRequestFilter_ filter, Employee employee);
        Task<IEnumerable<LeaveReportDtoResponse>> GenerateRequest(LeaveRequestFilter_ filter, Employee employee);

        Task<PagedResult_<LeaveApplicationDtoResponse>> GetLeaveApplication(Employee emp, LeaveRequestFilter_ filter);

        Task<LeaveApplication> GetById(Guid id);

        Task<(IEnumerable<NotificationDtoResponse> list, bool res)> ManageRequest(LeaveApplication data, Employee employee, bool isApproved, string? remarks, Guid userId);
        Task<LeaveEntitlement?> GetEmployeeEntitlementByTypeId(Guid id, Guid typeId);

        Task<PagedResult_<LeaveApplicationDtoResponse>> GetApplications(LeaveApplicationFilter_ filter, Employee emp);
        Task<int> ComputeDays(DateTime from, DateTime to);

        Task<Guid?> AddApplication(LeaveApplicationDtoRequest data, Guid userId);
        Task<bool> UpdateApplication(LeaveApplicationDtoRequest data, Guid userId);

        Task<LeaveApplication> GetApplicationById(Guid id);

        Task<bool> Update(LeaveApplication data, Guid userId);
        Task<bool> Remove(LeaveApplication d, Guid userId);

        Task<(List<NotificationDtoResponse> list, bool result)> WithdrawApplication(Guid id, Guid userId);
        Task<IEnumerable<LeaveEntitlement>> GetEmployeeEntitlements(Guid id);

        Task<int> GetEmployeeEntitlementsCount(Guid id);

        Task<bool> GrantEntitlements(Guid employeeId, IEnumerable<LeaveType> types, Guid userId);
        Task<IEnumerable<LeaveType>> GetBasicTypes();

        Task<bool> GrantEntitlementsToAll(IEnumerable<Employee> employees, Guid userId);

        Task<IEnumerable<LeaveType>> GetTypesResource();
        Task<int> GetTypesCount();

        Task<IEnumerable<LeaveType>> GetTypes(int page, int limit, string? search, IEnumerable<int>? classes);

        Task<LeaveType> GetTypeById(Guid id);

        Task<bool> SaveLeaveType(LeaveTypeDtoRequest request, Guid userId);
        Task<bool> UpdateLeaveType(LeaveTypeDtoRequest request, Guid userId);
        Task<bool> RemoveLeaveType(Guid id, Guid userId);

        Task<bool> CheckIfTypeExist(string name);

        Task<int> GetEntitlementsCount();

        Task<LeaveEntitlement> GetEntitlementById(Guid id);

        Task<bool> CheckIfEntitlementExist(Guid employeeId, Guid typeId);

        Task<bool> SaveEntitlement(LeaveEntitlementDtoRequest request, Guid userid);

        Task<bool> UpdateEntitlement(LeaveEntitlementDtoRequest request, Guid userid);

        Task<bool> RemoveEntitlement(Guid id, Guid userid);

        Task<IEnumerable<LeaveEntitlement>> GetLeaveEntitlementResources();

        Task<IEnumerable<LeaveEntitlement>> GetEntitlements(int page, int limit, string? search, IEnumerable<Guid>? employeeIds, IEnumerable<Guid>? leaveTypeIds, IEnumerable<int>? years);

        //Task<List<Guid>> GetEmployeeIdsByDepartment(List<Guid> deparmentIds);

        //Task<List<Guid>> GetEmployeeIdsByTeam(List<Guid> TeamIds);
    }
    internal class LeaveServices : ILeaveServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeesService _employeeServices;
        private readonly IPermissionServices _permissionServices;
        private readonly SmtpService _smtpService;
        private readonly IMailkitServices _mailkitServices;
        private readonly INotificationServices _notificationServices;
        private readonly ITrackServices _trackServices;
        private readonly ICommonServices _commonServices;

        public LeaveServices(IUnitOfWork unitOfWork
            , IEmployeesService employeesService
            , IPermissionServices permissionServices,
                SmtpService smtpService,
                IMailkitServices mailkitServices,
                INotificationServices notifServices,
                ITrackServices trackServices,
                ICommonServices commonServices)
        {
            _unitOfWork = unitOfWork;
            _employeeServices = employeesService;
            _permissionServices = permissionServices;
            _smtpService = smtpService;
            _mailkitServices = mailkitServices;
            _notificationServices = notifServices;
            _trackServices = trackServices;
            _commonServices = commonServices;

        }
        public async Task<LeaveApplication> GetApplicationById(Guid id)
            => await _unitOfWork._LeaveApplication.GetByIdAsync(id);
        public async Task<IEnumerable<LeaveReportDtoResponse>> GenerateRequest(LeaveRequestFilter_ filter, Employee employee)
        {
            var data = _unitOfWork._LeaveApplication.GetDbSet()
                         .AsNoTracking()
                         .Include(d => d.Employee)
                         .ThenInclude(e => e.TeamMembers)
                         .ThenInclude(tm => tm.Team)
                         .ThenInclude(t => t.Department)
                         .Include(d => d.LeaveType)
                         .AsEnumerable()
                         .Where(d =>
                         {
                             if (employee.Position.Level == PositionLevel.Manager)
                             {
                                 if (filter.IsAdmin && filter.DepartmentIds != null && !filter.DepartmentIds
                                     .Any(x => d.Employee.TeamMembers
                                     .Any(tm => tm.Team != null ? tm.Team.DepartmentId.Equals(x) : tm.DepartmentId.Equals(x))))
                                     return false;

                                 if (filter.IsAdmin && !d.Employee.TeamMembers.Any(eTm => eTm.Team != null ? eTm.Team.Department.ManagerId.Equals(employee.Id) : d.EmployeeId.Equals(employee.Id)))
                                     return false;
                             }
                             else
                             {
                                 if (!d.Employee.TeamMembers.Any(eTm => eTm.Team != null ? eTm.Team.LeadId.Equals(employee.Id) : false))
                                     return false;
                             }

                             if (filter.From != null && filter.To != null && (d.From < filter.From.Value || d.DateApplied > filter.To.Value))
                                 return false;

                             if (filter.Statuses != null ? !filter.Statuses.Any(s => (LeaveStatus)s == d.Status)
                                 : d.Status != LeaveStatus.Applied && d.Status != LeaveStatus.LeadApproved
                                     && (employee.Position.Level == PositionLevel.Manager ?
                                         d.Status != LeaveStatus.ApprovedCancelationRequest && d.Status != LeaveStatus.NonApprovedCancelationRequest
                                         : d.Status != LeaveStatus.NonApprovedCancelationRequest))
                                 return false;

                             if (filter.LeaveTypeIds != null && !filter.LeaveTypeIds.Any(l => l.Equals(d.LeaveTypeId)))
                                 return false;

                             if (filter.EmployeeIds != null && !filter.EmployeeIds.Any(e => e.Equals(d.EmployeeId)))
                                 return false;
                             return true;
                         })
                         .GroupBy(d => d.EmployeeId);

            var result = data.Select(d =>
            {
                var e = d.First().Employee;
                var p = d.Where(l => l.LeaveType.IsPaid);
                var np = d.Where(l => !l.LeaveType.IsPaid);
                return new LeaveReportDtoResponse
                {
                    EmployeeId = d.Key,
                    TotalPaid = p.Sum(l => l.Days),
                    CountPaid = p.Count(),
                    TotalNonPaid = np.Sum(l => l.Days),
                    CountNonPaid = np.Count(),
                    Employee = e.ToInitialEmployeeResponse_(),
                    Requests = d.OrderBy(a => a.LeaveType.IsPaid).ToList().ToLeaveApplicatinResponseList(employee.Settings.Timezone),
                };
            });

            return result is null ? Enumerable.Empty<LeaveReportDtoResponse>() : result;
        }

        public async Task<LeaveApplication> GetById(Guid id)
        {
            var result = await _unitOfWork._LeaveApplication.GetByIdAsync(id);
            return result;
        }

        public async Task<PagedResult_<LeaveApplicationDtoResponse>> GetRequest(LeaveRequestFilter_ filter, Employee employee)
        {
            var result = _unitOfWork._LeaveApplication.GetDbSet()
                        .AsNoTracking()
                        .Include(d => d.Employee)
                        .ThenInclude(e => e.TeamMembers)
                        .ThenInclude(tm => tm.Team)
                        .ThenInclude(t => t.Department)
                        .Include(d => d.LeaveType)
                        .AsEnumerable()
                        .Where(d =>
                        {
                            if (employee.Position.Level == PositionLevel.Manager)
                            {
                                if (filter.IsAdmin && filter.DepartmentIds != null && !filter.DepartmentIds
                                    .Any(x => d.Employee.TeamMembers
                                    .Any(tm => tm.Team != null ? tm.Team.DepartmentId.Equals(x) : tm.DepartmentId.Equals(x))))
                                    return false;

                                if (filter.IsAdmin && !d.Employee.TeamMembers.Any(eTm => eTm.Team != null ? eTm.Team.Department.ManagerId.Equals(employee.Id) : d.EmployeeId.Equals(employee.Id)))
                                    return false;
                            }
                            else
                            {
                                if (!d.Employee.TeamMembers.Any(eTm => eTm.Team != null ? eTm.Team.LeadId.Equals(employee.Id) : false))
                                    return false;
                            }

                            if (filter.From != null && filter.To != null && (d.From < filter.From.Value || d.DateApplied > filter.To.Value))
                                return false;

                            if (filter.Statuses != null ? !filter.Statuses.Any(s => (LeaveStatus)s == d.Status)
                                : d.Status != LeaveStatus.Applied && d.Status != LeaveStatus.LeadApproved
                                    && (employee.Position.Level == PositionLevel.Manager ?
                                        d.Status != LeaveStatus.ApprovedCancelationRequest && d.Status != LeaveStatus.NonApprovedCancelationRequest
                                        : d.Status != LeaveStatus.NonApprovedCancelationRequest))
                                return false;

                            if (filter.LeaveTypeIds != null && !filter.LeaveTypeIds.Any(l => l.Equals(d.LeaveTypeId)))
                                return false;

                            if (filter.EmployeeIds != null && !filter.EmployeeIds.Any(e => e.Equals(d.EmployeeId)))
                                return false;
                            return true;
                        });

            return result.ToLeaveApplicatinResponseList(employee.Settings.Timezone).ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<(IEnumerable<NotificationDtoResponse> list, bool res)> ManageRequest(LeaveApplication data, Data.Models.Employee.Employee employee, bool isApproved, string? remarks, Guid userId)
        {
            try
            {
                IEnumerable<NotificationDtoResponse> notifList = new List<NotificationDtoResponse>();
                if (isApproved)
                {
                    if (data.Status == LeaveStatus.NonApprovedCancelationRequest || data.Status == LeaveStatus.ApprovedCancelationRequest)
                    {
                        if (data.Status == LeaveStatus.NonApprovedCancelationRequest)
                            data.Status = LeaveStatus.Cancelled;
                        else
                        {
                            var entitlement = await GetEmployeeEntitlementByTypeId(data.EmployeeId, data.LeaveTypeId);

                            if (entitlement == null)
                                throw new Exception("Entitlement not found.");

                            entitlement.Balance = entitlement.Balance + data.Days;
                            entitlement.Used = entitlement.Used - data.Days;

                            if (!(await UpdateEntitlement(entitlement, userId)))
                                throw new Exception("Entitlement not saved.");

                            data.Status = LeaveStatus.Cancelled;
                        }
                        // await _smtpService.ManageLeaveRequest(7, data);

                        await _mailkitServices.LeaveRequest(LeaveTypeEnum.LeaveRequestCancelled, data, userId);
                        var notif = await _notificationServices.AddLeaveNotification(LeaveTypeEnum.LeaveRequestCancelled, data, userId);
                        if (notif is not null)
                            notifList = notif;
                    }
                    else
                    {
                        data.Status = employee.Position.Level == PositionLevel.TeamLead ? LeaveStatus.LeadApproved : LeaveStatus.HeadApproved;

                        if (data.Status == LeaveStatus.HeadApproved)
                        {
                            var entitlement = await GetEmployeeEntitlementByTypeId(data.EmployeeId, data.LeaveTypeId);

                            if (entitlement == null)
                                throw new Exception("Entitlement not found.");

                            entitlement.Balance = entitlement.Balance - data.Days;
                            entitlement.Used = entitlement.Used + data.Days;

                            if (!(await UpdateEntitlement(entitlement, userId)))
                                throw new Exception("Entitlement not saved.");
                            //await _smtpService.ManageLeaveRequest(4, data);
                            await _mailkitServices.LeaveRequest(LeaveTypeEnum.LeaveRequestManagerApproved, data, userId);
                            var notif = await _notificationServices.AddLeaveNotification(LeaveTypeEnum.LeaveRequestManagerApproved, data, userId);
                            if (notif is not null)
                                notifList = notif;
                        }
                        else
                        {
                            // await _smtpService.ManageLeaveRequest(3, data);
                            await _mailkitServices.LeaveRequest(LeaveTypeEnum.LeaveRequestLeadApproved, data, userId);
                            var notif = await _notificationServices.AddLeaveNotification(LeaveTypeEnum.LeaveRequestLeadApproved, data, userId);
                            if (notif is not null)
                                notifList = notif;
                        }
                    }
                }
                else
                {
                    data.Status = LeaveStatus.Rejected;
                    // await _smtpService.ManageLeaveRequest(5, data);
                    await _mailkitServices.LeaveRequest(LeaveTypeEnum.LeaveRequestRejected, data, userId);
                    var notif = await _notificationServices.AddLeaveNotification(LeaveTypeEnum.LeaveRequestRejected, data, userId);
                    if (notif is not null)
                        notifList = notif;
                }

                if (employee.Position.Level == PositionLevel.TeamLead)
                    data.ApprovedByLeadId = employee.Id;
                else
                    data.ApprovedByManagerId = employee.Id;

                data.Remarks = remarks;

                var leaveType = await _unitOfWork._LeaveTypes.GetByIdAsync(data.LeaveTypeId);
                if (leaveType is not null)
                {
                    if (leaveType.IsPaid)
                    {
                        if (data.Status == LeaveStatus.HeadApproved || data.Status == LeaveStatus.LeadApproved && isApproved)
                        {
                            await _trackServices.ManageTrackFromLeaveApplication(data, userId);
                        }

                        else if (data.Status == LeaveStatus.Cancelled)
                            await _trackServices.RemovedTrackFromWithdrawCancelledLeaveApplication(data, userId);

                    }

                }




                await _unitOfWork._LeaveApplication.UpdateAsync(data);
                return (notifList, await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        private async Task<bool> UpdateEntitlement(LeaveEntitlement data, Guid userId)
        {
            try
            {
                await _unitOfWork._LeaveEntitlements.UpdateAsync(data);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task<bool> SaveEntitlement(LeaveEntitlement data, Guid userId)
        {
            try
            {
                await _unitOfWork._LeaveEntitlements.AddAsync(data);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<LeaveEntitlement?> GetEmployeeEntitlementByTypeId(Guid id, Guid typeId)
            => await _unitOfWork._LeaveEntitlements.GetDbSet()
                .Where(d => d.EmployeeId.Equals(id) && d.LeaveTypeId
                .Equals(typeId))
                .FirstOrDefaultAsync();

        public async Task<PagedResult_<LeaveApplicationDtoResponse>> GetApplications(LeaveApplicationFilter_ filter, Employee emp)
        {
            var result = _unitOfWork._LeaveApplication.GetDbSet()
                .AsNoTracking()
                .Include(d => d.LeaveType)
                .Include(d => d.ApprovedByLead)
                .Include(d => d.ApprovedByManager)
                .AsEnumerable()
                .Where(d => d.EmployeeId == emp.Id
                && (filter.LeaveTypeIds != null && filter.LeaveTypeIds.Any() ? filter.LeaveTypeIds.Any(l => l.Equals(d.LeaveTypeId)) : true)
                && (filter.From != null && filter.To != null ? d.From >= filter.From.Value && d.DateApplied <= filter.To.Value : true)
                && (filter.Statuses != null && filter.Statuses.Any() ? filter.Statuses.Any(l => (LeaveStatus)l == d.Status) : true))
                .OrderBy(d => d.Status);

            return result.ToLeaveApplicatinResponseList(emp.Settings.Timezone).ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<int> ComputeDays(DateTime from, DateTime to)
            => await CountWorkingDays(from, to);

        private async Task<int> CountWorkingDays(DateTime from, DateTime to)
        {
            var holidays = _unitOfWork._CalendarEvents.GetDbSet().Where(c => c.Date.Date >= from.Date && c.Date.Date <= to.Date && c.Type == HolidayType.Regular).ToList();
            int result = 0;
            for (DateTime i = from; i <= to; i = i.AddDays(1))
            {
                if ((i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday) && !holidays.Any(h => h.Date.Date.Equals(i.Date)))
                    result++;
            }
            return result;
        }

        public async Task<Guid?> AddApplication(LeaveApplicationDtoRequest request, Guid userId)
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

                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? result.Id : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Update(LeaveApplication data, Guid userId)
        {
            try
            {
                await _unitOfWork._LeaveApplication.UpdateAsync(data);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Remove(LeaveApplication d, Guid userId)
        {
            try
            {
                await _unitOfWork._LeaveApplication.DeleteAsync(d);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<(List<NotificationDtoResponse> list, bool result)> WithdrawApplication(Guid id, Guid userId)
        {
            try
            {
                List<NotificationDtoResponse> notificationDtoResponses = new List<NotificationDtoResponse>();
                var d = await _unitOfWork._LeaveApplication.GetByIdAsync(id);
                var current = DateTime.UtcNow;
                if ((d.Status == LeaveStatus.HeadApproved || d.Status == LeaveStatus.LeadApproved) && d.From.Year == current.Year)
                {
                    d.Status = d.Status == LeaveStatus.HeadApproved ? LeaveStatus.ApprovedCancelationRequest : LeaveStatus.NonApprovedCancelationRequest;
                    //  await _smtpService.ManageLeaveRequest(6, d);
                    await _mailkitServices.LeaveRequest(LeaveTypeEnum.LeaveRequestCancelled, d, userId);
                    var notif = await _notificationServices.AddLeaveNotification(LeaveTypeEnum.LeaveRequestCancelled, d, userId);
                    if (notif is not null)
                        notificationDtoResponses = notif.ToList();
                }
                else
                {
                    // await _smtpService.ManageLeaveRequest(2, d);
                    d.Status = LeaveStatus.Withdrawn;
                    await _mailkitServices.LeaveRequest(LeaveTypeEnum.LeaveRequestWithdraw, d, userId);
                    var notif = await _notificationServices.AddLeaveNotification(LeaveTypeEnum.LeaveRequestWithdraw, d, userId);
                    if (notif is not null)
                        notificationDtoResponses = notif.ToList();
                }

                await _unitOfWork._LeaveApplication.UpdateAsync(d);
                return (notificationDtoResponses, await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false);
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
                var toUpdate = await GetById(data.Id);
                toUpdate.EmployeeId = emp.Id;
                toUpdate.LeaveTypeId = data.LeaveTypeId;
                toUpdate.From = data.From;
                toUpdate.To = data.To;
                toUpdate.Days = data.Days;
                toUpdate.Reason = data.Reason;
                toUpdate.DateApplied = DateTime.UtcNow;
                toUpdate.Status = LeaveStatus.Applied;

                var result = await Update(toUpdate, userId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }

        public async Task<IEnumerable<LeaveEntitlement>> GetEmployeeEntitlements(Guid id)
        {
            var result = _unitOfWork._LeaveEntitlements.GetDbSet()
                 .AsNoTracking()
                 .Include(d => d.LeaveType)
                 .AsEnumerable()
                 .Where(d => d.EmployeeId.Equals(id));

            return result is null ? Enumerable.Empty<LeaveEntitlement>() : result;
        }


        public async Task<int> GetEmployeeEntitlementsCount(Guid id)
                => await _unitOfWork._LeaveEntitlements.GetDbSet()
                .Where(d => d.EmployeeId.Equals(id))
                .CountAsync();
        public async Task<bool> GrantEntitlements(Guid employeeId, IEnumerable<LeaveType> types, Guid userId)
        {
            foreach (var type in types)
            {
                var existingEntitlement = await GetEmployeeEntitlementByTypeId(employeeId, type.Id);
                var computedCredits = (int)Math.Round(((double)type.EntitledDays / 12.00) * (12 - DateTime.UtcNow.Month), 0);
                if (existingEntitlement != null)
                {
                    existingEntitlement.Credits += computedCredits;
                    existingEntitlement.Balance += computedCredits;
                    existingEntitlement.Year = DateTime.UtcNow.Year;
                    if (!await UpdateEntitlement(existingEntitlement, userId))
                        return false;
                }
                else if (!await SaveEntitlement(new LeaveEntitlement
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = type.Id,
                    Credits = computedCredits,
                    Balance = computedCredits,
                    Year = DateTime.UtcNow.Year
                }, userId))
                    return false;
            }
            return true;
        }

        public async Task<IEnumerable<LeaveType>> GetBasicTypes()
        {
            var result = await _unitOfWork._LeaveTypes.GetDbSet()
                .Where(d => d.Class == LeaveClass.Basic)
                .ToListAsync();

            return result != null ? result : Enumerable.Empty<LeaveType>();
        }

        public async Task<bool> GrantEntitlementsToAll(IEnumerable<Employee> employees, Guid userId)
        {
            try
            {
                var types = await GetBasicTypes();

                foreach (var e in employees)
                {
                    foreach (var type in types)
                    {
                        await _unitOfWork._LeaveEntitlements.AddAsync(new LeaveEntitlement
                        {
                            EmployeeId = e.Id,
                            LeaveTypeId = type.Id,
                            Credits = type.EntitledDays,
                            Balance = type.EntitledDays,
                            Year = DateTime.UtcNow.Year
                        });
                    }
                }
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<LeaveType>> GetTypesResource()
        {
            var result = await _unitOfWork._LeaveTypes.GetAllAsync();
            return result != null ? result : Enumerable.Empty<LeaveType>();
        }

        public async Task<int> GetTypesCount()
        => await _unitOfWork._LeaveTypes.GetDbSet().CountAsync();


        public async Task<IEnumerable<LeaveType>> GetTypes(int page, int limit, string? search, IEnumerable<int>? classes)
        {
            var result = _unitOfWork._LeaveTypes.GetDbSet()
                          .AsEnumerable()
                          .Where(d => (search != null && !string.IsNullOrEmpty(search) ? d.Name.ToLower().Contains(search.ToLower()) : true)
                                    && (classes != null && classes.Any() ? classes.Any(c => (LeaveClass)c == d.Class) : true))
                          .Skip((page - 1) * limit).Take(limit);

            return result != null ? result : Enumerable.Empty<LeaveType>();
        }

        public async Task<LeaveType> GetTypeById(Guid id)
            => await _unitOfWork._LeaveTypes.GetByIdAsync(id);

        public async Task<bool> SaveLeaveType(LeaveTypeDtoRequest request, Guid userId)
        {
            try
            {
                await _unitOfWork._LeaveTypes.AddAsync(new LeaveType
                {
                    Name = request.Name,
                    Description = request.Description,
                    EntitledDays = request.EntitledDays,
                    Notification = request.Notification,
                    Class = (LeaveClass)request.Class,
                    IsPaid = request.IsPaid,
                    Active = true

                });

                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateLeaveType(LeaveTypeDtoRequest request, Guid userId)
        {
            try
            {
                var toUpdate = await _unitOfWork._LeaveTypes.GetByIdAsync(request.Id);
                if (toUpdate is null) return false;

                toUpdate.Name = request.Name;
                toUpdate.Class = (LeaveClass)request.Class;
                toUpdate.Description = request.Description;
                toUpdate.Notification = request.Notification;
                toUpdate.EntitledDays = request.EntitledDays;
                toUpdate.IsPaid = request.IsPaid;

                await _unitOfWork._LeaveTypes.UpdateAsync(toUpdate);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> RemoveLeaveType(Guid id, Guid userId)
        {
            try
            {
                var toDelete = await _unitOfWork._LeaveTypes.GetByIdAsync(id);
                if (toDelete is null) return false;
                await _unitOfWork._LeaveTypes.DeleteAsync(toDelete);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> CheckIfTypeExist(string name)
            => (await _unitOfWork._LeaveTypes.FindByConditionAsync(d => string.Equals(d.Name.ToLower().Trim(), name.ToLower().Trim()))) != null;


        public async Task<IEnumerable<LeaveEntitlement>> GetEntitlements(int page, int limit, string? search, IEnumerable<Guid>? employeeIds, IEnumerable<Guid>? leaveTypeIds, IEnumerable<int>? years)
        {
            var result = _unitOfWork._LeaveEntitlements.GetDbSet()
                .Include(d => d.Employee)
                .Include(d => d.LeaveType)
                .AsEnumerable()
                .Where(d => (search != null && !string.IsNullOrEmpty(search) ?
                    (d.Employee.Firstname.ToLower().Contains(search.ToLower()) || d.Employee.Lastname.ToLower().Contains(search.ToLower())) : true)
                    && (employeeIds != null && employeeIds.Any() ? employeeIds.Any(e => d.EmployeeId.Equals(e)) : true)
                    && (leaveTypeIds != null && leaveTypeIds.Any() ? leaveTypeIds.Any(l => d.LeaveTypeId.Equals(l)) : true)
                    && (years != null && years.Any() ? years.Any(y => d.Year == y) : true))
                .Skip((page - 1) * limit).Take(limit);

            return result != null ? result : Enumerable.Empty<LeaveEntitlement>();

        }

        public async Task<int> GetEntitlementsCount()
            => await _unitOfWork._LeaveEntitlements.GetCount();

        public async Task<LeaveEntitlement> GetEntitlementById(Guid id)
             => await _unitOfWork._LeaveEntitlements.GetByIdAsync(id);

        public async Task<bool> SaveEntitlement(LeaveEntitlementDtoRequest request, Guid userid)
        {
            try
            {
                await _unitOfWork._LeaveEntitlements.AddAsync(new LeaveEntitlement
                {
                    EmployeeId = request.EmployeeId,
                    LeaveTypeId = request.LeaveTypeId,
                    Credits = request.Credits,
                    Balance = request.Credits,
                    Year = request.Year
                });

                return await _unitOfWork.SaveChangeAsync(userid) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateEntitlement(LeaveEntitlementDtoRequest request, Guid userid)
        {
            try
            {
                var toUpdate = await _unitOfWork._LeaveEntitlements.GetByIdAsync(request.Id);
                if (toUpdate is null) return false;

                toUpdate.Balance = request.Credits - toUpdate.Used;

                if (toUpdate.Balance < 0)
                    throw new Exception("New credit is below on what is being used.");

                toUpdate.LeaveTypeId = request.LeaveTypeId;
                toUpdate.Credits = request.Credits;
                toUpdate.Year = request.Year;

                await _unitOfWork._LeaveEntitlements.UpdateAsync(toUpdate);
                return await _unitOfWork.SaveChangeAsync(userid) > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> RemoveEntitlement(Guid id, Guid userid)
        {
            try
            {
                var toDelete = await _unitOfWork._LeaveEntitlements.GetByIdAsync(id);
                if (toDelete is null) return false;
                await _unitOfWork._LeaveEntitlements.DeleteAsync(toDelete);
                return await _unitOfWork.SaveChangeAsync(userid) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> CheckIfEntitlementExist(Guid employeeId, Guid typeId)
         => (await _unitOfWork._LeaveEntitlements.FindByConditionAsync(d => d.EmployeeId.Equals(employeeId) && d.LeaveTypeId.Equals(typeId))) != null;

        public async Task<IEnumerable<LeaveEntitlement>> GetLeaveEntitlementResources()
        {
            var result = await _unitOfWork._LeaveEntitlements
                .GetAllAsync();
            return result != null ? result : Enumerable.Empty<LeaveEntitlement>();
        }

        public async Task<PagedResult_<LeaveApplicationDtoResponse>> GetLeaveApplication(Employee emp, LeaveRequestFilter_ filter)
        {
            List<Guid> employeeIds = new List<Guid>();
            var isAdmin = await _permissionServices.GetRoleByModule(emp.Id, Modules.Leave);

            var employee = await _unitOfWork._Employees.GetDbSet()
                .Include(f => f.Position)
                .FirstOrDefaultAsync(f => f.Id.Equals(emp.Id));

            var data = await ProcessLeaveApplication(filter, employee, isAdmin.Equals(Roles.Admin));
            return data.ToLeaveApplicatinResponseList(employee.Settings.Timezone).ToPagedList_(filter.Page, filter.Limit);

        }

        private async Task<IEnumerable<LeaveApplication>> ProcessLeaveApplication(LeaveRequestFilter_ filter, Employee emp, bool isAdmin = false)
        {
            List<Guid> employeeIds = new List<Guid>();

            if (emp.Position != null)
            {
                if (emp.Position.Level == PositionLevel.Manager)
                {
                    var assignDepartment = await _unitOfWork._Department.FindListByConditionAsync(f => f.ManagerId.Equals(emp.Id));
                    employeeIds = await this._commonServices.GetEmployeeIdsByDepartment(
                         assignDepartment.Select(f => f.Id).ToList());

                }
                else if (emp.Position.Level == PositionLevel.TeamLead)
                {
                    var assignTeam = await _unitOfWork._Team.FindListByConditionAsync(f => f.LeadId.Equals(emp.Id));
                    employeeIds = await this._commonServices.GetEmployeeIdsByTeam(assignTeam.Select(f => f.Id).ToList());
                }

                employeeIds.Add(emp.Id);
            }

            if (filter.DepartmentIds != null && filter.DepartmentIds.Any())
            {
                employeeIds = await this._commonServices.GetEmployeeIdsByDepartment(filter.DepartmentIds.ToList());
                isAdmin = false;
            }


            var data = await GetLeaveApplicationByEmployeeIds(employeeIds, isAdmin);
            var result = data.AsEnumerable().Where(f => f.Status != LeaveStatus.Cancelled &&
             (filter.From != null && filter.To != null ? f.From >= filter.From.Value && f.To <= filter.To.Value : true)
            && (filter.Statuses != null ? filter.Statuses.Any(s => (LeaveStatus)s == f.Status) : true)
            && (filter.LeaveTypeIds != null ? filter.LeaveTypeIds.Contains(f.LeaveTypeId) : true)
            );

            return result != null ? result : Enumerable.Empty<LeaveApplication>();
        }

        private async Task<IEnumerable<LeaveApplication>> GetLeaveApplicationByEmployeeIds(List<Guid> employeeIds, bool isAdmin = false)
        {
            var result = await _unitOfWork._LeaveApplication.GetDbSet()
                .AsNoTracking()
                .Include(m => m.Employee)
                .ThenInclude(t => t.TeamMembers)
                .Include(l => l.LeaveType)
                .Where(f => isAdmin ? true : employeeIds.Contains(f.EmployeeId))
                .ToListAsync();

            return result != null ? result : Enumerable.Empty<LeaveApplication>();
        }

    }
}
