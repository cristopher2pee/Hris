namespace Hris.Api.Models.Response
{
    public class SalaryHistoryResponse : BaseResponse
    {
        public decimal BasePay { get; set; }
        public DateTime EffectivityDate { get; set; }
    }
}
