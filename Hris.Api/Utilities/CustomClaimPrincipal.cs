using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.Models.IdentityServer;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Hris.Api.Utilities
{
    public interface ICustomClaimPrincipal
    {
        Task<Guid> GetUserObjectId(ClaimsPrincipal user);

    }
    public class CustomClaimPrincipal : ICustomClaimPrincipal
    {
        private readonly UserManager<Data.Models.IdentityServer.User> _userManager;
        private readonly SignInManager<Data.Models.IdentityServer.User> _signInManager;
        private readonly IEmployeesService _employeesService;
        public CustomClaimPrincipal(UserManager<Data.Models.IdentityServer.User> userManager, SignInManager<Data.Models.IdentityServer.User> signInManager, IEmployeesService employeesService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _employeesService = employeesService;
        }
        public async Task<Guid> GetUserObjectId(ClaimsPrincipal user)
        {
            var data = await _userManager.GetUserAsync(user);
            if (data == null) return Guid.Empty;

            var employee = await _employeesService.GetEmployee(f => f.Id.Equals(data.EmployeeId));
            return employee.ObjectId ?? Guid.Empty;
        }
    }
}
