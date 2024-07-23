using Hris.Business.Service.v1.EmployeeModule;
using Hris.Business.Service.v1.Notification;
using Hris.Data.DTO;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Graph.Models;

namespace Hris.Api.Hub
{
    public interface INotificationHelper
    {
        Task ProcessNotificationList(List<NotificationDtoResponse> res);
        Task SendAllNotification(NotificationDtoResponse res);
        Task SendGroupUserNotification(NotificationDtoResponse res, Guid employeeId);
        Task SendTotalUserNotification(int total, string username);
        Task SendTotalGroupNotification(int total, Guid employeeId);

        Task PublishNotification(NotificationDtoResponse res);

    }
    public class NotificationHelper : INotificationHelper
    {
        private readonly IHubContext<NotificationHub, INotificationHub> _notificationHub;
        private readonly IEmployeesService _employeeServices;
        private readonly INotificationServices _notificationServices;


        public NotificationHelper(IHubContext<NotificationHub, INotificationHub> notificationHub,
            IEmployeesService employeesService,
            INotificationServices notificationServices
            )
        { 
            _notificationHub = notificationHub;
            _employeeServices = employeesService;
            _notificationServices = notificationServices;
        }
        public async Task ProcessNotificationList(List<NotificationDtoResponse> res)
        {
            foreach (var item in res)
            {
                if (item.EmployeeId is not null)
                    await _notificationHub.Clients.Group(item.EmployeeId.Value.ToString()).SendNotification(item);

                var notificationList = await _notificationServices.GetNotificationsListByEmployeeId(item.EmployeeId.Value);
                if (notificationList != null && notificationList.Any())
                {
                    await SendTotalGroupNotification(notificationList.Where(f=>!f.IsRead).Count(),item.EmployeeId.Value);
                }        

            }
        }

        public async Task SendAllNotification(NotificationDtoResponse res)
        {
            await _notificationHub.Clients.All.SendNotification(res);
        }

        public async Task SendGroupUserNotification(NotificationDtoResponse res, Guid employeeId)
        {
            await _notificationHub.Clients.Group(employeeId.ToString()).SendNotification(res);
        }

        public async Task PublishNotification(NotificationDtoResponse res)
        {
            await _notificationHub.Clients.All.PublishNotification(res);
        }

        public async Task SendTotalGroupNotification(int total, Guid employeeId)
        {
            await _notificationHub.Clients.Group(employeeId.ToString()).SendTotalNotification(total);
        }

        public async Task SendTotalUserNotification(int total, string username)
        {
            await _notificationHub.Clients.User(username).SendTotalNotification(total);
        }
    }
}
