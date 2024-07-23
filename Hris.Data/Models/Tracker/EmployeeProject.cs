using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hris.Data.Models.Employee;

namespace Hris.Data.Models.Tracker
{
    public class EmployeeProject : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee.Employee Employee{get;set;}

        public Guid TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
