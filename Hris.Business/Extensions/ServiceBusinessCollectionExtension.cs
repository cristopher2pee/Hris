using Hris.Business.Helper;
using Hris.Business.Service.Mail;
using Hris.Business.Service.v1;
using Hris.Business.Service.v1.AdministratorModule;
using Hris.Business.Service.v1.ClockModule;
using Hris.Business.Service.v1.CommonModule;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Business.Service.v1.LeaveModule;
using Hris.Business.Service.v1.Notification;
using Hris.Business.Service.v1.PayrollModule;
using Hris.Business.Service.v1.Report;
using Hris.Business.Service.v1.Statutories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Extensions
{
    public static class ServiceBusinessCollectionExtension
    {
        public static IServiceCollection ServiceBusinessICollectionExtension(this IServiceCollection services)
        {
            //services.AddScoped<E>
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IUserSettingsServices, UserSettingsServices>();
            services.AddScoped<IAddressServices, AddressServices>();
            services.AddScoped<IFamilyServices, FamilyServices>();
            services.AddScoped<ISalaryHistoryServices, SalaryHistoryServices>();
            services.AddScoped<IAllowanceEntitlementServices, AllowanceEntitlementServices>();
            services.AddScoped<IStatutoryServices, StatutoryServices>();
            services.AddScoped<ITeamMemberServices, TeamMemberServices>();
            services.AddScoped<IAssignedProjectServices, AssignedProjectServices>();
            services.AddScoped<IPermissionServices, PermissionServices>();
            services.AddScoped<IAccessServices, AccessServices>();
            services.AddScoped<ICalendarServices, CalendarServices>();
            services.AddScoped<IAllowanceTypeServices, AllowanceTypesServices>();
            services.AddScoped<IDepartmentServices, DepartmentServices>();
            services.AddScoped<ITeamServices, TeamServices>();
            services.AddScoped<IPositionServices, PositionServices>();
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<IProjectServices, ProjectServices>();
            services.AddScoped<IProjectTaskServices, ProjectTaskServices>();
            services.AddScoped<ITrackServices, TrackServices>();
            services.AddScoped<ICommonServices, CommonServices>();
            services.AddScoped<ILeaveServices, LeaveServices>();
            services.AddScoped<IAllowanceServices, AllowanceServices>();
            services.AddScoped<IAccountServices, AccountServices>();
            services.AddScoped<ILeaveApplicationServices, LeaveAppicationServices>();            
            services.AddScoped<IMailkitServices, MailkitServices>();
            services.AddScoped<IDeductionTypesServices, DeductionTypesServices>();
            services.AddScoped<IEmployeesDeductionServices, EmployeesDeductionServices>();
            services.AddScoped<IEmployeeStatutoriesServices, EmployeeStatutoriesServices>();
            services.AddScoped<IShiftSchedulesServices, ShiftSchedulesServices>();
            services.AddScoped<ITaxTableServices, TaxTableServices>();
            services.AddScoped<INotificationServices, NotificationServices>();
            services.AddScoped<ILoanTypeServices, LoanTypesServices>();
            services.AddScoped<IEmployeeLoanServices, EmployeeLoanServices>();
            services.AddScoped<IPayrollConfigServices, PayrollConfigServices>();
            services.AddScoped<IPayrollRunServices, PayrollRunServices>();
            services.AddScoped<IPayrollRunAllowanceServices, PayrollRunAllowanceServices>();
            services.AddScoped<IPayrollRunDeductionsServices, PayrollRunDeductionsServices>();
            services.AddScoped<IPayrollRunLoansServices, PayrollRunLoansServices>();
            services.AddScoped<IPayrollRunTimeSheetsServices, PayrollRunTimeSheetsServices>();
            services.AddScoped<IPayrollRunTimeSheetsPayServices, PayrollRunTimeSheetsPayServices>();
            services.AddScoped<IPayrollRunPaySummaryServices, PayrollRunPaySummaryServices>();
            services.AddScoped<IReportServices, ReportServices>();
            services.AddScoped<IAuthInviteService, AuthInviteService>();
            services.AddScoped<IJwtTokenHelper, JwtTokenHelper>();
            services.AddScoped<ILeaveEntitlementServices, LeaveEntitlementServices>();
            services.AddScoped<IStatutoriesServices, StatutoriesServices>();

            services.AddScoped<IPayrollHelper, PayrollHelper>();
            return services;

        }
    }
}
