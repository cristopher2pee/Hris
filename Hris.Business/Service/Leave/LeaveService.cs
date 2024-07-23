using Hris.Business.Service.Common;
using Hris.Business.Service.Mail;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Leave;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Calendar = Hris.Data.Models.Administrator.Calendar;
using Employee = Hris.Data.Models.Employee.Employee;

namespace Hris.Business.Service.Leave
{
    public class LeaveService
    {
        private readonly IRepository<LeaveType> typeRepository;
        private readonly IRepository<LeaveEntitlement> entitlementRepository;
        private readonly IRepository<LeaveApplication> applicationRepository;
        private readonly IRepository<Calendar> calendarRepository;
        private readonly SmtpService smtpService;
  

        public LeaveService(IRepository<LeaveType> typeRepository,
            IRepository<LeaveEntitlement> entitlementRepository,
            IRepository<LeaveApplication> applicationRepository,
            IRepository<Calendar> calendarRepository,
            SmtpService smtpService)
        {
            this.typeRepository = typeRepository;
            this.entitlementRepository = entitlementRepository;
            this.applicationRepository = applicationRepository;
            this.calendarRepository = calendarRepository;
            this.smtpService = smtpService;
        }

        public async Task<int> GetRequestsCount()
            => (await applicationRepository.GetDbSet())
            .Where(d => d.Status == LeaveStatus.Applied)
            .Count();

        public async Task<(IEnumerable<LeaveApplication> list, int total)> GetRequests(bool isAdmin, 
            int? page = null,
            int? limit = null,
            DateTime? from = null,
            DateTime? to = null,
            Employee? employee = null,
            IEnumerable<Guid>? leaveTypeIds = null,
            IEnumerable<Guid>? departmentIds = null,
            IEnumerable<Guid>? employeeIds = null,
            IEnumerable<int>? statuses = null)
        {
            var q = (await applicationRepository.GetDbSet())
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
                        if (isAdmin && departmentIds != null && !departmentIds.Any(x => d.Employee.TeamMembers.Any(tm => tm.Team != null ? tm.Team.DepartmentId.Equals(x) : tm.DepartmentId.Equals(x))))
                            return false;

                        if (!isAdmin && !d.Employee.TeamMembers.Any(eTm => eTm.Team != null ? eTm.Team.Department.ManagerId.Equals(employee.Id) : d.EmployeeId.Equals(employee.Id)))
                            return false;
                    }
                    else
                    {
                        if (!d.Employee.TeamMembers.Any(eTm => eTm.Team != null ? eTm.Team.LeadId.Equals(employee.Id) : false))
                            return false;
                    }


                    if (from != null && to != null && (d.From < from.Value || d.DateApplied > to.Value))
                        return false;

                    if (statuses != null ? !statuses.Any(s => (LeaveStatus)s == d.Status)
                        : d.Status != LeaveStatus.Applied && d.Status != LeaveStatus.LeadApproved
                            && (employee.Position.Level == PositionLevel.Manager ?
                                d.Status != LeaveStatus.ApprovedCancelationRequest && d.Status != LeaveStatus.NonApprovedCancelationRequest
                                : d.Status != LeaveStatus.NonApprovedCancelationRequest))
                        return false;

                    if (leaveTypeIds != null && !leaveTypeIds.Any(l => l.Equals(d.LeaveTypeId)))
                        return false;

