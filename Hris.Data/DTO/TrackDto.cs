using Hris.Data.Extension;
using Hris.Data.Models.Clock;
using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class TrackDto
    {
    }

    public class ChangeDtoRequest
    {
        public Guid TrackChangeId { get; set; }
        public bool IsApproved { get; set; }
    }
    public class TrackDtoRequest : BaseDtoRequest
    {
        public DateTime Start { get; set; } = DateTime.UtcNow;
        public string StartStr { get; set; }
        public DateTime? End { get; set; }
        public string EndStr { get; set; }
        public string? Notes { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? TaskId { get; set; }
        public TrackStatus? Status { get; set; }
        public List<BreakDtoRequest>? Breaks { get; set; }
        public TrackTag Tag { get; set; }
    }

    public class TrackTimeChangeDtoRequest
    {
        public TrackDtoRequest Track { get; set; }
        public bool IsStart { get; set; }
        public TimeDtoRequest NewTime { get; set; }
    }

    public class TimeDtoRequest
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public string Ampm { get; set; }
    }

    public class BreakDtoRequest : BaseDtoRequest
    {
        public DateTime Start { get; set; } = DateTime.UtcNow;
        public DateTime? End { get; set; }
        public BreakStatus? Status { get; set; }
    }

    public class TrackDtoResponse : BaseDtoResponse
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string? Notes { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeDtoResponse? Employee { get; set; }
        public Guid? ProjectId { get; set; }
        public ProjectDtoResponse? Project { get; set; }
        public Guid? TaskId { get; set; }
        public TaskDtoResponse? Task { get; set; }
        public TrackStatus? Status { get; set; }
        public List<BreakDtoResponse>? Breaks { get; set; }
        public bool? IsPending { get; set; }
        public ChangeStatus? ChangeStatus { get; set; }
        public Guid? ParentTrackId { get; set; }
        public TrackDtoResponse? ParentTrack { get; set; }
        public IEnumerable<string>? Files { get; set; }
        public TrackTag Tag { get; set; }
    }

    public class BreakDtoResponse : BaseDtoResponse
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public BreakStatus? Status { get; set; }
    }

    public class ManualTrackDtoResponse
    {
        public TrackDtoResponse Track { get; set; }
        public bool IsWithin24Hours { get; set; }
    }

    public class TrackProjecDtotChangeRequest
    {
        public TrackDtoRequest Track { get; set; }
        public Guid ProjectId { get; set; }
        public Guid? TaskId { get; set; }
    }

    public class TrackDateTimeChangeDtoRequest
    {
        public TrackDtoRequest Track { get; set; }
        public DateTime NewDate { get; set; }
    }

    public static class TrackExtension_
    {
        public static TrackDtoResponse ToTrackDtoResponse(this Track d)
        {
            return new TrackDtoResponse
            {
                Id = d.Id,
                Start = d.Start.ConvertToTimezone_(d.Timezone),
                End = d.End != null ? d.End.Value.ConvertToTimezone_(d.Timezone) : null,
                Status = d.Status,
                EmployeeId = d.EmployeeId,
                Employee = d.Employee != null ? d.Employee.ToInitialEmployeeResponse_() : null,
                Notes = d.Notes,
                ProjectId = d.ProjectId,
                Project = d.Project != null ? d.Project.ToProjectDtoResponse() : null,
                TaskId = d.TaskId,
                Task = d.Task != null ? d.Task.ToTaskDtoResponse() : null,
                IsPending = d.IsPending,
                Tag = d.Tag,
                ChangeStatus = d.ChangeStatus,
                ParentTrackId = d.ParentTrackId,
                ParentTrack = d.ParentTrack != null ? d.ParentTrack.ToTrackDtoResponse() : null,
            };
        }

        public static IEnumerable<TrackDtoResponse> ToTrackDtoResponseList(this IEnumerable<Track> d)
            => d.Select(d => d.ToTrackDtoResponse());

        public class TrackImportDtoRequest
        {
            public int Id { get; set; }
            public DateTime TimeIn { get; set; }
            public DateTime TimeOut { get; set; }
            public string EmployeeId { get; set; }
        }

        public class TrackImportDtoResponse
        {
            public int Id { get; set; }
            public DateTime TimeIn { get; set; }
            public DateTime TimeOut { get; set; }
            public string EmployeeId { get; set; }
        }

        public static TrackImportDtoResponse ToTrackImportDtoRequestToResponse(this TrackImportDtoRequest d)
        {
            return new TrackImportDtoResponse
            {
                Id = d.Id,
                TimeIn = d.TimeIn,
                TimeOut = d.TimeOut,
                EmployeeId = d.EmployeeId,
            };
        }

    }
}
