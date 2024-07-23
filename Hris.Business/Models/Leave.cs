using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Models
{
    public class ScheduledLeaveReport
    {
        public string Employee { get; set; }
        public int TotalPaid { get; set; }
        public int CountPaid { get; set; }
        public int TotalNonPaid { get; set; }
        public int CountNonPaid { get; set; }
        public IEnumerable<ScheduledLeaveApplication> Requests { get; set; }
    }

    public class ScheduledLeaveApplication
    {
        public string LeaveType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Days { get; set; }
        public bool Paid { get; set; }
    }

}
