using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.Employee;
using Hris.Api.Models.Request.Settings;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service;
using Hris.Business.Service.Common;
using Hris.Business.Service.EmployeeModule;
using Hris.Business.Service.v1;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Business.Service.v1.PayrollModule;
using Hris.Data.DTO;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Settings;
using Hris.Data.Repository;
using Hris.Resource.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Kiota.Http.HttpClientLibrary.Middleware;
using static QuestPDF.Helpers.Colors;
using Employee = Hris.Data.Models.Employee.Employee;

namespace Hris.Api.Controllers.v1.EmployeeModule
{
    public class EmployeeController : BaseApiController<EmployeeController>
    {
        private readonly IEmployeesService _employeesService;
        private readonly IUserSettingsServices _userSettingsServices;
        private readonly StorageCloudService _cloudeService;
        private readonly IAddressServices _addressService;
        private readonly IFamilyServices _familyServices;
        private readonly ISalaryHistoryServices _salaryHistoryServices;
        private readonly IAllowanceEntitlementServices _allowanceEntitlementServices;
        private readonly IStatutoryServices _statutoryServices;
        private readonly IEmployeesDeductionServices _employeeDeductionServices;
        private readonly IEmployeeStatutoriesServices _employeeStatutoriesServices;
        private readonly ICustomClaimPrincipal _custom;
        public EmployeeController(IRepository<Employee> repository,
            IEmployeesService employeesService,
            IUserSettingsServices userSettingsServices,
             StorageCloudService storageCloudService,
             IAddressServices addressService,
             IFamilyServices familyServices,
             ISalaryHistoryServices salaryHistoryServices,
             IAllowanceEntitlementServices allowanceEntitlementServices,
             IStatutoryServices statutoryServices,
             IEmployeesDeductionServices employeesDeductionServices,
             IEmployeeStatutoriesServices employeeStatutoriesServices,
             ICustomClaimPrincipal custom,
             ILogger<EmployeeController> logger) : base(logger)

        {
            _employeesService = employeesService;
            _userSettingsServices = userSettingsServices;
            _cloudeService = storageCloudService;
            _addressService = addressService;
            _familyServices = familyServices;
            _salaryHistoryServices = salaryHistoryServices;
            _allowanceEntitlementServices = allowanceEntitlementServices;
            _statutoryServices = statutoryServices;
            _employeeDeductionServices = employeesDeductionServices;
            _employeeStatutoriesServices = employeeStatutoriesServices;
            _custom = custom;
        }

        [HttpGet("profile"), HrisAuthorize]
        public async Task<IActionResult> GetProfile()
        {
            var employee = await _employeesService.GetProfile(await _custom.GetUserObjectId(User));
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Employee.EMPLOYEE, Resource.Responses.Employee.NOT_FOUND);
            return HrisOk(employee.ToResponse());
        }

        [HttpGet("resource"), HrisAuthorize]
        public async Task<IActionResult> GetResource([FromQuery] string? search)
        {
            var result = await _employeesService.GetResources(search);
            return HrisOk(result.Select(e => e.ToEmployeeNameResponse()));
        }

