using Hris.Business.Extensions;
using Hris.Business.Models;
using Hris.Data.Models.Enum;
using Hris.Data.Repository;
using Hris.Business.Extensions;
using Microsoft.EntityFrameworkCore;
using Track = Hris.Data.Models.Clock.Track;
using Hris.Business.Service.Clock;
using Hris.Business.Service.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph.Models;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.ClockModule
{
    public class TrackService
    {
        private readonly IRepository<Track> repository;

        public TrackService(IRepository<Track> repository)
        {
            this.repository = repository;
        }

        public async Task<Track?> GetById(Guid id)
            => await (await repository.GetDbSet())
                .Where(d => d.Id.Equals(id))
                .FirstOrDefaultAsync();

        public async Task<Track?> GetCurrent(Guid objId)
            => await (await repository.GetDbSet())
                .AsNoTracking()
                .Include(d => d.Employee)
                .Where(d => d.Employee.ObjectId.Equals(objId) && d.End == null)
                .FirstOrDefaultAsync();

        public async Task<Track?> Start(Guid userId, Guid id, string tz, string notes, Guid? projectId, Guid? taskId)
            => await Add(new Track
            {
                Start = DateTime.UtcNow,
                Type = TrackType.Clock,
                Status = TrackStatus.Start,
                ProjectId = projectId,
                TaskId = taskId,
                Notes = notes,
                EmployeeId = id,
                Timezone = tz
            }, userId);

        public async Task<Track?> Stop(Track d, Guid userId)
        {
            d.End = DateTime.UtcNow;
            d.Status = TrackStatus.Stop;
            return await Update(d, userId);
        }

        public async Task<Track> Add(Track d, Guid userId)
        {
            try
            {
                d = await repository.Add(d);
                await SaveChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Track> Update(Track d, Guid userId)
        {
            try
            {
                d = await repository.Update(d);
                await SaveChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Track?> PathNotes(Guid id, string notes, Guid userId)
        {
            try
            {
                var d = await GetById(id);

                if (d == null)
                    throw new NullReferenceException();

                d.Notes = notes;

                return await Update(d, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Track?> PatchAttachment(Guid id, IFormFileCollection files, StorageCloudService service, Guid userId)
        {
            try
            {
                var d = await GetById(id);

                if (d == null)
                    throw new NullReferenceException();

                await service.UploadTaskFiles(files, id);
                d.Files = await service.GetTaskFilesUri(id);
                return await Update(d, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Track?> PatchDate(Guid id, DateTime date, Guid userId)
        {
            try
            {
                var d = await GetById(id);

                if (d == null)
                    throw new NullReferenceException();

                date = date.ToUniversalTime();

                d.Start = new DateTime(date.Year, date.Month, date.Day, d.Start.Hour, d.Start.Minute, d.Start.Second);
                d.End = new DateTime(date.Year, date.Month, date.Day, d.End.Value.Hour, d.End.Value.Minute, d.End.Value.Second);

                return await Update(d, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Track?> PatchTime(Guid id, bool isStart, DateTime date, Guid userId)
        {
            try
            {
                var d = await GetById(id);

                if (d == null)
                    throw new NullReferenceException();

                if(isStart)
                    d.Start = date.ToUniversalTime();
                else
                    d.End = date.ToUniversalTime();

                return await Update(d, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrackRecord?> GetList(Guid id, DateTime date, int limit = 4)
        {
            var recent = (await repository.GetDbSet())
                    .AsNoTracking()
                    .Where(t => t.EmployeeId.Equals(id) && t.Status == TrackStatus.Stop && t.ParentTrackId == null && t.Start <= date.AddDays(1).AddSeconds(-1))
                    .OrderByDescending(t => t.Start)
                    .FirstOrDefault();
            if (recent == null)
                return null;

            var response = new TrackRecord();

            for (int x = 1; x <= limit; x++)
            {
                var startOfWeek = recent.Start.AddDays(-(int)recent.Start.DayOfWeek).Date;
                var endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);

                var result = await GetWeekRecord(id, startOfWeek, endOfWeek);

                if (result != null && result.DayTracks.Any())
                    response.WeekTracks.Add(result);

                recent = (await repository.GetDbSet())
                    .AsNoTracking()
                    .Where(t => t.EmployeeId.Equals(id) && t.Status == TrackStatus.Stop && t.ParentTrackId == null && t.Start < startOfWeek)
                    .OrderByDescending(t => t.Start)
                    .FirstOrDefault();

                if (recent == null)
                {
                    response.HasMore = false;
                    response.Next = null;
                    break;
                }
                else
                {
                    response.HasMore = true;
                    response.Next = recent.Start;
                }
            }

            return response;
        }

        private async Task<WeekTrack?> GetWeekRecord(Guid employeeId, DateTime start, DateTime end)
        {
            TimeSpan weekTotal = new TimeSpan();
            var result = (await repository.GetDbSet())
                .AsNoTracking()
                .Include(t => t.Approver)
                .AsEnumerable()
                .Where(t => (t.Type == TrackType.Clock && t.Status == TrackStatus.Stop && t.EmployeeId == employeeId && t.ParentTrackId == null && t.Start >= start && t.Start <= end)
                    || (t.Type == TrackType.Manual && (t.ChangeStatus == ChangeStatus.Approved || t.ChangeStatus == ChangeStatus.Pending) && t.Status == TrackStatus.Stop && t.EmployeeId == employeeId && t.ParentTrackId == null && t.Start >= start && t.Start <= end))
                .GroupBy(t => t.Start.ConvertToTimezone(t.Timezone).Day)
                .Select(t => {
                    TimeSpan dayTotal = new TimeSpan();
                    foreach (var r in t.ToList())
                    {
                        if (r.Type == TrackType.Manual && r.IsPending == true)
                            continue;
                        var total = r.End.Value - r.Start;
                        dayTotal = dayTotal.Add(total);
                    }
                    var y = dayTotal.ToTrackFormat();
                    weekTotal = weekTotal.Add(dayTotal);
                    var firstRecord = t.First();
                    var currentDay = new DateTime(firstRecord.Start.ConvertToTimezone(firstRecord.Timezone).Year,
                        firstRecord.Start.ConvertToTimezone(firstRecord.Timezone).Month,
                        firstRecord.Start.ConvertToTimezone(firstRecord.Timezone).Day);

                    return new DayTrack
                    {
                        Current = currentDay,
                        DayTotal = dayTotal.ToTrackFormat(),
                        Tracks = t.Select(r => {
                            var total = (r.End.Value.ToUnix() - r.Start.ToUnix());
                            return new Business.Models.Track
                            {
                                Id = r.Id,
                                Notes = r.Notes,
                                ProjectId = r.ProjectId,
                                TaskId = r.TaskId,
                                Start = r.Start.ConvertToTimezone(r.Timezone),
                                End = r.End.Value.ConvertToTimezone(r.Timezone),
                                Total = TimeSpan.FromSeconds(total).ToTrackFormat(),
                                IsLocked = false,
                                IsPending = r.IsPending,
                                Type = r.Type,
                                ChangeStatus = r.ChangeStatus,
                                Approver = r.Approver != null ? r.Approver : null,
                                Files = r.Files != null ? r.Files.Split(',') : null
                            };
                        })
                        .OrderByDescending(t => t.Start)
                        .ToList()
                    };
                })
                .OrderByDescending(r => r.Current)
                .ToList();

            if (result == null)
                return null;

            return new WeekTrack
            {
                WeekStart = start,
                WeekEnd = end,
                WeekTotal = weekTotal.ToTrackFormat(),
                DayTracks = result
            };
        }

        public async Task<Track?> Delete(Guid id, Guid userId)
        {
            try
            {
                var d = await GetById(id);

                if (d == null)
                    throw new NullReferenceException();

                // Check change request
                var c = (await repository.GetDbSet()).Where(t => t.ParentTrackId.Equals(d.Id)).FirstOrDefault();
                if (c != null)
                    await repository.Delete(c);

                await repository.Delete(d);
                await SaveChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Track?> Duplicate(Guid id, Guid userId)
        {
            try
            {
                var d = await GetById(id);

                if (d == null)
                    throw new NullReferenceException();

                var now = DateTime.UtcNow;
                return await Add(new Track
                {
                    Start = new DateTime(now.Year, now.Month, now.Day, d.Start.Hour, d.Start.Minute, d.Start.Second, DateTimeKind.Utc),
                    End = new DateTime(now.Year, now.Month, now.Day, d.End.Value.Hour, d.End.Value.Minute, d.End.Value.Second, DateTimeKind.Utc),
                    Type = d.Type,
                    Status = d.Status,
                    Notes = d.Notes,
                    ProjectId = d.ProjectId,
                    TaskId = d.TaskId,
                    EmployeeId = d.EmployeeId,
                    Timezone = d.Timezone
                }, userId); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveChangesAsync(Guid userId)
            => await repository.SaveChangesAsync(userId);
    }
}
