using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Employee
{
    public class TeamMember : BaseEntity
    {
        public Guid? TeamId { get; set; }
        public virtual Team Team { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
