using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Leave
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EntitledDays { get; set; }
        public int Notification { get; set; }
        public LeaveClass Class { get; set; }
        public bool IsPaid { get; set; }
    }
}
