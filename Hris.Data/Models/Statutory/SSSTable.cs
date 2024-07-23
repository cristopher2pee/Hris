using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Statutory
{
    public class SSSTable : BaseEntity
    {
        public string Code { get; set; }
        public decimal RangeFrom { get; set; }
        public decimal RangeTo { get; set; }
        public decimal EE { get; set; }
        public decimal ER { get; set; }
        public decimal EC { get; set; }
    }
}
