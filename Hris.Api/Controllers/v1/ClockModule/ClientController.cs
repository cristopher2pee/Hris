using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.Client;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.ClockModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.ClockModule
{
    public class ClientController : BaseApiController<ClientController>
    {
        private readonly IClientServices _clientServices;
        private readonly ICustomClaimPrincipal _custom;
        public ClientController(IClientServices clientServices, ICustomClaimPrincipal custom, ILogger<ClientController> logger) : base(logger)
        {
            _clientServices = clientServices;
            _custom = custom;
        }

        [HttpGet("resource"), HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr, HrisRoles.Lead })]
        public async Task<IActionResult> GetResource()
        {
            var result = await _clientServices.GetResources();
            return HrisOk(result.Select(e => e.ToClientDtoResponse()));
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] BaseFilter_ filter)
        {
            var result = await _clientServices.GetAll(filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _clientServices.GetById(id);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ClientDtoRequest request)
        {
            var result = await _clientServices.Add(request, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError(Resource.Responses.Common.ERROR, Resource.Responses.Common.ERROR_SAVE);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClientDtoRequest request)
        {

            var result = await _clientServices.Update(request, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError(Resource.Responses.Common.ERROR, Resource.Responses.Common.ERROR_UPDATE);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var d = await _clientServices.GetById(id);
            if (d == null)
                return HrisError(Resource.Responses.Client.CLIENT, Resource.Responses.Client.NOT_FOUND);

            var result = await _clientServices.Delete(id, await _custom.GetUserObjectId(User));
            if (result is null) return HrisErrorBadRequest(new List<Models.Response.Error.ErrorDetails> { new Models.Response.Error.ErrorDetails
                (
                code : Resource.Responses.Common.ERROR,
                description : Resource.Responses.Common.ERROR_DELETE
                )});
            return HrisOk(result);

        }
    }
}
