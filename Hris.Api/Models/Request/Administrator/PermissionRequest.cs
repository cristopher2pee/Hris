using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Models.Request.Administrator
{
    public class PermissionRequest : BaseRequest
    {
        public Guid EmployeeId { get; set; }
        public string Module { get; set; }
        public string Role { get; set; }
    }

    public class PermissionChangeRequest : PermissionRequest
    {
        public string NewModule { get; set; }
        public string NewRole { get; set; }
    }
}
