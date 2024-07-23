using Hris.Data.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class DepartmentDto
    {
    }

    public class DepartmentDtoRequest : BaseDtoRequest
    {
        [Required(ErrorMessage = "Department Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Department Manager is required")]
        public Guid ManagerId { get; set; }
        public List<TeamDtoRequest>? Team { get; set; }
        public string templateUri { get; set; }
        public string templateName { get; set; }
    }

    public class DepartmentDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public Guid ManagerId { get; set; }
        public EmployeeDtoResponse? Manager { get; set; }
        public string ManagerName { get; set; }
        public string TemplateUri { get; set; }
        public string TemplateName { get; set; }
        public List<TeamDtoResponse> Team { get; set; }
    }

    public class TeamDtoRequest : BaseDtoRequest
    {
        [Required(ErrorMessage = "Team name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Team leader is required")]
        public Guid LeadId { get; set; }
        public Guid DepartmentId { get; set; }
    }

    public static class DepartmentExtension_
    {
        public static List<DepartmentDtoResponse> ToListResponse_(this IEnumerable<Department> d)
             => d.Select(e => e.ToResponse_()).ToList();

        public static DepartmentDtoResponse ToResponse_(this Department d)
            => new DepartmentDtoResponse
            {
                Id = d.Id,
                Active = d.Active,
                Name = d.Name,
                ManagerId = d.ManagerId,
                Manager = d.Manager != null ? d.Manager.ToInitialEmployeeResponse_() : null,
                Team = d.Teams?.ToList().ToListResponse_(),
                TemplateUri = d.TemplateUri,
                TemplateName = d.TemplateName
            };

        public static List<TeamDtoResponse> ToListResponse_(this List<Team> teams)
        {
            var teamResponse = new List<TeamDtoResponse>();

            if (teams != null)
            {
                teamResponse = teams.Select(e => e.ToResponse_()).ToList();
            }

            return teamResponse;
        }

        public static TeamDtoResponse ToResponse_(this Team teams)
        => new TeamDtoResponse
        {
            Id = teams.Id,
            Active = teams.Active,
            Name = teams.Name,
            LeadId = teams.LeadId,
            Lead = teams.Lead != null ? teams.Lead.ToResponse_() : null,
            DepartmentId = teams.DepartmentId,
        };
        public static IEnumerable<TeamMemberDtoResponse> ToTeamMemberResponseList(this IEnumerable<TeamMember> tms)
            => tms.Select(e => e.ToTeamMemberResponse()).ToList();

        public static TeamMemberDtoResponse ToTeamMemberResponse(this TeamMember d)
            => new TeamMemberDtoResponse
            {
                Id = d.Id,
                EmployeeId = d.EmployeeId,
                Employee = d.Employee != null ? d.Employee.ToInitialEmployeeResponse_() : null,
                TeamId = d.TeamId.Value,
                Team = d.Team != null ? d.Team.ToResponse_() : null,
                DepartmentId = d.Team != null ? d.Team.DepartmentId : null,
                Department = d.Team != null && d.Team.Department != null ? new DepartmentDtoResponse()
                {
                    Id = d.Team.Department.Id,
                    Name = d.Team.Department.Name,
                    ManagerId = d.Team.Department.ManagerId,
                    Manager = d.Team.Department.Manager.ToInitialEmployeeResponse_()
                } : null

            };

  

    }
}
