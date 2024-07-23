using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Request.Employee
{
    public class AllowanceTypeRequest : BaseRequest
    {
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public PayrollPeriod Period { get; set; }
        public bool IsDefault { get; set; }
    }
}
