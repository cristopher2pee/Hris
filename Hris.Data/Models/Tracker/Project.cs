using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Tracker
{
    public class Project:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }

        public virtual IEnumerable<Task>? Tasks { get; set; }= new List<Task>();
    }
}
