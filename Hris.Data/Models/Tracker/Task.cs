using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Tracker
{
    public  class Task: BaseEntity
    {
        public string Name { get; set; }
        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public bool IsBillable { get; set; }
        
        public Guid? ParentId { get; set; }
        public virtual Task ParentTask { get; set; }

        public virtual IEnumerable<Task>? ChildTasks { get; set; } = new List<Task>();


    }
}
