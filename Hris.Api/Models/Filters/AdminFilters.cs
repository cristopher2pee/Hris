namespace Hris.Api.Models.Filters
{
    public class CalendarFilter : BaseFilter
    {
        public IEnumerable<int>? Years { get; set; }
    }
}
