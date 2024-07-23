using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Request.Employee;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service;
using Hris.Business.Service.Administrator;
using Hris.Business.Service.Common;
using Hris.Business.Service.EmployeeModule;
using Hris.Business.Service.GraphApi;
using Hris.Data.Models.Administrator;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Settings;
using Hris.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Hris.Api.Controllers
{
    public class AccountController : BaseController<AccountController>
    {
        private readonly EmployeeService employeeService;
        private readonly StorageCloudService _storageCloudService;
        private readonly AzureAdService azureAdService;
        private readonly UserSettingsService _userSettingsService;
        private readonly PermissionService _permissionService;

        public AccountController(IRepository<Employee> repository,
            StorageCloudService storageCloudService,
            IRepository<UserSettings> userSettingsRepository,
            IRepository<Permission> permissionRepository,
            IRepository<Employee> employeeRepository,
            AzureAdService azureAdService)
        {
            employeeService = new EmployeeService((Repository<Employee>)repository);
            _storageCloudService = storageCloudService;
            this.azureAdService = azureAdService;
            _userSettingsService = new UserSettingsService(userSettingsRepository);
            _permissionService = new PermissionService((Repository<Permission>)permissionRepository, employeeRepository);
        }
 
        [HttpGet("invite"), HrisAuthorize(new string[] { HrisModules.Admin }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        public async Task<IActionResult> InviteUser([FromQuery] string email)
        {
            this.azureAdService.StartService();
            return HrisOk(await this.azureAdService.InviteUser(email));
        }

        [HrisAuthorize]
        [HttpGet("isOnBoarding")]
        public async Task<IActionResult> IsOnBoardingUser()
        {
            var employee = await employeeService.GetByObjectId(User.GetUserObjectId(), false);
            return HrisOk(employee == null || employee.ObjectId == null || employee.ObjectId == Guid.Empty);
        }

        [HrisAuthorize]
        [HttpPost("OnBoardingUser")]
        public async Task<IActionResult> OnBoardingUser([FromBody] EmployeeRequest employee)
        {
            var newEmployee = new Employee();

            var employeeDb = await employeeService.GetByObjectId(User.GetUserObjectId());

            bool isOnBoarding = (employeeDb == null || employeeDb.ObjectId == null || employeeDb.ObjectId == Guid.Empty);

            try
            {
                if (isOnBoarding)
                {
                    newEmployee = new Employee
                    {
                        ObjectId = User.GetUserObjectId(),
                        Email = employee.Email,
                        Firstname = employee.Firstname,
                        Lastname = employee.Lastname,
                        Middlename = employee.Middlename,
                        DateOfBirth = employee.DateOfBirth,
                        Gender = employee.Gender,
                        BloodType = employee.BloodType,
                        Citizenship = employee.Citizenship,
                        CivilStatus = employee.CivilStatus,
                        BirthPlace = employee.Birthplace,
                        Contact = employee.ContactNumber,
                        HomePhone = employee.ContactNumber,
                        DateHired = employee.DateHired,
                        Nickname = employee.Nickname,
                        Religion = employee.Religion,
                        Addresses = employee.Addresses?
                           .Select(a => new Hris.Data.Models.Employee.Address
                           {
                               Active = true,
                               Country = a.Country,
                               State = a.State,
                               City = a.City,
                               Village = a.Village,
                               Street = a.Street,
                               PostalCode = a.PostalCode,
                               IsRenting = a.IsRenting,
                               LandLord = a.IsRenting ? a.LandLord : string.Empty,
                               AddressType = a.Type,
                           }).ToList(),
                        Family = employee.Families?
                           .Select(f => new Family
                           {
                               Active = true,
                               Name = f.Name,
                               Relationship = f.RelationshipType,
                               IsEmergencyContact = f.IsEmergencyContact,
                               DateOfBrith = f.DateOfBirth,
                               IsColleauge = f.IsColleague,
                               ContactNumber = f.ContactNumber,
                               Address = f.Address != null ? new Data.Models.Employee.Address
                               {
                                   Country = f.Address.Country,
                                   State = f.Address.State,
                                   City = f.Address.City,
                                   Village = f.Address.Village,
                                   Street = f.Address.Street,
                                   PostalCode = f.Address.PostalCode,
                                   IsRenting = f.Address.IsRenting,
                                   LandLord = f.Address.IsRenting ? f.Address.LandLord : string.Empty,
                               } : null,
                           }).ToList(),
                        Code = string.Empty,
                        EmployeeStatus = EmployeeStatus.Probationary,
                        BankNo = string.Empty,
                        Settings = new UserSettings { 
                            Timezone = Defaults.DEF_TIMEZONE
                        },
                        Active = true
                    };

                    await employeeService.Add(newEmployee);
                    await employeeService.SaveChangesAsync(User.GetUserObjectId());

/*                    await _userSettingsService.AddDefault(newEmployee.Id, User.GetUserObjectId());
*/
                    await _permissionService.SetNewEmployeePermissions(User.GetUserObjectId(), newEmployee.Id);
                }

            }
            catch (Exception ex)
            {
                HrisError("Exception", ex.Message);
            }

            return HrisOk(newEmployee.ToInitialEmployeeResponse());
        }

        [HttpGet("profile"), HrisAuthorize]
        public async Task<IActionResult> GetUserProfile()
        {
            var employee = await employeeService.GetByObjectId(User.GetUserObjectId(), false);

            if (employee == null)
                employee = await employeeService.GetByEmail(User.GetUserEmail());

            if (employee != null && employee.ObjectId == null)
            {
                employee.ObjectId = User.GetUserObjectId();
                await employeeService.Update(employee, employee.Id);
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

            var employee = await employeeService.GetByObjectId(User.GetUserObjectId());

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

                    await employeeService.Update(employee);
                    await employeeService.SaveChangesAsync(User.GetUserObjectId());

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
            try
            {
                var d = await employeeService.GetById(id);

                if (d == null)
                    throw new Exception();

                await _userSettingsService.AddDefault(id, User.GetUserObjectId());
                await _permissionService.SetNewEmployeePermissions(User.GetUserObjectId(), id);

                return HrisOk(true);
            }
            catch (Exception)
            {
                return HrisOk(false);
            }
        }
    }
}
