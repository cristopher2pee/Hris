    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Employee
{
    public  class Team : BaseEntity
    {
        public string Name { get; set; }
        public Guid LeadId { get; set; }
        public virtual Employee Lead { get; set; }
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
