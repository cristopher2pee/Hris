using Hris.Api.Controllers.v1.PayrollModule;
using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Models.Filters;
using Hris.Api.Models.Request.Employee;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.Common;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.EmployeeModule
{
    public class DepartmentController : BaseApiController<DepartmentController>
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IEmployeesService _employeeService;
        private readonly StorageCloudService _storageCloudService;
        private readonly ICustomClaimPrincipal _custom;
        public DepartmentController(IDepartmentServices departmentServices,
            IEmployeesService employeeService,
            StorageCloudService storageCloudService,
            ICustomClaimPrincipal custom,
            ILogger<DepartmentController> logger) : base(logger)
        {
            _departmentServices = departmentServices;
            _employeeService = employeeService;
            _storageCloudService = storageCloudService;
            _custom = custom;

        }

        [HttpGet("resource"), HrisAuthorize]
        public async Task<IActionResult> GetResource([FromQuery] string? search)
        {
            var result = await _departmentServices.GetResource();
            return HrisOk(result.ToListResponse_());
        }

        [HttpGet("{id}"), HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _departmentServices.GetById(id);
            return HrisOk(result.ToResponse_());
        }

        [HttpGet, HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        public async Task<IActionResult> GetAll([FromQuery] DepartmentFilter_ filter)
        {
            var result = await _departmentServices.GetAll(filter);
            return HrisOk(result);
        }

        [HttpPost, HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentDtoRequest request)
        {
            var employee = await _employeeService.GetById(request.ManagerId);
            if (employee is null)
                return HrisErrorNotFound(Resource.Responses.Employee.EMPLOYEE, Resource.Responses.Employee.NOT_FOUND);

            var isExist = await _departmentServices.IsNameExisting(request.Name);
            if (isExist)
                return HrisError("Department", $"Department with name {request.Name} already exist");

            var result = await _departmentServices.AddDepartment(request, await _custom.GetUserObjectId(User));
            if (result is null)
                return HrisError("Department", "Error in saving department");

            return HrisOk(result);
        }

        [HttpPut, HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentDtoRequest request)
        {
            var result = await _departmentServices.UpdateDepartment(request, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Department", "Error in updating department");

            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Employees }, new string[] { HrisRoles.Admin, HrisRoles.Manager })]
        [HttpPut("{departmentId}/template")]

        public async Task<IActionResult> UpdateTemplate()
        {
            var form = Request.Form;
            var id = form["id"];

            if (string.IsNullOrEmpty(id))
                return HrisError(this.GetType().ToString(), "ID is required.");

            var department = await _departmentServices.GetDepartmentById(Guid.Parse(id));

            if (department == null)
                return HrisError(this.GetType().ToString(), "Department not found.");

            var file = form!.Files!.FirstOrDefault()!;
            await _storageCloudService.UploadAttachment(3, file, department.Id);
            department.TemplateName = file.FileName;
            department.TemplateUri = await _storageCloudService.GetAttachmentUri(3, department.Id);

            await _departmentServices.Update(department, await _custom.GetUserObjectId(User));

            return HrisOk(department.ToResponse_());

        }

        [HrisAuthorize]
        [HttpGet("{managerId}/teams")]
        public async Task<IActionResult> GetDepartmentByManagerId([FromRoute] Guid? managerId)
        {
            var result = await _departmentServices.GetDepartmentByManagerId(managerId);
            return HrisOk(result);
        }
    }
}
