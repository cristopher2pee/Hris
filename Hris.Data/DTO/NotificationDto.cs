using Hris.Data.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    public class NotificationDtoRequest : BaseDtoRequest
    {
        public Guid? EmployeeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; } = false;
        public string RedirectToUrl { get; set; }
        public DateTime Expiration { get; set; }
        public string Meta { get; set; }
    }

    public class ManageNotificationRequest
    {
        public List<ManangeNotificationDto> Notifications { get; set; }
    }

    public class ManangeNotificationDto
    {
        public Guid Id { get; set; } 
        public bool IsRead { get; set; }
    }
    public class NotificationDtoResponse : BaseDtoResponse
    {
        public Guid? EmployeeId { get; set; }
        public EmployeeBasicInfoDtoResponse Employee { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public string RedirectToUrl { get; set; }
        public DateTime Expiration { get; set; }
        public string Meta { get; set; }
    }

    public static class NotificationExtension
    {
        public static NotificationDtoResponse ToNotificationResponse(this Notification e)
        {
            return new NotificationDtoResponse
            {
                Id = e.Id,
                EmployeeId = e.EmployeeId,
                Title = e.Title,
                Description = e.Description,
                IsRead = e.IsRead,
                RedirectToUrl = e.RedirectToUrl,
                Expiration = e.Expiration,
                Meta = e.Meta,
            };
        }

        public static IEnumerable<NotificationDtoResponse> ToNotificationResponseList(this IEnumerable<Notification> e)
        {
            return e.Select(e => e.ToNotificationResponse());
        }


    }
}
