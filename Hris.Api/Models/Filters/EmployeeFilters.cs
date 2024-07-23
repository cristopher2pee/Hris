using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Filters
{
    public class EmployeeFilters : BaseFilter
    {
        public Guid? DepartmentId { get; set; }
        public Guid? TeamId { get; set; }
        public Guid? PositionId { get; set; }
        public EmployeeStatus? Status { get; set; }
    }

    public class TeamMemberFilter : BaseFilter
    {
        public Guid EmployeeId { get; set; }
    }
}
