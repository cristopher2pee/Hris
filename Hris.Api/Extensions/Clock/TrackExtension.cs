using Hris.Api.Models.Request.Clock;
using Hris.Api.Models.Response.ClockModule;
using Hris.Api.Models.Response.ClockWork;
using Hris.Business.Extensions;
using Hris.Data.Models.Clock;

namespace Hris.Api.Extensions.Clock
{
    public static class TrackExtension
    {
        public static TrackResponse ToRequestResponse(this Track d)
            => new TrackResponse
            {
                Id = d.Id,
                Start = d.Start.ConvertToTimezone(d.Timezone),
                End = d.End != null ? d.End.Value.ConvertToTimezone(d.Timezone) : null,
                Status = d.Status,
                EmployeeId = d.EmployeeId,
                Employee = d.Employee != null ? d.Employee.ToInitialEmployeeResponse() : null,
                Notes = d.Notes,
                ProjectId = d.ProjectId,
                Project = d.Project != null ? d.Project.ToProjectResponse() : null,
                TaskId = d.TaskId,
                Task = d.Task != null ? d.Task.ToTaskResponse() : null,
                IsPending = d.IsPending,
                ChangeStatus = d.ChangeStatus,
                ParentTrackId = d.ParentTrackId,
                ParentTrack = d.ParentTrack != null ? d.ParentTrack.ToChangeRequestResponse() : null,
            };

        public static IEnumerable<TrackResponse> ToRequestList(this IEnumerable<Track> d)
            => d.Select(d => d.ToRequestResponse());


        // Old
        public static TrackResponse ToTrackResponse(this Track track)
            => new TrackResponse
            {
                Id = track.Id,
                Start = track.Start,
                End = track.End,
                Status = track.Status,
                EmployeeId = track.EmployeeId,
                Notes = track.Notes,
                ProjectId = track.ProjectId,
                TaskId = track.TaskId,
                IsPending = track.IsPending,
                ParentTrackId = track.ParentTrackId,
                Files = track.Files != null ? track.Files.Split(',') : null
            };

        public static TrackRequest ToTrackRequest(this IFormCollection form)
        {
            var response = new TrackRequest();


            return response;
        }

        public static TrackResponse ToChangeRequestResponse(this Track track)
            => new TrackResponse
            {
                Id = track.Id,
                Start = track.Start.ConvertToTimezone(track.Timezone),
                End = track.End != null ? track.End.Value.ConvertToTimezone(track.Timezone) : null,
                Status = track.Status,
                EmployeeId = track.EmployeeId,
                Employee = track.Employee != null ? track.Employee.ToInitialEmployeeResponse() : null,
                Notes = track.Notes,
                ProjectId = track.ProjectId,
                Project = track.Project != null ? track.Project.ToProjectResponse() : null,
                TaskId = track.TaskId,
                Task = track.Task != null ? track.Task.ToTaskResponse() : null,
                IsPending = track.IsPending,
                ChangeStatus = track.ChangeStatus,
                ParentTrackId = track.ParentTrackId,
                ParentTrack = track.ParentTrack != null ? track.ParentTrack.ToChangeRequestResponse() : null,
            };
    }
}
