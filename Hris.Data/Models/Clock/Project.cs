using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hris.Data.Models.Clock
{
    public class Project : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public string Description { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
