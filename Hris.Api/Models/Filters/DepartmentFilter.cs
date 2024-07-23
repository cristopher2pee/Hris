namespace Hris.Api.Models.Filters
{
    public class DepartmentFilter : BaseFilter
    {
        public Guid? Department { get; set; }
        public Guid? Team { get; set; }
    }
}
