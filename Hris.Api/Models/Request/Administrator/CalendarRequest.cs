using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Request.Administrator
{
    public class CalendarRequest : BaseRequest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public HolidayType Type { get; set; }
    }
}
