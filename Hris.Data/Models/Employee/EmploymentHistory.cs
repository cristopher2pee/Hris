using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Employee
{
    public class EmploymentHistory:BaseEntity
    {
        public Guid EmployeeId { get; set; }
      
        public DateTime EffectivityDate { get; set; }

        public virtual Employee Employee { get; set; }

        public string Position { get; set; }
        
        public string Department { get; set; }
        public string Team { get; set; } 

    }
}
