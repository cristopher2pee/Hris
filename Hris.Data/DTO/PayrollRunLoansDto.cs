using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{

    public class PayrollRunLoansDtoRequest : BaseDtoRequest
    {
        public Guid PayrollRunId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid LoanTypesId { get; set; }
        public decimal Amount { get; set; }
        public PayrollPeriod PayrollPeriod { get; set; }

        public string Notes { get; set; }
    }

    public class PayrollRunLoansDtoResponse : BaseDtoResponse
    {
        public Guid PayrollRunId { get; set; }
        public PayrollRunDtoResponse? PayrollRun { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeBasicInfoDtoResponse? Employee { get; set; }
        public Guid LoanTypesId { get; set; }
        public LoanTypesDtoResponse? LoanTypes { get; set; }
        public decimal Amount { get; set; }
        public PayrollPeriod PayrollPeriod { get; set; }

        public string Notes { get; set; }
    }

    public static class PayrollRunLoanExtension
    {
        public static PayrollRunLoansDtoResponse ToPayrollRunLoansResponse(this PayrollRunLoans e)
        {
            return new PayrollRunLoansDtoResponse
            {
                Id = e.Id,
                PayrollRunId = e.PayrollRunId,
                PayrollRun = e.PayrollRun != null ? e.PayrollRun.ToPayrollRunResponse() : null,
                EmployeeId = e.EmployeeId,
                Employee = e.Employee != null ? e.Employee.ToBasicEmployeeInfo() : null,
                LoanTypesId = e.LoanTypesId,
                LoanTypes = e.LoanTypes != null ? e.LoanTypes.ToLoanTypesResponse() : null,
                Active = e.Active,
                PayrollPeriod = e.PayrollPeriod,
                Amount = e.Amount,
                Notes = e.Notes,
            };
        }

        public static IEnumerable<PayrollRunLoansDtoResponse> ToPayrollRunDeductionsResponseList(this IEnumerable<PayrollRunLoans> e)
            => e.Select(f => f.ToPayrollRunLoansResponse());
    }

}
