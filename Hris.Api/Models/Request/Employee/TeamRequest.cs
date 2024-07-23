using Hris.Data.Models.Employee;
using System.ComponentModel.DataAnnotations;

namespace Hris.Api.Models.Request.Employee
{
    public class TeamRequest : BaseRequest
    {
        [Required(ErrorMessage ="Team name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Team leader is required")]
        public Guid LeadId { get; set; }
        public Guid DepartmentId { get; set; }
    }

    public class TeamMemberRequest : BaseRequest
    {
        public Guid TeamId { get; set; }
        public Guid EmployeeId { get; set; }

        public Guid? DepartmentId { get; set; }
    }
}
