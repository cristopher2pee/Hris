using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Hub;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.Clock;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.Clock;
using Hris.Business.Service.Common;
using Hris.Business.Service.EmployeeModule;
using Hris.Business.Service.v1.ClockModule;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.DTO;
using Hris.Data.Models.Clock;
using Hris.Data.Models.Employee;
using Hris.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static Hris.Data.DTO.TrackExtension_;

namespace Hris.Api.Controllers.v1.ClockModule
{
    public class TrackController : BaseApiController<TrackController>
    {
        private readonly ITrackServices _trackServices;
        private readonly IEmployeesService _employeesService;
        private readonly StorageCloudService _storageCloudService;
        private readonly INotificationHelper _notifHelper;
        private readonly ICustomClaimPrincipal _custom;

        public TrackController(
            ITrackServices trackServices, IEmployeesService employeesService,
            StorageCloudService storage,
            INotificationHelper helper,
            ICustomClaimPrincipal custom,
             ILogger<TrackController> logger) : base(logger)
        {

            _trackServices = trackServices;
            _employeesService = employeesService;
            _storageCloudService = storage;
            _notifHelper = helper;
            _custom = custom;
        }

        [HttpGet, HrisAuthorize]
        public async Task<IActionResult> GetCurrent()
        {
            var d = await _trackServices.GetCurrent(await _custom.GetUserObjectId(User));
            return HrisOk(d);
        }

        [HttpPost, HrisAuthorize]
        public async Task<IActionResult> Start(TrackDtoRequest request)
        {
            var userId = await _custom.GetUserObjectId(User);
            var e = await _employeesService.GetByObjectId(userId, false);
            if (e == null)
                return HrisErrorNotFound(Resource.Responses.Track.TRACK, Resource.Responses.Employee.NOT_FOUND);

            var d = await _trackServices.Start(userId, e.Id, e.Settings.Timezone, request);
            return HrisOk(d);
        }

        [HttpPut, HrisAuthorize]
        public async Task<IActionResult> Stop(TrackRequest requrest)
        {
            var d = await _trackServices.GetById(requrest.Id);
            if (d == null)
                return HrisErrorNotFound(Resource.Responses.Track.TRACK, Resource.Responses.Track.NOT_FOUND);

            d = await _trackServices.Stop(d, await _custom.GetUserObjectId(User));
            return HrisOk(d);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("request")]
        public async Task<IActionResult> Get([FromQuery] ChangeRequestFilter_ filter)
        {
            var result = await _trackServices.GetAll(filter, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPut("request/{id}")]
        public async Task<IActionResult> ManageRequest([FromRoute] Guid id, [FromQuery] bool isApproved)
        {
            var e = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User));
            if (e == null)
                return HrisErrorNotFound(Resource.Responses.Track.TRACK, Resource.Responses.Employee.NOT_FOUND);

            var d = await _trackServices.GetById(id);
            if (d == null || d.ParentTrackId == null)
                return HrisErrorNotFound(Resource.Responses.Track.TRACK, Resource.Responses.Track.REQUEST_NOT_FOUND);

            var t = await _trackServices.GetById(d.ParentTrackId.Value);
            if (t == null)
                return HrisError(Resource.Responses.Track.TRACK, Resource.Responses.Track.CHANG_REQUEST_NO_PARENT);

            var result = await _trackServices.ManageRequest(e, d, t, isApproved, await _custom.GetUserObjectId(User));

            if (result.notif is not null && result.notif.Any())
                await _notifHelper.ProcessNotificationList(result.notif);

            return HrisOk(result.result);
        }

        [HrisAuthorize]
        [HttpPatch("{id}/file")]
        public async Task<IActionResult> AddFiles([FromRoute] Guid id)
        {
            var form = Request.Form;
            var trackToUpdate = await _trackServices.GetById(id);

            if (trackToUpdate == null)
                return HrisErrorNotFound(Resource.Responses.Track.TRACK, Resource.Responses.Track.REQUEST_NOT_FOUND);

            if (form.Files?.Any() ?? true)
            {
                await _storageCloudService.UploadTaskFiles(form.Files, id);
                var uris = await _storageCloudService.GetTaskFilesUri(id);
                trackToUpdate.Files = uris;
                await _trackServices.Update(trackToUpdate, await _custom.GetUserObjectId(User));
                return HrisOk(trackToUpdate.ToTrackDtoResponse());
            }
            else return HrisError("Track", "No file(s) attched.");
        }

