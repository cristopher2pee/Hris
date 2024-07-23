using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Administrator
{
    public class Access : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Module { get; set; }
        public string Roles { get; set; }
    }
}
