using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Payroll
{
    public class PayrollConfig : BaseEntity
    {
        public string Name { get; set; }
        public PayrollPeriod Period { get; set; }
        public int FromDay { get; set; }
        public int ToDay { get; set; }
        public int PayOutDay { get; set; }
        public Guid? ThirteenMonthId { get; set; }
        public virtual Data.Models.Payroll.AllowanceType ThirteenMonth { get; set; }
        public Guid? LeaveConversionId { get; set; }
        public virtual Data.Models.Payroll.AllowanceType LeaveConversion { get; set; }
        public TaxPeriodType TaxTypePeriod { get; set; }
        public string TemplateUri { get; set; }
        public string Template { get; set; }
    }

    public class PayrollConfigDetails : BaseEntity
    {
        public Guid PayrollConfigId { get; set; }
        public virtual PayrollConfig PayrollConfig { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Data.Models.Employee.Employee Employee { get; set; }
    }
}
