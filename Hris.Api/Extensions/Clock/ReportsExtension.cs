using Hris.Api.Extensions.Common;
using Hris.Api.Models.Response.ClockModule;
using Hris.Business.Extensions;
using Hris.Data.Models.Clock;
using Hris.Data.Models.Settings;

namespace Hris.Api.Extensions.Clock
{
    public static class ReportsExtension
    {
        public static GenerateReportResponse ToGenerateReportResponse(this IEnumerable<Track> tracks, UserSettings settings) 
        {
            var response = new GenerateReportResponse();

            response.Reports = tracks.Select(t =>
            {
                var start = t.Start.ConvertToTimezone(settings.Timezone);
                var end = t.End.Value.ConvertToTimezone(settings.Timezone);

                // Duration
                var total = TimeSpan.FromSeconds(t.End.Value.ToUnixTimestamp() - t.Start.ToUnixTimestamp());
                response.TotalDuration = response.TotalDuration.Add(total);

                // Decimal
                var totalDecimal = decimal.Round(Convert.ToDecimal(total.TotalMinutes / 60), 2);
                response.TotalDecimal += totalDecimal;

                return new ReportResponse
                {
                    StartDate = start.ToShortDateString(),
                    StartTime = start.TimeOfDay.ToFullString(),
                    EndDate = end.ToShortDateString(),
                    EndTime = end.TimeOfDay.ToFullString(),
                    Notes = t.Notes,
                    Start = start,
                    End = end,
                    Employee = t.Employee.ToEmployeeNameResponse(),
                    Project = t.Project != null ? t.Project.ToProjectResponse() : null,
                    Task = t.Task != null ? t.Task.ToTaskResponse() : null,
                    Attachments = t.Files,
                    TotalDuration = totalDecimal,
                    TotalDurationFormatted = string.Format("{0:0.00}", totalDecimal),
                    TotalDurationTimeFormat = total.ToFullString(),
                };
            });

            return response;
        }
    }
}
