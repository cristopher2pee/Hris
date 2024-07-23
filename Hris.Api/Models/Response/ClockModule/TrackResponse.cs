using Hris.Api.Models.Response.ClockWork;
using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response.ClockModule
{
    public class TrackResponse : BaseResponse
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string? Notes { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeResponse? Employee { get; set; }
        public Guid? ProjectId { get; set; }
        public ProjectResponse? Project { get; set; }
        public Guid? TaskId { get; set; }
        public TaskResponse? Task { get; set; }
        public TrackStatus? Status { get; set; }
        public List<BreakResponse>? Breaks { get; set; }
        public bool? IsPending { get; set; }
        public ChangeStatus? ChangeStatus { get; set; }
        public Guid? ParentTrackId { get; set; }
        public TrackResponse? ParentTrack { get; set; }
        public IEnumerable<string>? Files { get; set; }
    }

    public class ManualTrackResponse {
        public TrackResponse Track { get; set; }
        public bool IsWithin24Hours { get; set; }
    }
}
