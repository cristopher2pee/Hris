using Hris.Api.Controllers;
using Hris.Api.Extensions;
using Hris.Api.Models.Response;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.Administrator;
using Hris.Data.DataContext;
using Hris.Resource.Responses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Identity.Web;
using System.Reflection;
using System.Security.Claims;

namespace Hris.Api.Middleware
{
    public class HrisAuthorizationFilter : IAuthorizationFilter
    {
        private readonly string[] modules;
        private readonly string[] roles;
        public HrisAuthorizationFilter(string[] module, string[]? roles = null)
        {
            this.modules = module;


            if (roles == null || roles.Length == 0)
            {
                roles = new string[] { HrisRoles.User };
            }

            this.roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity?.IsAuthenticated ?? false)
            {
                context.Result = new HrisErrorUnAuthorized(Common.ACCESS_DENIED, Common.ACCESS_DENIED_MESSAGE);
                return;
            }

            var authUtil = context.HttpContext.RequestServices.GetRequiredService<ICustomClaimPrincipal>();
            var permissionService = context.HttpContext.RequestServices.GetRequiredService<PermissionService>();
            var objectId = authUtil.GetUserObjectId(context.HttpContext.User).Result;
            var assignedPermission = permissionService.GetPermissionsAsync(objectId).Result;


            if (!(roles.Length == 1 && roles.Contains(HrisRoles.User)))
            {

                if (assignedPermission != null)
                {

                    bool hasAccess = false;
                    foreach (var role in roles)
                        foreach (var module in this.modules)
                        {
                            hasAccess = !string.IsNullOrEmpty(assignedPermission.Where(e => e.Contains($"{module}.{role}", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault());
                            if (hasAccess)
                                return;
                        }


                    if (!hasAccess)
                    {
                        context.Result = new HrisError("Hris.Permission", "User doesn't have access to this page");
                        return;
                    }
                }
                else
                {
                    context.Result = new HrisError("Hris.Permission", $"User doesnt have access to {this.modules} module");
                    return;
                }

            }
        }


    }


    public class HrisAuthorizeAttribute : TypeFilterAttribute
    {
        public HrisAuthorizeAttribute(string[] module, string[] roles) : base(typeof(HrisAuthorizationFilter))
        {
            Arguments = new object[] { module, roles };
        }

        public HrisAuthorizeAttribute() : base(typeof(HrisAuthorizationFilter))
        {
            Arguments = new object[] { new string[] { }, new string[] { HrisRoles.User } };
        }
    }



}