        [HttpGet("resource/manager"), HrisAuthorize(new string[] { HrisModules.Employees },
            new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> GerResourceManager()
        {
            var result = await _employeesService
                .GetEmployeeByPosition(Data.Models.Enum.PositionLevel.Manager);
            return HrisOk(result.Select(e => e.ToInitialEmployeeResponse()));
        }

        [HttpGet("resource/lead"), HrisAuthorize(new string[] { HrisModules.Employees },
            new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> GetResourceByLead()
        {
            var result = await _employeesService
             .GetEmployeeByPosition(Data.Models.Enum.PositionLevel.TeamLead);
            return HrisOk(result.Select(e => e.ToInitialEmployeeResponse()));
        }

        [HttpGet("resource/member"), HrisAuthorize(new string[] { HrisModules.Employees },
            new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> GetResourceByMember()
        {
            var result = await _employeesService
                .GetEmployeeByPosition(null);
            return HrisOk(result.Select(e => e.ToInitialEmployeeResponse()));
        }

        [HttpGet, HrisAuthorize(new string[] { HrisModules.Employees },
            new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> Get([FromQuery] EmployeeFilters filter)
        {
            var result = await _employeesService.Get(filter.Page, filter.Limit,
                filter.Search, filter.PositionId, filter.Status);

            return HrisOk(result.list.ToResponseList(false)
                .ToListResponse(filter.Page, filter.Limit, result.total));
        }

        [HttpGet("{id}"), HrisAuthorize(new string[] { HrisModules.Employees },
            new string[] { HrisRoles.Admin, HrisRoles.Hr, HrisRoles.Manager })]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var res = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User), false);
            var user = await _employeesService.GetById(id, true);
            return HrisOk(user.ToResponse(res.Settings.Timezone));
        }

        [HttpGet("settings/{id}"), HrisAuthorize]
        public async Task<IActionResult> GetSettings([FromRoute] Guid id)
        {
            var res = await _userSettingsServices.GetByEmployeeId(id);
            if (res == null)
                return HrisErrorNotFound(Resource.Responses.Employee.EMPLOYEE, Resource.Responses.Employee.NOT_FOUND);
            return HrisOk(res.ToResponse());
        }

        [HttpPut("settings"), HrisAuthorize]
        public async Task<IActionResult> UpdateSettings([FromBody] UserSettingsRequest request)
        {
            var res = await _userSettingsServices.Update(new UserSettings
            {
                Id = request.Id,
                EmployeeId = request.EmployeeId,
                Timezone = request.Timezone,
                UITheme = request.UITheme
            }, await _custom.GetUserObjectId(User));
            return HrisOk(res.ToResponse());
        }

        [HttpDelete, HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> Remove([FromQuery] Guid id)
        {
            var res = await _employeesService.DeleteEmployee(id, await _custom.GetUserObjectId(User));
            return HrisOk(res.ToInitialEmployeeResponse());
        }

        [HttpPost, HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> Add([FromBody] EmployeeDtoRequest request)
        {
            var result = await _employeesService.Add(request, await _custom.GetUserObjectId(User));
            return HrisOk(result.ToResponse());

        }
        [HttpPut, HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        public async Task<IActionResult> Update([FromBody] EmployeeDtoRequest request)
        {
            var result = await _employeesService.Update(_employeesService.ProcessEmployeeRequest(request), await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HttpPatch("profile"), HrisAuthorize]
        public async Task<IActionResult> UpdateProfileImage()
        {
            var form = Request.Form;
            var id = form["id"];

            if (string.IsNullOrEmpty(id))
                return HrisError(this.GetType().ToString(), Resource.Responses.Employee.ID_REQUIRED);

            var employee = await _employeesService.GetById(Guid.Parse(id));

            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), Resource.Responses.Employee.NOT_FOUND);

            if (!form.Files.Any())
                return HrisError(this.GetType().ToString(), Resource.Responses.Common.FILE_NOT_FOUND);

            var file = form!.Files!.FirstOrDefault()!;
            await _cloudeService.UploadAttachment(5, file, employee.Id);
            employee.ProfileUri = await _cloudeService.GetAttachmentUri(5, employee.Id);

            await _employeesService.Update(employee, await _custom.GetUserObjectId(User));
            return HrisOk(employee.ProfileUri);
        }

        [HttpPatch("avatar"), HrisAuthorize]
        public async Task<IActionResult> UpdateAvatarImage()
        {
            var form = Request.Form;
            var id = form["id"];

            if (string.IsNullOrEmpty(id))
                return HrisError(this.GetType().ToString(), Resource.Responses.Employee.ID_REQUIRED);

            var employee = await _employeesService.GetById(Guid.Parse(id));

            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), Resource.Responses.Employee.NOT_FOUND);

            if (!form.Files.Any())
                return HrisError(this.GetType().ToString(), Resource.Responses.Common.FILE_NOT_FOUND);

            var file = form!.Files!.FirstOrDefault()!;

            await _cloudeService.UploadEmployeeAvatar(file, employee.Id);
            employee.AvatarUri = (await _cloudeService.GetEmployeeAvatarUri(employee.Id)).FirstOrDefault();

            await _employeesService.Update(employee, await _custom.GetUserObjectId(User));
            return HrisOk(employee.ToResponse());
        }

        [HttpGet("manual"), HrisAuthorize]
        public async Task<IActionResult> GetManual()
        {
            var m = "https://ghrisstorage.blob.core.windows.net/hris-container/Global_Files/Gemango_Company_Manual1.0.pdf";
            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User), false);

            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Employee.EMPLOYEE, Resource.Responses.Employee.NOT_FOUND);

            if (employee.Manual == null || !employee.Manual.Equals(m))
                return HrisOk(m);
            else
                return HrisOk();
        }

        [HttpPatch("manual"), HrisAuthorize]
        public async Task<IActionResult> ManualConfirmation([FromQuery] string link)
        {
            var employee = await _employeesService.GetByObjectId(await _custom.GetUserObjectId(User), false);
            if (employee == null)
                return HrisErrorNotFound(Resource.Responses.Employee.EMPLOYEE, Resource.Responses.Employee.NOT_FOUND);
            employee.Manual = link;

            employee = await _employeesService.Update(employee, await _custom.GetUserObjectId(User));
            return HrisOk(employee.ToResponse());
        }

        [HrisAuthorize(new string[] { HrisModules.Employees, HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("entitlements")]
        public async Task<IActionResult> GetEmployeeEntitlements([FromQuery] EmployeeEntitlementsFilter_ filter)
        {
            return HrisOk(await _employeesService.GetEmployeeEntitlements(filter));
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{id}/files")]
        public async Task<IActionResult> GetEmployeeFiles([FromRoute] Guid id, [FromQuery] string? uri)
        {
            var employee = await _employeesService.GetById(id);

            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), Resource.Responses.Employee.NOT_FOUND);

            return HrisOk(await _cloudeService.GoToFolder(employee.Id, uri));
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost("{id}/files")]
        public async Task<IActionResult> UploadEmployeeFile([FromRoute] Guid id)
        {
            var employee = await _employeesService.GetById(id);

            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), Resource.Responses.Employee.NOT_FOUND);
            var form = Request.Form;
            var uri = form["uri"];
            var file = form!.Files!.FirstOrDefault()!;
            await _cloudeService.UploadAttachment(6, file, employee.Id, !uri.Equals("null") ? uri : string.Empty);
            return HrisOk(true);
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("{id}/files")]
        public async Task<IActionResult> RemoveEmployeeFile([FromRoute] Guid id, [FromQuery] string? uri, [FromQuery] string fileUri, [FromQuery] bool isFile)
        {
            var employee = await _employeesService.GetById(id);
            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), Resource.Responses.Employee.NOT_FOUND);

