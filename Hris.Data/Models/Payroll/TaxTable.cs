using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Payroll
{
    public class TaxTable : BaseEntity
    {
        public TaxPeriodType TaxPeriodType { get; set; }
        public string Code { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RangeFrom { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RangeTo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal FixRate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxRate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ExcessOver { get; set; }
    }

}
