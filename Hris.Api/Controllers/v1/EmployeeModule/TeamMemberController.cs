using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.EmployeeModule
{
    public class TeamMemberController : BaseApiController<TeamMemberController>
    {
        private readonly ITeamMemberServices _teamMemberService;
        private readonly ICustomClaimPrincipal _custom;
        public TeamMemberController(ITeamMemberServices teamMemberServices, ICustomClaimPrincipal custom,
                        ILogger<TeamMemberController> logger) : base(logger)
        {
            _teamMemberService = teamMemberServices;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Lead, HrisRoles.Manager })]
        [HttpGet("load-resources")]
        public async Task<IActionResult> GetDepartmentTeamResources()
        {
            var result = await _teamMemberService.GetTeamMemberResources(await _custom.GetUserObjectId(User));
            if (result == null) { return HrisError("TeamMember", "Error in retrieving team member resources"); }
            return HrisOk(result);
        }


        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Lead, HrisRoles.Manager })]
        [HttpGet]
        public async Task<IActionResult> GetTeamMemberList([FromQuery] TeamMemberFilters filters)
        {
            var result = await _teamMemberService.GetTeamMemberList(filters);
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpGet("{employeeId}/department-manager-team-lead-info")]
        public async Task<IActionResult> GetDepartmentManagerTeamLeadInfo([FromRoute] Guid employeeId)
        {
            var result = await _teamMemberService.GetTeamLeadManagerInfo(employeeId);
            return HrisOk(result);
        }

        [HrisAuthorize]
        [HttpGet("{employeeId}/department-team-info")]
        public async Task<IActionResult> GetEmployeeTeamMemberInfo([FromRoute] Guid employeeId)
        {
            var result = await _teamMemberService.GetEmployeeTeamMemberInfo(employeeId);
            return HrisOk(result);
        }
    }
}
