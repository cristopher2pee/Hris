using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Hub;
using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.Mail;
using Hris.Business.Service.v1;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Business.Service.v1.Notification;
using Hris.Data.DTO;
using Hris.Data.Models.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Identity.Web;

namespace Hris.Api.Controllers.v1.Notification
{
    public class NotificationController : BaseApiController<NotificationController>
    {
        private readonly INotificationServices _notificationServices;
        private readonly IHubContext<NotificationHub, INotificationHub> _notificationHub;
        private readonly IEmployeesService _employeesService;
        private readonly INotificationHelper _helper;
        private readonly IMailkitServices _mailService;
        private readonly ICustomClaimPrincipal _custom;
        public NotificationController(INotificationServices notificationServices,
            IHubContext<NotificationHub, INotificationHub> notificationHub,
            IEmployeesService employeesService,
            INotificationHelper notifhelper,
            IMailkitServices mailServices,
            ICustomClaimPrincipal custom,
                        ILogger<NotificationController> logger) : base(logger)
        {
            _notificationServices = notificationServices;
            _notificationHub = notificationHub;
            _employeesService = employeesService;
            _helper = notifhelper;
            _mailService = mailServices;
            _custom = custom;
        }

        [HrisAuthorize]
        [HttpGet("list-page")]
        public async Task<IActionResult> GetNotificationListPagedByObjectId([FromQuery] NotificationFilter_ filter)
        {
            var result = await _notificationServices.GetNotificationListPagedByObjectId(await _custom.GetUserObjectId(User), filter);
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpGet("initialize")]
        public async Task<IActionResult> InitializeNotification()
        {
            var result = await _notificationServices.GetNotificationListByObjectId(await _custom.GetUserObjectId(User));
            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User));
            if (employee != null)
            {
                await _helper.SendTotalUserNotification(result.Count(), User.GetNameIdentifierId());
            }
            return HrisOk(new { Message = "Successfully Notify Users" });
        }

        [HrisAuthorize]
        [HttpGet("payroll-run-notify")]
        public async Task<IActionResult> PayrollRunNotify([FromQuery] Guid employeeId, [FromQuery] PayrollRunTypeNotification Type)
        {
            var result = await _notificationServices.NotifyPayrollRun(employeeId, await _custom.GetUserObjectId(User), Type);
            if (result.Value.notificationList.Count > 0)
                await _helper.ProcessNotificationList(result.Value.notificationList);
            if (result.Value.mailList.Count > 0)
                await _mailService.SendUserListEmail(result.Value.mailList);

            return HrisOk(new { Message = "Successfully Notify Users" });
        }

        [HrisAuthorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById([FromRoute] Guid id)
        {
            var result = await _notificationServices.GetNotificationById(id);
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpPost("publish-post")]
        public async Task<IActionResult> PublishPost([FromBody] NotificationDtoRequest req)
        {
            req.EmployeeId = null;
            var result = await _notificationServices.AddNotification(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Publishing Post");

            await _mailService.SendAllEmail(
                subject: result.Title
                , message: result.Description
                , images: req.Meta,
                redirectUrl: result.RedirectToUrl);

            await _helper.PublishNotification(result);
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpPut("manage-notifications")]
        public async Task<IActionResult> ManageNotifications([FromBody] ManageNotificationRequest req)
        {
            var result = await _notificationServices.ManageNotification(req, await _custom.GetUserObjectId(User));
            return HrisOk(new { Success = result });
        }

        [HrisAuthorize]
        [HttpPut]
        public async Task<IActionResult> UpdateNotification([FromBody] NotificationDtoRequest req)
        {
            var result = await _notificationServices.UpdateNotification(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Notification");
            return HrisOk(result);
        }
    }
}
