using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Payroll
{
    public class PayrollRunPaySummary : BaseEntity
    {
        public Guid PayrollRunId { get; set; }
        public virtual PayrollRun PayrollRun { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Data.Models.Employee.Employee Employee { get; set; }
        public decimal Basic { get; set; }
        public decimal TimeSheetsPay { get; set; }
        public decimal TimeSheetDeduction { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deduction { get; set; }
        public decimal Loan { get; set; }
        public decimal ThirteenMonthPay { get; set; }
        public decimal LeaveConversion { get; set; }
        public decimal GrossPay { get; set; }
        public decimal SSSER { get; set; }
        public decimal SSSEE { get; set; }
        public decimal SSSEC { get; set; }
        public decimal PHICER {  get; set; }
        public decimal PHICEE { get; set; }
        public decimal HDMFER { get; set; }
        public decimal HDMFEE { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxWitheld { get; set; }
        public decimal NetPay { get; set; }
    }
}
