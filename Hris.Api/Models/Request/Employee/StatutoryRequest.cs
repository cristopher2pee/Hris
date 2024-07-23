using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Request.Employee
{
    public class StatutoryRequest : BaseRequest
    {
        public StatutoryType StatutoryType { get; set; }
        public string StatutoryId { get; set; }
    }
}
