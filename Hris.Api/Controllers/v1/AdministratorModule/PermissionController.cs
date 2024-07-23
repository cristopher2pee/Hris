using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.Administrator;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.Administrator;
using Hris.Business.Service.EmployeeModule;
using Hris.Business.Service.v1.AdministratorModule;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hris.Resource;
using Hris.Api.Controllers.v1.PayrollModule;

namespace Hris.Api.Controllers.v1.AdministratorModule
{
    public class PermissionController : BaseApiController<PermissionController>
    {
        private readonly IPermissionServices _permissionServices;
        private readonly IEmployeesService _employeesService;
        private readonly ICustomClaimPrincipal _custom;
        public PermissionController(IPermissionServices permissionServices,
            IEmployeesService employeesService,
            ICustomClaimPrincipal custom,
            ILogger<PermissionController> logger) : base(logger)
        {
            _permissionServices = permissionServices;
            _employeesService = employeesService;
            _custom = custom;
        }

        [HttpGet("access/{id}"), HrisAuthorize]
        public async Task<IActionResult> GetUserAccess([FromRoute] Guid id)
        {
            var response = await _permissionServices.GetUserAccess(id);
            if (response is null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Permission {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            return HrisOk(response);
        }

        [HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PermissionFilter_ filter)
        {
            return HrisOk(await _permissionServices.GetAll(filter));
        }

        [HrisAuthorize]
        [HttpGet("access")]
        public async Task<IActionResult> GetUserAccess()
        {
            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User), false);

            if (employee is null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Employee {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            if (employee.ObjectId is null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"(Object ID) {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            var result = await _permissionServices.GetUserPermissionAccess(await _custom.GetUserObjectId(User));
            if (result is null)
                return HrisError(Resource.Responses.Common.ERROR, $"{Resource.Responses.Common.ERROR_ACCESS} (User Permission)");

            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpGet("employee-access/{id}")]
        public async Task<IActionResult> GetPermissionByEmployee([FromRoute] Guid id)
        {
            var employee = await _employeesService.GetById(id);
            if (employee is null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Employee {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            if (employee.ObjectId is null) return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Employee {Resource.Responses.Common.OBJECT_NOT_EXIST}");
            var objectId = employee.ObjectId;

            var result = await _permissionServices.GetUserPermissionAccess(objectId ?? Guid.Empty);
            if (result is null)
                return HrisError(Resource.Responses.Common.ERROR, $"{Resource.Responses.Common.ERROR_ACCESS} (User Permission)");

            return HrisOk(result);
        }


        [HttpPost, HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        public async Task<IActionResult> Add([FromBody] PermissionRequest request)
        {
            var employee = await _employeesService.GetDetailsById(1, request.EmployeeId);
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Employee {Resource.Responses.Common.OBJECT_NOT_EXIST}");
            await _permissionServices.ManagePermission(await _custom.GetUserObjectId(User), employee, request.Module, request.Role);
            return HrisOk(true);
        }

        [HttpPut, HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        public async Task<IActionResult> Update([FromBody] PermissionChangeRequest request)
        {

            var employee = await _employeesService.GetDetailsById(1, request.EmployeeId);
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Employee {Resource.Responses.Common.OBJECT_NOT_EXIST}");
            var result = await _permissionServices.UpdateRights(await _custom.GetUserObjectId(User), employee, request.Module, request.Role, request.NewModule, request.NewRole);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] PermissionRequest request)
        {

            var employee = (await _employeesService.GetByCondition(e => e.Id == request.EmployeeId)).FirstOrDefault();
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Common.NOTFOUND, $"Employee {Resource.Responses.Common.OBJECT_NOT_EXIST}");

            await _permissionServices.RemoveRights(await _custom.GetUserObjectId(User), employee, request.Module, request.Role);
            return HrisOk(true);
        }

    }
}
