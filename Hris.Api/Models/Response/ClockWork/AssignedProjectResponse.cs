namespace Hris.Api.Models.Response.ClockWork
{
    public class AssignedProjectResponse : BaseResponse
    {
        public Guid EmployeeId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TaskId { get; set; }
        public EmployeeResponse? Employee { get; set; }
        public ClientResponse? Client { get; set; }
        public ProjectResponse? Project { get; set; }
        public TaskResponse? Task { get; set; }

        // New
        public string ProjectsStr { get; set; }
        public string TasksStr { get; set; }

        public IEnumerable<TaskResponse> Tasks { get; set; }
    }
}
