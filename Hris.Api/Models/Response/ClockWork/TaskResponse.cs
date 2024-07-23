using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Models.Response.ClockWork
{
    public class TaskResponse : BaseResponse
    {
        public string Name { get; set; }
        public bool IsBillable { get; set; }
        public Guid? ParentTaskId { get; set; }
        public List<TaskResponse>? SubTasks { get; set;}
    }
}
