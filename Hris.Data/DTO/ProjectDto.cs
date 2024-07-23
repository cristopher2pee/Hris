using Hris.Data.Models.Clock;
using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class ProjectDto
    {
    }

    public class ProjectDtoRequest : BaseDtoRequest
    {
        public string Name { get; set; }
        public Guid ClientId { get; set; }
        public string? Description { get; set; }
        public ICollection<ProjectTaskDtoRequest>? Tasks { get; set; }
    }

    public class ProjectTaskDtoRequest : BaseDtoRequest
    {
        public string Name { get; set; }
        public bool IsBillable { get; set; }
        public Guid? ParentTaskId { get; set; }
        public bool IsCustom { get; set; }
        public ProjectTaskRate Rate { get; set; }
        public decimal Amount { get; set; }


    }


    public class TaskDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public bool IsBillable { get; set; }
        public Guid? ParentTaskId { get; set; }
        public Guid? ProjectId { get; set; }
        public List<TaskDtoResponse>? SubTasks { get; set; }
        public bool IsCustom { get; set; }
        public ProjectTaskRate Rate { get; set; }
        public decimal Amount { get; set; }
    }

    public class ProjectDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public Guid ClientId { get; set; }
        public virtual ClientDtoResponse? Client { get; set; }
        public string? Description { get; set; }
        public IEnumerable<TaskDtoResponse>? Tasks { get; set; }
    }

    public static class ProjectExtension_
    {
        public static TaskDtoResponse ToTaskDtoResponse(this ProjectTask d)
        {
            return new TaskDtoResponse
            {
                Id = d.Id,
                Active = d.Active,
                Name = d.Name,
                IsBillable = d.IsBillable,
                ParentTaskId = d.ParentTaskId,
                ProjectId = d.ProjectId,
                Amount = d.Amount,
                IsCustom = d.IsCustom,
                Rate = d.Rate,
            };
        }

        public static IEnumerable<TaskDtoResponse> ToTaskDtoResponseList(this IEnumerable<ProjectTask> tasks)
            => tasks.Select(e => e.ToTaskDtoResponse());

        public static ProjectDtoResponse ToProjectDtoResponse(this Project project)
        {
            return new ProjectDtoResponse
            {
                Id = project.Id,
                Name = project.Name,
                ClientId = project.ClientId,
                Client = project.Client != null ? new ClientDtoResponse
                {
                    Name = project.Client.Name,
                } : null,
                Description = project.Description,
                Tasks = project.Tasks != null ?
                        project.Tasks.Select(t => new TaskDtoResponse
                        {
                            Id = t.Id,
                            Name = t.Name,
                            IsBillable = t.IsBillable,
                            ParentTaskId = t.ParentTaskId
                        }).ToList() : null
            };
        }

        public static IEnumerable<ProjectDtoResponse> ToProjectDtoResponseList(this IEnumerable<Project> projects)
            => projects.Select(e => e.ToProjectDtoResponse());
    }

}
