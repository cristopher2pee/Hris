using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Tracker
{
    public class Track:BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee.Employee Employee { get; set; }

        public DateTime StartDateTimeUTC { get; set; }
        public DateTime EndDateTimeUTC { get; set;}

        public int OffSetHours { get; set; }
        public string Notes { get; set; }
        public bool IsLocked { get; set; }

        public Guid TaskId { get; set; }
        public virtual Task Task { get; set; }

        public virtual IEnumerable<Tags>? Tags { get; set; }= new List<Tags>();

    }
}
