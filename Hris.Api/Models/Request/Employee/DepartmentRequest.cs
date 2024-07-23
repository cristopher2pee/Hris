using System.ComponentModel.DataAnnotations;

namespace Hris.Api.Models.Request.Employee
{
    public class DepartmentRequest : BaseRequest
    {
        [Required(ErrorMessage ="Department Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Department Manager is required")]
        public Guid ManagerId { get; set; }
        public List<TeamRequest>? Team { get; set; }
    }

}
