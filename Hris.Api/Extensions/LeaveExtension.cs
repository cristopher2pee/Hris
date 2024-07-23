
using Hris.Api.Models.LeaveResponse;
using Hris.Business.Extensions;
using Hris.Data.Models.Leave;

namespace Hris.Api.Extensions
{
    public static class LeaveExtension
    {
        public static LeaveTypeResponse ToLeaveTypeResponse(this LeaveType d)
            => new LeaveTypeResponse
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Notification = d.Notification,
                EntitledDays = d.EntitledDays,
                Class = (int)d.Class,
                IsPaid = d.IsPaid
            };

        public static IEnumerable<LeaveTypeResponse> ToLeaveTypesList(this IEnumerable<LeaveType> list)
            => list.Select(d => d.ToLeaveTypeResponse());

        public static LeaveEntitlementResponse ToLeaveEntitlementResponse(this LeaveEntitlement d)
            => new LeaveEntitlementResponse
            {
                Id = d.Id,
                EmployeeId = d.EmployeeId,
                Employee = d.Employee != null ? d.Employee.ToEmployeeNameResponse() : null,
                LeaveTypeId = d.LeaveTypeId,
                LeaveType = d.LeaveType != null ? d.LeaveType.ToLeaveTypeResponse() : null,
                Credits = d.Credits,
                Used = d.Used,
                Balance = d.Balance,
                Year = d.Year
            };

        public static IEnumerable<LeaveEntitlementResponse> ToLeaveEntitlementsList(this IEnumerable<LeaveEntitlement> list)
            => list.Select(d => d.ToLeaveEntitlementResponse());

        public static LeaveApplicationResponse ToLeaveApplicationResponse(this LeaveApplication d, string timezone)
            => new LeaveApplicationResponse
            {
                Id = d.Id,
                LeaveTypeId = d.LeaveTypeId,
                LeaveType = d.LeaveType != null ? d.LeaveType.ToLeaveTypeResponse() : null,
                From = d.From.ConvertToTimezone(timezone),
                To = d.To.ConvertToTimezone(timezone),
                ReviewedBy = d.ApprovedByManager != null ? d.ApprovedByManager.ToEmployeeNameResponse() : d.ApprovedByLead != null ? d.ApprovedByLead.ToEmployeeNameResponse() : null,
                Days = d.Days,
                Reason = d.Reason,
                DateApplied = d.DateApplied.ConvertToTimezone(timezone),
                DateUpdated = d.Modified.ConvertToTimezone(timezone),
                Status = d.Status,
                EmployeeId = d.EmployeeId,
                Employee = d.Employee != null ? d.Employee.ToEmployeeNameResponse() : null,
                Remarks = d.Remarks,
                Document = d.Document,
                DocumentUri = d.DocumentUri
            };

        public static IEnumerable<LeaveApplicationResponse> ToLeaveApplicationList(this IEnumerable<LeaveApplication> list, string timezone)
            => list.Select(d => d.ToLeaveApplicationResponse(timezone));
    }
}
