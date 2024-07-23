namespace Hris.Api.Models.Request.Clock
{
    public class RecordRequest
    {
        public DateTime Start { get; set; } = DateTime.UtcNow;
        public DateTime End { get; set; }

    }
}
