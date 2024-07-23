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

    public class LoanTypesController : BaseApiController<LoanTypesController>
    {
        private readonly ILoanTypeServices _loanTypeServices;
        private readonly ICustomClaimPrincipal _custom;
        public LoanTypesController(ILoanTypeServices loanTypeServices, ICustomClaimPrincipal custom,
                        ILogger<LoanTypesController> logger) : base(logger)
        {
            _loanTypeServices = loanTypeServices;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin })]
        [HttpGet("resources")]
        public async Task<IActionResult> GetResources()
        {
            var result = await _loanTypeServices.GetResources();
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin })]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BaseFilter_ filter)
        {
            var result = await _loanTypeServices.GetAll(filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _loanTypeServices.GetById(id);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin })]
        [HttpGet("exists")]
        public async Task<IActionResult> IsExist([FromQuery] string? shortCode, [FromQuery] string? name)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(shortCode))
                result = await _loanTypeServices.isExists(f => f.ShortCode.ToLower().Equals(shortCode.ToLower()));
            if (!string.IsNullOrEmpty(name))
                result = await _loanTypeServices.isExists(f => f.Name.ToLower().Equals(name.ToLower()));

            return HrisOk(result);
        }


        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LoanTypesDtoRequest req)
        {
            var result = await _loanTypeServices.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Loan Types");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LoanTypesDtoRequest req)
        {
            var result = await _loanTypeServices.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Loan Types");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id)
        {
            var result = await _loanTypeServices.Delete(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }
    }
}
