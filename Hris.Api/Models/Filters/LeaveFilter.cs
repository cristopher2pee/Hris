using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Filters
{
    public class LeaveTypeFilter: BaseFilter
    {
        public string? Class { get; set; }
        public IEnumerable<int>? ClassList { get => Class?.Split(",").Select(d => int.Parse(d)); }
    }

    public class LeaveEntitlementFilter: BaseFilter 
    {
        public IEnumerable<Guid>? EmployeeIds { get; set; }
        public IEnumerable<Guid>? LeaveTypeIds { get; set; }
        public IEnumerable<int>? Years { get; set; }
    }
    public class LeaveApplicationFilter : BaseFilter
    {
        public IEnumerable<Guid>? LeaveTypeIds { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public IEnumerable<int>? Statuses { get; set; }
    }

    public class LeaveRequestFilter : BaseFilter
    {
        public bool IsAdmin { get; set; }
        public IEnumerable<Guid>? LeaveTypeIds { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public IEnumerable<int>? Statuses { get; set; }
        public IEnumerable<Guid>? EmployeeIds { get; set; }
        public IEnumerable<Guid>? DepartmentIds { get; set; }
        public IEnumerable<Guid>? TeamIds { get; set; }
    }
}
