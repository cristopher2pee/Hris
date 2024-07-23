using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.Employee;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.EmployeeModule
{
    public class PositionController : BaseApiController<PositionController>
    {
        private readonly IPositionServices _services;
        private readonly IEmployeesService _employeesService;
        private readonly ICustomClaimPrincipal _custom;
        public PositionController(IPositionServices services, IEmployeesService employeesService,
            ICustomClaimPrincipal custom,
            ILogger<PositionController> logger) : base(logger)
        {
            _services = services;
            _employeesService = employeesService;
            _custom = custom;

        }

        [HttpGet("resource"), HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> GetResource()
        {
            return HrisOk(await _services.GetResources());
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PositionFilter_ filter)
        {
            return HrisOk(await _services.GetAll(filter));
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return HrisOk(await _services.GetByIdResponse(id));
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PositionDtoRequest request)
        {
            var result = await _services.Add(request, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Position", "Error in saving position");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PositionDtoRequest request)
        {
            var result = await _services.Update(request, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Position", "Error in updating position");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var d = await _services.GetById(id);
            if (d == null)
                return HrisError(Resource.Responses.Position.POSITION, Hris.Resource.Responses.Position.NOT_FOUND);

            var result = await _services.Delete(id, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Position", "Error in deleting position");

            return HrisOk(result);
        }
    }
}
