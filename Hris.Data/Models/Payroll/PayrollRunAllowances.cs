using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Payroll
{
    public class PayrollRunAllowances : BaseEntity
    {
        public Guid PayrollRunId { get; set; }
        public virtual PayrollRun PayrollRun { get; set; }

        public Guid EmployeeId { get; set; }
        public virtual Data.Models.Employee.Employee Employee { get; set; }

        public Guid AllowanceTypeId { get; set; }
        public virtual AllowanceType AllowanceType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public PayrollPeriod PayrollPeriod { get; set; }
    }
}
