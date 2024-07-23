using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Employee
{
    public class Education:BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public EducationLevel Level { get; set;}
        public string Institution { get; set; }
        public int YearCompleted { get; set; }


    }
}
