namespace Hris.Api.Models.Request.Employee
{
    public class SalaryHistoryRequest : BaseRequest
    {
        public decimal BasePay { get; set; }
        public DateTime EffectivityDate { get; set; }
    }
}
