using Hris.Data.Models;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Models
{
    public class WeekTrack
    {
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
        public string WeekTotal { get; set; }
        public IEnumerable<DayTrack> DayTracks { get; set; }
    }

    public class DayTrack
    {
        public DateTime Current { get; set; }
        public string DayTotal { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }

    public class Track : BaseEntity
    {
        public string? Notes { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? TaskId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Total { get; set; }
        public bool IsLocked { get; set; }
        public bool? IsPending { get; set; }
        public TrackType Type { get; set; }
        public ChangeStatus? ChangeStatus { get; set; }
        public Employee Approver { get; set; }
        public IEnumerable<string>? Files { get; set; }
    }

    public class TrackRecord
    {
        public List<WeekTrack> WeekTracks { get; set; } = new List<WeekTrack>();
        public bool HasMore { get; set; }
        public DateTime? Next { get; set; }
    }
}
