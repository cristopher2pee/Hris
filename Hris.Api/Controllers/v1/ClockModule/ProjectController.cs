using Azure.Storage.Sas;
using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Extensions.Clock;
using Hris.Api.Middleware;
using Hris.Api.Models.Common;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.ClockWork;
using Hris.Api.Models.Response.ClockWork;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.Clock;
using Hris.Business.Service.v1.ClockModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;

namespace Hris.Api.Controllers.v1.ClockModule
{
    public class ProjectController : BaseApiController<ProjectController>
    {
        private readonly IProjectServices _projectServices;
        private readonly IProjectTaskServices _taskServices;
        private readonly IAssignedProjectServices _assignedProjectServices;
        private readonly ICustomClaimPrincipal _custom;
        public ProjectController(IProjectServices projectServices,
            IProjectTaskServices taskServices,
            IAssignedProjectServices assignedProjectServices,
            ICustomClaimPrincipal custom, ILogger<ProjectController> logger) : base(logger)
        {
            _projectServices = projectServices;
            _taskServices = taskServices;
            _assignedProjectServices = assignedProjectServices;
            _custom = custom;

        }

        [HttpGet("resource"), HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr, HrisRoles.Lead })]
        public async Task<IActionResult> GetResource([FromRoute] Guid id)
        {
            var result = await _projectServices.GetResources();
            return HrisOk(result.Select(e => e.ToProjectDtoResponse()));
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("Client/{id}")]
        public async Task<IActionResult> GetByClientId([FromRoute] Guid id)
        {
            return HrisOk(await _projectServices.GetByClientId(id));
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProjectFilter_ filter)
        {
            var result = await _projectServices.GetAll(filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return HrisOk(await _projectServices.GetById(id));
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPost("{id}/duplicate")]
        public async Task<IActionResult> Duplicate([FromRoute] Guid id)
        {
            var result = await _projectServices.DuplicateProject(id, await _custom.GetUserObjectId(User));
            if (!result) return HrisErrorBadRequest(
                new List<Models.Response.Error.ErrorDetails>
                {
                    new Models.Response.Error.ErrorDetails(code :Resource.Responses.Project.PROJECT, description : "Error in duplicate project" )
                });
            return HrisOk(result);
        }


        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProjectDtoRequest request)
        {

            var result = await _projectServices.Add(request, await _custom.GetUserObjectId(User));
            if (result is null) return HrisErrorBadRequest(
               new List<Models.Response.Error.ErrorDetails>
               {
                  new Models.Response.Error.ErrorDetails(code :Resource.Responses.Common.ERROR, description : Resource.Responses.Common.ERROR_SAVE )
               });
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProjectDtoRequest request)
        {
            var result = await _projectServices.Update(request, await _custom.GetUserObjectId(User));
            if (result is null) return HrisErrorBadRequest(
                   new List<Models.Response.Error.ErrorDetails>
                   {
                            new Models.Response.Error.ErrorDetails(code :Resource.Responses.Common.ERROR, description : Resource.Responses.Common.ERROR_UPDATE )
                   });
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var d = await _projectServices.GetById(id);
            if (d == null)
                return HrisErrorNotFound(Resource.Responses.Common.ERROR, Resource.Responses.Common.OBJECT_NOT_EXIST);
            var result = await _projectServices.DeleteProject(id, await _custom.GetUserObjectId(User));
            if (!result) return HrisErrorBadRequest(
                new List<Models.Response.Error.ErrorDetails>
                {
                      new Models.Response.Error.ErrorDetails(code :Resource.Responses.Project.PROJECT, description : Resource.Responses.Common.ERROR_DELETE )
                });
            return HrisOk(result);
        }

        [HttpGet("Task/resource"), HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr, HrisRoles.Lead })]
        public async Task<IActionResult> GetTaskResource()
        {
            var result = await _projectServices.GetTaskResources();
            return HrisOk(result.Select(e => e.ToTaskDtoResponse()));
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("{id}/Task/{taskId}")]
        public async Task<IActionResult> GetTaskById([FromRoute] Guid id, [FromRoute] Guid taskId)
            => HrisOk(await _taskServices.GetById(taskId));

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpDelete("{id}/Task/{taskId}")]
        public async Task<IActionResult> RemoveTask([FromRoute] Guid id, [FromRoute] Guid taskId)
        {
            var d = await _taskServices.GetById(taskId);
            if (d == null)
                return HrisErrorNotFound(Resource.Responses.Common.ERROR, Resource.Responses.Common.OBJECT_NOT_EXIST);
            return HrisOk((await _taskServices.DeactivateTask(taskId, await _custom.GetUserObjectId(User))));
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPost("{id}/Task")]
        public async Task<IActionResult> AddTask([FromRoute] Guid id, [FromBody] ProjectTaskDtoRequest request)
        {
            var d = await _projectServices.GetById(id);
            if (d == null)
                return HrisErrorNotFound(Resource.Responses.Common.ERROR, Resource.Responses.Common.OBJECT_NOT_EXIST);

            var result = await _taskServices.Add(request, id, await _custom.GetUserObjectId(User));
            if (result is null) return HrisErrorBadRequest(
                   new List<Models.Response.Error.ErrorDetails>
                   {
                           new Models.Response.Error.ErrorDetails(code :Resource.Responses.Common.ERROR, description : Resource.Responses.Common.ERROR_UPDATE )
                   });

            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPut("{id}/Task")]
        public async Task<IActionResult> UpdateTask([FromRoute] Guid id, [FromBody] ProjectTaskDtoRequest request)
        {

            var d = await _taskServices.GetById(request.Id);
            if (d == null)
                return HrisErrorNotFound(Resource.Responses.Common.ERROR, Resource.Responses.Common.OBJECT_NOT_EXIST);

            var result = await _taskServices.Update(request, id, await _custom.GetUserObjectId(User));
            if (result is null) return HrisErrorBadRequest(
                   new List<Models.Response.Error.ErrorDetails>
                   {
                             new Models.Response.Error.ErrorDetails(code :Resource.Responses.Common.ERROR, description : Resource.Responses.Common.ERROR_UPDATE )
                   });

            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("{id}/Task")]
        public async Task<IActionResult> GetTasksByProjectId([FromRoute] Guid id)
        {
            var d = await _taskServices.GetTasksByProjectId(id);
            if (d == null)
                return HrisErrorNotFound(Resource.Responses.Common.ERROR, Resource.Responses.Common.OBJECT_NOT_EXIST);
            return HrisOk(await _taskServices.GetTasksByProjectId(id));
        }

        [HttpGet("{id}/Task/{taskId}/subTasks"), HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        public async Task<IActionResult> GetSubTasksByTaskId([FromRoute] Guid id, [FromRoute] Guid taskId)
        {
            var d = await _taskServices.GetSubTaskByTaskId(id, taskId);
            if (d == null)
                return HrisErrorNotFound(Resource.Responses.Common.ERROR, Resource.Responses.Common.OBJECT_NOT_EXIST);
            return HrisOk(await _taskServices.GetSubTaskByTaskId(id, taskId));
        }

        [HttpGet("Assigned"), HrisAuthorize]
        public async Task<IActionResult> GetAssignedProjects([FromQuery] BaseFilter_ filter)
        {
            var result = await _assignedProjectServices.GetAssignedProjects(filter);
            return Ok(result);
        }

        [HttpGet("Assigned/{id}"), HrisAuthorize]
        public async Task<IActionResult> GetAssignedProjectAndTaskById([FromRoute] Guid id, [FromQuery] string? search)
        {
            var result = await _assignedProjectServices.GetAssignedProjectAndTaskById(id, search);
            return HrisOk(result);
        }

        [HttpGet("Assigned/{id}/available"), HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        public async Task<IActionResult> GetAvailableProjectAndTask([FromRoute] Guid id, [FromQuery] string? search)
        {
            var result = await _assignedProjectServices.GetAvailableProjectAndTask(id, search);
            return HrisOk(result);
        }

        [HttpPost("Assigned/{id}/{taskId}"), HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        public async Task<IActionResult> AssignTask(Guid id, Guid taskId)
        {
            var result = await _assignedProjectServices.AssignTask(id, taskId, await _custom.GetUserObjectId(User));
            return HrisOk(result.ToAssignedProjectResponse());
        }

        [HttpDelete("Assigned/{id}/{taskId}"), HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        public async Task<IActionResult> UnassignTask(Guid id, Guid taskId)
        {
            var result = await _assignedProjectServices.UnassignTask(id, taskId, await _custom.GetUserObjectId(User));
            return HrisOk(result.ToAssignedProjectResponse());
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPost("Assigned")]
        public async Task<IActionResult> AddAssignedProject([FromBody] AssignedProjectDtoRequest request)
        {

            var result = await _assignedProjectServices.Add(request, await _custom.GetUserObjectId(User));
            if (result is null) return HrisErrorBadRequest(
                  new List<Models.Response.Error.ErrorDetails>
                  {
                           new Models.Response.Error.ErrorDetails(code :Resource.Responses.Common.ERROR, description : Resource.Responses.Common.ERROR_SAVE )
                  });
            return HrisOk(result.ToAssignedProjectResponse());
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPut("Assigned")]
        public async Task<IActionResult> UpdateAssignedProject([FromBody] AssignedProjectDtoRequest request)
        {
            var result = await _assignedProjectServices.Update(request, await _custom.GetUserObjectId(User));
            if (result is null) return HrisErrorBadRequest(
                 new List<Models.Response.Error.ErrorDetails>
                 {
                           new Models.Response.Error.ErrorDetails(code :Resource.Responses.Common.ERROR, description : Resource.Responses.Common.ERROR_UPDATE )
                 });
            return HrisOk(result.ToAssignedProjectResponse());
        }


        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("id")]
        public async Task<IActionResult> GetProjectById([FromQuery] Guid id)
        {
            var project = await _projectServices.GetById(id);
            if (project == null)
                return HrisErrorNotFound("Project", "Project not found.");
            return HrisOk(project);
        }

        [HrisAuthorize]
        [HttpGet("task")]
        public async Task<IActionResult> GetTasks([FromQuery] Guid id, string? search)
        {
            var existingProject = await _projectServices.GetById(id);

            if (existingProject == null)
                return HrisErrorNotFound("Project", "Project does not exist.");

            var tasks = await _taskServices.GetTask(id, search);
            return HrisOk(tasks);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpDelete("task")]
        public async Task<IActionResult> DeleteTask([FromQuery] Guid id)
        {
            var task = await _taskServices.GetById(id);
            if (task == null)
                return HrisErrorNotFound("Project", "Task does not exist.");

            var result = await _taskServices.Delete(id, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError(Resource.Responses.Project.PROJECT, "Error in deleting task.");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("task/id")]
        public async Task<IActionResult> IsExistingTaskId([FromQuery] Guid id)
                => HrisOk((await _taskServices.GetById(id)) != null);

        //TO BE ASK TOPE
        //[HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        //[HttpGet("client")]
        //        public async Task<IActionResult> GetProjectByClient([FromQuery] Guid id)
        //    => HrisOk((await projectService.GetAll())
        //        .Where(p => p.ClientId == id)
        //        .Select(p => new DropdownValues(p.Id.ToString(), p.Name, p.Tasks != null && p.Tasks.Any() ? p.Tasks.Where(t => t.ParentTaskId == Guid.Empty).Select(t => new DropdownValues(t.Id, t.Name)) : null))
        //        .ToList());
    }
}
