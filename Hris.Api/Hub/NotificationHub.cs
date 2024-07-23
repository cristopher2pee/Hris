using Hris.Api.Middleware;
using Hris.Data.DTO;
using Microsoft.AspNetCore.SignalR;

namespace Hris.Api.Hub
{
    //[HrisAuthorize]
    public class NotificationHub : Hub<INotificationHub>
    {
        public Task SubscribeToUser(string userId)
        {
            return this.Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }
    }

    public interface INotificationHub
    {
        public Task SendNotification(NotificationDtoResponse notification);
        public Task ListOfNotifications(List<NotificationDtoResponse> listNotifications);
        public Task SendTotalNotification(int Total);
        public Task PublishNotification(NotificationDtoResponse notification);
    }
}
 