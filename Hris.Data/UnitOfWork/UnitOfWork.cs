using Hris.Data.DataContext;
using Hris.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IEmployeesRepository _Employees { get; set; }
        public IUserSettingsRepository _UserSettings { get; set; }

        public IAddressRepository _Address { get; set; }
        public IFamilyRepository _Family { get; set; }
        public ISalaryHistoryRepository _SalaryHistory { get; set; }

        public IAllowanceEntitlementRepository _AllowanceEntitlement { get; set; }
        public IStatutoryRepository _Statutory { get; set; }

        public ITeamMemberRepository _TeamMember { get; set; }

        public IAssignedProjectRepository _AssignedProject { get; set; }

        public IPermissionRepository _Permission { get; set; }

        public ILeaveApplicationRepository _LeaveApplication { get; set; }
        public ITrackRepository _Track { get; set; }

        public IAccessRepository _Access { get; set; }
        public ICalendarEventsRepository _CalendarEvents { get; set; }

        public IAllowanceTypesRepository _AllowanceTypes { get; set; }

        public IDepartmentRepository _Department { get; set; }

        public ITeamRepository _Team { get; set; }

        public IPositionsRepository _Positions { get; set; }

        public IClientRepository _Client { get; set; }

        public IProjectTaskRepository _ProjectTask { get; set; }

        public IProjectRepository _Project { get; set; }

        public ITaskRepository _Task { get; set; }

        public ILeaveEntitlementsRepository _LeaveEntitlements { get; set; }
        public ILeaveTypesRepository _LeaveTypes { get; set; }

        public IDeductionTypesRepository _DeductionTypes { get; set; }

        public IEmployeesDeductionRepository _EmployeesDeduction { get; set; }

    //    public IEmployeeStatutoriesRepository _EmployeeStatutories { get; set; }

        public IShiftSchedulesRepository _ShiftSchedules { get; set; }

        public ITaxTableRepository _TaxTable { get; set; }

        public INotificationRepository _Notification { get; set; }

        public ILoanTypesRepository _LoanTypes { get; set; }
        public IEmployeeLoansRepository _EmployeeLoans { get; set; }

        public IPayrollConfigRepository _PayrollConfig { get; set; }

        public IPayrollConfigDetailsRepository _PayrollConfigDetails { get; set; }

        public IPayrollRunRepository _PayrollRun { get; set; }
        public IPayrollRunAllowancesRepository _PayrollRunAllowances { get; set; }

        public IPayrollRunDeductionsRepository _PayrollRunDeductions { get; set; }
        public IPayrollRunLoansRepository _PayrollRunLoans { get; set; }
        public IPayrollRunTimeSheetsRepository _PayrollRunTimeSheets { get; set; }

        public IPayrollRunTimeSheetsPayRepository _PayrollRunTimeSheetsPay { get; set; }

        public IPayrollRunPaySummaryRepository _PayrollRunPaySummary { get; set; }
        public IAuthenticationInviteRepository _AuthenticationInvite { get; set; }

        public ISSSTableRepository _SSSTable { get; set; }
        public IHDMFTableRepository _HDMFTable { get; set; }
        public IPHICTableRepository _PHICTable { get; set; }

        public IPayrollRunCustomRateRepository _PayrollRunCustomRate { get; set; }

        public UnitOfWork(ApplicationDbContext dbContext,
            IEmployeesRepository employeesRepository,
            IUserSettingsRepository userSettings,
            IAddressRepository address,
            IFamilyRepository family,
            ISalaryHistoryRepository salaryHistory,
            IAllowanceEntitlementRepository allowanceEntitlement,
            IStatutoryRepository statutory,
            ITeamMemberRepository teamMember,
            IAssignedProjectRepository assignedProject,
            IPermissionRepository permission,
            ILeaveApplicationRepository leaveApplication,
            ITrackRepository track,
            IAccessRepository access,
            ICalendarEventsRepository calendarEvents,
            IAllowanceTypesRepository allowanceTypes,
            IDepartmentRepository department,
            ITeamRepository team,
            IPositionsRepository positions,
            IClientRepository client,
            IProjectTaskRepository projectTask,
            IProjectRepository project,
            ITaskRepository task,
            ILeaveEntitlementsRepository leaveEntitlements,
            ILeaveTypesRepository leaveTypes,
            IDeductionTypesRepository deductionTypes,
            IEmployeesDeductionRepository employeesDeduction,
        //    IEmployeeStatutoriesRepository employeeStatutories,
            IShiftSchedulesRepository shiftSchedules,
            ITaxTableRepository taxTable,
            INotificationRepository notification,
            ILoanTypesRepository loanTypes,
            IEmployeeLoansRepository employeeLoans,
            IPayrollConfigRepository payrollConfig,
            IPayrollConfigDetailsRepository payrollConfigDetails,
            IPayrollRunRepository PayrollRun,
            IPayrollRunAllowancesRepository PayrollRunAllowances,
            IPayrollRunLoansRepository payrollRunLoans,
            IPayrollRunDeductionsRepository PayrollRunDeductions,
            IPayrollRunTimeSheetsRepository payrollRunTimeSheets,
            IPayrollRunTimeSheetsPayRepository payrollRunTimeSheetsPay,
            IPayrollRunPaySummaryRepository payrollRunPaySummary,
            IAuthenticationInviteRepository authenticationInvite,
            ISSSTableRepository sSSTable,
            IHDMFTableRepository hDMFTable,
            IPHICTableRepository pHICTable,
            IPayrollRunCustomRateRepository payrollRunCustomRate
             )
        {
            _dbContext = dbContext;
            _Employees = employeesRepository;
            _UserSettings = userSettings;
            _Address = address;
            _Family = family;
            _SalaryHistory = salaryHistory;
            _AllowanceEntitlement = allowanceEntitlement;
            _Statutory = statutory;
            _TeamMember = teamMember;
            _AssignedProject = assignedProject;
            _Permission = permission;
            _LeaveApplication = leaveApplication;
            _Track = track;
            _Access = access;
            _CalendarEvents = calendarEvents;
            _AllowanceTypes = allowanceTypes;
            _Department = department;
            _Team = team;
            _Positions = positions;
            _Client = client;
            _ProjectTask = projectTask;
            _Project = project;
            _Task = task;
            _LeaveEntitlements = leaveEntitlements;
            _LeaveTypes = leaveTypes;
            _DeductionTypes = deductionTypes;
            _EmployeesDeduction = employeesDeduction;
         //   _EmployeeStatutories = employeeStatutories;
            _ShiftSchedules = shiftSchedules;
            _TaxTable = taxTable;
            _Notification = notification;
            _LoanTypes = loanTypes;
            _EmployeeLoans = employeeLoans;
            _PayrollConfig = payrollConfig;
            _PayrollConfigDetails = payrollConfigDetails;
            _PayrollRun = PayrollRun;
            _PayrollRunAllowances = PayrollRunAllowances;
            _PayrollRunDeductions = PayrollRunDeductions;
            _PayrollRunLoans = payrollRunLoans;
            _PayrollRunTimeSheets = payrollRunTimeSheets;
            _PayrollRunTimeSheetsPay = payrollRunTimeSheetsPay;
            _PayrollRunPaySummary = payrollRunPaySummary;
            _AuthenticationInvite = authenticationInvite;
            _SSSTable = sSSTable;
            _HDMFTable = hDMFTable;
            _PHICTable = pHICTable;
            _PayrollRunCustomRate = payrollRunCustomRate;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

        public async Task<int> SaveChangeAsync(Guid objId)
        {
            return await SaveChanges(objId);
        }

        private async Task<int> SaveChanges(Guid objId)
        {
            _dbContext.ChangeTracker.DetectChanges();
            var selectedEntityList = _dbContext.ChangeTracker.Entries().
               Where(x => x.Entity is BaseEntity && (x.State == EntityState.Modified || x.State == EntityState.Added));


            foreach (var entity in selectedEntityList)
            {
                ((BaseEntity)entity.Entity).ModifiedBy = objId;
                ((BaseEntity)entity.Entity).Modified = DateTime.Now.ToUniversalTime();

                if (entity.State == EntityState.Added)
                    ((BaseEntity)entity.Entity).Id = Guid.NewGuid();
            }

            return await _dbContext.SaveChangesAsync();
        }
    }
}
