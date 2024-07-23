using Hris.Api.Models.Response;
using Hris.Data.Models.Enum;

namespace Hris.Api.Models.LeaveResponse
{
    public class LeaveTypeResponse: BaseResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Notification { get; set; }
        public int EntitledDays { get; set; }
        public int Class { get; set; }
        public bool IsPaid { get; set; }
    }

    public class LeaveEntitlementResponse: BaseResponse
    {
        public Guid EmployeeId { get; set; }
        public EmployeeNameResponse? Employee { get; set; }
        public Guid LeaveTypeId { get; set; }
        public LeaveTypeResponse? LeaveType { get; set; }
        public int Credits { get; set; }
        public int Used { get; set; }
        public int Balance { get; set; }
        public int Year { get; set; }
    }

    public class LeaveApplicationResponse : BaseResponse
    {
        public Guid LeaveTypeId { get; set; }
        public LeaveTypeResponse? LeaveType { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime DateApplied { get; set; }
        public int Days { get; set; }
        public EmployeeNameResponse? ReviewedBy  { get; set; }
        public DateTime DateUpdated { get; set; }
        public LeaveStatus Status { get; set; }
        public string Reason { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeNameResponse? Employee { get; set; }
        public DepartmentResponse? Department { get; set; }
        public TeamResponse? Team { get; set; }
        public string Remarks { get; set; }
        public string Document { get; set; }
        public string DocumentUri { get; set; }
    }

    public class LeaveReportResponse
    {
        public Guid EmployeeId { get; set; }
        public int TotalPaid { get; set; }
        public int CountPaid { get; set; }
        public int TotalNonPaid { get; set; }
        public int CountNonPaid { get; set; }
        public EmployeeResponse? Employee { get; set; }
        public IEnumerable<LeaveApplicationResponse>? Requests { get; set; }
    }
}