                    if (employeeIds != null && !employeeIds.Any(e => e.Equals(d.EmployeeId)))
                        return false;
                    return true;
                });

            return (!page.HasValue && !limit.HasValue ? q :
                q.Skip((page.Value - 1) * limit.Value)
                    .Take(limit.Value)
                    .OrderBy(d => d.LeaveTypeId), q.Count());
        }

        public async Task<IEnumerable<IGrouping<Guid, LeaveApplication>>> GenerateScheduledReport(DateTime from, DateTime to)
            => (await applicationRepository.GetDbSet())
                .AsNoTracking()
                .Include(d => d.Employee)
                .Include(d => d.LeaveType)
                .AsEnumerable()
                .Where(d => from >= d.From && to <= d.To)
                .GroupBy(d => d.EmployeeId);

        public async Task<IEnumerable<IGrouping<Guid, LeaveApplication>>> GenerateRequests(bool isAdmin,
            int? page = null,
            int? limit = null,
            DateTime? from = null,
            DateTime? to = null,
            Employee? employee = null,
            IEnumerable<Guid>? leaveTypeIds = null,
            IEnumerable<Guid>? departmentIds = null,
            IEnumerable<Guid>? employeeIds = null,
            IEnumerable<int>? statuses = null)
            => (await applicationRepository.GetDbSet())
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
                        if (isAdmin && departmentIds != null && !departmentIds.Any(x => d.Employee.TeamMembers.Any(tm => tm.Team != null ? tm.Team.DepartmentId.Equals(x) : tm.DepartmentId.Equals(x))))
                            return false;

                        if (!isAdmin && !d.Employee.TeamMembers.Any(eTm => eTm.Team != null ? eTm.Team.Department.ManagerId.Equals(employee.Id) : d.EmployeeId.Equals(employee.Id)))
                            return false;
                    }
                    else
                    {
                        if (!d.Employee.TeamMembers.Any(eTm => eTm.Team != null ? eTm.Team.LeadId.Equals(employee.Id) : false))
                            return false;
                    }


                    if (from != null && to != null && (d.From < from.Value || d.DateApplied > to.Value))
                        return false;

                    if (statuses != null ? !statuses.Any(s => (LeaveStatus)s == d.Status)
                        : d.Status != LeaveStatus.Applied && d.Status != LeaveStatus.LeadApproved
                            && (employee.Position.Level == PositionLevel.Manager ?
                                d.Status != LeaveStatus.ApprovedCancelationRequest && d.Status != LeaveStatus.NonApprovedCancelationRequest
                                : d.Status != LeaveStatus.NonApprovedCancelationRequest))
                        return false;

                    if (leaveTypeIds != null && !leaveTypeIds.Any(l => l.Equals(d.LeaveTypeId)))
                        return false;

                    if (employeeIds != null && !employeeIds.Any(e => e.Equals(d.EmployeeId)))
                        return false;
                    return true;
                })
                .GroupBy(d => d.EmployeeId);

        public async Task<bool> ManageRequest(LeaveApplication data, Employee employee, bool isApproved, string? remarks, Guid userId)
        {
            try
            {
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
                        await smtpService.ManageLeaveRequest(7, data);
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
                            await smtpService.ManageLeaveRequest(4, data);
                        }
                        else
                            await smtpService.ManageLeaveRequest(3, data);
                    }
                }
                else
                {
                    data.Status = LeaveStatus.Rejected;
                    await smtpService.ManageLeaveRequest(5, data);
                }


                if (employee.Position.Level == PositionLevel.TeamLead)
                    data.ApprovedByLeadId = employee.Id;
                else
                    data.ApprovedByManagerId = employee.Id;

                data.Remarks = remarks;

                await applicationRepository.Update(data);
                return await SaveTypesChangesAsync(userId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> ComputeDays(DateTime from, DateTime to)
            => await CountWorkingDays(from, to);

        private async Task<int> CountWorkingDays(DateTime from, DateTime to)
        {
            var holidays = (await calendarRepository.GetDbSet()).Where(c => c.Date.Date >= from.Date && c.Date.Date <= to.Date && c.Type == HolidayType.Regular).ToList();
            int result = 0;
            for (DateTime i = from; i <= to; i = i.AddDays(1))
            { 
                if((i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday) && !holidays.Any(h => h.Date.Date.Equals(i.Date)))
                    result++;
            }
            return result;
        }

        public async Task<int> GetApplicationsCount(Guid id, IEnumerable<Guid>? leaveTypeIds, DateTime? from, DateTime? to, IEnumerable<int>? statuses)
            => (await applicationRepository.GetDbSet())
            .AsEnumerable()
            .Where(d => d.EmployeeId == id
                && (leaveTypeIds != null && leaveTypeIds.Any() ? leaveTypeIds.Any(l => l.Equals(d.LeaveTypeId)) : true)
                && (from != null && to != null ? d.From >= from.Value && d.DateApplied <= to.Value : true)
                && (statuses != null && statuses.Any() ? statuses.Any(l => l.Equals(d.Status)) : true))
            .Count();

        public async Task<IEnumerable<LeaveApplication>> GetApplications(int page, int limit, Guid id, IEnumerable<Guid>? leaveTypeIds, DateTime? from, DateTime? to, IEnumerable<int>? statuses)
            => (await applicationRepository.GetDbSet())
            .Include(d => d.LeaveType)
            .Include(d => d.ApprovedByLead)
            .Include(d => d.ApprovedByManager)
            .AsEnumerable()
            .Where(d => d.EmployeeId == id 
                && (leaveTypeIds != null && leaveTypeIds.Any() ? leaveTypeIds.Any(l => l.Equals(d.LeaveTypeId)) : true)
                && (from != null && to != null ? d.From >= from.Value && d.DateApplied <= to.Value : true)
                && (statuses != null && statuses.Any() ? statuses.Any(l => (LeaveStatus)l == d.Status) : true))
            .OrderBy(d => d.Status)
            .Skip((page - 1) * limit).Take(limit);

        public async Task<LeaveApplication> GetApplicationById(Guid id)
            => await applicationRepository.GetByIdAsync(id);

        public async Task<Guid?> AddApplication(LeaveApplication data, Guid userId)
        {
            try
            {                 
                await applicationRepository.Add(data);
                await SaveTypesChangesAsync(userId);

                // Send Email - Removed await
                await smtpService.ManageLeaveRequest(1, data);
                return data.Id;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> WithdrawApplication(Guid id, Guid userId)
        {
            try
            {
                var d = await applicationRepository.GetByIdAsync(id);
                var current = DateTime.UtcNow;
                if ((d.Status == LeaveStatus.HeadApproved || d.Status == LeaveStatus.LeadApproved) && d.From.Year == current.Year)
                {
                    d.Status = d.Status == LeaveStatus.HeadApproved ? LeaveStatus.ApprovedCancelationRequest : LeaveStatus.NonApprovedCancelationRequest;
                    await smtpService.ManageLeaveRequest(6, d);
                }
                else
                {
                    await smtpService.ManageLeaveRequest(2, d);
                    d.Status = LeaveStatus.Withdrawn;
                }

                await applicationRepository.Update(d);
                return await SaveTypesChangesAsync(userId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> UpdateApplication(LeaveApplication data, Guid userId)
        {
            try
            {
                await applicationRepository.Update(data);
                return await SaveTypesChangesAsync(userId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveApplication(LeaveApplication d, Guid userId)
        {
            try
            {
                await applicationRepository.Delete(d);
                return await SaveEntitlementChangesAsync(userId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<LeaveType>> GetTypesResource()
            => await typeRepository.GetAllAsync();

        public async Task<int> GetTypesCount()
            => (await typeRepository.GetDbSet()).Count();

        public async Task<IEnumerable<LeaveType>> GetTypes(int page, int limit, string? search, IEnumerable<int>? classes)
            => (await this.typeRepository.GetDbSet())
                .AsEnumerable()
                .Where(d => (search != null && !string.IsNullOrEmpty(search) ? d.Name.ToLower().Contains(search.ToLower()) : true)
                    && (classes != null && classes.Any() ? classes.Any(c => (LeaveClass)c == d.Class) : true))
                .Skip((page - 1) * limit).Take(limit);

        public async Task<IEnumerable<LeaveType>> GetBasicTypes()
            => (await this.typeRepository.GetDbSet())
                .Where(d => d.Class == LeaveClass.Basic)
                .ToList();

        public async Task<LeaveType> GetTypeById(Guid id)
            => await typeRepository.GetByIdAsync(id);

        public async Task<bool> CheckIfTypeExist(string name)
            => (await typeRepository.FindByConditionAsync(d => string.Equals(d.Name.ToLower().Trim(), name.ToLower().Trim()))) != null;

        public async Task<bool> SaveType(LeaveType data, Guid userId)
        {
            try
            {
                await typeRepository.Add(data);
                return await SaveTypesChangesAsync(userId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateType(LeaveType data, Guid userId)
        {
            try
            {
                await typeRepository.Update(data);
                return await SaveTypesChangesAsync(userId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveType(LeaveType d, Guid userId)
        {
            try
            {
                await typeRepository.Delete(d);
                return await SaveEntitlementChangesAsync(userId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int> GetEmployeeEntitlementsCount(Guid id)
            => (await entitlementRepository.GetDbSet())
            .Where(d => d.EmployeeId.Equals(id))
            .Count();    
        public async Task<IEnumerable<LeaveEntitlement>> GetEmployeeEntitlements(Guid id)
            => (await this.entitlementRepository.GetDbSet())
                .Include(d => d.LeaveType)
                .AsEnumerable()
                .Where(d => d.EmployeeId.Equals(id));

        public async Task<int> GetEntitlementsCount()
            => (await entitlementRepository.GetDbSet()).Count();

        public async Task<IEnumerable<LeaveEntitlement>> GetEntitlements(int page, int limit, string? search, IEnumerable<Guid>? employeeIds, IEnumerable<Guid>? leaveTypeIds, IEnumerable<int>? years)
            => (await this.entitlementRepository.GetDbSet())
                .Include(d => d.Employee)
                .Include(d => d.LeaveType)
                .AsEnumerable()
                .Where(d => (search != null && !string.IsNullOrEmpty(search) ? 
                    (d.Employee.Firstname.ToLower().Contains(search.ToLower()) || d.Employee.Lastname.ToLower().Contains(search.ToLower())) : true)
                    && (employeeIds != null && employeeIds.Any() ? employeeIds.Any(e => d.EmployeeId.Equals(e)) : true)
                    && (leaveTypeIds != null && leaveTypeIds.Any() ? leaveTypeIds.Any(l => d.LeaveTypeId.Equals(l)) : true)
                    && (years != null && years.Any() ? years.Any(y => d.Year == y) : true))
                .Skip((page - 1) * limit).Take(limit);

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
        public async Task<bool> GrantEntitlementsToAll(IEnumerable<Employee> employees, Guid userId)
        {
            try
            {
                var types = await GetBasicTypes();

                foreach (var e in employees)
                {
                    foreach (var type in types)
                    {
                        await entitlementRepository.Add(new LeaveEntitlement
                        {
                            EmployeeId = e.Id,
                            LeaveTypeId = type.Id,
                            Credits = type.EntitledDays,
                            Balance = type.EntitledDays,
                            Year = DateTime.UtcNow.Year
                        });
                    }
                }
                await SaveEntitlementChangesAsync(userId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<LeaveEntitlement> GetEntitlementById(Guid id)
            => await entitlementRepository.GetByIdAsync(id);

        public async Task<LeaveEntitlement?> GetEmployeeEntitlementByTypeId(Guid id, Guid typeId)
            => (await entitlementRepository.GetDbSet())
                .Where(d => d.EmployeeId.Equals(id) && d.LeaveTypeId
                .Equals(typeId))
                .FirstOrDefault();

        public async Task<bool> CheckIfEntitlementExist(Guid employeeId, Guid typeId)
            => (await entitlementRepository.FindByConditionAsync(d => d.EmployeeId.Equals(employeeId) && d.LeaveTypeId.Equals(typeId))) != null;

        public async Task<bool> SaveEntitlement(LeaveEntitlement data, Guid userId)
        {
            try
            {
                await entitlementRepository.Add(data);
                return await SaveEntitlementChangesAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateEntitlement(LeaveEntitlement data, Guid userId)
        {
            try
            {


                await entitlementRepository.Update(data);
                return await SaveEntitlementChangesAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveEntitlement(LeaveEntitlement d, Guid userId)
        {
            try
            {
                await entitlementRepository.Delete(d);
                return await SaveEntitlementChangesAsync(userId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SaveTypesChangesAsync(Guid clientId)
            => await this.typeRepository.SaveChangesAsync(clientId);

        public async Task<bool> SaveEntitlementChangesAsync(Guid clientId)
            => await this.entitlementRepository.SaveChangesAsync(clientId);
    }
}
