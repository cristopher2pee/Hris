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
    internal interface IRepositoryWrapper
    {

    }

    public interface IEmployeesRepository : IGenericRepository<Employee> { }
    public interface IUserSettingsRepository : IGenericRepository<UserSettings> { }
    public interface IAddressRepository : IGenericRepository<Address> { }
    public interface IFamilyRepository : IGenericRepository<Family> { }
    public interface ISalaryHistoryRepository : IGenericRepository<SalaryHistory> { }
    public interface IAllowanceEntitlementRepository : IGenericRepository<AllowanceEntitlement> { }
    public interface IStatutoryRepository : IGenericRepository<Statutory> { }
    public interface ITeamMemberRepository : IGenericRepository<TeamMember> { }
    public interface IAssignedProjectRepository : IGenericRepository<AssignedProject> { }
    public interface IPermissionRepository : IGenericRepository<Permission> { }
    public interface ILeaveApplicationRepository : IGenericRepository<LeaveApplication> { }
    public interface ITrackRepository : IGenericRepository<Track> { }
    public interface IAccessRepository : IGenericRepository<Access> { }
    public interface ICalendarEventsRepository : IGenericRepository<Calendar> { }
    public interface IAllowanceTypesRepository : IGenericRepository<AllowanceType> { }
    public interface IDepartmentRepository : IGenericRepository<Department> { }
    public interface ITeamRepository : IGenericRepository<Team> { };
    public interface IPositionsRepository : IGenericRepository<Position> { };
    public interface IClientRepository : IGenericRepository<Client> { };
    public interface IProjectTaskRepository : IGenericRepository<ProjectTask> { };
    public interface IProjectRepository : IGenericRepository<Project> { };
    public interface ITaskRepository : IGenericRepository<Task> { };
    public interface ILeaveEntitlementsRepository : IGenericRepository<LeaveEntitlement> { };
    public interface ILeaveTypesRepository : IGenericRepository<LeaveType> { };

    public interface IDeductionTypesRepository : IGenericRepository<DeductionTypes> { };
    public interface IEmployeesDeductionRepository : IGenericRepository<EmployeesDeduction> { };
    //public interface IEmployeeStatutoriesRepository : IGenericRepository<EmployeeStatutories> { };
    public interface IShiftSchedulesRepository : IGenericRepository<ShiftSchedule> { };
    public interface ITaxTableRepository : IGenericRepository<TaxTable> { };
    public interface INotificationRepository : IGenericRepository<Notification> { }

    public interface ILoanTypesRepository : IGenericRepository<LoanTypes> { };
    public interface IEmployeeLoansRepository : IGenericRepository<EmployeeLoans> { };

    public interface IPayrollConfigRepository : IGenericRepository<PayrollConfig> { };
    public interface IPayrollConfigDetailsRepository : IGenericRepository<PayrollConfigDetails> { };
    public interface IPayrollRunRepository : IGenericRepository<PayrollRun> { };
    public interface IPayrollRunAllowancesRepository : IGenericRepository<PayrollRunAllowances> { };
    public interface IPayrollRunDeductionsRepository : IGenericRepository<PayrollRunDeductions> { };
    public interface IPayrollRunLoansRepository : IGenericRepository<PayrollRunLoans> { };
    public interface IPayrollRunTimeSheetsRepository : IGenericRepository<PayrollRunTimeSheets> { };
    public interface IPayrollRunTimeSheetsPayRepository : IGenericRepository<PayrollRunTimeSheetsPay> { };

    public interface IPayrollRunPaySummaryRepository : IGenericRepository<PayrollRunPaySummary> { };
    public interface IAuthenticationInviteRepository : IGenericRepository<AuthenticationInvite> { };

    public interface ISSSTableRepository : IGenericRepository<SSSTable> { };
    public interface IHDMFTableRepository : IGenericRepository<HDMFTable> { };
    public interface IPHICTableRepository : IGenericRepository<PHICTable> { };

    public interface IPayrollRunCustomRateRepository : IGenericRepository<PayrollRunCustomRate> { };

}
