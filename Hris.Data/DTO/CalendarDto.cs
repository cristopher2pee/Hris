using Hris.Data.Extension;
using Hris.Data.Models.Administrator;
using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class CalendarDto
    {
    }

    public class CalendarDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public HolidayType Type { get; set; }
    }

    public class CalendarDtoRequest : BaseDtoRequest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public HolidayType Type { get; set; }
    }

    public static class CalendarEventExtension_
    {
        public static CalendarDtoResponse ToCalendarResponse_(this Calendar access, string timezone)
            => new CalendarDtoResponse
            {
                Id = access.Id,
                Name = access.Name,
                Date = access.Date.ConvertToTimezone_(timezone),
                Description = access.Description,
                Type = access.Type
            };



        public static IEnumerable<CalendarDtoResponse> ToCalendarResponseList_(this IEnumerable<Calendar> list, string timezone)
            => list.Select(d => d.ToCalendarResponse_(timezone));
    }
}
