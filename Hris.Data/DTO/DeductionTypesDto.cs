using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    public class DeductionTypesDtoRequest : BaseDtoRequest
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsDefault { get; set; }
    }

    public class DeductionTypesDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsDefault { get; set; }
    }

    public static class DeductionTypesExtension
    {
        public static DeductionTypesDtoResponse ToDeductionTypesResponse(this DeductionTypes entity)
        {
            return new DeductionTypesDtoResponse
            {
                Amount = entity.Amount,
                Name = entity.Name,
                Id = entity.Id,
                IsDefault = entity.IsDefault,
                Active = entity.Active,
            };
        }

        public static IEnumerable<DeductionTypesDtoResponse> ToDeductionTypesResponseList(this IEnumerable<DeductionTypes> entities)
            => entities.Select(e => e.ToDeductionTypesResponse());
    }
}
