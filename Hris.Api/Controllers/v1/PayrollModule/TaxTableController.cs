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

    public class TaxTableController : BaseApiController<TaxTableController>
    {
        private readonly ITaxTableServices _taxTableServices;
        private readonly ICustomClaimPrincipal _custom;
        public TaxTableController(ITaxTableServices taxTableServices, ICustomClaimPrincipal custom,
                        ILogger<TaxTableController> logger) : base(logger)
        {
            _taxTableServices = taxTableServices;
            _custom = custom;
        }

        [HttpGet]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> GetAll()
        {
            var res = await _taxTableServices.GetAll();
            return HrisOk(res);
        }

        [HttpGet("compute-tax-withheld")]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> ComputeTaxTableWithHeld([FromQuery]TaxPeriodType type, [FromQuery] decimal netPay)
        {
            var res = await _taxTableServices.ComputeTaxWithHeld( type,netPay);
            return HrisOk(res);
        }


        [HttpGet("{id}")]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var res = await _taxTableServices.GetById(id);
            return HrisOk(res);
        }

        [HttpPost]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> AddTaxTable([FromBody] TaxTableDtoRequest req)
        {
            var result = await _taxTableServices.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Tax");
            return HrisOk(result);
        }

        [HttpPut]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> UpdateTaxTable([FromBody] TaxTableDtoRequest req)
        {
            var result = await _taxTableServices.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Tax");
            return HrisOk(result);
        }

        [HttpDelete("{id}")]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> DeleteTaxTable([FromRoute] Guid id)
        {
            var result = await _taxTableServices.Delete(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }
    }
}
