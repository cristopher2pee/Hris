using Azure.Core;
using Hris.Business.Extensions;
using Hris.Business.Models;
using Hris.Business.Models.Common;
using Hris.Business.Service.Clock;
using Hris.Business.Service.Mail;
using Hris.Business.Service.v1.AdministratorModule;
using Hris.Business.Service.v1.CommonModule;
using Hris.Business.Service.v1.LeaveModule;
using Hris.Business.Service.v1.Notification;
using Hris.Data.DTO;
using Hris.Data.Extension;
using Hris.Data.Models.Clock;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Leave;
using Hris.Data.UnitOfWork;
using Hris.Resource.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Graph.DeviceManagement.ImportedWindowsAutopilotDeviceIdentities.Import;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.Security;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Kiota.Abstractions;
using Microsoft.VisualBasic;
using QuestPDF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hris.Data.DTO.TrackExtension_;
using static QuestPDF.Helpers.Colors;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Track = Hris.Data.Models.Clock.Track;

namespace Hris.Business.Service.v1.ClockModule
{
    public interface ITrackServices
    {
        Task<PagedResult_<TrackDtoResponse>> GetAll(ChangeRequestFilter_ filter, Guid objId);
        Task<bool> RemovedTrackFromWithdrawCancelledLeaveApplication(LeaveApplication app, Guid userId);
        Task<Track?> Update(Track d, Guid userId);
        Task<Track> GetById(Guid id);
        Task<PagedResult_<ReportDtoResponse>> GetReports(ReportDtoRequest request, Guid u);

        Task<PagedResult_<ReportDtoResponse>> GetReportMeta(ReportDataFilter filter, Guid u);
        Task<Track> GetCurrent(Guid objId);
        Task<Track?> Stop(Track d, Guid userId);
        Task<(List<NotificationDtoResponse> notif, TrackDtoResponse result)> ManageRequest(Data.Models.Employee.Employee e, Track d, Track t, bool isApproved, Guid userId);
        Task<Track?> Start(Guid userId, Guid id, string tz, TrackDtoRequest request);
        Task<IEnumerable<Track>> GetReports(
            DateTime start,
            DateTime end,
            IEnumerable<Guid>? employeeIds,
            IEnumerable<Guid>? clientIds,
            IEnumerable<Guid>? projectIds,
        IEnumerable<Guid>? taskIds);

        Task<RecordListDtoResponse> GetListRecordResponse(DateTime date, Data.Models.Employee.Employee employee, int limit = 4);

        Task<TrackDtoResponse> AddTrack(TrackDtoRequest request, Guid userId);
        Task<TrackDtoResponse?> UpdateTrack(TrackDtoRequest request, Guid userId);
        Task<(List<NotificationDtoResponse> notifList, TrackDtoResponse res)> AddManualTrack(TrackDtoRequest request, Guid userId);

        Task<bool> HasCurrent(Guid objId);
        Task<TrackDtoResponse?> GetCurrentStatus(Guid objId);
        Task<bool> PatchTag(TrackDtoRequest request, Guid userId);

        Task<bool> PatchNote(TrackDtoRequest request, Guid userId);

        Task<bool> PatchProject(TrackProjecDtotChangeRequest request, Guid userId);

        Task<(List<NotificationDtoResponse> listNotifications, bool result)> PatchTrackDate(TrackDateTimeChangeDtoRequest request, Guid userId);

        Task<(List<NotificationDtoResponse> list, bool result)> PatchTrackTime(TrackTimeChangeDtoRequest request, Guid userId);

        Task<bool> Duplicate(Guid id, Guid userId);
        Task<bool> DeleteTrack(Guid id, Guid userid);

        Task<PagedResult_<TrackDtoResponse>> GetChangeRequests(ChangeRequestFilter_ filter);

        Task<bool> ManageChangeRequest(ChangeDtoRequest request, Guid id);
        Task<IEnumerable<TrackImportDtoResponse>> AddTestImport(IEnumerable<TrackImportDtoRequest> request, string timezone, Guid id);
        Task<bool> ManageTestImport(bool isConfirmed, Guid id);

        Task<bool> ManageTrackFromLeaveApplication(LeaveApplication data, Guid userId);

    }
    internal class TrackServices : ITrackServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationServices _notificationServices;
        private readonly IPermissionServices _permissionService;
        private readonly ICommonServices _commonService;
        private readonly IMailkitServices _mailService;
        public TrackServices(IUnitOfWork unitOfWork, INotificationServices notificationServices,
            IPermissionServices permissionServices,
            ICommonServices commonServices,
            IMailkitServices mailServices)
        {
            _unitOfWork = unitOfWork;
            _notificationServices = notificationServices;
            _permissionService = permissionServices;
            _commonService = commonServices;
            _mailService = mailServices;
        }

        public async Task<PagedResult_<TrackDtoResponse>> GetAll(ChangeRequestFilter_ filter, Guid objId)
        {
            var employeeIds = new List<Guid>();

            var employee = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Position)
                .Where(f => f.ObjectId.Equals(objId))
                .FirstOrDefaultAsync();

            if (employee is null) return null;

            var resultAdmin = await _permissionService.GetRoleByModule(employee.Id, Modules.Clock);
            var isAdmin = resultAdmin.Equals(Roles.Admin);

            if (employee.Position != null)
            {
                if (employee.Position.Level == PositionLevel.Manager)
                {
                    var assignDepartment = await _unitOfWork._Department.FindListByConditionAsync(f => f.ManagerId.Equals(employee.Id));
                    employeeIds = await this._commonService.GetEmployeeIdsByDepartment(assignDepartment.Select(f => f.Id).ToList());
                }
                else if (employee.Position.Level == PositionLevel.TeamLead)
                {
                    var assignTeam = await _unitOfWork._Team.FindListByConditionAsync(f => f.LeadId.Equals(employee.Id));
                    employeeIds = await this._commonService.GetEmployeeIdsByTeam(assignTeam.Select(e => e.Id).ToList());
                }
            }

