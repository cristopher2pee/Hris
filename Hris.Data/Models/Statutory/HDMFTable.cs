using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Statutory
{
    public class HDMFTable : BaseEntity
    {
        public string Code { get; set; }
        public decimal RangeFrom { get; set; }
        public decimal RangeTo { get; set; }
        public decimal HDMFEE { get; set; }
        public decimal HDMFER { get; set; }
        public decimal HDMFEEMax { get; set; }
        public decimal HDMFERMax { get; set; }
    }
}
