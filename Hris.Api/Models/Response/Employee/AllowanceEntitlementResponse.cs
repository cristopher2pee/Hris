using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response.Employee
{
    public class AllowanceEntitlementResponse : BaseResponse
    {
        public Guid EmployeeId { get; set; }
        public Guid AllowanceTypeId { get; set; }
        public AllowanceTypeResponse? AllowanceType { get; set; }
        public decimal Amount { get; set; }
        public PayrollPeriod Period { get; set; }
        public DateTime EffectivityDate { get; set; }
    }
}
