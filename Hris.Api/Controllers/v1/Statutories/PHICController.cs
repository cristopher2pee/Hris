using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.Statutories;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.Statutories
{

    public class PHICController : BaseApiController<PHICController>
    {

        private readonly IStatutoriesServices _services;
        private readonly ICustomClaimPrincipal _custom;
        public PHICController(ICustomClaimPrincipal custom, IStatutoriesServices services, ILogger<PHICController> logger) : base(logger)
        {
            _services = services;
            _custom = custom;
        }

        [HttpGet("list"), HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> GetList()
        {
            var result = await _services.GetListPHIC(f => f.Active);
            return HrisOk(result);
        }

        [HttpGet("{id}"), HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _services.GetListPHIC(f => f.Id.Equals(id));
            return HrisOk(result);
        }


        [HttpPost, HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> Add([FromBody] PHICTableDto.PHIC_Request req)
        {
            var result = await _services.AddPHIC(req, await _custom.GetUserObjectId(User));
            return result is null ? HrisError(Resource.Responses.Common.ERROR, Resource.Responses.Common.ERROR_SAVE) :
                HrisOk(result);
        }

        [HttpPut, HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> Update([FromBody] PHICTableDto.PHIC_Request req)
        {
            var result = await _services.UpdatePHIC(req, await _custom.GetUserObjectId(User));
            return result is null ? HrisError(Resource.Responses.Common.ERROR, Resource.Responses.Common.ERROR_UPDATE) :
                HrisOk(result);
        }

        [HttpDelete("{id}"), HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _services.DeletePHIC(id, await _custom.GetUserObjectId(User));
            return result ? HrisOk(new { Success = result })
                : HrisError(Resource.Responses.Common.ERROR, Resource.Responses.Common.ERROR_DELETE);
        }

    }
}
