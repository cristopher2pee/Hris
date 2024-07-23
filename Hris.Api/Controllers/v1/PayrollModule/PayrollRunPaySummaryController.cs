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
    public class PayrollRunPaySummaryController : BaseApiController<PayrollRunPaySummaryController>
    {
        private readonly IPayrollRunPaySummaryServices _services;
        private readonly ICustomClaimPrincipal _custom;
        public PayrollRunPaySummaryController(IPayrollRunPaySummaryServices services, ICustomClaimPrincipal custom,
                        ILogger<PayrollRunPaySummaryController> logger) : base(logger)
        {
            _services = services;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _services.GetPayrollRunPaySummary(f => f.Id.Equals(id));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PayrollRunPaySummaryDtoRequest req)
        {
            var result = await _services.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Payroll Pay Summary");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PayrollRunPaySummaryDtoRequest req)
        {
            var result = await _services.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Payroll Pay Summary");
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
