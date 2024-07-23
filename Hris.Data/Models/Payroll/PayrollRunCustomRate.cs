using Hris.Data.Models.Clock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Payroll
{
    public class PayrollRunCustomRate : BaseEntity
    {
        public Guid PayrollRunId { get; set; }
        public virtual PayrollRun PayrollRun { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Data.Models.Employee.Employee Employee { get; set; }
        public string Name { get; set; }
        public Guid? TaskId { get; set; }
        public virtual ProjectTask? Task { get; set; }
        public decimal Hours { get; set; }
        public decimal Rate { get; set; }
        public decimal Pay { get; set; }

    }
}
