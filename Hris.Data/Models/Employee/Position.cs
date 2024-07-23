using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Employee
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public PositionLevel Level { get; set; }
    }
}
