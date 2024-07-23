using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    public class PayrollRunDeductionsDtoRequest : BaseDtoRequest
    {
        public Guid PayrollRunId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid DeductionTypesId { get; set; }
        public decimal Amount { get; set; }
        public PayrollPeriod PayrollPeriod { get; set; }
        public string Notes { get; set; }
    }

    public class PayrollRunDeductionsDtoResponse : BaseDtoResponse
    {
        public Guid PayrollRunId { get; set; }
        public PayrollRunDtoResponse? PayrollRun { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeBasicInfoDtoResponse? Employee { get; set; }
        public Guid DeductionTypesId { get; set; }
        public DeductionTypesDtoResponse? DeductionTypes { get; set; }
        public decimal Amount { get; set; }
        public PayrollPeriod PayrollPeriod { get; set; }
        public string Notes { get; set; }
    }

    public class PayrollRunEmployeeDtoResponse 
    {
        public Guid EmployeeId { get; set; }
        public Guid payrollRunId { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public static class PayrollRunDeductionsExtension
    {
        public static PayrollRunDeductionsDtoResponse ToPayrollRunDeductionsResponse(this PayrollRunDeductions e)
        {
            return new PayrollRunDeductionsDtoResponse
            {
                Id = e.Id,
                PayrollRunId = e.PayrollRunId,
                PayrollRun = e.PayrollRun != null ? e.PayrollRun.ToPayrollRunResponse() : null,
                EmployeeId = e.EmployeeId,
                Employee = e.Employee != null ? e.Employee.ToBasicEmployeeInfo() : null,
                DeductionTypesId = e.DeductionTypesId,
                DeductionTypes = e.DeductionTypes != null ? e.DeductionTypes.ToDeductionTypesResponse() : null,
                Active  = e.Active,
                PayrollPeriod = e.PayrollPeriod,
                Amount = e.Amount,
                Notes = e.Notes,
            };
        }

        public static IEnumerable<PayrollRunDeductionsDtoResponse> ToPayrollRunDeductionsResponseList(this IEnumerable<PayrollRunDeductions> e)
            => e.Select(f => f.ToPayrollRunDeductionsResponse());
    }
}
