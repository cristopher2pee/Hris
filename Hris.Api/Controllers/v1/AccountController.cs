using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Hris.Data.Models.Employee;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Api.Models.Request.Employee;
using Hris.Data.DTO;
using Microsoft.VisualBasic;
using Hris.Business.Service.v1;
using Hris.Business.Service.v1.AdministratorModule;
using Hris.Business.Service.EmployeeModule;
using Hris.Business.Service.Common;
using Hris.Business.Service.Administrator;
using Hris.Business.Service;
using Hris.Api.Security;
using Hris.Business.Service.GraphApi;
using Hris.Data.Models.Enum;
using Microsoft.AspNetCore.Identity;
using Hris.Api.Utilities;
using Hris.Business.Service.Mail;
using Hris.Data.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using Hris.Api.Controllers.v1.PayrollModule;

namespace Hris.Api.Controllers.v1
{
    public class AccountController : BaseApiController<AccountController>
    {
        private readonly IEmployeesService _employeesService;
        private readonly IAccountServices _accountServices;
        private readonly IPermissionServices _permissionServices;
        private readonly StorageCloudService _storageCloudService;
        private readonly IUserSettingsServices _userSettingServices;
        private readonly AzureAdService _azureAdService;
        private readonly UserManager<Data.Models.IdentityServer.User> _userManager;
        private readonly SignInManager<Data.Models.IdentityServer.User> _signManager;
        private readonly ICustomClaimPrincipal _custom;
        private readonly IMailkitServices _mailkitServices;
        private readonly IAuthInviteService _authInviteService;

        public AccountController(IEmployeesService employeesService,
            IAccountServices accountServices,
            IPermissionServices permissionServices,
            StorageCloudService storageCloudService,
            IUserSettingsServices userSettingsServices,
            AzureAdService azureAdService,
             UserManager<Data.Models.IdentityServer.User> userManager,
             SignInManager<Data.Models.IdentityServer.User> signManager,
             ICustomClaimPrincipal custom,
             IMailkitServices mailkitServices,
             IAuthInviteService authInviteService,
              ILogger<AccountController> logger) : base(logger)
        {
            _employeesService = employeesService;
            _accountServices = accountServices;
            _permissionServices = permissionServices;
            _storageCloudService = storageCloudService;
            _userSettingServices = userSettingsServices;
            _azureAdService = azureAdService;
            _signManager = signManager;
            _userManager = userManager;
            _custom = custom;
            _mailkitServices = mailkitServices;
            _authInviteService = authInviteService;
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] UserDtoRequest reg)
        //{
        //    try
        //    {
        //        var user = new Data.Models.IdentityServer.User
        //        {
        //            Email = reg.Email,
        //            EmployeeId = reg.EmployeeId,
        //            UserName = reg.Email,
        //            PasswordHash = reg.Password
        //        };

        //        var result = await _userManager.CreateAsync(user, user.PasswordHash!);
        //        if(result.Succeeded)
        //        {
        //            return HrisOk("Successfully Register User.");
        //        }

        //        return HrisError("Register", "Error in registering user.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return HrisError(ex.Source, ex.Message);
        //    }
        //}

