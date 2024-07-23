using Hris.Data.Models.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hris.Data.Models.Payroll
{
    public class AllowanceType : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string Name { get; set; }
      // public AllowancePeriod Period { get; set; }
        public bool IsDefault { get; set; }
        public bool IsTaxable { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Limit { get; set; }
    }
}
