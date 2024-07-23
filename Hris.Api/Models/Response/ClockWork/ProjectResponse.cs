using Hris.Api.Models.Response.Employee;
using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response.ClockWork
{
    public class ProjectResponse : BaseResponse
    {
        public string Name { get; set; }
        public Guid ClientId { get; set; }
        public virtual ClientResponse? Client { get; set; }
        public string? Description { get; set; }
        public IEnumerable<TaskResponse>? Tasks { get; set; }
    }
}