            var tracks = await ProcessTrackByEmployeeIds(employeeIds, isAdmin);
            var data = tracks.AsEnumerable()
                     .Where(d => (!filter.Search.IsNullOrEmpty() && d.Employee != null ? d.Employee.Firstname.Has(filter.Search)
                                     || (d.Employee.Middlename != null && d.Employee.Middlename.Has(filter.Search))
                                     || d.Employee.Lastname.Has(filter.Search)
                                 : true)
                             && d.ParentTrackId != null
                             && (filter.ChangeStatus != null ? d.ChangeStatus.Equals(filter.ChangeStatus) : d.ChangeStatus == ChangeStatus.Pending));

            return data.ToTrackDtoResponseList().ToPagedList_(filter.Page, filter.Limit);

            //var data = _unitOfWork._Track.GetDbSet()
            //    .AsNoTracking()
            //    .Include(d => d.Project)
            //    .Include(d => d.Task)
            //    .Include(d => d.Employee)
            //    .Include(d => d.ParentTrack)
            //    .ThenInclude(d => d.Project)
            //    .AsEnumerable()

            //    .Where(d => (!filter.Search.IsNullOrEmpty() && d.Employee != null ? d.Employee.Firstname.Has(filter.Search)
            //                    || (d.Employee.Middlename != null && d.Employee.Middlename.Has(filter.Search))
            //                    || d.Employee.Lastname.Has(filter.Search)
            //                : true)
            //            && d.ParentTrackId != null
            //            && (filter.ChangeStatus != null ? d.ChangeStatus.Equals(filter.ChangeStatus) : d.ChangeStatus == ChangeStatus.Pending));

