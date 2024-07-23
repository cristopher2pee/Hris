using Hris.Data.DataContext;
using Hris.Data.Models;
using Hris.Data.Models.Administrator;
using Hris.Data.Models.Clock;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Leave;
using Hris.Data.Models.Notification;
using Hris.Data.Models.Payroll;
using Hris.Data.Models.Settings;
using Hris.Data.Models.Statutory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.UnitOfWork
{
    internal class RepositoryWrapper
    {
    }

    public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class UserSettingsRepository : GenericRepository<UserSettings>, IUserSettingsRepository
    {
        public UserSettingsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class FamilyRepository : GenericRepository<Family>, IFamilyRepository
    {
        public FamilyRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class SalaryHistoryRepository : GenericRepository<SalaryHistory>, ISalaryHistoryRepository
    {
        public SalaryHistoryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class AllowanceEntitlementRepository : GenericRepository<AllowanceEntitlement>, IAllowanceEntitlementRepository
    {
        public AllowanceEntitlementRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class StatutoryRepository : GenericRepository<Statutory>, IStatutoryRepository
    {
        public StatutoryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class TeamMemberRepository : GenericRepository<TeamMember>, ITeamMemberRepository
    {
        public TeamMemberRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class AssignedProjectRepository : GenericRepository<AssignedProject>, IAssignedProjectRepository
    {
        public AssignedProjectRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class LeaveApplicationRepository : GenericRepository<LeaveApplication>, ILeaveApplicationRepository
    {
        public LeaveApplicationRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class TrackRepository : GenericRepository<Track>, ITrackRepository
    {
        public TrackRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class AccessRepository : GenericRepository<Access>, IAccessRepository
    {
        public AccessRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class CalendarEventsRepository : GenericRepository<Calendar>, ICalendarEventsRepository
    {
        public CalendarEventsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class AllowanceTypesRepository : GenericRepository<AllowanceType>, IAllowanceTypesRepository
    {
        public AllowanceTypesRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PositionRepository : GenericRepository<Position>, IPositionsRepository
    {
        public PositionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class ProjectTaskRepository : GenericRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class LeaveEntitlementsRepository : GenericRepository<LeaveEntitlement>, ILeaveEntitlementsRepository
    {
        public LeaveEntitlementsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class LeaveTypesRepository : GenericRepository<LeaveType>, ILeaveTypesRepository
    {
        public LeaveTypesRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class DeductionTypesRepository : GenericRepository<DeductionTypes>, IDeductionTypesRepository
    {
        public DeductionTypesRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class EmployeesDeductionRepository : GenericRepository<EmployeesDeduction>, IEmployeesDeductionRepository
    {
        public EmployeesDeductionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    //public class EmployeeStatutoriesRepository : GenericRepository<EmployeeStatutories>, IEmployeeStatutoriesRepository
    //{
    //    public EmployeeStatutoriesRepository(ApplicationDbContext context) : base(context)
    //    {

    //    }
    //}

    public class ShiftSchedulesRepository : GenericRepository<ShiftSchedule>, IShiftSchedulesRepository
    {
        public ShiftSchedulesRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class TaxTableRepository : GenericRepository<TaxTable>, ITaxTableRepository
    {
        public TaxTableRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class LoanTypesRepository : GenericRepository<LoanTypes>, ILoanTypesRepository
    {
        public LoanTypesRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class EmployeeLoansRepository : GenericRepository<EmployeeLoans>, IEmployeeLoansRepository
    {
        public EmployeeLoansRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PayrollConfigRepository : GenericRepository<PayrollConfig>, IPayrollConfigRepository
    {
        public PayrollConfigRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PayrollConfigDetailsRepository : GenericRepository<PayrollConfigDetails>, IPayrollConfigDetailsRepository
    {
        public PayrollConfigDetailsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PayrollRunRepository : GenericRepository<PayrollRun>, IPayrollRunRepository
    {
        public PayrollRunRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PayrollRunAllowancesRepository : GenericRepository<PayrollRunAllowances>, IPayrollRunAllowancesRepository
    {
        public PayrollRunAllowancesRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PayrollRunDeductionsRepository : GenericRepository<PayrollRunDeductions>, IPayrollRunDeductionsRepository
    {
        public PayrollRunDeductionsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PayrollRunLoansRepository : GenericRepository<PayrollRunLoans>, IPayrollRunLoansRepository
    {
        public PayrollRunLoansRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PayrollRunTimeSheetsRepository : GenericRepository<PayrollRunTimeSheets>, IPayrollRunTimeSheetsRepository
    {
        public PayrollRunTimeSheetsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PayrollRunTimeSheetsPayRepository : GenericRepository<PayrollRunTimeSheetsPay>, IPayrollRunTimeSheetsPayRepository
    {
        public PayrollRunTimeSheetsPayRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PayrollRunPaySummaryRepository : GenericRepository<PayrollRunPaySummary>, IPayrollRunPaySummaryRepository
    {
        public PayrollRunPaySummaryRepository(ApplicationDbContext context) : base(context)
        {

        }
    };

    public class AuthenticationInviteRepository : GenericRepository<AuthenticationInvite>, IAuthenticationInviteRepository
    {
        public AuthenticationInviteRepository(ApplicationDbContext context) : base(context)
        {

        }
    };

    public class SSSTableRepository : GenericRepository<SSSTable>, ISSSTableRepository
    {
        public SSSTableRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class HDMFTableRepository : GenericRepository<HDMFTable>, IHDMFTableRepository
    {
        public HDMFTableRepository(ApplicationDbContext context) : base(context)
        {


        }
    }

    public class PHICTableRepository : GenericRepository<PHICTable>, IPHICTableRepository
    {
        public PHICTableRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

    public class PayrollRunCustomRateRepository : GenericRepository<PayrollRunCustomRate>, IPayrollRunCustomRateRepository
    {
        public PayrollRunCustomRateRepository(ApplicationDbContext context) : base(context)
        {

        }
    }

}
