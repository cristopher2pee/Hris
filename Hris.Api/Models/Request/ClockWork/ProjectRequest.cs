using Hris.Api.Models.Response.ClockWork;
using Hris.Api.Models.Response;
using Hris.Api.Models.Request.Client;

namespace Hris.Api.Models.Request.ClockWork
{
    public class ProjectRequest : BaseRequest
    {
        public string Name { get; set; }
        public Guid ClientId { get; set; }
        public string? Description { get; set; }
        public ICollection<ProjectTaskRequest>? Tasks { get; set; }
    }

    public class ProjectTaskRequest : BaseRequest 
    {
        public string Name { get; set; }
        public bool IsBillable { get; set; }
        public Guid? ParentTaskId { get; set; }
    }
}
