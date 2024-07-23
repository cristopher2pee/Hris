using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    public class EmployeeLoansDtoRequest : BaseDtoRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid LoanTypesId { get; set; }
        public decimal LoanAmount { get; set; }
        public int Months { get; set; }

        public PayrollPeriod Period { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Amortization { get; set; }
        public string Notes { get; set; }
        public LoanStatus Status { get; set; }
    }
    public class EmployeeLoansDtoResponse : BaseDtoResponse
    {
        public Guid EmployeeId { get; set; }
        public EmployeeDtoResponse? Employee { get; set; }

        public Guid LoanTypesId { get; set; }
        public LoanTypesDtoResponse? LoanTypes { get; set; }
        public decimal LoanAmount { get; set; }
        public PayrollPeriod Period { get; set; }
        public int Months { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Amortization { get; set; }
        public string Notes { get; set; }
        public LoanStatus Status { get; set; }
    }

    public static class EmployeeLoansExtension
    {
        public static EmployeeLoansDtoResponse ToEmployeeLoansResponse(this EmployeeLoans e)
        {
            return new EmployeeLoansDtoResponse
            {
                Id = e.Id,
                EmployeeId = e.EmployeeId,
                Employee = e.Employee != null ? e.Employee.ToResponse_() : null,
                LoanTypesId = e.LoanTypesId,
                LoanTypes = e.LoanTypes != null ? e.LoanTypes.ToLoanTypesResponse() : null,
                LoanAmount = e.LoanAmount,
                Period = e.Period,
                From = e.From,
                To = e.To,
                Months = e.Months,
                Amortization = e.Amortization,
                Notes = e.Notes,
                Status = e.Status,
            };
        }

        public static IEnumerable<EmployeeLoansDtoResponse> ToEmployeeLoansResponseList(this IEnumerable<EmployeeLoans> e)
            => e.Select(e => e.ToEmployeeLoansResponse());
    }
}
