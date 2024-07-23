using Hris.Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class LeaveEntitlementDto
    {
    }

    public class LeaveEntitlementDtoRequest : BaseDtoRequest
    {
        public Guid EmployeeId { get; set; }
        public int Year { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int Credits { get; set; }
    }

    public class LeaveEntitlementDtoResponse : BaseDtoResponse
    {
        public int  Year { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeNameDtoResponse? Employee { get; set; }
        public Guid LeaveTypeId { get; set; } 
        public LeaveTypeDtoResponse LeaveType { get; set; }

        public int Credits { get; set; }
        public int Used { get; set; }

        public int Balance { get; set; }
    }

    public static class LeaveEntitlementExtension_
    {
        public static LeaveEntitlementDtoResponse ToLeaveEntitlementDtoResponse(this LeaveEntitlement e)
        {
            return new LeaveEntitlementDtoResponse
            {
                Id = e.Id,
                EmployeeId = e.EmployeeId,
                Employee = e.Employee != null ? e.Employee.ToEmployeeNameResponse_() : null,
                LeaveTypeId = e.LeaveTypeId,
                LeaveType = e.LeaveType != null ?  e.LeaveType.ToLeaveTypeDtoResponse() : null,
                Credits = e.Credits,
                Used = e.Used,
                Balance = e.Balance,
            };
        }

        public static IEnumerable<LeaveEntitlementDtoResponse> ToLeaveEntitlementDtoResponseList(this IEnumerable<LeaveEntitlement> entities)
            => entities.Select(ToLeaveEntitlementDtoResponse).ToList();
    }

}
