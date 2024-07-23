namespace Hris.Api.Models.Request.ClockWork
{
    public class AssignedProjectRequest : BaseRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TaskId { get; set; }
    }
}
