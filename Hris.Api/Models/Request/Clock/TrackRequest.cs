using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Request.Clock
{
    public class TrackRequest : BaseRequest
    {
        public DateTime Start { get; set; } = DateTime.UtcNow;
        public DateTime? End { get; set; }
        public string? Notes { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? TaskId { get; set; }
        public TrackStatus? Status { get; set; }
        public TrackTag Tag { get; set; } = TrackTag.Office;
    }

    public class TrackDateTimeChangeRequest
    {
        public TrackRequest Track { get; set; }
        public string NewDate { get; set; }
    }

    public class TrackTimeChangeRequest
    {
        public TrackRequest Track { get; set; }
        public bool IsStart { get; set; }
        public TimeRequest NewTime { get; set; }
    }

    public class TimeRequest 
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public string Ampm { get; set; }
    }

    public class TrackProjectChangeRequest
    {
        public TrackRequest Track { get; set; }
        public Guid ProjectId { get; set; }
        public Guid? TaskId { get; set; }
    }
}
