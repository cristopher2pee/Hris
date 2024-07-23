namespace Hris.Api.Models.Request.ClockWork
{
    public class TaskRequest: BaseRequest
    {
        public string Name { get; set; }
        public Boolean IsBillable { get; set; }

        public Guid? ParentTaskId { get; set; }
    }
}
