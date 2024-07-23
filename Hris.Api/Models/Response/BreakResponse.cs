using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response
{
    public class BreakResponse : BaseResponse
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public BreakStatus? Status { get; set; }
    }
}
