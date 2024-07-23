using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Middleware;
using Hris.Api.Models.Common;
using Hris.Api.Models.Response;
using Hris.Api.Security;
using Hris.Business.Service.Clock;
using Hris.Business.Service.EmployeeModule;
using Hris.Business.Service.v1.ClockModule;
using Hris.Business.Service.v1.CommonModule;
using Hris.Business.Service.v1.EmployeeModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.CommonModule
{

    public class ResourceController : BaseApiController<ResourceController>
    {
        private readonly ICommonServices _commonServices;
        private readonly IDepartmentServices _departmentServices;
        public ResourceController(ICommonServices commonServices,
                IDepartmentServices departmentServices,
                ILogger<ResourceController> logger) : base(logger)
        {
            _commonServices = commonServices;
            _departmentServices = departmentServices;
        }
        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("{departmentId}/team")]
        public async Task<IActionResult> GetTeamByDepartment(Guid departmentId)
        {
            var existingdepartment = await _departmentServices.GetDepartmentById(departmentId);
            if (existingdepartment == null)
                return HrisErrorNotFound("Resource", "Department doest not exist");

            if (existingdepartment.Teams != null && existingdepartment.Teams.Any())
            {
                var result = await _commonServices.GetTeamByDepartmentDropDown(departmentId);
                return HrisOk(result);
            }
            else
            {
                return HrisError("Resource", "Department has no team.");
            }
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("changeStatus")]
        public async Task<IActionResult> GetChangeRequestResources()
        {
            var result = await _commonServices.GetChangeStatusDropDown();
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("reports")]
        public async Task<IActionResult> GetReportsResources()
        {
            var result = await _commonServices.GetReportsResources();
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Clock }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpGet("reports/{ids}")]
        public async Task<IActionResult> GetProjectsByClients([FromRoute] string ids)
        {
            var result = await _commonServices.GetProjectsByClients(ids);
            return HrisOk(result);
        }

    }
}
