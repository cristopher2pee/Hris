using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Extensions.Clock;
using Hris.Api.Middleware;
using Hris.Api.Models.Request.ClockWork;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.Clock;
using Hris.Business.Service.v1.ClockModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.ClockModule
{
    public class AssignedProjectController : BaseApiController<AssignedProjectController>
    {
        private readonly IAssignedProjectServices _assignedProjectServices;
        private readonly ICustomClaimPrincipal _custom;
        public AssignedProjectController(IAssignedProjectServices assignedProjectServices, ICustomClaimPrincipal custom, ILogger<AssignedProjectController> logger) : base(logger)
        {
            _assignedProjectServices = assignedProjectServices;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AssignedProjectDtoRequest client)
        {
            var result = await _assignedProjectServices.Add(client, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError(Resource.Responses.Common.ERROR, Resource.Responses.Common.ERROR_SAVE);
            return HrisOk(result.ToAssignedProjectResponse());
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AssignedProjectDtoRequest assignedProject)
        {
            var isExist = await _assignedProjectServices.GetById(assignedProject.Id);
            if (isExist == null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Assign Project {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            var result = await _assignedProjectServices.Update(assignedProject, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError(Resource.Responses.Common.ERROR, Resource.Responses.Common.ERROR_UPDATE);
            return HrisOk(result.ToAssignedProjectResponse());
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid assignProjectId)
        {
            var existingProject = await _assignedProjectServices.GetById(assignProjectId);

            if (existingProject == null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Assign Project {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            var result = await _assignedProjectServices.Delete(assignProjectId, await _custom.GetUserObjectId(User));
            if (!result) return HrisError(Resource.Responses.Common.ERROR, Resource.Responses.Common.ERROR_DELETE);
            return HrisOk(existingProject.ToAssignedProjectResponse());

        }
    }
}
