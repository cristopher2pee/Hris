using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.PayrollModule;
using Hris.Data.DTO;
using Hris.Resource.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.PayrollModule
{
    public class PayrollRunController : BaseApiController<PayrollConfigController>
    {
        private readonly IPayrollRunServices _payrollRunServices;
        private readonly IPayrollRunTimeSheetsPayServices _payrollRunTimeSheetsPayServices;
        private readonly IPayrollRunPaySummaryServices _payrollRunPaySummaryServices;
        private readonly ICustomClaimPrincipal _custom;

        public PayrollRunController(IPayrollRunServices payrollRunServices,
            IPayrollRunTimeSheetsPayServices payrollRunTimeSheetsPayServices,
            IPayrollRunPaySummaryServices payrollRunPaySummaryServices,
            ICustomClaimPrincipal custom,
                        ILogger<PayrollConfigController> logger) : base(logger)
        {
            _payrollRunServices = payrollRunServices;
            _payrollRunTimeSheetsPayServices = payrollRunTimeSheetsPayServices;
            _payrollRunPaySummaryServices = payrollRunPaySummaryServices;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PayrollRunFiler filter)
        {
            var result = await _payrollRunServices.GetAll(filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _payrollRunServices.GetById(id);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("resources/{year}")]
        public async Task<IActionResult> GetPayrollRunByYear([FromRoute] int year)
        {
            var result = await _payrollRunServices.GetPayrollRunList(f => f.Year.Equals(year) && f.IsLocked);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PayrollRunDtoRequest req)
        {
                var result = await _payrollRunServices.Add(req, await _custom.GetUserObjectId(User));
                if (result is null) return HrisError("Error", "Error in Saving Payroll Run");
                return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PayrollRunDtoRequest req)
        {
                var result = await _payrollRunServices.Update(req, await _custom.GetUserObjectId(User));
                if (result is null) return HrisError("Error", "Error in Updating Payroll Run");
                return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
                var result = await _payrollRunServices.Delete(id, await _custom.GetUserObjectId(User));
                return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("get-holidays")]
        [HttpGet("holidays")]
        public async Task<IActionResult> GetHolidays([FromQuery] Guid payrollRunId, [FromQuery] Guid payrollConfigId, [FromQuery] BaseFilter_ filter)
        {
            var result = await _payrollRunServices.GetPayrollRunHolidays(payrollRunId, payrollConfigId, await _custom.GetUserObjectId(User), filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("get-track-request")]
        [HttpGet("employee/track/request")]
        public async Task<IActionResult> GetTracksRequest([FromQuery] Guid payrollRunId, [FromQuery] Guid payrollConfigId, [FromQuery] BaseFilter_ filter)
        {
            var result = await _payrollRunServices.GetPayrollRunTracks(payrollRunId, payrollConfigId, await _custom.GetUserObjectId(User), filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("get-leave-application-request")]
        [HttpGet("employee/leave-application/request")]
        public async Task<IActionResult> GetLeaveApplicationRequest([FromQuery] Guid payrollRunId, [FromQuery] Guid payrollConfigId, [FromQuery] BaseFilter_ filter)
        {
            var result = await _payrollRunServices.GetPayrollRunLeaveApplications(payrollRunId, payrollConfigId, await _custom.GetUserObjectId(User), filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("get-employee-settings-info")]
        [HttpGet("employee/settings/info")]
        public async Task<IActionResult> GetEmployeeSettingsInfo([FromQuery] Guid payrollRunId, [FromQuery] Guid payrollConfigId, [FromQuery] BaseFilter_ filter)
        {
            var result = await _payrollRunServices.GetEmployeeVerificationPayrollRun(payrollRunId, payrollConfigId, await _custom.GetUserObjectId(User), filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("get-employee-track-details")]
        [HttpGet("employee/track/details")]
        public async Task<IActionResult> GetPayrollTrackDetailsByEmployee([FromQuery] Guid payrollRunId, [FromQuery] Guid employeeId, [FromQuery] BaseFilter_ filter)
        {
            var result = await _payrollRunServices.GetPayrollTrackDetailsByEmployee(payrollRunId, employeeId, filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("exists")]
        public async Task<IActionResult> isExist([FromQuery] int month, [FromQuery] int year, [FromQuery] Guid payrollConfigId)
        {
            var result = await _payrollRunServices.isExist(f => f.Month.Equals(month) && f.Year.Equals(year)
                && f.PayrollConfigId.Equals(payrollConfigId));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("get-employee-loans")]
        [HttpGet("employee/loans")]
        public async Task<IActionResult> GetEmployeeLoan([FromQuery] Guid payrollRunId, [FromQuery] Guid payrollConfigId, [FromQuery] BaseFilter_ filter)
        {
            var result = await _payrollRunServices.GetEmployeeLoan(payrollRunId, payrollConfigId, await _custom.GetUserObjectId(User), filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("get-employee-allowances")]
        [HttpGet("employee/allowances")]
        public async Task<IActionResult> GetEmployeeAllowance([FromQuery] Guid payrollRunId, [FromQuery] Guid payrollConfigId, [FromQuery] BaseFilter_ filter)
        {
            var result = await _payrollRunServices.GetEmployeeAllowance(payrollRunId, payrollConfigId, await _custom.GetUserObjectId(User), filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("get-employee-deductions")]
        [HttpGet("employee/deductions")]
        public async Task<IActionResult> GetEmployeeDeduction([FromQuery] Guid payrollRunId, [FromQuery] Guid payrollConfigId, [FromQuery] BaseFilter_ filter)
        {
            var result = await _payrollRunServices.GetEmployeeDeduction(payrollRunId, payrollConfigId, await _custom.GetUserObjectId(User), filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("get-employee-time-sheets")]
        [HttpGet("employee/time/sheets")]
        public async Task<IActionResult> GetEmployeeDeduction([FromQuery] Guid payrollRunId, [FromQuery] BaseFilter_ filter)
        {
            var result = await _payrollRunServices.GetPayrollRunTimeSheets(payrollRunId, filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("get-employee-time-sheets")]
        [HttpGet("employee/pay/summary")]
        public async Task<IActionResult> GetEmployeePaySummary([FromQuery] Guid payrollRunId, [FromQuery] BaseFilter_ filter)
        {
            var result = await _payrollRunPaySummaryServices.GetPayrollRunPaySummaryListPage(f => f.PayrollRunId.Equals(payrollRunId), filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("get-employee-time-sheets")]
        [HttpGet("employee/time/sheets/pay")]
        public async Task<IActionResult> GetEmployeeSheetsPay([FromQuery] Guid payrollRunId, [FromQuery] BaseFilter_ filter)
        {
            var result = await _payrollRunTimeSheetsPayServices.GetPayrollRunTimeSheetsPayListPage((f => f.PayrollRunId.Equals(payrollRunId)), filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //[HttpGet("process-employee-loans")]
        [HttpGet("process/employee/loans")]
        public async Task<IActionResult> ProcessEmployeeLoansByPayrollRun([FromQuery] Guid payrollRunId, [FromQuery] Guid payrollConfigId)
        {
            var toCheck = await _payrollRunServices.GetPayrollRun(f => f.Id.Equals(payrollRunId));
            if (toCheck.IsLocked) return HrisError(PayrollRunMessage.PAYROLL_RUN, PayrollRunMessage.LOCKED_MESSAGE);
            var result = await _payrollRunServices.ProcessEmployeeLoansByPayrollRun(payrollRunId, payrollConfigId, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        // [HttpGet("process-employee-allowances")]
        [HttpGet("process/employee/allowances")]
        public async Task<IActionResult> ProcessEmployeeAllowanceByPayrollRun([FromQuery] Guid payrollRunId, [FromQuery] Guid payrollConfigId)
        {
            var toCheck = await _payrollRunServices.GetPayrollRun(f => f.Id.Equals(payrollRunId));
            if (toCheck.IsLocked) return HrisError(PayrollRunMessage.PAYROLL_RUN, PayrollRunMessage.LOCKED_MESSAGE);
            var result = await _payrollRunServices.ProcessEmployeeAllowanceByPayrollRun(payrollRunId, payrollConfigId, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        // [HttpGet("process-employee-deductions")]
        [HttpGet("process/employee/deductions")]
        public async Task<IActionResult> ProcessEmployeeDeductionsByPayrollRun([FromQuery] Guid payrollRunId, [FromQuery] Guid payrollConfigId)
        {
            var toCheck = await _payrollRunServices.GetPayrollRun(f => f.Id.Equals(payrollRunId));
            if (toCheck.IsLocked) return HrisError(PayrollRunMessage.PAYROLL_RUN, PayrollRunMessage.LOCKED_MESSAGE);
            var result = await _payrollRunServices.ProcessEmployeeDeductionsByPayrollRun(payrollRunId, payrollConfigId, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        // [HttpGet("process-employee-time-sheets")]
        [HttpGet("process/employee/time/sheets")]
        public async Task<IActionResult> ProcessEmployeeTimeSheetsByPayrollRun([FromQuery] Guid payrollRunId, [FromQuery] Guid payrollConfigId)
        {
            var toCheck = await _payrollRunServices.GetPayrollRun(f => f.Id.Equals(payrollRunId));
            if (toCheck.IsLocked) return HrisError(PayrollRunMessage.PAYROLL_RUN, PayrollRunMessage.LOCKED_MESSAGE);
            var result = await _payrollRunServices.ProcessPayrollRunTimeSheets(payrollRunId, payrollConfigId, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        // [HttpGet("process-employee-time-sheets")]
        [HttpGet("process/employee/time/sheets/pay")]
        public async Task<IActionResult> ProcessEmployeeTimeSheetsPayByPayrollRun([FromQuery] Guid payrollRunId)
        {
            var toCheck = await _payrollRunServices.GetPayrollRun(f => f.Id.Equals(payrollRunId));
            if (toCheck.IsLocked) return HrisError(PayrollRunMessage.PAYROLL_RUN, PayrollRunMessage.LOCKED_MESSAGE);
            var result = await _payrollRunTimeSheetsPayServices.ProcessPayrollRunTimeSheetsPay(payrollRunId, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        // [HttpGet("process-employee-time-sheets")]
        [HttpGet("process/employee/pay/summary")]
        public async Task<IActionResult> ProcessEmployeePaySummary([FromQuery] Guid payrollRunId)
        {
            var toCheck = await _payrollRunServices.GetPayrollRun(f => f.Id.Equals(payrollRunId));
            if (toCheck.IsLocked) return HrisError(PayrollRunMessage.PAYROLL_RUN, PayrollRunMessage.LOCKED_MESSAGE);
            var result = await _payrollRunPaySummaryServices.ProcessEmployeesPaySummary(payrollRunId, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        //[HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        //// [HttpGet("process-employee-time-sheets")]
        //[HttpGet("process/employee/pay/summary")]
        //public async Task<IActionResult> ([FromQuery] Guid payrollRunId)
        //{
        //    var result = await _payrollRunTimeSheetsPayServices.ProcessPayrollRunTimeSheetsPay(payrollRunId, await _custom.GetUserObjectId(User));
        //    return HrisOk(result);
        //}
    }
}
