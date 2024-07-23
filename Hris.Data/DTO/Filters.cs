using Hris.Data.Models;
using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class Filters
    {
    }

    public class BaseFilter_
    {
        [Range(1, int.MaxValue, ErrorMessage = "Current Page must be a positive number larger or equal to 1")]
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 50;
        public string Search { get; set; } = string.Empty;
    }

    public class PayrollRunFiler : BaseFilter_
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
    }
    
    public class NotificationFilter_ : BaseFilter_
    {
        public bool? isRead { get; set; }
    }

    public class PayrollConfigDetailsFilter : BaseFilter_
    {
        public Guid? PayrollConfigId { get; set; }
    }

    public class EmployeeLoansFilter_ : BaseFilter_
    {
        public List<Guid>? LoanTypesIds { get; set; }
    }


    public class EmployeeEntitlementsFilter_ : BaseFilter_
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

    }

    public class AccessFilter_ : BaseFilter_
    {
        public string? Name { get; set; }
        public string? Module { get; set; }
        public string? Role { get; set; }
    }

    public class CalendarFilter_ : BaseFilter_
    {
        public IEnumerable<int>? Years { get; set; }
    }

    public class PermissionFilter_ : BaseFilter_
    {
        public string? Module { get; set; }
        public string? Role { get; set; }
    }

    public class AllowanceTypeFilter_ : BaseFilter_
    {
        public PayrollPeriod? Period { get; set; }
    }

    public class DepartmentFilter_ : BaseFilter_
    {
        public Guid? Department { get; set; }
        public Guid? Team { get; set; }
    }

    public class PositionFilter_ : BaseFilter_
    {
        public PositionLevel? Level { get; set; }
    }

    public class ProjectFilter_ : BaseFilter_
    {
        public Guid? ClientId { get; set; }
    }
    public class ChangeRequestFilter_ : BaseFilter_
    {
        public ChangeStatus ChangeStatus { get; set; } = Data.Models.Enum.ChangeStatus.Pending;
    }

    public class LeaveRequestFilter_ : BaseFilter_
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

    public class LeaveApplicationFilter_ : BaseFilter_
    {
        public IEnumerable<Guid>? LeaveTypeIds { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public IEnumerable<int>? Statuses { get; set; }
    }

    public class ReportDataFilter : BaseFilter_
    {
        public int Index { get; set; }
        public int Size { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Guid>? EmployeeIds { get; set; }
        public Guid? ClientId { get; set; }
        public List<Guid>? ClientIds { get; set; }
        public Guid? ProjectId { get; set; }
        public List<Guid>? ProjectIds { get; set; }
        public Guid? TaskId { get; set; }
        public List<Guid>? TaskIds { get; set; }
    }

    public class TeamMemberFilters : BaseFilter_
    {
        public Guid? DepartmentId { get; set; }
        public Guid? TeamId { get; set; }
    }

    public class DeductionTypeFilters : BaseFilter_
    {

    }

    public class EmployeesDeductionFilters : BaseFilter_
    {
        public List<Guid> DeductionTypesIds { get; set; }       
            
    }

    public class NotificationFiltes : BaseFilter_
    {
        public Guid? EmployeeId { get; set; }
        public bool? isRead { get; set; }
    }
}

