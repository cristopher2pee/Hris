using Hris.Data.Extension;
using Hris.Data.Models.Clock;
using Hris.Data.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class ReportDto
    {
    }

    public class ReportDtoRequest
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

    public class ReportDtoResponse
    {
        public EmployeeNameDtoResponse Employee { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string? Notes { get; set; }
        public ProjectDtoResponse? Project { get; set; }
        public TaskDtoResponse? Task { get; set; }

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

    public class GenerateReportDtoResponse
    {
        public IEnumerable<ReportDtoResponse> Reports { get; set; }
        public decimal TotalDecimal { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public string TotalDurationFormatted { get => TotalDuration.ToFullString_(); }
        public int TotalHours { get => (int)Math.Ceiling(TotalDuration.TotalHours); }
        public int TotalMinutes { get => TotalDuration.Minutes; }
        public int TotalSeconds { get => TotalDuration.Seconds; }
    }

    public class DailyReportDtoRequest
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class EmployeePayslipInfo
    {
        public EmployeeBasicInfoDtoResponse Employee { get; set; }
        public SalaryHistoryDtoResponse EmployeeSalary { get; set; }
        public PayrollRunDtoResponse PayrollRun { get; set; }
        public List<PayrollRunAllowanceDtoResponse> EmployeePayrollRunAllowance { get; set; }
        public List<PayrollRunDeductionsDtoResponse> EmployeePayrollRunDeductions { get; set; }
        public List<PayrollRunLoansDtoResponse> EmployeePayrollRunLoans { get; set; }
        //public EmployeeStatutoriesDtoResponse EmployeeStatutories { get; set; }
        public PayrollRunTimeSheetsDtoResponse EmployeePayrollRunTimeSheets { get; set; }
        public PayrollRunTimeSheetsPayDtoResponse EmployeePayrollRunTimeSheetsPay { get; set; }
        public  PayrollRunPaySummaryDtoResponse EmployeePayrollRunPaySummary { get; set; }
        public List<LeaveEntitlementDtoResponse> EmployeeLeaveEntitlements { get; set; }
        public StatutoriesTableDto.Calculated_Statutories EmployeeStatutories { get; set; }
    }

    public static class ReportDtoExtension
    {
        public static GenerateReportDtoResponse ToGenerateReportResponse_(this IEnumerable<Track> tracks, UserSettings settings)
        {
            var response = new GenerateReportDtoResponse();

            response.Reports = tracks.Select(t =>
            {
                var start = t.Start.ConvertToTimezone_(settings.Timezone);
                var end = t.End.Value.ConvertToTimezone_(settings.Timezone);

                // Duration
                var total = TimeSpan.FromSeconds(t.End.Value.ToUnixTimestamp_() - t.Start.ToUnixTimestamp_());
                response.TotalDuration = response.TotalDuration.Add(total);

                // Decimal
                var totalDecimal = decimal.Round(Convert.ToDecimal(total.TotalMinutes / 60), 2);
                response.TotalDecimal += totalDecimal;

                return new ReportDtoResponse
                {
                    StartDate = start.ToShortDateString(),
                    StartTime = start.TimeOfDay.ToFullString_(),
                    EndDate = end.ToShortDateString(),
                    EndTime = end.TimeOfDay.ToFullString_(),
                    Notes = t.Notes,
                    Start = start,
                    End = end,
                    Employee = t.Employee.ToEmployeeNameResponse_(),
                    Project = t.Project != null ? t.Project.ToProjectDtoResponse() : null,
                    Task = t.Task != null ? t.Task.ToTaskDtoResponse() : null,
                    Attachments = t.Files,
                    TotalDuration = totalDecimal,
                    TotalDurationFormatted = string.Format("{0:0.00}", totalDecimal),
                    TotalDurationTimeFormat = total.ToFullString_(),
                };
            });

            return response;
        }
    }
}
