using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.Common;
using Hris.Business.Service.v1.PayrollModule;
using Hris.Data.DTO;
using Hris.Data.Models.Enum;
using Hris.Resource.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.PayrollModule
{

    public class PayrollConfigController : BaseApiController<PayrollConfigController>
    {
        private readonly IPayrollConfigServices _services;
        private readonly StorageCloudService _storageCloudService;
        private readonly ICustomClaimPrincipal _custom;
        public PayrollConfigController(IPayrollConfigServices services, StorageCloudService storageCloudService, ICustomClaimPrincipal custom,
                        ILogger<PayrollConfigController> logger) : base(logger)
        {
            _services = services;
            _storageCloudService = storageCloudService;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet]
        public async Task<IActionResult> GetAllPayrolConfig([FromQuery] BaseFilter_ filter)
        {
            var result = await _services.GetAllPayrollConfig(filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("exists")]
        public async Task<IActionResult> isPayrollConfigExist([FromQuery] string name, PayrollPeriod period)
        {
            var result = await _services.isPayrollConfigExist(f => f.Name.ToLower().Equals(name.ToLower())
                && f.Period.Equals(period));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllPayrolConfigById([FromRoute] Guid id)
        {
            var result = await _services.GetPayrollConfigById(id);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost]
        public async Task<IActionResult> AddPayrollConfig([FromBody] PayrollConfigDtoRequest req)
        {
            var result = await _services.AddPayrollConfig(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Payroll Config");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]
        public async Task<IActionResult> UpdatePayrollConfig([FromBody] PayrollConfigDtoRequest req)
        {
            var result = await _services.UpdatePayrollConfig(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Payroll Config");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut("attachement")]
        public async Task<IActionResult> UpdatePayrollConfig()
        {
            var form = Request.Form;
            var id = form["id"];
            if (string.IsNullOrEmpty(id))
                return HrisError(this.GetType().ToString(), "Payroll Config Id is empty.");

            var appId = Guid.Parse(id);
            var result = await _services.GetPayrollConfig(f => f.Id.Equals(appId));
            if (result is null)
                return HrisError(this.GetType().ToString(), "Payroll Config not found.");

            if (!form.Files.Any())
                return HrisError(this.GetType().ToString(), "No Files Attached.");

            var file = form!.Files!.FirstOrDefault()!;
            await _storageCloudService.UploadAttachment(10, file, result.Id);

            result.Template = file.FileName;
            result.TemplateUri = await _storageCloudService.GetAttachmentUri(10, result.Id);

            var toUpdate = await _services.UpdatePayrollConfig(result, await _custom.GetUserObjectId(User));
            return HrisOk(toUpdate);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayrollConfig([FromRoute] Guid id)
        {
            var result = await _services.DeletePayrollConfig(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("details")]
        public async Task<IActionResult> GetAllPayrolConfigDetails([FromQuery] PayrollConfigDetailsFilter filter)
        {
            var result = await _services.GetAllPayrollConfigDetails(filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("details/isExist")]
        public async Task<IActionResult> IsPayollConfigDetailsExist([FromQuery] Guid employeeId, Guid payrollConfigId)
        {
            var result = await _services.isConfigDetailsExist(f => f.EmployeeId.Equals(employeeId) && f.PayrollConfigId.Equals(payrollConfigId));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetAllPayrolConfigDetails([FromRoute] Guid id)
        {
            var result = await _services.GetPayrollConfigDetailsById(id);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost("details")]
        public async Task<IActionResult> AddPayrollConfigDetails([FromBody] PayrollConfigDetailsDtoRequest req)
        {
            var result = await _services.AddPayrollConfigDetails(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Payroll Config Details");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut("details")]
        public async Task<IActionResult> UpdatePayrollConfigDetails([FromBody] PayrollConfigDetailsDtoRequest req)
        {
            var result = await _services.UpdatePayrollConfigDetails(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Payroll Config Details");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("details/{id}")]
        public async Task<IActionResult> DeletePayrollConfigDetails([FromRoute] Guid id)
        {
            var result = await _services.DeletePayrollConfigDetails(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost("details/add-batch-employee")]
        public async Task<IActionResult> AddBatchConfigDetails([FromBody] BatchEmployeePayrollConfigDetailsRequest req)
        {
            var result = await _services.AddBatchPayrollConfigDetails(req, await _custom.GetUserObjectId(User));
            return HrisOk(new { Success = result });
        }
    }
}
