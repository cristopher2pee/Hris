using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hris.Data.Models.Employee;
using Microsoft.AspNetCore.Identity;

namespace Hris.Data.Models.IdentityServer
{
    public class User : IdentityUser
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee.Employee Employee { get; set; }
    }
}
