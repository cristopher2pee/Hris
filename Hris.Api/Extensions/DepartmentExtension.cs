using Hris.Api.Models.Response;
using Hris.Data.Models.Employee;
using Microsoft.Identity.Client;

namespace Hris.Api.Extensions
{
    public static class DepartmentExtension
    {
        public static List<DepartmentResponse> ToListResponse(this IEnumerable<Department> d)
            => d.Select(e => e.ToResponse()).ToList();

        public static DepartmentResponse ToResponse(this Department d)
            => new DepartmentResponse
            {
                Id = d.Id,
                Active = d.Active,
                Name = d.Name,
                ManagerId = d.ManagerId,
                Manager = d.Manager != null ? d.Manager.ToInitialEmployeeResponse() : null,
                Team = d.Teams?.ToList().ToListResponse(),
                TemplateUri = d.TemplateUri,
                TemplateName = d.TemplateName
            };

        public static List<TeamResponse> ToListResponse(this List<Team> teams)
        {
            var teamResponse = new List<TeamResponse>();

            if (teams != null)
            {
                teamResponse = teams.Select(e => e.ToResponse()).ToList();
            }

            return teamResponse;
        }

        public static TeamResponse ToResponse(this Team teams)
            => new TeamResponse
            {
                Id = teams.Id,
                Active = teams.Active,
                Name = teams.Name,
                LeadId = teams.LeadId,
                Lead = teams.Lead != null ? teams.Lead.ToResponse() : null,
                DepartmentId = teams.DepartmentId,
            };
    }
}
