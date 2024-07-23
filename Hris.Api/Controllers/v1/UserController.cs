using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Middleware;
using Hris.Api.Models.Response;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.EmployeeModule;
using Hris.Business.Service.Mail;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.ODataErrors;
using Microsoft.Win32;
using static QuestPDF.Helpers.Colors;

namespace Hris.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController<UserController>
    {

        private readonly UserManager<Data.Models.IdentityServer.User> _userManager;
        private readonly SignInManager<Data.Models.IdentityServer.User> _signManager;
        private readonly IEmployeesService _employeeService;
        private readonly ICustomClaimPrincipal _custom;
        private readonly IMailkitServices _mailkitServices;

        public UserController(
                        UserManager<Data.Models.IdentityServer.User> userManager,
                        SignInManager<Data.Models.IdentityServer.User> signManager,
                        IEmployeesService employeesService,
                        ICustomClaimPrincipal customClaimPrincipal,
                        IMailkitServices mailkitServices,
                        ILogger<UserController> logger) : base(logger)

        {
            _userManager = userManager;
            _signManager = signManager;
            _employeeService = employeesService;
            _custom = customClaimPrincipal;
            _mailkitServices = mailkitServices;
        }


        [HrisAuthorize]
        [HttpPost("register/employee")]
        public async Task<IActionResult> RegisterExistingEmployee([FromBody] UserDtoRequest req)
        {
            var employee = await _employeeService.GetEmployee(f => f.Id.Equals(req.EmployeeId));
            if (employee is null) return HrisErrorNotFound(Resource.Responses.Common.ERROR, Resource.Responses.Common.USER_NOT_FOUND);
            var user = new Data.Models.IdentityServer.User
            {
                Email = employee.Email,
                EmployeeId = employee.Id,
                UserName = employee.Email,
                PasswordHash = req.newPassword
            };

            var toSave = await _userManager.CreateAsync(user, user.PasswordHash!);
            if (toSave.Succeeded)
            {
                var userToUpdate = await _userManager.FindByEmailAsync(user.Email);
                if (userToUpdate != null)
                {
                    employee.ObjectId = Guid.Parse(userToUpdate.Id);
                    await _employeeService.Update(employee, await _custom.GetUserObjectId(User));
                }
                return HrisOk(new { success = toSave.Succeeded });
            }
            else
                return HrisErrorBadRequest(toSave.Errors.ToErrorDetailList().ToList());

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateAccountRequest req)
        {
            var existingUser = await _userManager.FindByEmailAsync(req.email);
            if (existingUser is not null) return HrisError(Resource.Responses.Common.ERROR, Resource.Responses.Common.USER_EXISTING);

            var employee = await _employeeService.CreateDummy(req.email);

            var user = new Data.Models.IdentityServer.User
            {
                Email = req.email,
                EmployeeId = employee.Id,
                UserName = req.email,
                PasswordHash = req.password
            };

            var toSave = await _userManager.CreateAsync(user, user.PasswordHash!);
            if (toSave.Succeeded)
            {
                return HrisOk(new { success = toSave.Succeeded });
            }
            else
                return HrisErrorBadRequest(toSave.Errors.ToErrorDetailList().ToList());

        }



        //[HrisAuthorize]
        //[HttpPost("register/employee")]
        //public async Task<IActionResult> RegisterNewEmployee([FromBody] RegisterDtoRequest req)
        //{
        //    try
        //    {
        //        Data.Models.Employee.Employee employee = null;
        //        var result = await _employeeService.GetEmployee(f => f.Email.ToLower().Trim().Equals(req.EmployeeDtoRequest.Email.ToLower().Trim()));
        //        if (result != null)
        //        {
        //            req.EmployeeDtoRequest.Id = result.Id;
        //            employee = await _employeeService.Update(_employeeService.ProcessEmployeeRequest(req.EmployeeDtoRequest), await _custom.GetUserObjectId(User));
        //        }
        //        else
        //            employee = await _employeeService.Add(req.EmployeeDtoRequest, await _custom.GetUserObjectId(User));

        //        var user = new Data.Models.IdentityServer.User
        //        {
        //            Email = employee.Email,
        //            EmployeeId = employee.Id,
        //            UserName = employee.Email,
        //            PasswordHash = req.Password
        //        };

        //        var toSave = await _userManager.CreateAsync(user, user.PasswordHash!);
        //        if (toSave.Succeeded)
        //        {
        //            var userToUpdate = await _userManager.FindByEmailAsync(user.Email);
        //            if (userToUpdate != null)
        //            {
        //                var toUpdate = await _employeeService.GetById(employee.Id);
        //                if (toUpdate != null)
        //                {
        //                    toUpdate.ObjectId = Guid.Parse(userToUpdate.Id);
        //                    await _employeeService.Update(toUpdate, await _custom.GetUserObjectId(User));
        //                }

        //            }
        //            return HrisOk(new { success = toSave.Succeeded });
        //        }
        //        else
        //        {
        //            //    await _employeeService.Delete(employee.Id, await _custom.GetUserObjectId(User));
        //            var error = toSave.Errors
        //                  .Select(e => new Api.Models.Response.Error.ErrorDetails(e.Code, e.Description)).ToList();
        //            return HrisErrorBadRequest(error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return HrisError(Resource.Responses.Common.ERROR, ex.Message);
        //    }

        //}

        [HrisAuthorize]
        [HttpPost("request/change-email")]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailRequest req)
        {
            var user = await _userManager.FindByEmailAsync(req.OldEmail);
            if (user == null) return HrisErrorNotFound(Resource.Responses.Common.ERROR, Resource.Responses.Common.USER_NOT_FOUND);

            user.Email = req.NewEmail;
            user.UserName = req.NewEmail;

            var toUpdate = await _userManager.UpdateAsync(user);
            if (toUpdate.Succeeded)
                return HrisOk(new { success = toUpdate.Succeeded });
            else
                return HrisErrorBadRequest(toUpdate.Errors.ToErrorDetailList().ToList());
        }


        [HrisAuthorize]
        [HttpPost("request/change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest req)
        {
            var user = await _userManager.FindByEmailAsync(req.email);
            if (user == null) return HrisErrorNotFound(Resource.Responses.Common.ERROR, Resource.Responses.Common.USER_NOT_FOUND);

            var toChanged = await _userManager.ChangePasswordAsync(user, req.oldPassword, req.newPassword);
            if (toChanged.Succeeded)
                return HrisOk(new { success = toChanged.Succeeded });
            else
                return HrisErrorBadRequest(toChanged.Errors.ToErrorDetailList().ToList());

        }

        [HttpGet("request/forgot-token")]
        public async Task<IActionResult> RequestResetToken([FromQuery] string email)
        {

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return HrisErrorNotFound(Resource.Responses.Common.ERROR, Resource.Responses.Common.USER_NOT_FOUND);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var isSend = await _mailkitServices.ForgotPassword(token, email);


            if (isSend && !string.IsNullOrEmpty(token))
                return HrisOk(new { Success = true, Description = "Please check your email" });
            else
                return HrisError("Error", "Encounter error during generating token");

        }


        [HttpGet("request/forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromQuery] ResetPasswordRequest req)
        {
            var user = await _userManager.FindByEmailAsync(req.email);
            if (user == null) return HrisErrorNotFound(Resource.Responses.Common.ERROR, Resource.Responses.Common.USER_NOT_FOUND);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var toReset = await _userManager.ResetPasswordAsync(user, token, req.password);

            if (toReset.Succeeded)
                return HrisOk(new { success = toReset.Succeeded });
            else
                return HrisErrorBadRequest(toReset.Errors.ToErrorDetailList().ToList());

        }
    }
}
