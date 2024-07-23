using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.Employee;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Extensions;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.EmployeeModule
{
    public class TeamController : BaseApiController<TeamController>
    {
        private readonly ITeamServices _teamServices;
        private readonly ITeamMemberServices _teamMemberServices;
        private readonly ICustomClaimPrincipal _custom;
        public TeamController(ITeamServices teamService, ITeamMemberServices teamMemberServices
            , ICustomClaimPrincipal custom,
                        ILogger<TeamController> logger) : base(logger)
        {
            _teamServices = teamService;
            _teamMemberServices = teamMemberServices;
            _custom = custom;
        }

        [HrisAuthorize]
        [HttpGet("Resources")]
        public async Task<IActionResult> GetResources()
        {
            var result = await _teamServices.GetResources();
            return HrisOk(result.Select(e => e.ToResponse_()));
        }

        [HrisAuthorize]
        [HttpGet("Member")]
        public async Task<IActionResult> GetByMemberId([FromQuery] TeamMemberFilter request)
        {
            var teamMember = await _teamMemberServices.GetByMemberId(request.Page, request.Limit, request.EmployeeId);
            return Ok(teamMember.list.ToList().ToListResponse_(request.Page, request.Limit, teamMember.total));
        }

        [HttpGet("Member/{teamId}"), HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> GetByTeamId([FromRoute] Guid teamId)
        {
            var result = await _teamMemberServices.GetByTeamId(teamId);
            return Ok(result.ToTeamMemberResponseList());
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost("Member")]
        public async Task<IActionResult> AddMember([FromBody] TeamMemberRequest request)
        {
            var data = await _teamMemberServices.AddMember(request.TeamId, request.EmployeeId, await _custom.GetUserObjectId(User));
            return HrisOk(data);
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("Member/{id}")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var member = await _teamMemberServices.GetMemberById(id);
            if (member == null)
                return HrisError(Resource.Responses.TeamMember.TEAM_MEMBER, Resource.Responses.TeamMember.NOT_FOUND);
            await _teamMemberServices.RemoveMember(member, await _custom.GetUserObjectId(User));
            return HrisOk(true);
        }

    }
}
