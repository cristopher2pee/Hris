using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class AssignedProjectDto
    {
    }

    public class AssignedProjectDtoRequest : BaseDtoRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TaskId { get; set; }
    }

    public class AssignedProjectDtoResponse : BaseDtoResponse
    {
        public Guid EmployeeId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TaskId { get; set; }
        public EmployeeDtoResponse? Employee { get; set; }
        public ClientDtoResponse? Client { get; set; }
        public ProjectDtoResponse? Project { get; set; }
        public TaskDtoResponse? Task { get; set; }

        // New
        public string ProjectsStr { get; set; }
        public string TasksStr { get; set; }

        public IEnumerable<TaskDtoResponse> Tasks { get; set; }
    }
}
