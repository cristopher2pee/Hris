using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{


    public class PayrollConfigDtoRequest : BaseDtoRequest
    {
        public string Name { get; set; }
        public PayrollPeriod Period { get; set; }
        public int FromDay { get; set; }
        public int ToDay { get; set; }
        public int PayOutDay { get; set; }
        public Guid? ThirteenMonthId { get; set; }
        public Guid? LeaveConversionId { get; set; }
       public TaxPeriodType TaxTypePeriod { get; set; }
        public string TemplateUri { get; set; }

        public string Template { get; set; }
    }

    public class PayrollConfigDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public PayrollPeriod Period { get; set; }
        public int FromDay { get; set; }
        public int ToDay { get; set; }
        public int PayOutDay { get; set; }
        public Guid? ThirteenMonthId { get; set; }
        public AllowanceTypeDtoResponse? ThirteenMonth { get; set; }
        public Guid? LeaveConversionId { get; set; }
        public AllowanceTypeDtoResponse? LeaveConversion { get; set; }
        public TaxPeriodType TaxTypePeriod { get; set; }

        public string TemplateUri { get; set; }

        public string Template { get; set; }
    }

    public static class PayrollConfigExtension
    {
        public static PayrollConfigDtoResponse ToPayrollConfigResponse(this PayrollConfig e)
        {
            return new PayrollConfigDtoResponse
            {
                Id = e.Id,
                Name = e.Name,
                Period = e.Period,
                FromDay = e.FromDay,
                ToDay = e.ToDay,
                PayOutDay = e.PayOutDay,
                Active = e.Active,
                ThirteenMonthId = e.ThirteenMonthId,
                LeaveConversionId = e.LeaveConversionId,
                ThirteenMonth = e.ThirteenMonth != null ? e.ThirteenMonth.ToAllowanceTypeResponse() : null,
                LeaveConversion = e.LeaveConversion != null ? e.LeaveConversion.ToAllowanceTypeResponse() : null,
                TaxTypePeriod = e.TaxTypePeriod,
                TemplateUri = e.TemplateUri,
                Template = e.Template,
            };
        }

        public static IEnumerable<PayrollConfigDtoResponse> ToPayrollConfigResponseList(this IEnumerable<PayrollConfig> e)
            => e.Select(e => e.ToPayrollConfigResponse());

        public static PayrollConfigDetailsDtoResponse ToPayrollConfigDetailsResponse(this PayrollConfigDetails e)
        {
            return new PayrollConfigDetailsDtoResponse
            {
                Id = e.Id,
                PayrollConfigId = e.PayrollConfigId,
                EmployeeId = e.EmployeeId,
                PayrollConfig = e.PayrollConfig != null ? e.PayrollConfig.ToPayrollConfigResponse() : null,
                Employee = e.Employee != null ? e.Employee.ToResponse_() : null
            };
        }

        public static IEnumerable<PayrollConfigDetailsDtoResponse> ToPayrollConfigDetailsResponseList(this IEnumerable<PayrollConfigDetails> e)
            => e.Select(e => e.ToPayrollConfigDetailsResponse());
    }

    public class PayrollConfigDetailsDtoRequest : BaseDtoRequest
    {
        public Guid PayrollConfigId { get; set; }
        public Guid EmployeeId { get; set; }
    }

    public class PayrollConfigDetailsDtoResponse : BaseDtoResponse
    {
        public Guid PayrollConfigId { get; set; }
        public PayrollConfigDtoResponse? PayrollConfig { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeDtoResponse? Employee { get; set; }

    }

    public static class PayrollRunExtension
    {
        public static PayrollRunDtoResponse ToPayrollRunResponse(this PayrollRun e)
        {
            return new PayrollRunDtoResponse
            {
                Id = e.Id,
                Month = e.Month,
                Year = e.Year,
                PayrollConfigId = e.PayrollConfigId,
                PayrollCode = e.PayrollCode,
                PayrollConfig = e.PayrollConfig != null ? e.PayrollConfig.ToPayrollConfigResponse() : null,
                ApprovedById = e.ApprovedById.HasValue ? e.ApprovedById : null,
                ApprovedBy = e.ApprovedBy != null ? e.ApprovedBy.ToInitialEmployeeResponse_() : null,
                PayrollRunStatus = e.PayrollRunStatus,
                Notes = e.Notes,
                Active = e.Active,
                IsLocked = e.IsLocked,
                ApprovedDate = e.ApprovedDate,
                ModifiedDate = e.Modified
            };
        }

        public static IEnumerable<PayrollRunDtoResponse> ToPayrollRunResponseList(this IEnumerable<PayrollRun> e)
            => e.Select(e => e.ToPayrollRunResponse());
    }

    public class PayrollRunDtoRequest : BaseDtoRequest
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string PayrollCode { get; set; }
        public Guid PayrollConfigId { get; set; }
        public Guid? ApprovedById { get; set; }
        public PayrollRunStatusEnum PayrollRunStatus { get; set; }
        public string Notes { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? ApprovedDate { get; set; }


    }

    public class PayrollRunDtoResponse : BaseDtoResponse
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string PayrollCode { get; set; }
        public Guid PayrollConfigId { get; set; }
        public PayrollConfigDtoResponse? PayrollConfig { get; set; }
        public Guid? ApprovedById { get; set; }
        public EmployeeDtoResponse? ApprovedBy { get; set; }
        public PayrollRunStatusEnum PayrollRunStatus { get; set; }
        public EmployeeDtoResponse GeneratedBy { get; set; }
        public Guid GeneratedId { get; set; }
        public string Notes { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class PayrollRunEmployeeSettingsInfo : BaseDtoResponse
    {
        public EmployeeBasicInfoDtoResponse Employee { get; set; }
        public SalaryHistoryDtoResponse? Salary { get; set; }
        public List<AllowanceEntitlementDtoResponse>? Allowance { get; set; }
        public EmployeeStatutoriesDtoResponse? Statutory { get; set; }
        public TaxTable TaxTable { get; set; }
        public ShiftSchedulesDtoResponse Shift { get; set; }


    }

    public class BatchEmployeePayrollConfigDetailsRequest
    {
        public Guid PayrollConfigId { get; set; }
        public List<Guid> EmployeeIds { get; set; }
    }
}
