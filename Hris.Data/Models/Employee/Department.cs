using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Employee
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public Guid ManagerId { get; set; }
        public string? TemplateUri { get; set; }
        public string? TemplateName { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
