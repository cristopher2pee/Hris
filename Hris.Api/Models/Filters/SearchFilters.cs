using Hris.Data.Models.Enum;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Identity.Client;

namespace Hris.Api.Models.Filters
{
    public class EmployeeSearchFilter : BaseFilter
    {
        public string Status { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
    }

    public class EmployeeManagerialFilter : BaseFilter
    {
        public PositionLevel Level { get; set; }
    }
    public class PositionFilter : BaseFilter
    {
        public PositionLevel? Level { get; set; }
    }

    public class AllowanceTypeFilter : BaseFilter
    {
        public PayrollPeriod? Period { get; set; }
    }
    public class EmployeeEntitlementsFilter : BaseFilter
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

    }
    public class AllowanceEntitlementFilter : BaseFilter
    {
        public string AllowanceType { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;

    }

    public class ProjectFilter : BaseFilter
    {
        public Guid? ClientId { get; set; }
    }
    public class TaskFilter : BaseFilter
    {
        public string? Name { get; set; }
    }

    public class PermissionFilter : BaseFilter
    {
        public string? Module { get; set; }
        public string? Role { get; set; }
    }

    public class AssignedProjectFilter : BaseFilter
    {
    }

    public class AccessFilter : BaseFilter
    {
        public string? Name { get; set; }
        public string? Module { get; set; }
        public string? Role { get; set; }
    }

    public class ChangeRequestFilter : BaseFilter
    {
        public ChangeStatus ChangeStatus { get; set; } = Data.Models.Enum.ChangeStatus.Pending;
    }
}
