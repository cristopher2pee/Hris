using Azure;
using Hris.Api.Extensions.Clock;
using Hris.Api.Models.Response;
using Hris.Api.Models.Response.ClockWork;
using Hris.Data.Models.Clock;
using System.Threading.Tasks;

namespace Hris.Api.Extensions.Clock
{
    public static class ProjectExtension
    {
        public static ProjectResponse ToResponse(this Project d)
            => new ProjectResponse
            {
                Id = d.Id,
                Active = d.Active,
                Name = d.Name,
                ClientId = d.ClientId,
                Client = d.Client != null ? d.Client.ToResponse() : null,
                Description = d.Description,
                Tasks = d.Tasks != null && d.Tasks.Any() ? d.Tasks.ToTaskList() : null
            };

        public static TaskResponse ToResponse(this ProjectTask d)
            => new TaskResponse
            {
                Id = d.Id,
                Active = d.Active,
                Name = d.Name,
                IsBillable = d.IsBillable,
                ParentTaskId = d.ParentTaskId
            };

        public static IEnumerable<TaskResponse> ToTaskList(this IEnumerable<ProjectTask> d)
            => d.Select(d => d.ToResponse());

        public static IEnumerable<ProjectResponse> ToList(this IEnumerable<Project> d)
            => d.Select(d => d.ToResponse());

        // Old 
        public static ProjectResponse ToProjectLisResponse(this Project project)
            => new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                ClientId = project.ClientId,
                Client = project.Client != null ? new ClientResponse
                {
                    Name = project.Client.Name,
                } : null,
                Description = project.Description
            };

        public static ProjectResponse ToProjectResponse(this Project project)
            => new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                ClientId = project.ClientId,
                Client = project.Client != null ? new ClientResponse
                {
                    Name = project.Client.Name,
                } : null,
                Description = project.Description,
                Tasks = project.Tasks != null ?
                        project.Tasks.Select(t => new TaskResponse
                        {
                            Id = t.Id,
                            Name = t.Name,
                            IsBillable = t.IsBillable,
                            ParentTaskId = t.ParentTaskId
                        }).ToList() : null
            };

        public static TaskResponse ToTaskResponse(this ProjectTask task)
            => new TaskResponse
            {
                Id = task.Id,
                Name = task.Name,
                IsBillable = task.IsBillable,
            };

        public static IEnumerable<AssignedProjectResponse> ToAssignedProjectList(this IEnumerable<AssignedProject> d)
            => d.Select(d => d.ToAssignedProjectResponse());

        public static AssignedProjectResponse ToAssignedProjectResponse(this AssignedProject d)
            => new AssignedProjectResponse
            {
                Id = d.Id,
                EmployeeId = d.EmployeeId,
                ClientId = d.ClientId,
                ProjectId = d.ProjectId,
                TaskId = d.TaskId,
                Employee = d.Employee != null ? new EmployeeResponse
                {
                    Id = d.Employee.Id,
                    FirstName = d.Employee.Firstname,
                    MiddleName = d.Employee.Middlename,
                    LastName = d.Employee.Lastname
                } : null,
                Client = d.Project != null && d.Project.Client != null ? 
                    new ClientResponse
                    {
                        Id = d.Project.Client.Id,
                        Name = d.Project.Client.Name
                    } : null,
                Project = d.Project != null ? 
                    new ProjectResponse
                    {
                        Id = d.Project.Id,
                        Name = d.Project.Name
                    } : null,
                Task = d.Task != null ? 
                new TaskResponse
                    {
                        Id = d.Task.Id,
                        Name = d.Task.Name
                    } : null
            };
    }
}
