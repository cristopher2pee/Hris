using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{

    public class PayrollRunAllowanceDtoRequest : BaseDtoRequest
    {
        public Guid PayrollRunId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid AllowanceTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public PayrollPeriod PayrollPeriod { get; set; }
    }

    public class PayrollRunAllowanceDtoResponse : BaseDtoResponse
    {
        public Guid PayrollRunId { get; set; }
        public PayrollRunDtoResponse? PayrollRun { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeBasicInfoDtoResponse? Employee { get; set; }
        public Guid AllowanceTypeId { get; set; }
        public AllowanceTypeDtoResponse? AllowanceType { get; set; }
        public decimal Amount { get; set; }

        public string Notes { get; set; }
        public PayrollPeriod PayrollPeriod { get; set; }
    }

    public static class PayrollRunAllowanceExtension
    {
        public static PayrollRunAllowanceDtoResponse ToPayrollRunAllowanceResponse(this PayrollRunAllowances e)
        {
            return new PayrollRunAllowanceDtoResponse
            {
                Id = e.Id,
                PayrollRunId = e.PayrollRunId,
                PayrollRun = e.PayrollRun != null ? e.PayrollRun.ToPayrollRunResponse() : null,
                EmployeeId = e.EmployeeId,
                Employee = e.Employee != null ? e.Employee.ToBasicEmployeeInfo() : null,
                AllowanceTypeId = e.AllowanceTypeId,
                AllowanceType = e.AllowanceType != null ? e.AllowanceType.ToAllowanceTypeResponse() : null,
                Amount = e.Amount,
                PayrollPeriod = e.PayrollPeriod,
                Notes = e.Notes,
            };
        }

        public static IEnumerable<PayrollRunAllowanceDtoResponse> ToPayrollRunAllowanceResponseList(this IEnumerable<PayrollRunAllowances> e)
            => e.Select(e => e.ToPayrollRunAllowanceResponse());
    }
}
