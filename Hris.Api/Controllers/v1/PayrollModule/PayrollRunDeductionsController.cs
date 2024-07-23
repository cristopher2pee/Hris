using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.PayrollModule;
using Hris.Data.DTO;
using Hris.Data.Models.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.PayrollModule
{


    public class PayrollRunDeductionsController : BaseApiController<PayrollRunDeductionsController>
    {
        private readonly IPayrollRunDeductionsServices _payrollRunDeductionsServices;
        private readonly ICustomClaimPrincipal _custom;
        public PayrollRunDeductionsController(IPayrollRunDeductionsServices payrollRunDeductionsServices, ICustomClaimPrincipal custom,
                        ILogger<PayrollRunDeductionsController> logger) : base(logger)
        {
            _payrollRunDeductionsServices = payrollRunDeductionsServices;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{employeeId}/{payrollRunId}/list")]
        public async Task<IActionResult> GetByPayrollRunData([FromRoute] Guid employeeId, [FromRoute] Guid payrollRunId)
        {
            var result = await _payrollRunDeductionsServices.GetListByExpression(f => f.EmployeeId.Equals(employeeId)
                && f.PayrollRunId.Equals(payrollRunId));
            return HrisOk(result);
        }


        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPayrollRunData([FromRoute] Guid id)
        {
            var result = await _payrollRunDeductionsServices.GetByExpression(f => f.Id.Equals(id));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("exists")]
        public async Task<IActionResult> isExist([FromQuery] Guid employeeId, [FromQuery] Guid deductionTypeId, [FromQuery] Guid payrollRunId)
        {
            var result = await _payrollRunDeductionsServices.isExist(f => f.EmployeeId.Equals(employeeId)
                && f.DeductionTypesId.Equals(deductionTypeId)
                && f.PayrollRunId.Equals(payrollRunId));

            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PayrollRunDeductionsDtoRequest req)
        {
            var result = await _payrollRunDeductionsServices.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Payroll Run Deductions");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PayrollRunDeductionsDtoRequest req)
        {
            var result = await _payrollRunDeductionsServices.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Payroll Run Deductions");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _payrollRunDeductionsServices.Delete(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }
    }
}
