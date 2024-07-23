using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.PayrollModule;
using Hris.Data.DTO;
using Hris.Data.Models.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.PayrollModule
{
    public class PayrollRunAllowancesController : BaseApiController<PayrollRunAllowancesController>
    {
        private readonly IPayrollRunAllowanceServices _payrollRunAllowanceServices;
        private readonly ICustomClaimPrincipal _custom;
        public PayrollRunAllowancesController(IPayrollRunAllowanceServices payrollRunAllowanceServices, ICustomClaimPrincipal custom,
                        ILogger<PayrollRunAllowancesController> logger) : base(logger)
        {
            _payrollRunAllowanceServices = payrollRunAllowanceServices;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetByEmployeeId([FromRoute] Guid employeeId)
        {
            var result = await _payrollRunAllowanceServices.GetByEmployeeId(employeeId);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _payrollRunAllowanceServices.GetByExpression(f => f.Id.Equals(id));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{employeeId}/{payrollRunId}/list")]
        public async Task<IActionResult> GetByPayrollRunData([FromRoute] Guid employeeId, [FromRoute] Guid payrollRunId)
        {
            var result = await _payrollRunAllowanceServices.GetListByExpression(f => f.EmployeeId.Equals(employeeId)
            && f.PayrollRunId.Equals(payrollRunId));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("exists")]
        public async Task<IActionResult> isExist([FromQuery] Guid employeeId, [FromQuery] Guid allowanceTypeId,
            [FromQuery] Guid payrollRunId)
        {
            var result = await _payrollRunAllowanceServices.isExist(f => f.EmployeeId.Equals(employeeId)
                && f.AllowanceTypeId.Equals(allowanceTypeId)
                && f.PayrollRunId.Equals(payrollRunId));

            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PayrollRunAllowanceDtoRequest req)
        {
            var result = await _payrollRunAllowanceServices.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Payroll Run Allowance");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PayrollRunAllowanceDtoRequest req)
        {
            var result = await _payrollRunAllowanceServices.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Payroll Run Allowance");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayrollConfig([FromRoute] Guid id)
        {
            var result = await _payrollRunAllowanceServices.Delete(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

    }
}
