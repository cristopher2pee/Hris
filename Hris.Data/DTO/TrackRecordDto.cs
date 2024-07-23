using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class TrackRecordDto
    {
    }

    public class TrackRecordDtoResponse
    {
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
        public string WeekTotal { get; set; }
        public IEnumerable<DayRecordDtoResponse> DayRecords { get; set; }
    }

    public class DayRecordDtoResponse
    {
        public DateTime Current { get; set; }
        public string DayTotal { get; set; }
        public IEnumerable<RecordDtoResponse> Tracks { get; set; }
    }

    public class RecordDtoResponse : BaseDtoResponse
    {
        public string? Notes { get; set; }
        public Guid? ProjectId { get; set; }
        public ProjectDtoResponse? Project { get; set; }
        public Guid? TaskId { get; set; }
        public TaskDtoResponse? Task { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Total { get; set; }
        public bool IsLocked { get; set; }
        public bool? IsPending { get; set; }
        public TrackType Type { get; set; }
        public ChangeStatus? ChangeStatus { get; set; }
        public EmployeeNameDtoResponse? Approver { get; set; }
        public IEnumerable<string>? Files { get; set; }
        public TrackTag Tag { get; set; }
    }

    public class RecordListDtoResponse
    {
        public List<TrackRecordDtoResponse> Data { get; set; }
        public bool HasMore { get; set; }
        public DateTime? Next { get; set; }

        public RecordListDtoResponse()
        {
            Data = new List<TrackRecordDtoResponse>();
        }
    }
}
