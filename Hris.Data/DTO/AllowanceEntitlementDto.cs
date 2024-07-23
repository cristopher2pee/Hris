using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    public class AllowanceEntitlementDtoRequest : BaseDtoRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid AllowanceTypeId { get; set; }
        public decimal Amount { get; set; }
        public PayrollPeriod Period { get; set; }
        public DateTime EffectivityDate { get; set; }
    }

    public class AllowanceEntitlementDtoResponse : BaseDtoResponse
    {
        public Guid EmployeeId { get; set; }
        public Guid AllowanceTypeId { get; set; }
        public AllowanceTypeDtoResponse? AllowanceType { get; set; }
        public decimal Amount { get; set; }
        public PayrollPeriod Period { get; set; }
        public DateTime EffectivityDate { get; set; }
    }


    public static class AllowanceEntitlementExtension_
    {
        public static AllowanceEntitlementDtoResponse ToAllowanceEntitlement_(this AllowanceEntitlement e)
            => new AllowanceEntitlementDtoResponse
            {
                Id = e.Id,
                EmployeeId = e.EmployeeId,
                AllowanceTypeId = e.AllowanceTypeId,
                Amount = e.Amount,
               // EffectivityDate = e.EffectivityDate,
                Period = e.Period
            };
    }
}
