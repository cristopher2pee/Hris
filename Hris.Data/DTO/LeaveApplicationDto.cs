using Hris.Data.Extension;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class LeaveApplicationDto
    {
    }

    public class LeaveApplicationDtoResponse : BaseDtoResponse
    {
        public Guid LeaveTypeId { get; set; }
        public LeaveTypeDtoResponse? LeaveType { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime DateApplied { get; set; }
        public int Days { get; set; }
        public EmployeeNameDtoResponse? ReviewedBy { get; set; }
        public DateTime DateUpdated { get; set; }
        public LeaveStatus Status { get; set; }
        public string Reason { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeNameDtoResponse? Employee { get; set; }
        public DepartmentDtoResponse? Department { get; set; }
        public TeamDtoResponse? Team { get; set; }
        public string Remarks { get; set; }
        public string Document { get; set; }
        public string DocumentUri { get; set; }
    }

    public class LeaveTypeDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Notification { get; set; }
        public int EntitledDays { get; set; }
        public int Class { get; set; }
        public bool IsPaid { get; set; }
    }

    public class LeaveTypeDtoRequest : BaseDtoRequest
    {
        public string Name { get; set; }
        public int Class { get; set; }
        public string Description { get; set; }
        public int Notification { get; set; }
        public int EntitledDays { get; set; }
        public bool IsPaid { get; set; }
    }

    public class LeaveReportDtoResponse
    {
        public Guid EmployeeId { get; set; }
        public int TotalPaid { get; set; }
        public int CountPaid { get; set; }
        public int TotalNonPaid { get; set; }
        public int CountNonPaid { get; set; }
        public EmployeeDtoResponse? Employee { get; set; }
        public IEnumerable<LeaveApplicationDtoResponse>? Requests { get; set; }
    }

    public class LeaveApplicationDtoRequest : BaseDtoRequest
    {
        public Guid LeaveTypeId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Days { get; set; }
        public string Reason { get; set; }
        public string? Remarks { get; set; }
    }


    public static class LeaveApplicationExtension_
    {
        public static LeaveApplicationDtoResponse ToLeaveApplicationDtoResponse(this LeaveApplication d, string timezone = "China Standard Time")
        {
            return new LeaveApplicationDtoResponse
            {
                Id = d.Id,
                LeaveTypeId = d.LeaveTypeId,
                LeaveType = d.LeaveType != null ? d.LeaveType.ToLeaveTypeDtoResponse() : null,
                From = d.From.ConvertToTimezone_(timezone),
                To = d.To.ConvertToTimezone_(timezone),
                ReviewedBy = d.ApprovedByManager != null ? d.ApprovedByManager.ToEmployeeNameResponse_() : d.ApprovedByLead != null ? d.ApprovedByLead.ToEmployeeNameResponse_() : null,
                Days = d.Days,
                Reason = d.Reason,
                DateApplied = d.DateApplied.ConvertToTimezone_(timezone),
                DateUpdated = d.Modified.ConvertToTimezone_(timezone),
                Status = d.Status,
                EmployeeId = d.EmployeeId,
                Employee = d.Employee != null ? d.Employee.ToEmployeeNameResponse_() : null,
                Remarks = d.Remarks,
                Document = d.Document,
                DocumentUri = d.DocumentUri
            };
        }

        public static IEnumerable<LeaveApplicationDtoResponse> ToLeaveApplicatinResponseList(this IEnumerable<LeaveApplication> applications, string timezone)
        {
            return applications.Select(e=>e.ToLeaveApplicationDtoResponse(timezone)).ToList();
        }

        public static LeaveTypeDtoResponse ToLeaveTypeDtoResponse(this LeaveType d)
        {
            return new LeaveTypeDtoResponse
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Notification = d.Notification,
                EntitledDays = d.EntitledDays,
                Class = (int)d.Class,
                IsPaid = d.IsPaid
            };
        }

        public static IEnumerable<LeaveTypeDtoResponse> ToLeaveTypeDtoResponseList(this IEnumerable<LeaveType> list)
            => list.Select(d => d.ToLeaveTypeDtoResponse());
    }


}
