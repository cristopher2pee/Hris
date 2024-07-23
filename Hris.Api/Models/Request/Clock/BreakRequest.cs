using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Request.Clock
{
    public class BreakRequest : BaseRequest
    {
        public DateTime Start { get; set; } = DateTime.UtcNow;
        public DateTime? End { get; set; }
        public BreakStatus? Status { get; set; }
    }
}
