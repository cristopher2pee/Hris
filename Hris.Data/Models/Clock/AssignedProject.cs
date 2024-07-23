using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hris.Data.Models.Employee;

namespace Hris.Data.Models.Clock
{
    public class AssignedProject : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TaskId { get; set; }
        public virtual Employee.Employee Employee { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectTask Task { get; set; }
    }
}
