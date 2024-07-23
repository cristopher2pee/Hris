using EntityFrameworkCore.EncryptColumn.Attribute;
using Hris.Api.Models.Response.ClockWork;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hris.Api.Models.Response.Payroll
{
    public class AllowanceTypeResponse : BaseResponse
    {
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public PayrollPeriod Period { get; set; }
        public bool IsDefault { get; set; }
    }

    public class AllowanceEntitlementResponse : BaseResponse
    {
        public Guid EmployeeId { get; set; }
        public Guid AllowanceTypeId { get; set; }
        public AllowanceTypeResponse AllowanceType { get; set; }
        public decimal Amount { get; set; }
        public PayrollPeriod Period { get; set; }
        public DateTime EffectivityDate { get; set; }
    }
}
