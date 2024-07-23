using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Models.Common
{
    public class Permission
    {
        public Modules Module { get; set; }
        public Roles Role {  get; set; }
    }
}
