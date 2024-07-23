using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class PayrollRunPaySummaryDto
    {
    }

    public class PayrollRunPaySummaryDtoRequest : BaseDtoRequest
    {
        public Guid PayrollRunId { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal Basic { get; set; }
        public decimal TimeSheetsPay { get; set; }
        public decimal TimeSheetDeduction { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deduction { get; set; }
        public decimal Loan { get; set; }
        public decimal ThirteenMonthPay { get; set; }
        public decimal LeaveConversion { get; set; }
        public decimal GrossPay { get; set; }
        public decimal SSSER { get; set; }
        public decimal SSSEE { get; set; }
        public decimal SSSEC { get; set; }
        public decimal PHICER { get; set; }
        public decimal PHICEE { get; set; }
        public decimal HDMFER { get; set; }
        public decimal HDMFEE { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxWitheld { get; set; }
        public decimal NetPay { get; set; }
    }

    public class PayrollRunPaySummaryDtoResponse : BaseDtoResponse
    {
        public Guid PayrollRunId { get; set; }
        public PayrollRunDtoResponse? PayrollRun { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeBasicInfoDtoResponse? Employee { get; set; }
        public decimal Basic { get; set; }
        public decimal TimeSheetsPay { get; set; }
        public decimal TimeSheetDeduction { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deduction { get; set; }
        public decimal Loan { get; set; }
        public decimal ThirteenMonthPay { get; set; }
        public decimal LeaveConversion { get; set; }
        public decimal GrossPay { get; set; }
        public decimal SSSER { get; set; }
        public decimal SSSEE { get; set; }
        public decimal SSSEC { get; set; }
        public decimal PHICER { get; set; }
        public decimal PHICEE { get; set; }
        public decimal HDMFER { get; set; }
        public decimal HDMFEE { get; set; }
        public string TaxCode { get; set; }
        public decimal TaxWitheld { get; set; }
        public decimal NetPay { get; set; }
    }

    public static class PayrollRunPaySummaryExtension
    {
        public static PayrollRunPaySummaryDtoResponse ToPayrollRunPaySummaryDtoResponse(this PayrollRunPaySummary e )
        {
            return new PayrollRunPaySummaryDtoResponse
            {
                Id = e.Id,
                PayrollRunId = e.PayrollRunId,
                PayrollRun = e.PayrollRun != null ? e.PayrollRun.ToPayrollRunResponse() : null,
                EmployeeId = e.EmployeeId,
                Employee = e.Employee != null ? e.Employee.ToBasicEmployeeInfo() : null,
                Basic = e.Basic,
                TimeSheetsPay = e.TimeSheetsPay,
                TimeSheetDeduction = e.TimeSheetDeduction,
                Allowances = e.Allowances,
                Deduction = e.Deduction,
                Loan = e.Loan,
                ThirteenMonthPay = e.ThirteenMonthPay,
                LeaveConversion = e.LeaveConversion,
                GrossPay = e.GrossPay,
                SSSER = e.SSSER,
                SSSEE = e.SSSEE,
                SSSEC = e.SSSEC,
                PHICER = e.PHICER,
                PHICEE = e.PHICEE,
                HDMFER = e.HDMFER,
                HDMFEE = e.HDMFEE,
                TaxCode = e.TaxCode,
                TaxWitheld = e.TaxWitheld,
                NetPay = e.NetPay,
                Active = e.Active
            };
        }


        public static IEnumerable<PayrollRunPaySummaryDtoResponse> ToPayrollRunPaySummaryDtoResponseList(this IEnumerable<PayrollRunPaySummary> e)
            => e.Select(f => f.ToPayrollRunPaySummaryDtoResponse());
    }
}
