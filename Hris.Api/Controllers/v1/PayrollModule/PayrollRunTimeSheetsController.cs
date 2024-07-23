using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.PayrollModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.PayrollModule
{

    public class PayrollRunTimeSheetsController : BaseApiController<PayrollRunTimeSheetsController>
    {
        private readonly IPayrollRunTimeSheetsServices _services;
        private readonly ICustomClaimPrincipal _custom;
        public PayrollRunTimeSheetsController(IPayrollRunTimeSheetsServices services, ICustomClaimPrincipal custom,
                        ILogger<PayrollRunTimeSheetsController> logger) : base(logger)
        {
            _services = services;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _services.GetPayrollRunTimeSheets(f => f.Id.Equals(id));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{employeeId}/{payrollRunId}")]
        public async Task<IActionResult> GetByEmployeeIdRunId([FromRoute] Guid employeeId, [FromRoute] Guid payrollRunId)
        {
            var result = await _services.GetPayrollRunTimeSheets(f => f.EmployeeId.Equals(employeeId)
                && f.PayrollRunId.Equals(payrollRunId));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("exists")]
        public async Task<IActionResult> isExist([FromQuery] Guid employeeId, [FromQuery] Guid payrollRunId)
        {
            var result = await _services.isExist(f => f.EmployeeId.Equals(employeeId)
                && f.PayrollRunId.Equals(payrollRunId));

            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] BaseFilter_ filter)
        {
            var result = await _services.GetPayrollRunTimeSheetsPagedList(filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PayrollRunTimeSheetsDtoRequest req)
        {
            var result = await _services.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Payroll Run Time Sheets");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PayrollRunTimeSheetsDtoRequest req)
        {
            var result = await _services.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Payroll Run Time Sheets");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _services.Delete(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut("{employeeId}/{payrollRunId}/included")]
        public async Task<IActionResult> UpdateIncludePay([FromRoute] Guid employeeId, [FromRoute] Guid payrollRunId,
            [FromBody] PayrollRunIncludeRequest param)
        {

            var result = await _services.UpdateIncludedPayByEmployee(f => f.EmployeeId.Equals(employeeId)
                    && f.PayrollRunId.Equals(payrollRunId)
                    , param, await _custom.GetUserObjectId(User));

            return HrisOk(result);

        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut("{payrollRunId}/13-month-pay/included")]
        public async Task<IActionResult> UpdateAll13MonthPay([FromRoute] Guid payrollRunId,
            [FromBody] PayrollRunIncludeRequest param)
        {
            var result = await _services.UpdateAllIncludeEmployee(f => f.PayrollRunId.Equals(payrollRunId)
                    && f.PayrollRunId.Equals(payrollRunId), true
                    , param, await _custom.GetUserObjectId(User));

            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut("{payrollRunId}/leave/included")]
        public async Task<IActionResult> UpdateAll1LeavePay([FromRoute] Guid payrollRunId,
         [FromBody] PayrollRunIncludeRequest param)
        {
            var result = await _services.UpdateAllIncludeEmployee(f => f.PayrollRunId.Equals(payrollRunId)
                    && f.PayrollRunId.Equals(payrollRunId), false
                    , param, await _custom.GetUserObjectId(User));

            return HrisOk(result);
        }

    }
}
