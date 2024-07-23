namespace Hris.Api.Models.Request.Clock
{
    public class ReportsRequest
    {
        public int Index { get; set; }
        public int Size { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Guid>? EmployeeIds { get; set; }
        public Guid? ClientId { get; set; }
        public List<Guid>? ClientIds { get; set; }
        public Guid? ProjectId { get; set; }
        public List<Guid>? ProjectIds { get; set; }
        public Guid? TaskId { get; set; }
        public List<Guid>? TaskIds { get; set; }
    }

    public class DailyReportRequest
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
