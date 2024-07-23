using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Payroll
{
    public class LoanTypes : BaseEntity
    {
        public string ShortCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
