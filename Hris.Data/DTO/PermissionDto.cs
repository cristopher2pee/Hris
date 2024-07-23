using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class PermissionDto
    {
    }

    public class PermissionDtoResponse : BaseDtoResponse
    {
        public EmployeeDtoResponse Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public string Module { get; set; }
        public string Role { get; set; }
    }

    public class PermissionDtoRequest : BaseDtoRequest
    {
        public Guid EmployeeId { get; set; }
        public string Module { get; set; }
        public string Role { get; set; }
    }

    public class PermissionDtoChangeRequest : PermissionDtoRequest
    {
        public string NewModule { get; set; }
        public string NewRole { get; set; }
    }

    public class PermissionAccessDtoResponse
    {
        public string Module { get; set; }
        public string Role { get; set; }
        public List<string> Paths { get; set; }

        public PermissionAccessDtoResponse(string module, string role)
        {
            this.Module = module;
            this.Role = role;
            this.Paths = new List<string>();
        }
    }

    public static class PermissionDtoExtension
    {
        public static List<PermissionAccessDtoResponse> ToPermissionAccessListReponse(this List<string> access)
        {
            var response = new List<PermissionAccessDtoResponse>();
            foreach (var x in access)
            {
                var splitted = x.Split('.', StringSplitOptions.RemoveEmptyEntries);
                response.Add(new PermissionAccessDtoResponse(splitted[0], splitted[1]));
            }
            return response;
        }
    }
        
}
