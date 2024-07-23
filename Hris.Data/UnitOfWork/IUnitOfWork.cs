using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeesRepository _Employees { get; }

        IUserSettingsRepository _UserSettings { get; }
        IAddressRepository _Address { get; }

        IFamilyRepository _Family { get; }
        ISalaryHistoryRepository _SalaryHistory { get; }

        IAllowanceEntitlementRepository _AllowanceEntitlement { get; }
        IStatutoryRepository _Statutory { get; }

        ITeamMemberRepository _TeamMember { get; }

        IAssignedProjectRepository _AssignedProject { get; }

        IPermissionRepository _Permission { get; }

        ILeaveApplicationRepository _LeaveApplication { get; }
        ITrackRepository _Track { get; }
        IAccessRepository _Access { get; }

        ICalendarEventsRepository _CalendarEvents { get; }

        IAllowanceTypesRepository _AllowanceTypes { get; }

        IDepartmentRepository _Department { get; }

        ITeamRepository _Team { get; }

        IPositionsRepository _Positions { get; }

        IClientRepository _Client { get; }
        IProjectTaskRepository _ProjectTask { get; }

        IProjectRepository _Project { get; }

        ITaskRepository _Task { get; }

        ILeaveEntitlementsRepository _LeaveEntitlements { get; }

        ILeaveTypesRepository _LeaveTypes { get; }

        IDeductionTypesRepository _DeductionTypes { get; }

        IEmployeesDeductionRepository _EmployeesDeduction { get; }

        //IEmployeeStatutoriesRepository _EmployeeStatutories { get; }

        IShiftSchedulesRepository _ShiftSchedules { get; }

        ITaxTableRepository _TaxTable { get; }

        INotificationRepository _Notification { get; }

        ILoanTypesRepository _LoanTypes { get; }
        IEmployeeLoansRepository _EmployeeLoans { get; }

        IPayrollConfigRepository _PayrollConfig { get; }

        IPayrollConfigDetailsRepository _PayrollConfigDetails { get; }

        IPayrollRunRepository _PayrollRun { get; }

        IPayrollRunAllowancesRepository _PayrollRunAllowances { get; }

        IPayrollRunDeductionsRepository _PayrollRunDeductions { get; }
        IPayrollRunLoansRepository _PayrollRunLoans { get; }
        IPayrollRunTimeSheetsRepository _PayrollRunTimeSheets { get; }
        IPayrollRunTimeSheetsPayRepository _PayrollRunTimeSheetsPay { get; }
        IPayrollRunPaySummaryRepository _PayrollRunPaySummary { get; }
        IAuthenticationInviteRepository _AuthenticationInvite { get; }

        ISSSTableRepository _SSSTable { get; }
        IHDMFTableRepository _HDMFTable { get; }
        IPHICTableRepository _PHICTable { get; }

        IPayrollRunCustomRateRepository _PayrollRunCustomRate { get; }
        Task<int> SaveChangeAsync(Guid objId);
    }
}
