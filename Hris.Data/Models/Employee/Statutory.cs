using EntityFrameworkCore.EncryptColumn.Attribute;
using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Employee
{
    public class Statutory : BaseEntity
    {
        public Guid EmployeeId { get; set; }

        public StatutoryType StatutoryType { get; set; }

        [EncryptColumn]
        public string StutoryId { get; set; }

        public Guid ReferenceId { get; set; }

    }
}