            await _cloudeService.RemoveFileOrFolder(6, employee.Id, uri, fileUri, isFile);
            return HrisOk(true);
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{id}/folder")]
        public async Task<IActionResult> AddFolder([FromRoute] Guid id, [FromQuery] string folderName, [FromQuery] string? uri)
        {
            var employee = await _employeesService.GetById(id);

            if (employee == null)
                return HrisErrorNotFound(this.GetType().ToString(), Resource.Responses.Employee.NOT_FOUND);

            if (!await _cloudeService.AddFolder(employee.Id, folderName, uri))
                return HrisError(this.GetType().ToString(), Resource.Responses.Common.SOMETHING_WENT_WRONG);

            return HrisOk(true);
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("address")]

        public async Task<IActionResult> DeleteAddress([FromQuery] Guid addressId)
        {

            var address = await _addressService.GetById(addressId);
            if (address == null)
                return HrisErrorNotFound("Address", "Address does not exist.");
            await _addressService.Delete(address, await _custom.GetUserObjectId(User));
            return HrisOk(true);
        }

        [HrisAuthorize]
        [HttpDelete("family")]
        public async Task<IActionResult> RemoveFamily(Guid id)
        {
            var existingFamily = await _familyServices.GetById(id);
            if (existingFamily == null)
                return HrisErrorNotFound("Family", "Family record does not exist.");
            await _familyServices.Delete(existingFamily, await _custom.GetUserObjectId(User));
            return HrisOk(true);
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("salary-history")]
        public async Task<IActionResult> RemoveSalaryHistory(Guid id)
        {
            var existingSH = await _salaryHistoryServices.GetById(id);
            if (existingSH == null)
                return HrisErrorNotFound("Salary History", "Salary History record does not exist.");
            await _salaryHistoryServices.Delete(existingSH, await _custom.GetUserObjectId(User));
            return HrisOk(existingSH);

        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("entitlements")]
        public async Task<IActionResult> RemoveAllowance(Guid id)
        {
            var existingEntitlement = await _allowanceEntitlementServices.GetById(id);
            if (existingEntitlement == null)
                return HrisErrorNotFound("Allowance Entitlement", "Allowance Entitlement record does not exist.");
            await _allowanceEntitlementServices.Delete(existingEntitlement.Id, await _custom.GetUserObjectId(User));
            return HrisOk(existingEntitlement);
        }

