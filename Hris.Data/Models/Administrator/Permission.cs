using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hris.Data.Models;

namespace Hris.Data.Models.Administrator
{
    public class Permission : BaseEntity
    {
        public Guid EmployeeId { get; set; }

        public virtual Hris.Data.Models.Employee.Employee Employee { get; set; }

        public string Access { get; set; }
    }
}
