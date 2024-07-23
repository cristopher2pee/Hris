using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.Employee;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.EmployeeModule
{

    public class AllowanceTypeController : BaseApiController<AllowanceTypeController>
    {
        private readonly IAllowanceTypeServices _allowanceTypeServices;
        private readonly IAllowanceEntitlementServices _allowanceEntitlementServices;
        private readonly ICustomClaimPrincipal _custom;
        public AllowanceTypeController(IAllowanceTypeServices services, IAllowanceEntitlementServices allowanceEntitlementServices
            , ICustomClaimPrincipal custom
            , ILogger<AllowanceTypeController> logger) : base(logger)
        {
            _allowanceTypeServices = services;
            _allowanceEntitlementServices = allowanceEntitlementServices;
            _custom = custom;

        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost]

        public async Task<IActionResult> Add([FromBody] AllowanceTypeDtoRequest allowancetype)
        {
            var result = await _allowanceTypeServices.Add(allowancetype, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Allowance Type", "Error in saving allowance type.");
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpGet("resource")]
        public async Task<IActionResult> GetResource()
        {
            var result = await _allowanceTypeServices.GetResources();
            return HrisOk(result);
        }


        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] AllowanceTypeFilter_ filter)
        {
            return HrisOk(await _allowanceTypeServices.GetAll(filter));
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("exists")]
        public async Task<IActionResult> GetAll([FromQuery] string name)
        {
            var result = await _allowanceTypeServices.isAllowanceTypeExist(f => f.Name.ToLower().Equals(name.ToLower()));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]

        public async Task<IActionResult> Update([FromBody] AllowanceTypeDtoRequest allowancetype)
        {
            var result = await _allowanceTypeServices.Update(allowancetype, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Allowance Type", "Error in updating allowance type.");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            var toBedeleted = await _allowanceTypeServices.GetById(Id);
            if (toBedeleted == null)
                return HrisErrorNotFound("Allowance Type", "Allowance Type does not exist.");

            var isUsed = await _allowanceEntitlementServices.IsAllowanceTypeUsed(Id);
            if (isUsed)
                return HrisError("Allowance Type", "Allowance type is being used. Cannot be deleted.");

            var result = await _allowanceTypeServices.Delete(Id, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Allowance Type", "Error in deleting allowance type.");

            return HrisOk(result);
        }
    }
}
