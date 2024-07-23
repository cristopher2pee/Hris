using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Payroll
{
    public class PayrollRun : BaseEntity
    {

        public int Month { get; set; }
        public int Year { get; set; }
        public string PayrollCode { get; set; }
        public Guid PayrollConfigId { get; set; }
        public virtual PayrollConfig PayrollConfig { get; set; }
        public Guid? ApprovedById { get; set; }
        public virtual Data.Models.Employee.Employee ApprovedBy { get; set; }
        public PayrollRunStatusEnum PayrollRunStatus { get; set; }
        public string Notes { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }
}