            //return data.ToTrackDtoResponseList().ToPagedList_(filter.Page, filter.Limit);
        }

        private async Task<IEnumerable<Track>> ProcessTrackByEmployeeIds(List<Guid> employeeIds, bool isAdmin = false)
        {
            if (isAdmin)
            {
                return await _unitOfWork._Track.GetDbSet()
                    .AsNoTracking()
                    .Include(d => d.Project)
                    .Include(d => d.Task)
                    .Include(d => d.Employee)
                    .Include(d => d.ParentTrack)
                    .ThenInclude(d => d.Project)
                    .ToListAsync();
            }
            else
            {
                return await _unitOfWork._Track.GetDbSet()
                    .AsNoTracking()
                    .Include(d => d.Project)
                    .Include(d => d.Task)
                    .Include(d => d.Employee)
                    .Include(d => d.ParentTrack)
                    .ThenInclude(d => d.Project)
                    .Where(f => employeeIds.Contains(f.EmployeeId))
                    .ToListAsync();
            }
        }

        public async Task<Track?> Update(Track d, Guid userId)
        {
            try
            {
                d = await _unitOfWork._Track.UpdateAsync(d);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? d : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task<Track?> Add(Track d, Guid userId)
        {
            try
            {
                d = await _unitOfWork._Track.AddAsync(d);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? d : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task<Track?> Delete(Track d, Guid userId)
        {
            try
            {
                d = await _unitOfWork._Track.DeleteAsync(d);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? d : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Track> GetById(Guid id)
        {
            return await _unitOfWork._Track.GetByIdAsync(id);
        }

        public async Task<PagedResult_<ReportDtoResponse>> GetReportMeta(ReportDataFilter request, Guid userId)
        {
            var employee = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(userId));
            var settings = await _unitOfWork._UserSettings.FindByConditionAsync(f => f.EmployeeId.Equals(employee.Id));

            var data = _unitOfWork._Track.GetDbSet()
                                 .Include(t => t.Employee)
                 .Include(t => t.Project)
                 .ThenInclude(p => p.Client)
                 .Include(t => t.Task)
                 .AsEnumerable()
                 .Where(t => t.Status == Data.Models.Enum.TrackStatus.Stop && (t.IsPending == null || t.IsPending == false) && t.ParentTrackId == null
                     && (t.Start.Date >= request.Start.ToUniversalTime().Date && t.End.Value.Date <= request.End.ToUniversalTime().Date)
                     && (request.EmployeeIds != null && request.EmployeeIds.Any() ? t.Employee != null ? request.EmployeeIds.Where(c => c.Equals(t.Employee.Id)).Any() : false : true)
                     && (request.ClientIds != null && request.ClientIds.Any() ? t.Project != null && t.Project.ClientId != Guid.Empty ? request.ClientIds.Where(c => c.Equals(t.Project.ClientId)).Any() : false : true)
                     && (request.ProjectIds != null && request.ProjectIds.Any() ? t.ProjectId != null ? request.ProjectIds.Where(g => g.Equals(t.ProjectId.Value)).Any() : false : true)
                     && (request.TaskIds != null && request.TaskIds.Any() ? t.TaskId != null ? request.TaskIds.Where(g => g.Equals(t.TaskId.Value)).Any() : false : true))
                 .OrderByDescending(t => t.Start)
             .Select(t =>
             {
                 var total = TimeSpan.FromSeconds(t.End.Value.ToUnixTimestamp_() - t.Start.ToUnixTimestamp_());
                 var start = t.Start.ConvertToTimezone_(settings.Timezone);
                 var end = t.End.Value.ConvertToTimezone_(settings.Timezone);
                 return new ReportDtoResponse
                 {
                     Notes = t.Notes,
                     Start = start,
                     End = end,
                     Employee = t.Employee.ToEmployeeNameResponse_(),
                     Project = t.Project != null ? t.Project.ToProjectDtoResponse() : null,
                     Task = t.Task != null ? t.Task.ToTaskDtoResponse() : null,
                     TotalDurationTimeFormat = total.ToFullString_(),
                 };
             })
                 .ToPagedList_(request.Page, request.Limit);

            return data;
        }

        public async Task<PagedResult_<ReportDtoResponse>> GetReports(ReportDtoRequest request, Guid userId)
        {
            var employee = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(userId));
            var settings = await _unitOfWork._UserSettings.FindByConditionAsync(f => f.EmployeeId.Equals(employee.Id));

            var data = _unitOfWork._Track.GetDbSet()
                                 .Include(t => t.Employee)
                 .Include(t => t.Project)
                 .ThenInclude(p => p.Client)
                 .Include(t => t.Task)
                 .AsEnumerable()
                 .Where(t => t.Status == Data.Models.Enum.TrackStatus.Stop && (t.IsPending == null || t.IsPending == false) && t.ParentTrackId == null
                     && (t.Start.Date >= request.Start.ToUniversalTime().Date && t.End.Value.Date <= request.End.ToUniversalTime().Date)
                     && (request.EmployeeIds != null && request.EmployeeIds.Any() ? t.Employee != null ? request.EmployeeIds.Where(c => c.Equals(t.Employee.Id)).Any() : false : true)
                     && (request.ClientIds != null && request.ClientIds.Any() ? t.Project != null && t.Project.ClientId != Guid.Empty ? request.ClientIds.Where(c => c.Equals(t.Project.ClientId)).Any() : false : true)
                     && (request.ProjectIds != null && request.ProjectIds.Any() ? t.ProjectId != null ? request.ProjectIds.Where(g => g.Equals(t.ProjectId.Value)).Any() : false : true)
                     && (request.TaskIds != null && request.TaskIds.Any() ? t.TaskId != null ? request.TaskIds.Where(g => g.Equals(t.TaskId.Value)).Any() : false : true))
                 .OrderByDescending(t => t.Start)
             .Select(t =>
             {
                 var total = TimeSpan.FromSeconds(t.End.Value.ToUnixTimestamp_() - t.Start.ToUnixTimestamp_());
                 var start = t.Start.ConvertToTimezone_(settings.Timezone);
                 var end = t.End.Value.ConvertToTimezone_(settings.Timezone);
                 return new ReportDtoResponse
                 {
                     Notes = t.Notes,
                     Start = start,
                     End = end,
                     Employee = t.Employee.ToEmployeeNameResponse_(),
                     Project = t.Project != null ? t.Project.ToProjectDtoResponse() : null,
                     Task = t.Task != null ? t.Task.ToTaskDtoResponse() : null,
                     TotalDurationTimeFormat = total.ToFullString_(),
                 };
             })
                 .ToPagedList_(request.Index, request.Size);

            return data;
        }

        public async Task<IEnumerable<Track>> GetReports(DateTime start, DateTime end, IEnumerable<Guid>? employeeIds, IEnumerable<Guid>? clientIds, IEnumerable<Guid>? projectIds, IEnumerable<Guid>? taskIds)
        {
            var result = _unitOfWork._Track.GetDbSet()
                 .AsNoTracking()
                .Include(t => t.Employee)
                .Include(t => t.Project)
                    .ThenInclude(p => p.Client)
                .Include(t => t.Task)
                .AsEnumerable()
                .Where(t => t.Status == Data.Models.Enum.TrackStatus.Stop && (t.IsPending == null || t.IsPending == false) && t.ParentTrackId == null
                    && t.Start.Date >= start.ToUniversalTime().Date && t.End.Value.Date <= end.ToUniversalTime().Date
                    && (employeeIds != null && employeeIds.Any() ? t.Employee != null ? employeeIds.Where(c => c.Equals(t.Employee.Id)).Any() : false : true)
                    && (clientIds != null && clientIds.Any() ? t.Project != null && t.Project.ClientId != Guid.Empty ? clientIds.Where(c => c.Equals(t.Project.ClientId)).Any() : false : true)
                    && (projectIds != null && projectIds.Any() ? t.ProjectId != null ? projectIds.Where(g => g.Equals(t.ProjectId.Value)).Any() : false : true)
                    && (taskIds != null && taskIds.Any() ? t.TaskId != null ? taskIds.Where(g => g.Equals(t.TaskId.Value)).Any() : false : true))
                .OrderByDescending(t => t.Start);

            if (result is null) return Enumerable.Empty<Track>();

            return result;
        }

        public async Task<(List<NotificationDtoResponse> notif, TrackDtoResponse result)> ManageRequest(Data.Models.Employee.Employee e, Track trackChange, Track track, bool isApproved, Guid userId)
        {
            track.IsPending = trackChange.IsPending = false;
            track.ApproverId = trackChange.ApproverId = e.Id;
            var list = new List<NotificationDtoResponse>();

            if (isApproved)
            {
                track.Type = TrackType.Clock;
                track.Start = trackChange.Start;
                track.End = trackChange.End;
                track.ProjectId = trackChange.ProjectId;
                track.TaskId = trackChange.TaskId;
                track.Tag = trackChange.Tag;
                trackChange.ChangeStatus = track.ChangeStatus = ChangeStatus.Approved;
            }
            else
            {
                track.ChangeStatus = trackChange.ChangeStatus = ChangeStatus.Declined;
                if (track.Type == TrackType.Manual)
                    track.IsPending = true;
            }

            await Update(track, userId);
            var data = await Update(trackChange, userId);

            if (data is not null)
            {
                var result = await _notificationServices.AddTrackNotification(data.ToTrackDtoResponse(), 1, userId);
                list = result.Value.notificationList.ToList();
                await _mailService.SendUserListEmail(result.Value.mailList);
            }

            return (list, trackChange.ToTrackDtoResponse());
        }

        public async Task<Track> GetCurrent(Guid objId)
        {
            var result = await _unitOfWork._Track.GetDbSet()
                 .AsNoTracking()
                 .Where(d => d.Employee.ObjectId.Equals(objId) && d.End == null)
                 .Include(d => d.Project)
                 .Include(d => d.Task)
                 .FirstOrDefaultAsync();

            return result;
        }

        public async Task<Track?> Stop(Track d, Guid userId)
        {
            d.End = DateTime.UtcNow;
            d.Status = TrackStatus.Stop;

            if(d.Tag == TrackTag.Overtime)
            {
                d.IsPending = true;
                d = await Update(d, userId);

                if (d is null)
                    throw new NullReferenceException();

                return await Add(ToPendingTrack(d), userId);
            }
            else
                return await Update(d, userId);
        }

        public async Task<Track?> Start(Guid userId, Guid id, string tz, TrackDtoRequest request)
        {
            var track = await Add(new Track
            {
                Start = DateTime.UtcNow,
                Type = TrackType.Clock,
                Status = TrackStatus.Start,
                ProjectId = request.ProjectId,
                TaskId = request.TaskId,
                Tag = request.Tag,
                Notes = request.Notes,
                EmployeeId = id,
                Timezone = tz
            }, userId);

            return await _unitOfWork._Track.GetDbSet()
                 .AsNoTracking()
                 .Where(d => d.Id.Equals(track.Id))
                 .Include(d => d.Project)
                 .Include(d => d.Task)
                 .FirstOrDefaultAsync(); ;
        }

        public async Task<RecordListDtoResponse> GetListRecordResponse(DateTime date, Data.Models.Employee.Employee employee, int limit = 4)
        {
            var response = new RecordListDtoResponse();

            var current = await _unitOfWork._Track.GetDbSet()
                .AsNoTracking()
                 .Where(t => t.EmployeeId == employee.Id && t.Status == TrackStatus.Stop
                    && t.ParentTrackId == null && t.Start <= date.AddDays(1).AddSeconds(-1))
                 .OrderByDescending(t => t.Start)
                 .FirstOrDefaultAsync();

            if (current != null)
            {
                for (int x = 1; x <= limit; x++)
                {
                    var startOfWeek = current.Start.AddDays(-(int)current.Start.DayOfWeek).Date;
                    var endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);

                    var result = await GetWeekRecord(employee.Id, startOfWeek, endOfWeek);

                    if (result != null && result.DayRecords.Any())
                        response.Data.Add(result);

                    current = await _unitOfWork._Track.GetDbSet()
                                    .AsNoTracking()
                                    .Where(t => t.EmployeeId == employee.Id && t.Status == TrackStatus.Stop && t.ParentTrackId == null && t.Start < startOfWeek)
                                    .OrderByDescending(t => t.Start)
                                    .FirstOrDefaultAsync();

                    if (current == null)
                    {
                        response.HasMore = false;
                        response.Next = null;
                        break;
                    }
                    else
                    {
                        response.HasMore = true;
                        response.Next = current.Start;
                    }
                }
            }

            return response;
        }

        private async Task<TrackRecordDtoResponse> GetWeekRecord(Guid employeeId, DateTime start, DateTime end)
        {
            TimeSpan weekTotal = new TimeSpan();
            var result = _unitOfWork._Track.GetDbSet()
                               .AsNoTracking()
                .Include(t => t.Approver)
                .Include(t => t.Project)
                .Include(t => t.Task)
                .AsEnumerable()
                .Where(t => (t.Type == TrackType.Clock && t.Status == TrackStatus.Stop && t.EmployeeId == employeeId && t.ParentTrackId == null && t.Start >= start && t.Start <= end)
                    || (t.Type == TrackType.Manual && (t.ChangeStatus == ChangeStatus.Approved || t.ChangeStatus == ChangeStatus.Pending) && t.Status == TrackStatus.Stop && t.EmployeeId == employeeId && t.ParentTrackId == null && t.Start >= start && t.Start <= end))
                .GroupBy(t => t.Start.ConvertToTimezone(t.Timezone).Day)
                .Select(t =>
                {
                    TimeSpan dayTotal = new TimeSpan();
                    foreach (var r in t.ToList())
                    {
                        if (r.Type == TrackType.Manual && r.IsPending == true)
                            continue;
                        var total = r.End.Value - r.Start;
                        dayTotal = dayTotal.Add(total);
                    }
                    var y = dayTotal.ToFullString_();
                    weekTotal = weekTotal.Add(dayTotal);
                    var firstRecord = t.First();
                    var currentDay = new DateTime(firstRecord.Start.ConvertToTimezone(firstRecord.Timezone).Year,
                        firstRecord.Start.ConvertToTimezone(firstRecord.Timezone).Month,
                        firstRecord.Start.ConvertToTimezone(firstRecord.Timezone).Day);

                    return new DayRecordDtoResponse
                    {
                        Current = currentDay,
                        DayTotal = dayTotal.ToFullString_(),
                        Tracks = t.Select(r =>
                        {
                            var total = (r.End.Value.ToUnixTimestamp_() - r.Start.ToUnixTimestamp_());
                            return new RecordDtoResponse
                            {
                                Id = r.Id,
                                Notes = r.Notes,
                                ProjectId = r.ProjectId,
                                Project = r.Project != null ? r.Project.ToProjectDtoResponse() : null,
                                TaskId = r.TaskId,
                                Task = r.Task != null ? r.Task.ToTaskDtoResponse() : null,
                                Start = r.Start.ConvertToTimezone(r.Timezone),
                                End = r.End.Value.ConvertToTimezone(r.Timezone),
                                Total = TimeSpan.FromSeconds(total).ToFullString_(),
                                IsLocked = r.IsLocked,
                                IsPending = r.IsPending,
                                Type = r.Type,
                                Tag = r.Tag,
                                ChangeStatus = r.ChangeStatus,
                                Approver = r.Approver != null ? r.Approver.ToEmployeeNameResponse_() : null,
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

            return new TrackRecordDtoResponse
            {
                WeekStart = start,
                WeekEnd = end,
                WeekTotal = weekTotal.ToFullString_(),
                DayRecords = result
            };
        }

        public async Task<TrackDtoResponse?> AddTrack(TrackDtoRequest track, Guid userId)
        {
            try
            {
                var employee = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(userId));
                var settings = await _unitOfWork._UserSettings.FindByConditionAsync(f => f.EmployeeId.Equals(employee.Id));

                var result = await _unitOfWork._Track.AddAsync(new Data.Models.Clock.Track
                {
                    Start = track.Start,
                    Type = TrackType.Clock,
                    Status = TrackStatus.Start,
                    ProjectId = track.ProjectId,
                    TaskId = track.TaskId,
                    Notes = track.Notes,
                    EmployeeId = employee.Id,
                    Timezone = settings.Timezone
                });

                if (result is null) return null;
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? result.ToTrackDtoResponse() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<(List<NotificationDtoResponse> notifList, TrackDtoResponse res)> AddManualTrack(TrackDtoRequest track, Guid userId)
        {
            try
            {
                var listOfNotification = new List<NotificationDtoResponse>();
                var employee = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(userId));
                var settings = await _unitOfWork._UserSettings.FindByConditionAsync(f => f.EmployeeId.Equals(employee.Id));

                var isPending = !this.IsWithin24hrs(track.Start) || track.Tag == TrackTag.Overtime;

                var combineStartDateTime = track.Start.Date.Add(DateTime.Parse(track.StartStr).TimeOfDay)
                    .GetUTCFromTimezone(settings.Timezone);
                var combineEndDateTime = track.End.Value.Date.Add(DateTime.Parse(track.EndStr).TimeOfDay)
                    .GetUTCFromTimezone(settings.Timezone);

                var newTrack = new Track
                {
                    Start = combineStartDateTime,
                    End = combineEndDateTime,
                    Type = isPending ? TrackType.Clock : TrackType.Manual,
                    Status = TrackStatus.Stop,
                    ProjectId = track.ProjectId,
                    TaskId = track.TaskId,
                    Notes = track.Notes,
                    EmployeeId = employee.Id,
                    Timezone = settings.Timezone,
                    Tag = track.Tag,
                    IsPending = isPending,
                    ChangeStatus = !isPending ? ChangeStatus.Approved : ChangeStatus.Pending
                };


                await Add(newTrack, userId);

                if (isPending)
                {
                    var data = await Add(ToPendingTrack(newTrack), userId);
                    var result = await _notificationServices.AddTrackNotification(data.ToTrackDtoResponse(), 1, userId);
                    if (result is not null)
                    {
                        listOfNotification = result.Value.notificationList.ToList();
                        await _mailService.SendUserListEmail(result.Value.mailList);
                    }
                       

                }
                return (listOfNotification, newTrack.ToTrackDtoResponse());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private Track ToPendingTrack(Track track)
            => new Track
            {
                Start = track.Start,
                End = track.End,
                ParentTrackId = track.Id,
                Type = track.Type,
                Status = track.Status,
                ProjectId = track.ProjectId,
                TaskId = track.TaskId,
                EmployeeId = track.EmployeeId,
                Tag = track.Tag,
                Timezone = track.Timezone,
                IsPending = true,
                ChangeStatus = ChangeStatus.Pending
            };

        private bool IsWithin24hrs(DateTime dt)
            => dt > DateTime.UtcNow.AddHours(-24);

        public async Task<bool> HasCurrent(Guid employeeId)
        {
            var employee = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(employeeId));
            var result = await _unitOfWork._Track.GetDbSet()
                .AnyAsync(f => f.EmployeeId.Equals(employee.Id) &&
                (f.Status == TrackStatus.Start || f.Status == TrackStatus.Pause || f.Status == TrackStatus.Resume));

            return result;
        }

        public async Task<TrackDtoResponse?> GetCurrentStatus(Guid objId)
        {
            var employee = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(objId));
            var result = await _unitOfWork._Track
                .FindByConditionAsync(t => t.EmployeeId == employee.Id && t.ParentTrackId == null
                && (t.Status == TrackStatus.Start || t.Status == TrackStatus.Pause || t.Status == TrackStatus.Resume));

            return result is not null ? result.ToTrackDtoResponse() : null;
        }

        public async Task<TrackDtoResponse?> UpdateTrack(TrackDtoRequest request, Guid userId)
        {
            try
            {
                var toUpdate = await _unitOfWork._Track.GetByIdAsync(request.Id);
                if (toUpdate is null) return null;

                toUpdate.Notes = request.Notes;
                toUpdate.ProjectId = request.ProjectId;
                toUpdate.TaskId = request.TaskId;
                toUpdate.Tag = request.Tag;

                var result = await Update(toUpdate, userId);
                if (result is null) return null;

                return result.ToTrackDtoResponse();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> PatchProject(TrackProjecDtotChangeRequest request, Guid userId)
        {
            try
            {
                var trackToUpdate = await GetById(request.Track.Id);
                if (trackToUpdate is null) return false;

                var trackChange = await _unitOfWork._Track.FindByConditionAsync(t => t.ParentTrackId.Equals(trackToUpdate.Id) && t.IsPending == true);
                var isWithin24Hours = IsWithin24hrs(trackToUpdate.Start);

                if (!isWithin24Hours)
                {
                    trackToUpdate.IsPending = true;
                    if (trackChange == null)
                        await Add(new Track
                        {
                            ProjectId = request.ProjectId,
                            TaskId = request.TaskId,
                            Start = trackToUpdate.Start,
                            End = trackToUpdate.End,
                            ParentTrackId = trackToUpdate.Id,
                            Type = trackToUpdate.Type,
                            Status = trackToUpdate.Status,
                            EmployeeId = trackToUpdate.EmployeeId,
                            Timezone = trackToUpdate.Timezone,
                            IsPending = true,
                            ChangeStatus = ChangeStatus.Pending,
                            ApproverId = null
                        }, userId);
                    else
                    {
                        trackChange.ProjectId = request.ProjectId;
                        trackChange.TaskId = request.TaskId;
                        trackChange.IsPending = true;
                        trackChange.ChangeStatus = ChangeStatus.Pending;
                        trackChange.ApproverId = null;
                        await Update(trackChange, userId);
                    }
                    trackToUpdate.IsPending = true;
                    trackToUpdate.ChangeStatus = ChangeStatus.Pending;
                }
                else
                {
                    trackToUpdate.ProjectId = request.ProjectId;
                    trackToUpdate.TaskId = request.TaskId;
                }

                trackToUpdate.ApproverId = null;
                await Update(trackToUpdate, userId);
                return isWithin24Hours;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<(List<NotificationDtoResponse> listNotifications, bool result)> PatchTrackDate(TrackDateTimeChangeDtoRequest request, Guid userId)
        {
            try
            {
                var list = new List<NotificationDtoResponse>();
                var trackToUpdate = await GetById(request.Track.Id);

                if (trackToUpdate == null)
                    return (list, false);

                var start = trackToUpdate.Start.ConvertToTimezone(trackToUpdate.Timezone);
                var end = trackToUpdate.End.Value.ConvertToTimezone(trackToUpdate.Timezone);

                var trackChange = await _unitOfWork._Track.FindByConditionAsync(t => t.ParentTrackId.Equals(trackToUpdate.Id) && t.IsPending == true);

                var updatedStartUtcDate = new DateTime(request.NewDate.Year, request.NewDate.Month, request.NewDate.Day,
                    trackChange == null ? start.ToUniversalTime().Hour : trackChange.Start.Hour,
                    trackChange == null ? start.ToUniversalTime().Minute : trackChange.Start.Minute,
                    trackChange == null ? start.ToUniversalTime().Second : trackChange.Start.Second);

                var updatedEndUtcDate = new DateTime(request.NewDate.Year, request.NewDate.Month, request.NewDate.Day,
                    trackChange == null ? end.ToUniversalTime().Hour : trackChange.End.Value.Hour,
                    trackChange == null ? end.ToUniversalTime().Minute : trackChange.End.Value.Minute,
                    trackChange == null ? end.ToUniversalTime().Second : trackChange.End.Value.Second);

                if (trackChange == null)
                    await Add(new Track
                    {
                        ProjectId = trackToUpdate.ProjectId,
                        TaskId = trackToUpdate.TaskId,
                        Start = updatedStartUtcDate,
                        End = updatedEndUtcDate,
                        ParentTrackId = trackToUpdate.Id,
                        Type = trackToUpdate.Type,
                        Status = trackToUpdate.Status,
                        EmployeeId = trackToUpdate.EmployeeId,
                        Timezone = trackToUpdate.Timezone,
                        IsPending = true,
                        ChangeStatus = ChangeStatus.Pending,
                        ApproverId = null
                    }, userId);
                else
                {
                    trackChange.Start = updatedStartUtcDate;
                    trackChange.End = updatedEndUtcDate;
                    trackChange.IsPending = true;
                    trackChange.ChangeStatus = ChangeStatus.Pending;
                    trackChange.ApproverId = null;
                    await Update(trackChange, userId);
                }

                trackToUpdate.IsPending = true;
                trackToUpdate.ChangeStatus = ChangeStatus.Pending;
                trackToUpdate.ApproverId = null;

                if (trackToUpdate.ChangeStatus == ChangeStatus.Pending)
                {
                    var result = await _notificationServices.AddTrackNotification(trackToUpdate.ToTrackDtoResponse(), 3, userId);
                    list = result.Value.notificationList.ToList();
                    await _mailService.SendUserListEmail(result.Value.mailList);
                }

                await Update(trackToUpdate, userId);
                return (list, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<(List<NotificationDtoResponse> list, bool result)> PatchTrackTime(TrackTimeChangeDtoRequest request, Guid userId)
        {
            try
            {
                var list = new List<NotificationDtoResponse>();
                var trackToUpdate = await GetById(request.Track.Id);

                if (trackToUpdate == null) return (list, false);


                var date = request.IsStart ? trackToUpdate.Start : trackToUpdate.End.Value;

                var newTime = new DateTime(date.Year, date.Month, date.Day,
                    (string.Equals(request.NewTime.Ampm, "PM") && request.NewTime.Hours < 12) ? request.NewTime.Hours + 12 : request.NewTime.Hours,
                        request.NewTime.Minutes, request.NewTime.Seconds).GetUTCFromTimezone(trackToUpdate.Timezone);

                var isWithin24Hours = this.IsWithin24hrs(trackToUpdate.Start);
                if (!isWithin24Hours)
                {
                    trackToUpdate.IsPending = true;
                    trackToUpdate.ChangeStatus = ChangeStatus.Pending;

                    var trackChange = await _unitOfWork._Track.FindByConditionAsync(t => t.ParentTrackId.Equals(trackToUpdate.Id) && t.IsPending == true);

                    if (trackChange == null)
                    {
                        trackChange = new Track
                        {
                            ParentTrackId = trackToUpdate.Id,
                            ProjectId = trackToUpdate.ProjectId,
                            TaskId = trackToUpdate.TaskId,
                            Start = request.IsStart ? newTime : trackToUpdate.Start,
                            End = !request.IsStart ? newTime : trackToUpdate.End,
                            Type = trackToUpdate.Type,
                            Status = trackToUpdate.Status,
                            EmployeeId = trackToUpdate.EmployeeId,
                            Timezone = trackToUpdate.Timezone,
                            IsPending = true,
                            ChangeStatus = ChangeStatus.Pending,
                        };
                        await Add(trackChange, userId);
                    }
                    else
                    {
                        if (request.IsStart)
                            trackChange.Start = newTime;
                        else
                            trackChange.End = newTime;
                        trackChange.IsPending = true;
                        trackChange.ChangeStatus = ChangeStatus.Pending;
                        trackChange.ApproverId = null;
                        await Update(trackChange, userId);
                    }

                    if (trackChange.ChangeStatus == ChangeStatus.Pending)
                    {
                        var result = await _notificationServices.AddTrackNotification(trackChange.ToTrackDtoResponse(), 2, userId);
                        list = result.Value.notificationList.ToList();
                        await _mailService.SendUserListEmail(result.Value.mailList);
                    }
                }
                else
                    if (request.IsStart)
                    trackToUpdate.Start = newTime;
                else
                    trackToUpdate.End = newTime;

                trackToUpdate.ApproverId = null;

                await Update(trackToUpdate, userId);
                return (list, isWithin24Hours);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Duplicate(Guid id, Guid userId)
        {
            try
            {
                var existingTrack = await GetById(id);
                if (existingTrack == null) return false;

                var now = DateTime.UtcNow;
                await Add(new Track
                {
                    Start = new DateTime(now.Year, now.Month, now.Day, existingTrack.Start.Hour,
                        existingTrack.Start.Minute, existingTrack.Start.Second, DateTimeKind.Utc),
                    End = new DateTime(now.Year, now.Month, now.Day, existingTrack.End.Value.Hour,
                        existingTrack.End.Value.Minute, existingTrack.End.Value.Second, DateTimeKind.Utc),
                    Type = existingTrack.Type,
                    Status = existingTrack.Status,
                    Notes = existingTrack.Notes,
                    ProjectId = existingTrack.ProjectId,
                    TaskId = existingTrack.TaskId,
                    EmployeeId = existingTrack.EmployeeId,
                    Timezone = existingTrack.Timezone
                }, userId);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeleteTrack(Guid id, Guid userid)
        {
            try
            {
                var trackToDelete = await GetById(id);
                if (trackToDelete is null) return false;

                var trackChange = await _unitOfWork._Track.FindByConditionAsync(f => f.ParentTrackId.Equals(trackToDelete.Id));
                if (trackChange is not null)
                    await Delete(trackChange, userid);

                await Delete(trackToDelete, userid);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResult_<TrackDtoResponse>> GetChangeRequests(ChangeRequestFilter_ filter)
        {
            var result = _unitOfWork._Track.GetDbSet()
                 .AsNoTracking()
                 .Include(t => t.Project)
                .Include(t => t.Task)
                .Include(t => t.Employee)
                .Include(t => t.ParentTrack)
                    .ThenInclude(pt => pt.Project)
                .AsEnumerable()
                .Where(t => (!string.IsNullOrEmpty(filter.Search) ? t.Employee.Firstname.Contains(filter.Search, StringComparison.OrdinalIgnoreCase)
                        || t.Employee.Lastname.Contains(filter.Search, StringComparison.OrdinalIgnoreCase)
                        || t.Employee.Middlename.Contains(filter.Search, StringComparison.OrdinalIgnoreCase) : true)
                    && t.ParentTrackId != null && (filter.ChangeStatus != 0 ? t.ChangeStatus == filter.ChangeStatus : t.ChangeStatus == ChangeStatus.Pending))
                .ToList();

            return result.ToTrackDtoResponseList().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<bool> ManageChangeRequest(ChangeDtoRequest request, Guid userId)
        {
            try
            {
                var employee = await _unitOfWork._Employees.FindByConditionAsync(f => f.Id.Equals(userId));
                if (employee is null) return false;

                var trackChange = await GetById(request.TrackChangeId);
                if (trackChange == null) return false;
                if (trackChange.ParentTrackId == null) return false;

                var trackToUpdate = await GetById(trackChange.ParentTrackId.Value);

                trackToUpdate.IsPending = trackChange.IsPending = false;
                trackToUpdate.ApproverId = trackChange.ApproverId = employee.Id;
                if (request.IsApproved)
                {
                    trackToUpdate.Type = TrackType.Clock;
                    trackToUpdate.Start = trackChange.Start;
                    trackToUpdate.End = trackChange.End;
                    trackToUpdate.ProjectId = trackChange.ProjectId;
                    trackToUpdate.TaskId = trackChange.TaskId;
                    trackToUpdate.Tag = trackChange.Tag;
                    trackChange.ChangeStatus = ChangeStatus.Approved;
                }
                else
                {
                    trackChange.ChangeStatus = ChangeStatus.Declined;
                    trackToUpdate.ChangeStatus = ChangeStatus.Declined;

                    if (trackToUpdate.Type == TrackType.Manual)
                    {
                        trackToUpdate.IsPending = true;
                    }
                }
                await Update(trackToUpdate, userId);
                await Update(trackChange, userId);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<bool> PatchTag(TrackDtoRequest request, Guid userId)
        {
            try
            {
                var trackToUpdate = await GetById(request.Id);

                if (trackToUpdate is null)
                    return false;

                if (request.Tag == TrackTag.Overtime)
                {
                    trackToUpdate.IsPending = true;
                    var trackChange = await _unitOfWork._Track.FindByConditionAsync(t => t.ParentTrackId.Equals(trackToUpdate.Id) && t.IsPending == true);
                    if (trackChange is null)
                    {
                        trackChange = ToPendingTrack(trackToUpdate);
                        trackChange.Tag = request.Tag;
                        await Add(trackChange, userId);
                    }
                    else
                    {
                        trackChange.Tag = request.Tag;
                        await Update(trackChange, userId);
                    }
                }
                else
                    trackToUpdate.Tag = request.Tag;

                await Update(trackToUpdate, userId);

                return true;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> PatchNote(TrackDtoRequest request, Guid userId)
        {
            try
            {
                var trackToUpdate = await GetById(request.Id);

                if (trackToUpdate == null)
                    return false;

                trackToUpdate.Notes = request.Notes;

                var trackChange = await _unitOfWork._Track.FindByConditionAsync(t => t.ParentTrackId.Equals(trackToUpdate.Id) && t.IsPending == true);

                var isWithin24Hours = this.IsWithin24hrs(trackToUpdate.Start);
                if (!isWithin24Hours)
                {
                    if (trackChange == null)
                        await Add(new Track
                        {
                            ProjectId = trackToUpdate.ProjectId,
                            TaskId = trackToUpdate.TaskId,
                            Start = trackToUpdate.Start,
                            End = trackToUpdate.End,
                            ParentTrackId = trackToUpdate.Id,
                            Type = trackToUpdate.Type,
                            Status = trackToUpdate.Status,
                            EmployeeId = trackToUpdate.EmployeeId,
                            Timezone = trackToUpdate.Timezone,
                            IsPending = true,
                            ChangeStatus = ChangeStatus.Pending,
                            Notes = trackToUpdate.Notes,
                            ApproverId = null
                        }, userId);
                    else
                    {
                        trackChange.Notes = trackToUpdate.Notes;
                        trackChange.IsPending = true;
                        trackChange.ChangeStatus = ChangeStatus.Pending;
                        trackChange.ApproverId = null;
                        await Update(trackChange, userId);
                    }
                }
                else
                {
                    trackToUpdate.Notes = trackToUpdate.Notes;
                }

                trackToUpdate.IsPending = true;
                trackToUpdate.ChangeStatus = ChangeStatus.Pending;
                trackToUpdate.ApproverId = null;

                await Update(trackToUpdate, userId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<TrackImportDtoResponse>> AddTestImport(IEnumerable<TrackImportDtoRequest> request, string timezone, Guid id)
        {
            try
            {
                var result = new List<TrackImportDtoResponse>();
                // Remove Pending Imported Tracks
                var existingImportedTracks = await _unitOfWork._Track.FindListByConditionAsync(d => d.Type == TrackType.Import && d.Tag == TrackTag.Office && d.Status == TrackStatus.None);
                if (existingImportedTracks is not null)
                {
                    await _unitOfWork._Track.DeleteRange(existingImportedTracks.ToArray());
                    await _unitOfWork.SaveChangeAsync(id);
                }

                foreach (var imp in request)
                {
                    var employee = await _unitOfWork._Employees.FindByConditionAsync(d => d.Code.ToLower().Contains(imp.EmployeeId.ToLower()));

                    if (employee is null)
                        continue;

                    var start = imp.TimeIn;
                    var end = imp.TimeOut;

                    var existing = await _unitOfWork._Track.FindByConditionAsync(d => d.EmployeeId.Equals(employee.Id) && d.Start.Date.Equals(start.Date));

                    if (existing is not null)
                        result.Add(imp.ToTrackImportDtoRequestToResponse());
                    else
                        await Add(new Track
                        {
                            Start = start,
                            End = end,
                            Type = TrackType.Import,
                            Tag = TrackTag.Office,
                            Status = TrackStatus.None,
                            EmployeeId = employee.Id,
                            Timezone = timezone
                        }, id);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> ManageTestImport(bool isConfirmed, Guid id)
        {
            try
            {
                var tracks = await _unitOfWork._Track.FindListByConditionAsync(d => d.Type == TrackType.Import && d.Tag == TrackTag.Office && d.Status == TrackStatus.None);

                if (tracks is null)
                    throw new NullReferenceException();

                if (isConfirmed)
                    foreach (var track in tracks)
                    {
                        track.Type = TrackType.Clock;
                        track.Status = TrackStatus.Stop;
                        track.Tag = TrackTag.Office;
                        await _unitOfWork._Track.UpdateAsync(track);
                    }
                else
                    await _unitOfWork._Track.DeleteRange(tracks.ToArray());
                await _unitOfWork.SaveChangeAsync(id);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex );
            }
        }

        public async Task<bool> RemovedTrackFromWithdrawCancelledLeaveApplication(LeaveApplication app, Guid userId)
        {
            var trackList = new List<Track>();
            foreach (DateTime day in EachDay(app.From, app.To))
            {
                var date = day;
                var isHolidayOrWeekEnd = await IsHolidayOrWeekend(date);

                if (!isHolidayOrWeekEnd)
                {
                    var data = await _unitOfWork._Track.GetDbSet()
                        .AsNoTracking()
                        .Where(f => f.EmployeeId.Equals(app.EmployeeId)
                          && f.Tag == TrackTag.PaidLeave && f.IsLocked == true
                          && f.Start.Date == date)
                        .FirstOrDefaultAsync();

                    if (data is not null)
                        trackList.Add(data);
                }
            }
            await _unitOfWork._Track.DeleteRange(trackList.ToArray());
            return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
        }

        public async Task<bool> ManageTrackFromLeaveApplication(LeaveApplication data, Guid userId)
        {
            var employee = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Include(f => f.ShiftSchedule)
                .Include(f => f.Settings)
                .Where(f => f.Id.Equals(data.EmployeeId))
                .FirstOrDefaultAsync();

            long timeStartDefault = 1713243648201;
            long timeEndDefault = 1713272456967;

            DateTime startDateTime = new DateTime();
            DateTime endDateTime = new DateTime();

            if (employee is not null)
            {
                foreach (DateTime day in EachDay(data.From, data.To))
                {
                    var date = day;
                    var isHolidayOrWeekEnd = await IsHolidayOrWeekend(date);
                    if (!isHolidayOrWeekEnd)
                    {
                        var startTime = employee.ShiftSchedule != null ? new DateTime().AddMilliseconds(employee.ShiftSchedule.TimeIn)
                            : new DateTime().AddMilliseconds(timeStartDefault);
                        var endTime = employee.ShiftSchedule != null ? new DateTime().AddMilliseconds(employee.ShiftSchedule.TimeOut)
                            : new DateTime().AddMilliseconds(timeEndDefault);

                        startDateTime = date.Date.Add(startTime.TimeOfDay);
                        endDateTime = date.Date.Add(endTime.TimeOfDay);

                        var track = new Track
                        {
                            EmployeeId = employee.Id,
                            Start = startDateTime,
                            End = endDateTime,
                            Notes = "Approved Leave by Team Lead or Manager",
                            Timezone = employee.Settings.Timezone,
                            Type = TrackType.Clock,
                            Status = TrackStatus.Stop,
                            Tag = TrackTag.PaidLeave,
                            IsLocked = true,
                            IsPending = false,
                            Active = true,

                        };

                        await _unitOfWork._Track.AddAsync(track);
                    }
                }
            }

            return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
        }

        private async Task<bool> IsHolidayOrWeekend(DateTime date)
        {
            var holidays = await _unitOfWork._CalendarEvents.GetDbSet()
                .Where(f => f.Date.Date == date.Date.Date && f.Type == HolidayType.Regular)
                .ToListAsync();

            if ((holidays != null && holidays.Any()) || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return true;
            else
                return false;
        }

        private IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

    }
}
