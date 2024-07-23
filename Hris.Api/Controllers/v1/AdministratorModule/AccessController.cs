using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.AdministratorModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.AdministratorModule
{

    public class AccessController : BaseApiController<AccessController>
    {
        private readonly IAccessServices _accessServices;
        private readonly ICustomClaimPrincipal _custom;
        public AccessController(IAccessServices accessServices, ICustomClaimPrincipal custom, ILogger<AccessController> logger) : base(logger)
        {
            _accessServices = accessServices;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] AccessFilter_ filter)
        {
            return HrisOk(await _accessServices.GetAll(filter));
        }

        [HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AccessDtoRequest req)
        {
            var result = await _accessServices.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError(Resource.Responses.Common.ERROR, Resource.Responses.Common.ERROR_SAVE);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AccessDtoRequest req)
        {

            var result = await _accessServices.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, Resource.Responses.Common.OBJECT_NOT_EXIST);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {

            var result = await _accessServices.Delete(Id, await _custom.GetUserObjectId(User));
            if (result is null) return HrisErrorBadRequest(new List<Models.Response.Error.ErrorDetails>
                { new Models.Response.Error.ErrorDetails
                (code :  Resource.Responses.Common.ERROR ,description : Resource.Responses.Common.ERROR_DELETE)});
            return HrisOk(result);
        }
    }
}
