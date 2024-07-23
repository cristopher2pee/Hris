using Hris.Api.Models.Response.ClockWork;
using Hris.Api.Models.Response.Payroll;
using Hris.Data.Models.Payroll;

namespace Hris.Api.Extensions.Payroll
{
    public static class AllowanceExtension
    {
        public static AllowanceTypeResponse ToResponse(this AllowanceType d)
            => new AllowanceTypeResponse
            {
                Id = d.Id,
                Active = d.Active,
                Name = d.Name,
                Amount = d.Amount,
               // Period = d.Period,
                IsDefault = d.IsDefault
            };

        public static IEnumerable<AllowanceTypeResponse> ToList(this IEnumerable<AllowanceType> d)
            => d.Select(d => d.ToResponse());

        public static AllowanceEntitlementResponse ToResponse(this AllowanceEntitlement d)
            => new AllowanceEntitlementResponse
            {
                Id = d.Id,
                Active = d.Active,
                AllowanceTypeId = d.AllowanceTypeId,
                AllowanceType = d.AllowanceType.ToResponse(),
                Amount = d.Amount,
                Period = d.Period,
               // EffectivityDate = d.EffectivityDate
            };

        public static IEnumerable<AllowanceEntitlementResponse> ToList(this IEnumerable<AllowanceEntitlement> d)
            => d.Select(d => d.ToResponse());
    }
}
