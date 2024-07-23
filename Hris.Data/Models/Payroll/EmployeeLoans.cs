using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Payroll
{
    public class EmployeeLoans : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public virtual Data.Models.Employee.Employee Employee { get; set; }

        public Guid LoanTypesId { get; set; }
        public virtual LoanTypes LoanTypes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LoanAmount { get; set; }
        public PayrollPeriod Period { get; set; }
        public int Months { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amortization { get; set; }

        public string Notes { get; set; }

        public LoanStatus Status { get; set; }
    }
}
