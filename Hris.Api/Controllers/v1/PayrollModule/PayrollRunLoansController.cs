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
    public class PayrollRunLoansController : BaseApiController<PayrollRunLoansController>
    {
        private readonly IPayrollRunLoansServices _payrollRunLoansServices;
        private readonly ICustomClaimPrincipal _custom;
        public PayrollRunLoansController(IPayrollRunLoansServices payrollRunLoansServices, ICustomClaimPrincipal custom,
                        ILogger<PayrollRunLoansController> logger) : base(logger)
        {
            _payrollRunLoansServices = payrollRunLoansServices;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _payrollRunLoansServices.GetByExpression(f => f.Id.Equals(id));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{employeeId}/{payrollRunId}/list")]
        public async Task<IActionResult> GetByPayrollRunList([FromRoute] Guid employeeId, [FromRoute] Guid payrollRunId)
        {
            var result = await _payrollRunLoansServices.GetListByExpression(f => f.EmployeeId.Equals(employeeId)
                && f.PayrollRunId.Equals(payrollRunId));
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("exists")]
        public async Task<IActionResult> isExist([FromQuery] Guid employeeId, [FromQuery] Guid loanTypesId, [FromQuery] Guid payrollRunId)
        {
            var result = await _payrollRunLoansServices.isExist(f => f.EmployeeId.Equals(employeeId)
                && f.LoanTypesId.Equals(loanTypesId)
                && f.PayrollRunId.Equals(payrollRunId));

            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PayrollRunLoansDtoRequest req)
        {
            var result = await _payrollRunLoansServices.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Payroll Run Loans");
            return HrisOk(result);
        }


        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PayrollRunLoansDtoRequest req)
        {
            var result = await _payrollRunLoansServices.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Payroll Run Loans");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _payrollRunLoansServices.Delete(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }
    }
}
