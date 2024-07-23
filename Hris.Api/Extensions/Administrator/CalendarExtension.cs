using Hris.Api.Models.LeaveResponse;
using Hris.Api.Models.Response.Administrator;
using Hris.Business.Extensions;
using Hris.Data.Models.Administrator;
using Hris.Data.Models.Leave;

namespace Hris.Api.Extensions.Administrator
{
    public static class CalendarExtension
    {
        public static CalendarResponse ToCalendarResponse(this Calendar access, string timezone)
            => new CalendarResponse
            {
                Id = access.Id,
                Name = access.Name,
                Date = access.Date.ConvertToTimezone(timezone),
                Description = access.Description,
                Type = access.Type
            };

        public static IEnumerable<CalendarResponse> ToCalendarResponseList(this IEnumerable<Calendar> list, string timezone)
            => list.Select(d => d.ToCalendarResponse(timezone));
    }
}
