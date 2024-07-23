using Hris.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Models.Response.Administrator
{
    public class PermissionResponse : BaseResponse
    {
        public EmployeeResponse Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public string Module { get; set; }
        public string Role { get; set; }
    }

    public class PermissionAccessResponse
    {
        public string Module { get; set; }
        public string Role { get; set; }
        public List<string> Paths { get; set; }

        public PermissionAccessResponse(string module, string role)
        {
            this.Module = module;
            this.Role = role;
            this.Paths = new List<string>();
        }
    }
}
