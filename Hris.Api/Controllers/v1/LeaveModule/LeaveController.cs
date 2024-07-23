using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Hub;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.Leave;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.Administrator;
using Hris.Business.Service.Common;
using Hris.Business.Service.EmployeeModule;
using Hris.Business.Service.v1.AdministratorModule;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Business.Service.v1.LeaveModule;
using Hris.Data.DTO;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Leave;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.LeaveModule
{

    public class LeaveController : BaseApiController<LeaveController>
    {
        private readonly IEmployeesService _employeeServices;
        private readonly IPermissionServices _permissionServices;
        private readonly ILeaveServices _leaveServices;
        private readonly IUserSettingsServices _userSettingsServices;
        private readonly StorageCloudService _storageCloudService;
        private readonly INotificationHelper _NotifHelper;
        private readonly ICustomClaimPrincipal _custom;

        public LeaveController(IEmployeesService employeesService,
            IPermissionServices permissionServices,
            ILeaveServices leaveServices,
            StorageCloudService storageCloudService,
            IUserSettingsServices userSettingsServices,
            INotificationHelper notifHelper,
            ICustomClaimPrincipal custom,
                        ILogger<LeaveController> logger) : base(logger)
        {
            _employeeServices = employeesService;
            _permissionServices = permissionServices;
            _storageCloudService = storageCloudService;
            _leaveServices = leaveServices;
            _userSettingsServices = userSettingsServices;
            _NotifHelper = notifHelper;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Lead, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpGet("isAdmin")]
        public async Task<IActionResult> IsAdmin()
        {
            var employee = await _employeeServices.GetByObjectId(await _custom.GetUserObjectId(User), false);
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Employee.EMPLOYEE, Resource.Responses.Employee.NOT_FOUND);

            var role = await _permissionServices.GetRoleByModule(employee.Id, Modules.Leave);
            return HrisOk(role.Equals(Roles.Admin) || role.Equals(Roles.Hr));
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Lead, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpGet("request")]
        public async Task<IActionResult> GetRequests([FromQuery] LeaveRequestFilter_ filter)
        {
            var employee = await _employeeServices.GetDetailsById(3, await _custom.GetUserObjectId(User), true);
            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            var result = await _leaveServices.GetLeaveApplication(employee, filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Lead, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpGet("request/generate")]
        public async Task<IActionResult> GenerateRequest([FromQuery] LeaveRequestFilter_ filter)
        {
            var employee = await _employeeServices.GetDetailsById(3, await _custom.GetUserObjectId(User), true);
            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            var result = await _leaveServices.GenerateRequest(filter, employee);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Lead, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpPut("request")]
        public async Task<IActionResult> ManageRequest([FromBody] LeaveApplicationRequest request, [FromQuery] bool isApproved)
        {
            var application = await _leaveServices.GetById(request.Id);
            if (application == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Leave Application Request not found.");

            var employee = await _employeeServices.GetDetailsById(3, await _custom.GetUserObjectId(User), true);
            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            var result = await _leaveServices.ManageRequest(application, employee, isApproved, request.Remarks, await _custom.GetUserObjectId(User));
            await _NotifHelper.ProcessNotificationList(result.list.ToList());
            return HrisOk(result.res);
        }

        [HrisAuthorize]
        [HttpGet("application")]
        public async Task<IActionResult> GetApplications([FromQuery] LeaveApplicationFilter_ filter)
        {
            var employee = await _employeeServices.GetByObjectId(await _custom.GetUserObjectId(User), false);
            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            var settings = (await _userSettingsServices.GetByCondition(s => s.EmployeeId.Equals(employee.Id))).FirstOrDefault();
            if (settings == null)
                return HrisErrorNotFound(this.GetType().ToString(), "User settings not found.");

            var result = await _leaveServices.GetApplications(filter, employee);
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpGet("application/{id}")]
        public async Task<IActionResult> GetApplicationById([FromRoute] Guid id)
        {
            var employee = await _employeeServices.GetByObjectId(await _custom.GetUserObjectId(User), false);
            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            var settings = (await _userSettingsServices.GetByCondition(s => s.EmployeeId.Equals(employee.Id))).FirstOrDefault();
            if (settings == null)
                return HrisErrorNotFound(this.GetType().ToString(), "User settings not found.");

            var leave = await _leaveServices.GetById(id);
            if (leave == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Leave Application not found.");
            return HrisOk(leave.ToLeaveApplicationResponse(settings.Timezone));
        }

        [HrisAuthorize]
        [HttpGet("application/days")]
        public async Task<IActionResult> ComputeDays([FromQuery] DateTime from, [FromQuery] DateTime to)
             => HrisOk(await _leaveServices.ComputeDays(from, to));

        [HrisAuthorize]
        [HttpPost("application")]
        public async Task<IActionResult> SaveApplication(LeaveApplicationDtoRequest request)
        {
            var employee = await _employeeServices.GetByObjectId(await _custom.GetUserObjectId(User), false);

            if (employee == null)
                return HrisError(this.GetType().ToString(), "Employee does not exist.");

            var result = await _leaveServices.AddApplication(request, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpPut("application/attachment")]
        public async Task<IActionResult> UpdateApplicationAttachment()
        {
            var form = Request.Form;
            var id = form["id"];

            if (string.IsNullOrEmpty(id))
                return HrisError(this.GetType().ToString(), "Leave Application Id is empty.");

            var appId = Guid.Parse(id);

            var leave = await _leaveServices.GetApplicationById(appId);

            if (leave == null)
                return HrisError(this.GetType().ToString(), "Leave Application not found.");

            if (!form.Files.Any())
                return HrisError(this.GetType().ToString(), "No Files Attached.");

            var file = form!.Files!.FirstOrDefault()!;
            await _storageCloudService.UploadAttachment(4, file, leave.Id);
            leave.Document = file.FileName;
            leave.DocumentUri = await _storageCloudService.GetAttachmentUri(4, leave.Id);

            return HrisOk(await _leaveServices.Update(leave, await _custom.GetUserObjectId(User)));
        }

        [HrisAuthorize]
        [HttpGet("application/withdraw")]
        public async Task<IActionResult> WithdrawApplication([FromQuery] Guid id)
        {
            var result = await _leaveServices.WithdrawApplication(id, await _custom.GetUserObjectId(User));
            await _NotifHelper.ProcessNotificationList(result.list);
            return HrisOk(result.result);
        }


        [HrisAuthorize]
        [HttpPut("application")]
        public async Task<IActionResult> UpdateApplication(LeaveApplicationDtoRequest request)
        {
            var employee = await _employeeServices.GetByObjectId(await _custom.GetUserObjectId(User), false);
            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            var result = await _leaveServices.UpdateApplication(request, await _custom.GetUserObjectId(User));
            return HrisOk(result);

        }

        [HrisAuthorize]
        [HttpDelete("application/{id}")]
        public async Task<IActionResult> RemoveApplication([FromRoute] Guid id)
        {
            var leave = await _leaveServices.GetApplicationById(id);
            if (leave == null)
                return HrisError(this.GetType().ToString(), "Leave Application does not exist.");

            return HrisOk(await _leaveServices.Remove(leave, await _custom.GetUserObjectId(User)));
        }

        [HrisAuthorize]
        [HttpGet("entitlements")]
        public async Task<IActionResult> GetEmployeeEntitlement([FromQuery] BaseFilter filter)
        {
            var employee = await _employeeServices.GetByObjectId(await _custom.GetUserObjectId(User), false);
            if (employee == null)
                return HrisError(this.GetType().ToString(), "Employee does not exist.");

            return Ok((await _leaveServices.GetEmployeeEntitlements(employee.Id)).ToLeaveEntitlementsList()
                .ToListResponse(filter.Page, filter.Limit, await _leaveServices.GetEmployeeEntitlementsCount(employee.Id)));
        }

        [HrisAuthorize]
        [HttpGet("entitlements/grant")]
        public async Task<IActionResult> GrantEmployeeEntitlements([FromQuery] Guid id)
        {
            var employee = await _employeeServices.GetById(id);
            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            return Ok(await _leaveServices.GrantEntitlements(id,
                await _leaveServices.GetBasicTypes(), await _custom.GetUserObjectId(User)));
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Lead, HrisRoles.Manager })]
        [HttpGet("entitlements/grant-all")]
        public async Task<IActionResult> AssignEntitlements()
        {
            var employees = await _employeeServices.GetByCondition(f => f.Active && f.EmployeeStatus == EmployeeStatus.FullTime);
            var result = await _leaveServices.GrantEntitlementsToAll(employees, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpGet("entitlements/{id}")]
        public async Task<IActionResult> GetEntitlementsByEmployeeId([FromRoute] Guid id, [FromQuery] BaseFilter filter)
        {
            var employee = await _employeeServices.GetById(id);
            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            return Ok((await _leaveServices.GetEmployeeEntitlements(employee.Id)).ToLeaveEntitlementsList()
                .ToListResponse(filter.Page, filter.Limit, await _leaveServices.GetEmployeeEntitlementsCount(employee.Id)));
        }

        [HrisAuthorize]
        [HttpGet("resource")]
        public async Task<IActionResult> GetResource()
            => HrisOk((await _leaveServices.GetTypesResource()).ToLeaveTypesList());

        [HrisAuthorize]
        [HttpGet("types/resource")]
        public async Task<IActionResult> GetLeaveTypeResource()
        => HrisOk((await _leaveServices.GetTypesResource()).ToLeaveTypesList());

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        [HttpGet("types")]
        public async Task<IActionResult> GetAllTypes([FromQuery] LeaveTypeFilter filter)
            => HrisOk((await _leaveServices.GetTypes(filter.Page, filter.Limit, filter.Search, filter.ClassList)).ToLeaveTypesList()
                .ToListResponse(filter.Page, filter.Limit, await _leaveServices.GetTypesCount()));

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        [HttpGet("types/{id}")]
        public async Task<IActionResult> GetTypeById([FromRoute] Guid id)
        {
            var leave = await _leaveServices.GetTypeById(id);
            if (leave == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Leave type not found.");

            return HrisOk(leave.ToLeaveTypeResponse());
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        [HttpPost("types")]
        public async Task<IActionResult> SaveType(LeaveTypeDtoRequest request)
        {
            if (request.Notification < 0)
                return HrisError(this.GetType().ToString(), "Notification days should be equal or above 0.");

            if (request.EntitledDays <= 0)
                return HrisError(this.GetType().ToString(), "Entitled days should be above 0.");

            if (await _leaveServices.CheckIfTypeExist(request.Name))
                return HrisError(this.GetType().ToString(), "Leave type already exist with this name.");

            var result = await _leaveServices.SaveLeaveType(request, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        [HttpPut("types")]
        public async Task<IActionResult> UpdateType(LeaveTypeDtoRequest request)
        {
            if (request.Notification < 0)
                return HrisError(this.GetType().ToString(), "Notification days should be equal or above 0.");

            if (request.EntitledDays <= 0)
                return HrisError(this.GetType().ToString(), "Entitled days should be above 0.");

            var type = await _leaveServices.GetTypeById(request.Id);

            if (type == null)
                return HrisError(this.GetType().ToString(), "Leave type does not exist.");

            var result = await _leaveServices.UpdateLeaveType(request, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        [HttpDelete("types/{id}")]
        public async Task<IActionResult> RemoveTypes([FromRoute] Guid id)
        {
            var leave = await _leaveServices.GetTypeById(id);
            if (leave == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Leave Type does not exist.");

            var result = await _leaveServices.RemoveLeaveType(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        [HttpGet("entitlement")]
        public async Task<IActionResult> GetAllEntitlements([FromQuery] LeaveEntitlementFilter filter)
            => HrisOk((await _leaveServices.GetEntitlements(filter.Page, filter.Limit, filter.Search, filter.EmployeeIds, filter.LeaveTypeIds, filter.Years))
                .ToLeaveEntitlementsList().ToListResponse(filter.Page, filter.Limit, await _leaveServices.GetEntitlementsCount()));

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        [HttpGet("entitlement/{id}")]
        public async Task<IActionResult> GetEntitlementById([FromRoute] Guid id)
        {
            var leave = await _leaveServices.GetEntitlementById(id);
            if (leave == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Leave Entitlement does not exist.");
            return HrisOk(leave.ToLeaveEntitlementResponse());
        }

        [HrisAuthorize]
        [HttpGet("entitlement/type")]
        public async Task<IActionResult> GetEntitlementByTypeId([FromQuery] Guid typeId)
        {
            var employee = await _employeeServices.GetByObjectId(await _custom.GetUserObjectId(User), false);
            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            var leave = await _leaveServices.GetEmployeeEntitlementByTypeId(employee.Id, typeId);
            if (leave == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Leave Entitlement does not exist.");

            return HrisOk(leave.ToLeaveEntitlementResponse());
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        [HttpPost("entitlement")]
        public async Task<IActionResult> SaveEntitlement(LeaveEntitlementDtoRequest request)
        {
            if (await _leaveServices.CheckIfEntitlementExist(request.EmployeeId, request.LeaveTypeId))
                return HrisError(this.GetType().ToString(), "Entitlement already exist.");

            var result = await _leaveServices.SaveEntitlement(request, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        [HttpPut("entitlement")]
        public async Task<IActionResult> UpdateEntitlement(LeaveEntitlementDtoRequest request)
        {
            var entitlement = await _leaveServices.GetEntitlementById(request.Id);
            if (entitlement == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Leave Entitlement does not exist.");

            if (!entitlement.LeaveTypeId.Equals(request.LeaveTypeId) && (await _leaveServices.CheckIfEntitlementExist(request.EmployeeId, request.LeaveTypeId)))
                return HrisError(this.GetType().ToString(), "Entitlement already exist with the same record.");

            entitlement.Balance = request.Credits - entitlement.Used;

            if (entitlement.Balance < 0)
                return HrisError(this.GetType().ToString(), "New credit is below on what is being used.");

            var result = await _leaveServices.UpdateEntitlement(request, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        [HttpGet("entitlement/resources")]

        public async Task<IActionResult> GetEntitlementResources()
        {
            return HrisOk(await _leaveServices.GetLeaveEntitlementResources());
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        [HttpDelete("entitlement/{id}")]
        public async Task<IActionResult> RemoveEntitlement([FromRoute] Guid id)
        {
            var leave = await _leaveServices.GetEntitlementById(id);

            if (leave == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Leave Entitlement does not exist.");

            var result = await _leaveServices.RemoveEntitlement(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

    }
}
