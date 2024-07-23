using Hris.Api.Extensions;
using Hris.Api.Middleware;
using Hris.Api.Security;
using Hris.Api.Utilities;
using Hris.Business.Service.v1.PayrollModule;
using Hris.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1.PayrollModule
{

    public class EmployeeLoansController : BaseApiController<EmployeeLoansController>
    {
        private readonly IEmployeeLoanServices _employeeLoanServices;
        private readonly ICustomClaimPrincipal _custom;
        public EmployeeLoansController(IEmployeeLoanServices employeeLoanServices, ICustomClaimPrincipal custom,
                        ILogger<EmployeeLoansController> logger) : base(logger)
        {
            _employeeLoanServices = employeeLoanServices;
            _custom = custom;
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] EmployeeLoansFilter_ filter)
        {
            var result = await _employeeLoanServices.GetAll(filter);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("isExist")]
        public async Task<IActionResult> isExist([FromQuery] Guid employeeId, Guid loanTypesId)
        {
            var result = await _employeeLoanServices.isEmployeeLoanExist(employeeId, loanTypesId);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _employeeLoanServices.GetById(id);
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeLoansDtoRequest req)
        {
            var isExist = await _employeeLoanServices
                .isExist(f => f.EmployeeId.Equals(req.EmployeeId) && f.LoanTypesId.Equals(req.LoanTypesId));
            if (isExist)
                return HrisError("Employee Loans", "There is already an existing record for an Employee and a Loan Type");

            var result = await _employeeLoanServices.Add(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Saving Employee Loans");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeLoansDtoRequest req)
        {
            var result = await _employeeLoanServices.Update(req, await _custom.GetUserObjectId(User));
            if (result is null) return HrisError("Error", "Error in Updating Employee Loans");
            return HrisOk(result);
        }

        [HrisAuthorize(new string[] { HrisModules.Payroll }, new string[] { HrisRoles.Admin, HrisRoles.Hr })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _employeeLoanServices.Delete(id, await _custom.GetUserObjectId(User));
            return HrisOk(result);
        }
    }
}
