using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hris.Data.Models.Leave
{
    public class LeaveEntitlement : BaseEntity
    {
        public int Year { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid LeaveTypeId { get; set; }
        public int Credits { get; set; }
        public int Used { get; set; }
        public int Balance { get; set; }
        public virtual Employee.Employee Employee { get; set; }
        public virtual LeaveType LeaveType { get; set; }
    }
}
