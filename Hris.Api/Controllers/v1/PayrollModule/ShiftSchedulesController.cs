using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.PayrollModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.PayrollModule
{

    public class ShiftSchedulesController : BaseApiController<ShiftSchedulesController>
    {
        private readonly IShiftSchedulesServices _shiftScheduleServices;
        private readonly ICustomClaimPrincipal _custom;
        public ShiftSchedulesController(IShiftSchedulesServices shiftSchedules,
            ICustomClaimPrincipal custom,
            ILogger<ShiftSchedulesController> logger) : base(logger)
        {
            _shiftScheduleServices = shiftSchedules;
            _custom = custom;
        }

        [HttpGet]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> GetAll([FromQuery] BaseFilter_ filters)
        {
            var result = await _shiftScheduleServices.GetAll(filters);
            return HrisOk(result);
        }

        [HttpGet("{id}")]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _shiftScheduleServices.GetById(id);
            if (result is null)
                return HrisErrorNotFound("NOT FOUND", "Object Not Found.");
            return HrisOk(result);
        }

        [HttpGet("resources")]
        [HrisAuthorize]
        public async Task<IActionResult> GetResources()
        {
            var result = await _shiftScheduleServices.GetResources();
            return HrisOk(result);
        }

        [HttpPost]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> AddShiftSchedule([FromBody] ShiftSchedulesDtoRequest req)
        {

            var result = await _shiftScheduleServices.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Shift Schedules");
            return HrisOk(result);
        }

        [HttpPut]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> UpdateShiftSchedule([FromBody] ShiftSchedulesDtoRequest req)
        {
            var result = await _shiftScheduleServices.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Shift Schedules");
            return HrisOk(result);

        }

        [HttpDelete("{id}")]
        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> DeleteShiftSchedule([FromRoute] Guid id)
        {

            var result = await _shiftScheduleServices.Delete(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }
    }
}
