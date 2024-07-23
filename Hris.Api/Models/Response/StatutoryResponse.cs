using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response
{
    public class StatutoryResponse : BaseResponse
    {
        public StatutoryType StatutoryType { get; set; }
        public string StatutoryId { get; set; }
    }
}
