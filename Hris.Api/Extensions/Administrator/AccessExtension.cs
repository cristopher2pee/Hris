using Hris.Api.Models.Response.Administrator;
using Hris.Data.Models.Administrator;

namespace Hris.Api.Extensions.Administrator
{
    public static class AccessExtension
    {
        public static AccessReponse ToAccessResponse(this Access access)
        {
            return new AccessReponse
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
