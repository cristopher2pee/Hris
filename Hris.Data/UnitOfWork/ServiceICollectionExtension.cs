using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.UnitOfWork
{
    public static class ServiceICollectionExtension
    {
        public static IServiceCollection RepositoryServiceCollectionExtension(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IUserSettingsRepository, UserSettingsRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<ISalaryHistoryRepository, SalaryHistoryRepository>();
            services.AddScoped<IAllowanceEntitlementRepository, AllowanceEntitlementRepository>();
            services.AddScoped<IStatutoryRepository, StatutoryRepository>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<IAssignedProjectRepository, AssignedProjectRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<ILeaveApplicationRepository, LeaveApplicationRepository>();
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IAccessRepository, AccessRepository>();
            services.AddScoped<ICalendarEventsRepository, CalendarEventsRepository>();
            services.AddScoped<IAllowanceTypesRepository, AllowanceTypesRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IPositionsRepository, PositionRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ILeaveEntitlementsRepository, LeaveEntitlementsRepository>();
            services.AddScoped<ILeaveTypesRepository, LeaveTypesRepository>();
            services.AddScoped<IDeductionTypesRepository, DeductionTypesRepository>();
            services.AddScoped<IEmployeesDeductionRepository, EmployeesDeductionRepository>();
           // services.AddScoped<IEmployeeStatutoriesRepository, EmployeeStatutoriesRepository>();
            services.AddScoped<IShiftSchedulesRepository, ShiftSchedulesRepository>();
            services.AddScoped<ITaxTableRepository, TaxTableRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<ILoanTypesRepository, LoanTypesRepository>();
            services.AddScoped<IEmployeeLoansRepository, EmployeeLoansRepository>();
            services.AddScoped<IPayrollConfigRepository, PayrollConfigRepository>();
            services.AddScoped<IPayrollConfigDetailsRepository, PayrollConfigDetailsRepository>();
            services.AddScoped<IPayrollRunRepository, PayrollRunRepository>();
            services.AddScoped<IPayrollRunAllowancesRepository, PayrollRunAllowancesRepository>();
            services.AddScoped<IPayrollRunDeductionsRepository, PayrollRunDeductionsRepository>();
            services.AddScoped<IPayrollRunLoansRepository, PayrollRunLoansRepository>();
            services.AddScoped<IPayrollRunTimeSheetsRepository, PayrollRunTimeSheetsRepository>();
            services.AddScoped<IPayrollRunTimeSheetsPayRepository, PayrollRunTimeSheetsPayRepository>();
            services.AddScoped<IPayrollRunPaySummaryRepository, PayrollRunPaySummaryRepository>();
            services.AddScoped<IAuthenticationInviteRepository, AuthenticationInviteRepository>();
            services.AddScoped<ISSSTableRepository, SSSTableRepository>();
            services.AddScoped<IHDMFTableRepository, HDMFTableRepository>();
            services.AddScoped<IPHICTableRepository, PHICTableRepository>();
            services.AddScoped<IPayrollRunCustomRateRepository,PayrollRunCustomRateRepository>();
            return services;
        }
    }
}
