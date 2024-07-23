using Hris.Data.Models.Enum;

namespace Hris.Data.Models.Clock
{
    public class Track : BaseEntity
    {
        public virtual Hris.Data.Models.Employee.Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string? Notes { get; set; }
        public string Timezone { get; set; }
        public Guid? ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public Guid? TaskId { get; set; }
        public virtual ProjectTask? Task { get; set; }
        public TrackType Type { get; set; }
        public TrackStatus Status { get; set; }
        public TrackTag Tag { get; set; }
        public bool IsLocked { get; set; }
        public bool? IsPending { get; set; }
        public ChangeStatus? ChangeStatus { get; set; }
        public virtual Hris.Data.Models.Clock.Track? ParentTrack { get; set; }
        public Guid? ParentTrackId { get; set; }
        public virtual Hris.Data.Models.Employee.Employee? Approver { get; set; }
        public Guid? ApproverId { get; set; }
        public string? Files { get; set; }
    }
}
 