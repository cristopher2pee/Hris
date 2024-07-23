using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.Administrator;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.AdministratorModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hris.Resource;
using Hris.Api.Controllers.v1.PayrollModule;

namespace Hris.Api.Controllers.v1.AdministratorModule
{
    public class CalendarController : BaseApiController<CalendarController>
    {
        private readonly ICalendarServices _services;
        private readonly ICustomClaimPrincipal _custom;
        public CalendarController(ICalendarServices services, ICustomClaimPrincipal custom, ILogger<CalendarController> logger) : base(logger)
        {
            _services = services;
            _custom = custom;
        }

        [HttpGet, HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> GetAll([FromQuery] CalendarFilter_ filter)
        {
            return HrisOk(await _services.GetAll(filter, await _custom.GetUserObjectId(User)));
        }

        [HttpGet("{id}"), HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return HrisOk(await _services.GetById(id, await _custom.GetUserObjectId(User)));
        }

        [HttpGet("range"), HrisAuthorize]
        public async Task<IActionResult> GetByRange([FromQuery] DateTime from, DateTime to)
        {
            return HrisOk(await _services.GetByRange(from, to, await _custom.GetUserObjectId(User)));
        }

        [HttpPost, HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> Save([FromBody] CalendarDtoRequest request)
        {
            return HrisOk(await _services.Save(request, await _custom.GetUserObjectId(User)));
        }

        [HttpPut, HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> Update([FromBody] CalendarDtoRequest request)
        {
            return HrisOk(await _services.Update(request, await _custom.GetUserObjectId(User)));
        }

        [HttpDelete("{id}"), HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            return HrisOk(await _services.Remove(id, await _custom.GetUserObjectId(User)));
        }

        [HttpGet("duplicate"), HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> Duplicate()
            => HrisOk(await _services.Duplicate(await _custom.GetUserObjectId(User)));
    }
}
