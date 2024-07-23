using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Administrator
{
    public class Calendar : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public HolidayType Type { get; set; }
        public string Timezone { get; set; }
    }
}
