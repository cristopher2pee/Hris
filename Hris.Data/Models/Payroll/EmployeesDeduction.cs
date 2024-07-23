using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Payroll
{
    public class EmployeesDeduction : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }
        public Guid DeductionTypesId { get; set; }
        public virtual DeductionTypes DeductionTypes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public PayrollPeriod Period { get; set; }
    }
}
