using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Clock
{
    public class ProjectTask : BaseEntity
    {
        public string Name { get; set; }
        public bool IsBillable { get; set; }
        public Guid? ParentTaskId { get; set; }
        public Guid? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public bool IsCustom { get; set; }
        public ProjectTaskRate Rate { get; set; }
        public decimal Amount { get; set; }

    }
}