        [HrisAuthorize]
        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] DateTime date, int limit = 4)
        {
            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User));
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Track.TRACK, Resource.Responses.Employee.NOT_FOUND);

            var result = await _trackServices.GetListRecordResponse(date, employee, limit);
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrackById([FromRoute] Guid id)
        {
            var existingTrack = await _trackServices.GetById(id);
            if (existingTrack == null)
                return HrisErrorNotFound(Resource.Responses.Track.TRACK, Resource.Responses.Track.REQUEST_NOT_FOUND);
            return HrisOk(existingTrack.ToTrackDtoResponse());
        }

        //[HrisAuthorize]
        //[HttpPost]
        //public async Task<IActionResult> Start(TrackDtoRequest track)
        //{
        //    try
        //    {
        //        var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User));
        //        if (employee == null)
        //            return HrisError("Tracking", "Employee not found.");

        //        var result = await _trackServices.AddTrack(track, await _custom.GetUserObjectId(User));
        //        return HrisOk(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return HrisError("Exception", ex.Message);
        //    }

        //}

        [HrisAuthorize]
        [HttpPost("manual")]
        public async Task<IActionResult> AddManualTrack(TrackDtoRequest track)
        {
            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User));
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Track.TRACK, Resource.Responses.Employee.NOT_FOUND);

            var result = await _trackServices.AddManualTrack(track, await _custom.GetUserObjectId(User));
            if (result.notifList is not null && result.notifList.Any())
            {
                await _notifHelper.ProcessNotificationList(result.notifList);
            }
            return HrisOk(result.res);
        }

        [HrisAuthorize]
        [HttpPost("manual-attachment")]
        public async Task<IActionResult> AddManualTrackAttachment()
        {
            var form = Request.Form;

            var trackId = form["id"];

            if (string.IsNullOrEmpty(trackId))
                return HrisError("Track", "Track id is empty.");

            var existingTrack = await _trackServices.GetById(Guid.Parse(trackId));
            if (existingTrack == null)
                return HrisError("Track", "Track does not exist.");

            if (form.Files?.Any() == false)
                return HrisError("Track", "No files attached.");

            await _storageCloudService.UploadTaskFiles(form.Files, existingTrack.Id);
            var uri = await _storageCloudService.GetTaskFilesUri(existingTrack.Id);
            existingTrack.Files = uri;
            await _trackServices.Update(existingTrack, await _custom.GetUserObjectId(User));
            return HrisOk(existingTrack.ToTrackDtoResponse());
        }

        [HrisAuthorize]
        [HttpGet("hasCurrent")]
        public async Task<IActionResult> HasCurrent()
        {
            var result = await _trackServices.HasCurrent(await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpGet("GetCurrentStatus")]
        public async Task<IActionResult> GetCurrentStatus()
        {
            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User), false);
            if (employee is null)
                return HrisErrorNotFound(Resource.Responses.Track.TRACK, Resource.Responses.Employee.NOT_FOUND);

            var result = await _trackServices.GetCurrentStatus(await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpPatch("notes")]
        public async Task<IActionResult> PatchNote([FromBody] TrackDtoRequest updatedTrack)
        {
            var trackToUpdate = await _trackServices.GetById(updatedTrack.Id);
            if (trackToUpdate is null) return HrisErrorNotFound(Resource.Responses.Track.TRACK, Resource.Responses.Track.NOT_FOUND);

            var res = await _trackServices.UpdateTrack(updatedTrack, await _custom.GetUserObjectId(User));
            if (res is null) return HrisError(Resource.Responses.Track.TRACK, Resource.Responses.Track.UPDATE_ERROR);
            return HrisOk(res);
        }

        [HrisAuthorize]
        [HttpPatch]
        public async Task<IActionResult> PatchTrack([FromBody] TrackDtoRequest updatedTrack)
        {
            var trackToUpdate = await _trackServices.GetById(updatedTrack.Id);
            if (trackToUpdate is null) return HrisErrorNotFound(Resource.Responses.Track.TRACK, Resource.Responses.Track.NOT_FOUND);

            var res = await _trackServices.PatchTag(updatedTrack, await _custom.GetUserObjectId(User));
            if (!res) return HrisError(Resource.Responses.Track.TRACK, Resource.Responses.Track.UPDATE_ERROR);
            return HrisOk(res);
        }

        [HrisAuthorize]
        [HttpPatch("project")]
        public async Task<IActionResult> PatchProject([FromBody] TrackProjecDtotChangeRequest request)
        {
            var result = await _trackServices.PatchProject(request, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpPatch("date")]
        public async Task<IActionResult> PatchTrackDate([FromBody] TrackDateTimeChangeDtoRequest request)
        {
            var result = await _trackServices.PatchTrackDate(request, await _custom.GetUserObjectId(User));
            if (result.listNotifications != null && result.listNotifications.Any())
            {
                await _notifHelper.ProcessNotificationList(result.listNotifications);
            }
            return HrisOk(result.result);
        }

        [HrisAuthorize]
        [HttpPatch("time")]
        public async Task<IActionResult> PatchTrackTime([FromBody] TrackTimeChangeDtoRequest request)
        {
            var result = await _trackServices.PatchTrackTime(request, await _custom.GetUserObjectId(User));
            if (result.list != null && result.list.Any())
            {
                await _notifHelper.ProcessNotificationList(result.list);
            }
            return HrisOk(result.result);
        }

        [HrisAuthorize]
        [HttpPatch("files")]
        public async Task<IActionResult> PatchFiles()
        {

            var form = Request.Form;
            var taskId = Guid.Parse(form["id"]);

            if (taskId == null)
                return HrisErrorNotFound("Track", "Task id not found.");

            var trackToUpdate = await _trackServices.GetById(taskId);

            if (trackToUpdate == null)
                return HrisErrorNotFound("Track", "Track does not exist.");

            if (form.Files?.Any() ?? true)
            {
                await _storageCloudService.UploadTaskFiles(form.Files, taskId);
                var uris = await _storageCloudService.GetTaskFilesUri(taskId);
                trackToUpdate.Files = uris;
                await _trackServices.Update(trackToUpdate, await _custom.GetUserObjectId(User));
                return HrisOk(trackToUpdate.ToTrackDtoResponse());
            }
            else
                return HrisError("Track", "No file(s) attched.");
        }

        [HrisAuthorize]
        [HttpDelete("{id}/attachments")]
        public async Task<IActionResult> RemoveFile([FromRoute] Guid id, [FromQuery] string fileName)
        {
            var track = await _trackServices.GetById(id);

            if (track == null)
                return HrisErrorNotFound(this.GetType().ToString(), "Track does not exist.");

            if (track.Files.IsNullOrEmpty())
                return HrisError(this.GetType().ToString(), "Track files is empty.");

            if (await _storageCloudService.Remove(7, track.Id, fileName))
            {
                var files = track.Files.Split(',').ToList();
                files.Remove(files.Find(u => u.Contains(fileName)));
                track.Files = files.Any() ? string.Join(",", files) : null;

                await _trackServices.Update(track, await _custom.GetUserObjectId(User));

                return HrisOk(track.ToTrackDtoResponse());
            }
            else
                return HrisError(this.GetType().ToString(), "Something went wrong.");
        }

        [HrisAuthorize]
        [HttpGet("duplicate")]
        public async Task<IActionResult> Duplicate([FromQuery] Guid id)
        {
            var result = await _trackServices.Duplicate(id, await _custom.GetUserObjectId(User));
            if (!result) return HrisError("Track", "Track does not exist.");

            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var result = await _trackServices.DeleteTrack(id, await _custom.GetUserObjectId(User));
            if (!result) return HrisError("Track", "Track does not exist.");

            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("change/list")]
        public async Task<IActionResult> GetChangeRequests([FromQuery] ChangeRequestFilter_ filter)
        {
            var result = await _trackServices.GetChangeRequests(filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPut("change/manage")]
        public async Task<IActionResult> ManageChangeRequest([FromBody] ChangeDtoRequest request)
        {
            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User));

            if (employee == null)
                return HrisError("Tracking", "Employee not found.");

            var trackChange = await _trackServices.GetById(request.TrackChangeId);

            if (trackChange == null)
                return HrisError("Track", "Track Change request does not exist.");

            if (trackChange.ParentTrackId == null)
                return HrisError("Track", "Track Change has no Parent Track.");

            var result = await _trackServices.ManageChangeRequest(request, await _custom.GetUserObjectId(User));
            if (!result) return HrisError("Track", "Error in manage request");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost("import")]
        public async Task<IActionResult> AddTestImport([FromBody] IEnumerable<TrackImportDtoRequest> request)
        {
            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User), false);
            if (employee is null)
                throw new NullReferenceException();
            return HrisOk(await _trackServices.AddTestImport(request, employee.Settings.Timezone, await _custom.GetUserObjectId(User)));
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPatch("import")]
        public async Task<IActionResult> ManageTestImport([FromQuery] bool isConfirmed)
        {
            return HrisOk(await _trackServices.ManageTestImport(isConfirmed, await _custom.GetUserObjectId(User)));
        }

    }
}
