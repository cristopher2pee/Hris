using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.Employee;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Extensions;
using Hris.Business.Service.v1;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.PayrollModule
{
    public class AllowanceController : BaseApiController<AllowanceController>
    {
        private readonly IAllowanceServices _allowanceServices;
        private readonly ICustomClaimPrincipal _custom;
        public AllowanceController(IAllowanceServices allowanceServices, ICustomClaimPrincipal custom,
                        ILogger<AllowanceController> logger) : base(logger)
        {
            _allowanceServices = allowanceServices;
            _custom = custom;
        }

        [HttpGet("Type/resource"), HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> GetTypeResource([FromQuery] string? search)
            => Ok((await _allowanceServices.GetTypeResource(search)).Select(e => e.ToAllowanceTypeResponse()));

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("Type")]
        public async Task<IActionResult> GetType([FromQuery] AllowanceTypeFilter filter)
        {
            var type = await _allowanceServices.GetType(filter.Page, filter.Limit, filter.Search, filter.Period);
            return Ok(type.list.ToList().ToListResponse_(filter.Page, filter.Limit, type.total));
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("Type/{id}")]
        public async Task<IActionResult> GetTypeById([FromRoute] Guid id)
        {
            var res = await _allowanceServices.GetTypeById(id);
            return HrisOk(res.ToAllowanceTypeResponse());
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost("Type")]
        public async Task<IActionResult> AddType([FromBody] AllowanceTypeDtoRequest request)
        {
            var result = await _allowanceServices.SaveAllowanceType(request, await _custom.GetUserObjectId(User));
            return HrisOk(result.ToAllowanceTypeResponse());
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut("Type")]
        public async Task<IActionResult> UpdateType([FromBody] AllowanceTypeDtoRequest request)
        {
            var allowance = await _allowanceServices.GetTypeById(request.Id);
            if (allowance == null)
                return HrisError(Resource.Responses.AllowanceType.ALLOWANCE_TYPE, Resource.Responses.AllowanceType.NOT_FOUND);

            var res = await _allowanceServices.UpdateAllowanceType(request, await _custom.GetUserObjectId(User));
            return HrisOk(res.ToAllowanceTypeResponse());
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("Type/{id}")]
        public async Task<IActionResult> RemoveType([FromRoute] Guid id)
        {
            var allowance = await _allowanceServices.GetTypeById(id);
            if (allowance == null)
                return HrisError(Resource.Responses.AllowanceType.ALLOWANCE_TYPE, Resource.Responses.AllowanceType.NOT_FOUND);

            var result = await _allowanceServices.RemoveAllowanceType(id, await _custom.GetUserObjectId(User));
            return HrisOk(result.ToAllowanceTypeResponse());
        }
    }
}
