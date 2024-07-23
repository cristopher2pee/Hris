using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Payroll
{
    public class ShiftSchedule : BaseEntity
    {
        public string Name { get; set; }
        public long  TimeIn { get; set; }
        public long TimeOut { get; set; }
        public int BreakTime { get; set; }
        public WeekDays RestDays { get; set; }
    }


}
