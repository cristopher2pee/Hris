using Hris.Api.Models.Response.Administrator;

namespace Hris.Api.Extensions.Administrator
{
    public static class PermissionExtension
    {
        public static List<PermissionAccessResponse> ToPermissionAccessListReponse(this List<string> access)
        { 
            var response = new List<PermissionAccessResponse>();

            foreach (var x in access) 
            { 
                var splitted = x.Split('.', StringSplitOptions.RemoveEmptyEntries);
                response.Add(new PermissionAccessResponse(splitted[0], splitted[1]));
            }
            return response;
        }
    }
}
