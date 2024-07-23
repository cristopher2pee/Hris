using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Leave
{
    public class LeaveApplication: BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee.Employee Employee { get; set; }
        public Guid LeaveTypeId { get; set; }
        public virtual LeaveType LeaveType { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime DateApplied { get; set; }
        public int Days { get; set; }
        public string Reason { get; set; }
        public string Document { get; set; }
        public string DocumentUri { get; set; }
        public Guid? ApprovedByLeadId { get; set; }
        public virtual Employee.Employee? ApprovedByLead { get; set; }
        public Guid? ApprovedByManagerId { get; set; }
        public virtual Employee.Employee? ApprovedByManager { get; set; }
        public string Remarks { get; set; }
        public LeaveStatus Status { get; set; }

    }
}