        [HrisAuthorize(new string[] { HrisModules.Employees, HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("statutory")]
        public async Task<IActionResult> RemoveStatutory(Guid id)
        {
            var existingStatutory = await _statutoryServices.GetById(id);
            if (existingStatutory == null)
                return HrisErrorNotFound("Statutory", "Statutory record does not exist.");
            await _statutoryServices.Delete(existingStatutory, await _custom.GetUserObjectId(User));
            return HrisOk(existingStatutory);
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpGet("profile/certificate-of-employment")]
        public async Task<IActionResult> GetProfileForCertificate()
        {
            var data = await _employeesService.GetProfileForCertificate(await _custom.GetUserObjectId(User));
            if (data is null) return HrisErrorNotFound(Resource.Responses.Employee.EMPLOYEE, Resource.Responses.Employee.NOT_FOUND);
            return HrisOk(data.ToResponse(data.Settings.Timezone!));
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpPost("{employeeId}/request/certificate-of-employment")]
        public async Task<IActionResult> UploadCertificate([FromRoute] Guid employeeId)
        {
            var form = Request.Form;
            var file = form!.Files!.FirstOrDefault()!;
            await _cloudeService.UploadAttachment(9, file, employeeId);

            var url = await _cloudeService.GetAttachmentUri(9, employeeId);
            return HrisOk(url);
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpGet("{employeeId}/request/certificate-of-employment")]
        public async Task<IActionResult> GetCertificateEmploymentInfo([FromRoute] Guid employeeId)
        {
            try
            {
                var data = await _employeesService.GetCertificateEmploymentResponse(employeeId);
                if (data is null) return HrisError("Employee", "Error in requesting data");
                return HrisOk(data);
            }
            catch (Exception ex)
            {
                return HrisError("Exception", ex.Message);
            }
        }



        [HttpGet("{objectId}/view/certificate-of-employment")]
        public async Task<IActionResult> ViewCertificate([FromRoute] Guid objectId)
        {
            try
            {
                var employee = await _employeesService.GetByObjectId(objectId);

                if (employee == null)
                    throw new NullReferenceException();

                var url = await _cloudeService.GetAttachmentUri(9, employee.Id);

                return HrisOk(url);
            }
            catch (Exception ex)
            {
                return HrisError("Exception", ex.Message);
            }
        }


        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpGet("{employeeId}/deductions")]
        public async Task<IActionResult> GetEmployeeDeduction([FromRoute] Guid employeeId)
        {
            var result = await _employeeDeductionServices.GetDeductionByEmployeeId(employeeId);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpGet("deduction/{Id}")]
        public async Task<IActionResult> GetDeduction([FromRoute] Guid Id)
        {
            var result = await _employeeDeductionServices.GetById(Id);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpPost("deduction")]
        public async Task<IActionResult> AddDeduction([FromBody] EmployeesDeductionDtoRequest req)
        {
            try
            {
                //var isExist = await _employeeDeductionServices.isDeductionTypeExist(req.EmployeeId, req.DeductionTypesId);
                //if (isExist)
                //    return HrisError("Deduction", "Deduction Types Already Exist.");

                var result = await _employeeDeductionServices.Add(req, await _custom.GetUserObjectId(User));
                if (result is null) return HrisError("Error", "Error in saving employee deduction");
                return HrisOk(result);
            }
            catch (Exception ex)
            {
                return HrisError("Exception", ex.Message);
            }
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpGet("deduction/exists")]
        public async Task<IActionResult> isEmployeeDeductionExist([FromQuery] Guid deductionTypeId, PayrollPeriod period, Guid employeeId)
        {
            var result = await _employeeDeductionServices.IsExist(f => f.DeductionTypesId.Equals(deductionTypeId)
                    && f.Period.Equals(period)
                    && f.EmployeeId.Equals(employeeId));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpPut("deduction")]
        public async Task<IActionResult> UpdateDeduction([FromBody] EmployeesDeductionDtoRequest req)
        {
            try
            {
                var result = await _employeeDeductionServices.Update(req, await _custom.GetUserObjectId(User));
                if (result is null) return HrisError("Error", "Error in updating employee deduction");
                return HrisOk(result);
            }
            catch (Exception ex)
            {
                return HrisError("Exception", ex.Message);
            }
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        [HttpDelete("deduction/{Id}")]
        public async Task<IActionResult> DeleteDeduction([FromRoute] Guid Id)
        {
            try
            {
                var result = await _employeeDeductionServices.Delete(Id, await _custom.GetUserObjectId(User));
                if (result is null) return HrisError("Error", "Error in deleting employee deduction");
                return HrisOk(result);
            }
            catch (Exception ex)
            {
                return HrisError("Exception", ex.Message);
            }
        }

        //[HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        //[HttpGet("{employeeId}/statutories")]
        //public async Task<IActionResult> GetStatutoriesByEmployeeId([FromRoute] Guid employeeId)
        //{
        //    var result = await _employeeStatutoriesServices.GetByEmployeeId(employeeId);
        //    return HrisOk(result);
        //}

        //[HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        //[HttpGet("statutories/{id}")]
        //public async Task<IActionResult> GetStatutoriesById([FromRoute] Guid id)
        //{
        //    var result = await _employeeStatutoriesServices.GetById(id);
        //    return HrisOk(result);
        //}

        //[HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        //[HttpPost("statutories")]
        //public async Task<IActionResult> AddEmployeeStatutories([FromBody] EmployeeStatutoriesDtoRequest req)
        //{
        //    var result = await _employeeStatutoriesServices.Add(req, await _custom.GetUserObjectId(User));
        //    if (result is null) return HrisError("Error", "Error in saving employee statutories");
        //    return HrisOk(result);
        //}

        //[HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        //[HttpPut("statutories")]
        //public async Task<IActionResult> UpdateEmployeeByIdStatutories([FromBody] EmployeeStatutoriesDtoRequest req)
        //{
        //    var result = await _employeeStatutoriesServices.Update(req, await _custom.GetUserObjectId(User));
        //    if (result is null) return HrisError("Error", "Error in updating employee statutories");
        //    return HrisOk(result);
        //}

        //[HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        //[HttpPut("{employeeId}/statutories")]
        //public async Task<IActionResult> UpdateEmployeeByEmployeeIdStatutories([FromRoute] Guid employeeId, [FromBody] EmployeeStatutoriesDtoRequest req)
        //{
        //    var result = await _employeeStatutoriesServices.UpdateByEmployeeId(req, await _custom.GetUserObjectId(User));
        //    if (result is null) return HrisError("Error", "Error in updating employee statutories");

        //    return HrisOk(result);
        //}


        //[HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        //[HttpDelete("{employeeId}/statutories")]
        //public async Task<IActionResult> DeleteStatutoriesByEmployeeId([FromRoute] Guid employeeId)
        //{
        //    var result = await _employeeStatutoriesServices.DeleteByEmployeeId(employeeId, await _custom.GetUserObjectId(User));
        //    if (!result) return HrisError("Error", "Error in deleting employee statutories");

        //    return HrisOk(result);
        //}

        //[HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Manager, HrisRoles.Hr })]
        //[HttpDelete("statutories/{id}")]
        //public async Task<IActionResult> DeleteStatutoriesById([FromRoute] Guid id)
        //{
        //    var result = await _employeeStatutoriesServices.Delete(id, await _custom.GetUserObjectId(User));
        //    if (!result) return HrisError("Error", "Error in deleting employee statutories");

        //    return HrisOk(result);
        //}

    }
}
