using Hris.Api.Settings;
using Microsoft.Identity.Web;
using System.Security.Claims;

namespace Hris.Api.Extensions
{
    public static class UserClaimsExtension
    {
        public static Guid GetUserObjectId(this ClaimsPrincipal principal)
        {
            Guid userId = Guid.Empty;
            string _userId = principal.GetObjectId() ?? string.Empty;
            
            Guid.TryParse(_userId, out userId);

            return userId;          
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
            => principal.Claims.Where(e => e.Type == ApplicationSettings.UserClaims?.UserEmail)?.FirstOrDefault()?.Value ?? string.Empty;

        public static string GetUserRole(this ClaimsPrincipal principal)
            => principal.Claims.Where(e => e.Type == ApplicationSettings.UserClaims?.UserRole)?.FirstOrDefault()?.Value ?? string.Empty;

        public static string GetUserId(this ClaimsPrincipal principal)
            => principal.Claims.Where(e=>e.Type == ApplicationSettings.UserClaims?.NameIdentifier)?.FirstOrDefault()?.Value ?? string.Empty;

        public static Guid GetUserIdentityId(this ClaimsPrincipal principal)
        {
            Guid userId = Guid.Empty;
            var user = principal.Claims.Where(e => e.Type == ApplicationSettings.UserClaims?.NameIdentifier)?.FirstOrDefault()?.Value ?? string.Empty;
            Guid.TryParse(user, out userId);

            return userId;
        }
    }
}
