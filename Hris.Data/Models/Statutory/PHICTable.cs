using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Statutory
{
    public class PHICTable : BaseEntity
    {
        public string Code { get; set; }
        public decimal RangeFrom { get; set; }
        public decimal RangeTo { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal EEShare { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal ERShare { get; set; }
    }
}
