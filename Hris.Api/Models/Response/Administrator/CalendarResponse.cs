using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response.Administrator
{
    public class CalendarResponse: BaseResponse
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public HolidayType Type { get; set; }
    }
}
