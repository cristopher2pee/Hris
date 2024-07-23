using Hris.Data.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class AccessDto
    {
    }

    public class AccessDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Module { get; set; }
        public List<string> Roles { get; set; }
    }

    public class AccessDtoRequest : BaseDtoRequest
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Module { get; set; }
        public List<string> Roles { get; set; }
    }

    public static class AccessExtension_
    {
        public static AccessDtoResponse ToAccessResponse(this Access access)
        {
            return new AccessDtoResponse
            {
                Id = access.Id,
                Name = access.Name,
                Path = access.Path,
                Module = access.Module,
                Roles = access.Roles.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
            };
        }
    }

}
