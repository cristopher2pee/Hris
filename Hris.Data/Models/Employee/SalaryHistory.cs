using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Employee
{
    public class SalaryHistory : BaseEntity
    {
        public Guid PositionId { get; set; }
        public virtual Position Position { get; set; }
        [EncryptColumn]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BasePay { get; set; }
        public DateTime EffectivityDate { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
