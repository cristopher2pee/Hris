using EntityFrameworkCore.EncryptColumn.Attribute;
using Hris.Data.Models.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Payroll
{
    public class AllowanceEntitlement : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid AllowanceTypeId { get; set; }
        public virtual AllowanceType AllowanceType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [EncryptColumn]
        public decimal Amount { get; set; }
        public PayrollPeriod Period { get; set; }
       // public DateTime EffectivityDate { get; set; }
    }
}
