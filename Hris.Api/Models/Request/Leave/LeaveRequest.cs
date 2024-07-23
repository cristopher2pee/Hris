using Microsoft.Kiota.Abstractions;

namespace Hris.Api.Models.Request.Leave
{
    public class LeaveTypeRequest: BaseRequest
    {
        public string Name { get; set; }
        public int Class { get; set; }
        public string Description { get; set; }
        public int Notification { get; set; }
        public int EntitledDays { get; set; }
        public bool IsPaid { get; set; }
    }

    public class LeaveEntitlementRequest: BaseRequest
    {
        public Guid EmployeeId { get; set; }
        public int Year { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int Credits { get; set; }
    }

    public class LeaveApplicationRequest : BaseRequest
    {
        public Guid LeaveTypeId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Days { get; set; }
        public string Reason { get; set; }
        public string? Remarks { get; set; }
    }
}