        [HrisAuthorize]
        [HttpGet("isAdmin")]
        public async Task<IActionResult> IsAdmin([FromQuery] Modules module)
        {
            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User), false);
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Employee.EMPLOYEE, Resource.Responses.Employee.NOT_FOUND);

            var permission = await _permissionServices.GetRoleByModule(employee.Id, module);
            return HrisOk(permission.Equals(Roles.Admin) || permission.Equals(Roles.Hr));
        }

        [HttpGet("invite"), HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        public async Task<IActionResult> InviteUser([FromQuery] string email)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
                return HrisError("USER", Resource.Responses.Common.USER_EXISTING);

            if (email.IsNullOrEmpty())
                return HrisError("USER", "User Email Empty.");

            var result = await _authInviteService.Invite(email, await _custom.GetUserObjectId(User));
            return HrisOk(await _mailkitServices.InviteUser(email, result.Token));

        }

        [HttpGet("invite/verify")]
        public async Task<IActionResult> VerifyInvite([FromQuery] string email)
        {
            if (email.IsNullOrEmpty())
                return HrisError("USER", "User Email Empty.");

            return HrisOk(await _authInviteService.Verify(email));
        }

        [HttpDelete("invite")]
        public async Task<IActionResult> DeleteInvite([FromQuery] string email)
        {
            var existing = await _authInviteService.GetByEmail(email);

            if (existing == null)
                return HrisErrorNotFound("USER", "User not found.");

            await _authInviteService.Delete(existing, await _custom.GetUserObjectId(User));
            return HrisOk(true);
        }

        [HrisAuthorize, HttpGet("on-boarding")]
        public async Task<IActionResult> CheckUserIfOnboarding()
        {
            var employee = await _employeesService.GetByEmail(User.GetUserEmail());
            return HrisOk(employee == null || employee.ObjectId == null || employee.ObjectId == Guid.Empty);
        }

        [HrisAuthorize]
        [HttpPost("on-boarding")]
        public async Task<IActionResult> OnBoardingUser([FromBody] EmployeeDtoRequest employee)
        {
            var employeeDb = await _employeesService.GetByEmail(User.GetUserEmail());

            bool isOnBoarding = (employeeDb == null || employeeDb.ObjectId == null || employeeDb.ObjectId == Guid.Empty);

            if (isOnBoarding)
            {
                var existingUser = await _userManager.FindByEmailAsync(employeeDb.Email);

                if (existingUser == null)
                    return HrisErrorNotFound("USER", "User not found.");

                var result = await _accountServices.OnBoardingUser(employee, Guid.Parse(existingUser.Id));
                if (result is null) return HrisError("Onboarding", "Error in saving onboarding.");

                await _permissionServices.SetNewEmployeePermissions(await _custom.GetUserObjectId(User), result.Id);
                return HrisOk(result.ToInitialEmployeeResponse_());

            }
            else
            {
                return HrisOk(new Employee().ToInitialEmployeeResponse_());
            }
        }

        [HttpGet("profile"), HrisAuthorize]
        public async Task<IActionResult> GetUserProfile()
        {
            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User), false);

            if (employee == null)
                employee = await _employeesService.GetByEmail(User.GetUserEmail());

            if (employee != null && employee.ObjectId == null)
            {
                employee.ObjectId = await _custom.GetUserObjectId(User);
                await _employeesService.Update(employee, employee.Id);
            }
            else
                return HrisOk();

            return HrisOk(employee.ToResponse());
        }

        [HrisAuthorize]
        [HttpPost("avatar")]
        public async Task<IActionResult> UploadAvatar()
        {

            var form = Request.Form;

            List<string> avatarUri = new List<string>();

            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User));

            if (employee != null)
            {
                if (form.Files?.Any() ?? true)
                {
                    if (form?.Files?.Sum(x => x.Length) > (long)3 * 1024 * 1024)
                    {
                        return HrisError("ImageSize.TooBig", "Total size of Images exceeded 3Mb");
                    }

                    await _storageCloudService.UploadEmployeeAvatar(form!.Files!.FirstOrDefault()!, employee.Id);

                    avatarUri = await _storageCloudService.GetEmployeeAvatarUri(employee.Id);

                    employee.AvatarUri = avatarUri.FirstOrDefault();
                    await _employeesService.Update(employee, await _custom.GetUserObjectId(User));
                }

            }
            else
            {
                return HrisError("User.Record", "Cannot find user record");
            }
            return HrisOk(employee.AvatarUri);
        }

        [HttpGet("defaults/{id}"), HrisAuthorize]
        public async Task<IActionResult> AssignDefaults([FromRoute] Guid id)
        {
            var d = await _employeesService.GetById(id);
            if (d == null)
                return HrisErrorNotFound("USER", "User not found.");

            await _userSettingServices.AddDefault(id, await _custom.GetUserObjectId(User));
            await _permissionServices.SetNewEmployeePermissions(await _custom.GetUserObjectId(User), id);

            return HrisOk(true);
        }
    }
}
