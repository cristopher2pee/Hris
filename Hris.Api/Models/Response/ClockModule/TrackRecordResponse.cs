using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response.ClockModule
{
    public class TrackRecordResponse
    {
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
        public string WeekTotal { get; set; }
        public IEnumerable<DayRecordResponse> DayRecords { get; set; }
    }

    public class DayRecordResponse
    {
        public DateTime Current { get; set; }
        public string DayTotal { get; set; }
        public IEnumerable<RecordResponse> Tracks { get; set; }
    }

    public class RecordResponse : BaseResponse
    {
        public string? Notes { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? TaskId { get; set; }
        public DateTime Start { get; set;}
        public DateTime? End { get; set; }
        public string Total { get; set; }
        public bool IsLocked { get; set; }
        public bool? IsPending { get; set; }
        public TrackType Type { get; set; }
        public ChangeStatus? ChangeStatus { get; set; }
        public EmployeeNameResponse? Approver { get; set; }
        public IEnumerable<string>? Files { get; set; }
    }

    public class RecordListResponse
    {
        public List<TrackRecordResponse> Data { get; set; }
        public bool HasMore { get; set; }
        public DateTime? Next { get; set; }

        public RecordListResponse()
        {
            Data = new List<TrackRecordResponse>();
        }
    }
}
