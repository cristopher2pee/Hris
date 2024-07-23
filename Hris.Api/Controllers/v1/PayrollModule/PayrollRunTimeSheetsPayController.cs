using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.PayrollModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.PayrollModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollRunTimeSheetsPayController : BaseApiController<PayrollRunTimeSheetsPayController>
    {
        private readonly IPayrollRunTimeSheetsPayServices _services;
        private readonly ICustomClaimPrincipal _custom;
        public PayrollRunTimeSheetsPayController(IPayrollRunTimeSheetsPayServices services, ICustomClaimPrincipal custom,
                        ILogger<PayrollRunTimeSheetsPayController> logger) : base(logger)
        {
            _services = services;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _services.GetPayrollRunTimeSheetsPay(f => f.Id.Equals(id));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{employeeId}/{payrollRunId}")]
        public async Task<IActionResult> GetByEmployeeIdRunId([FromRoute] Guid employeeId, [FromRoute] Guid payrollRunId)
        {
            var result = await _services.GetPayrollRunTimeSheetsPay(f => f.EmployeeId.Equals(employeeId)
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
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PayrollRunTimeSheetsPayDtoRequest req)
        {
            var result = await _services.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Payroll Run Time Sheets Pay");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PayrollRunTimeSheetsPayDtoRequest req)
        {
            var result = await _services.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Payroll Run Time Sheets Pay");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _services.Delete(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

    }
}
