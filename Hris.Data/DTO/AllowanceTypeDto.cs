using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class AllowanceTypeDto
    {
    }

    public class AllowanceTypeDtoRequest : BaseDtoRequest
    {
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public PayrollPeriod Period { get; set; }
        public bool IsDefault { get; set; }
        public bool isTaxable { get; set; }
        public decimal Limit { get; set; }
    }

    public class AllowanceTypeDtoResponse : BaseDtoResponse
    {
        public Decimal Amount { get; set; }
        public string Name { get; set; }
        public PayrollPeriod Period { get; set; }
        public bool IsDefault { get; set; }

        public bool IsTaxable { get; set; }
        public decimal Limit { get; set; }
    }

    public static class AllowanceTypeExtension_
    {
        public static AllowanceTypeDtoResponse ToAllowanceTypeResponse(this AllowanceType entity)
        {
            return new AllowanceTypeDtoResponse
            {
                
                Amount = entity.Amount,
                Name = entity.Name,
                Id = entity.Id,
               // Period = entity.Period,
                IsDefault = entity.IsDefault,
                Active = entity.Active,
                IsTaxable = entity.IsTaxable,
                Limit = entity.Limit,
            };
        }

        public static IEnumerable<AllowanceTypeDtoResponse> ToAllowanceTypeResponseList(this IEnumerable<AllowanceType> entities)
            => entities.Select(e => e.ToAllowanceTypeResponse());
    }
}
