using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Request.Employee;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.PayrollModule;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.DTO;
using Hris.Data.Models.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.EmployeeModule
{
    public class AllowanceEntitlementController : BaseApiController<AllowanceEntitlementController>
    {
        private readonly IAllowanceEntitlementServices _services;
        private readonly ICustomClaimPrincipal _custom;
        public AllowanceEntitlementController(IAllowanceEntitlementServices services, ICustomClaimPrincipal custom, ILogger<AllowanceEntitlementController> logger) : base(logger)
        {
            _services = services;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HrisOk(_services.GetAll());
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AllowanceEntitlementDtoRequest entitlement)
        {
            var result = await _services.Add(entitlement, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in saving allowance entitlement.");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AllowanceEntitlementDtoRequest entitlement)
        {
            var result = await _services.Update(entitlement, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in updating allowance entitlement.");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            var result = await _services.Delete(Id, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in deleting allowance entitlement.");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("exists")]
        public async Task<IActionResult> IsExists([FromQuery] Guid allowanceTypeId, PayrollPeriod payrollPeriod, Guid employeeId)
        {
            var result = await _services.IsAllowanceTypeUsed(f => f.AllowanceTypeId.Equals(allowanceTypeId)
                    && f.Period.Equals(payrollPeriod) && f.EmployeeId.Equals(employeeId));
            return HrisOk(result);
        }
    }
}
