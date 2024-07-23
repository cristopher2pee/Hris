using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Hub;
using Hris.Api.Middleware;
using Hris.Api.Models.Response;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service;
using Hris.Business.Service.Common;
using Hris.Business.Service.EmployeeModule;
using Hris.Business.Service.Leave;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Business.Service.v1.LeaveModule;
using Hris.Data.DTO;
using Hris.Data.Models.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.LeaveModule
{
    public class LeaveApplicationController : BaseApiController<LeaveApplicationController>
    {
        private readonly IEmployeesService _employeeService;
        private readonly ILeaveApplicationServices _leaveApplicationService;
        private readonly IUserSettingsServices _userSettingsServices;
        private readonly ILeaveServices _leaveServices;
        private readonly StorageCloudService _storageCloudService;
        private readonly INotificationHelper _NotifHelper;
        private readonly ICustomClaimPrincipal _custom;
        private readonly ILeaveEntitlementServices _leaveEntitlementServices;

        public LeaveApplicationController(IEmployeesService employeesService,
                ILeaveApplicationServices leaveApplicationServices,
                ILeaveServices leaveServices,
                StorageCloudService storageCloudService,
                IUserSettingsServices userSettingsServices,
                INotificationHelper notificationHelper,
                ICustomClaimPrincipal custom,
                ILeaveEntitlementServices leaveEntitlementServices,
                ILogger<LeaveApplicationController> logger) : base(logger)
        {
            _employeeService = employeesService;
            _leaveApplicationService = leaveApplicationServices;
            _userSettingsServices = userSettingsServices;
            _leaveServices = leaveServices;
            _storageCloudService = storageCloudService;
            _NotifHelper = notificationHelper;
            _custom = custom;
            _leaveEntitlementServices = leaveEntitlementServices;
        }

        [HttpGet("entitlement"), HrisAuthorize]
        public async Task<IActionResult> GetEntitlementByEmployeeId()
        {
            var emp = await _employeeService.GetByObjectId(await _custom.GetUserObjectId(User));
            if (emp is null) return HrisErrorNotFound("Leave Application", "Employee not found");
            var result = await _leaveApplicationService.GetEntitlementListByEmployeeId(emp.Id);
            return HrisOk(result);
        }

        [HttpGet("leave-application"), HrisAuthorize]
        public async Task<IActionResult> GetLeaveApplicationByEmployee([FromQuery] LeaveApplicationFilter_ filter)
        {
            var employee = await _employeeService.GetByObjectId(await _custom.GetUserObjectId(User), false);

            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            var settings = (await _userSettingsServices.GetByCondition(s => s.EmployeeId.Equals(employee.Id))).FirstOrDefault();

            if (settings == null)
                return HrisError(this.GetType().ToString(), "User settings not found.");

            var result = await _leaveApplicationService.GetLeaveApplicationByEmployee(filter, employee.Id);
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpPost("leave-application")]
        public async Task<IActionResult> SaveApplication(LeaveApplicationDtoRequest request)
        {
            var employee = await _employeeService.GetByObjectId(await _custom.GetUserObjectId(User), false);

            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            var entitlements = await _leaveEntitlementServices.GetLeaveEntitlement(f => f.EmployeeId.Equals(employee.Id)
                && f.LeaveTypeId.Equals(request.LeaveTypeId) && f.Year.Equals(DateTime.Now.Year));

            var remaining = entitlements.Credits - entitlements.Used;
            if (request.Days > remaining)
                return HrisError(Resource.Responses.Leave.INVALID_LEAVE_REQUEST, Resource.Responses.Leave.INVALID_LEAVE_REQUEST_MESSAGE);

            var result = await _leaveApplicationService.AddLeaveApplication(request, await _custom.GetUserObjectId(User));
            if (result is not null)
            {
                await _NotifHelper.ProcessNotificationList(result.ToList());
            }
            return HrisOk(result != null ? true : false);
        }

        [HrisAuthorize]
        [HttpGet("leave-application/days")]
        public async Task<IActionResult> ComputeDays([FromQuery] DateTime from, [FromQuery] DateTime to)
             => HrisOk(await _leaveApplicationService.ComputeDays(from, to));

        [HrisAuthorize]
        [HttpPut("leave-application")]
        public async Task<IActionResult> UpdateLeaveApplication(LeaveApplicationDtoRequest request)
        {
            var employee = await _employeeService.GetByObjectId(await _custom.GetUserObjectId(User), false);

            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            var result = await _leaveApplicationService.UpdateApplication(request, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpGet("leave-application/{id}")]
        public async Task<IActionResult> GetLeaveApplicationById([FromRoute] Guid id)
        {
            var employee = await _employeeService.GetByObjectId(await _custom.GetUserObjectId(User), false);

            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            var settings = (await _userSettingsServices.GetByCondition(s => s.EmployeeId.Equals(employee.Id))).FirstOrDefault();

            if (settings == null)
                return HrisErrorNotFound(this.GetType().ToString(), "User settings not found.");

            var data = await _leaveApplicationService.GetById(id);
            if (data == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Leave Application not found.");

            return HrisOk(data.ToLeaveApplicationDtoResponse(settings.Timezone));
        }

        [HrisAuthorize]
        [HttpGet("leave-application/withdraw")]
        public async Task<IActionResult> WithdrawLeaveApplication([FromQuery] Guid id)
        {
            var result = await _leaveApplicationService.LeaveWithdrawApplication(id, await _custom.GetUserObjectId(User));
            if (result != null) await _NotifHelper.ProcessNotificationList(result.ToList());
            return HrisOk(result != null ? true : false);
        }

        [HrisAuthorize]
        [HttpPut("leave-application/attachment")]

        public async Task<IActionResult> UpdateApplicationAttachment()
        {
            var form = Request.Form;
            var id = form["id"];

            if (string.IsNullOrEmpty(id))
                return HrisErrorNotFound(this.GetType().ToString(), "Leave Application Id is empty.");

            var appId = Guid.Parse(id);

            var leave = await _leaveServices.GetApplicationById(appId);

            if (leave == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Leave Application not found.");

            if (!form.Files.Any())
                return HrisErrorNotFound(this.GetType().ToString(), "No Files Attached.");

            var file = form!.Files!.FirstOrDefault()!;
            await _storageCloudService.UploadAttachment(4, file, leave.Id);
            leave.Document = file.FileName;
            leave.DocumentUri = await _storageCloudService.GetAttachmentUri(4, leave.Id);

            return HrisOk(await _leaveServices.Update(leave, await _custom.GetUserObjectId(User)));
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Lead, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpGet("leave-request")]
        public async Task<IActionResult> GetRequests([FromQuery] LeaveRequestFilter_ filter)
        {

            var employee = await _employeeService.GetDetailsById(3, await _custom.GetUserObjectId(User), true);

            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Employee does not exist.");

            if (employee.Position == null || (employee.Position.Level != PositionLevel.TeamLead && employee.Position.Level != PositionLevel.Manager))
                return HrisErrorNotFound(this.GetType().ToString(), "Only Managers & Leads can access.");

            var result = await _leaveServices.GetRequest(filter, employee);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Leave }, new string[] { HrisRoles.Admin, HrisRoles.Lead, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpGet("leave-application/team-member")]
        public async Task<IActionResult> GetEmployeeLeaveApplication([FromQuery] Guid employeeId, [FromQuery] Guid leaveTypeId)
        {
            var settings = await _userSettingsServices.GetByEmployeeId(employeeId);
            var result = await _leaveApplicationService.GetLeaveApplication(f => f.EmployeeId.Equals(employeeId) && f.LeaveTypeId.Equals(leaveTypeId), settings.Timezone!);
            return HrisOk(result);
        }
    }
}
