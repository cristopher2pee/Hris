using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.PayrollModule;
using Hris.Business.Service.v1;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.PayrollModule
{

    public class DeductionTypesController : BaseApiController<DeductionTypesController>
    {
        private readonly IDeductionTypesServices _deductionTypesServices;
        private readonly ICustomClaimPrincipal _custom;

        public DeductionTypesController(IDeductionTypesServices deductionTypesServices, ICustomClaimPrincipal custom,
                        ILogger<DeductionTypesController> logger) : base(logger)
        {
            _deductionTypesServices = deductionTypesServices;
            _custom = custom;
        }

        [HttpGet]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> GetAll([FromQuery] DeductionTypeFilters filters)
        {
            var result = await _deductionTypesServices.GetAll(filters);
            return HrisOk(result);
        }

        [HttpGet("{id}")]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _deductionTypesServices.GetById(id);
            return HrisOk(result);
        }

        [HttpGet("exists")]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> isExists([FromQuery] string name)
        {
            var result = await _deductionTypesServices.IsExists(f => f.Name.ToLower().Equals(name.ToLower()));
            return HrisOk(result);
        }

        [HttpGet("resources")]
        [HrisAuthorize]
        public async Task<IActionResult> GetResources()
        {
            var result = await _deductionTypesServices.Resources();
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost]
        public async Task<IActionResult> AddDeductionType([FromBody] DeductionTypesDtoRequest req)
        {
            var result = await _deductionTypesServices.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in adding deduction types");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]
        public async Task<IActionResult> UpdateDeductionType([FromBody] DeductionTypesDtoRequest req)
        {
            var result = await _deductionTypesServices.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in updating deduction types");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeductionType([FromRoute] Guid id)
        {
            var result = await _deductionTypesServices.Delete(id, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in deleting deduction types");
            return HrisOk(result);
        }

    }
}
