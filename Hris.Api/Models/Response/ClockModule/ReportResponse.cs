using Hris.Api.Extensions.Common;
using Hris.Api.Models.Response.ClockWork;

namespace Hris.Api.Models.Response.ClockModule
{

    public class ReportResponse
    {
        public EmployeeNameResponse Employee { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string? Notes { get; set; }
        public ProjectResponse? Project { get; set; }
        public TaskResponse? Task { get; set; }
        public string TotalDurationTimeFormat { get; set; }
        public string Attachments { get; set; }

        // Extended
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public decimal TotalDuration { get; set; }
        public string TotalDurationFormatted { get; set; }
    }

    public class GenerateReportResponse
    {
        public IEnumerable<ReportResponse> Reports { get; set; }
        public decimal TotalDecimal { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public string TotalDurationFormatted { get => TotalDuration.ToFullString(); }
        public int TotalHours { get => (int)Math.Ceiling(TotalDuration.TotalHours); }
        public int TotalMinutes { get => TotalDuration.Minutes; }
        public int TotalSeconds { get => TotalDuration.Seconds; }
    }
}
