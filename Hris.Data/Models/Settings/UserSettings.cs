using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Settings
{
    public class UserSettings: BaseEntity
    {
        public Guid? EmployeeId { get; set; }
        public string? ProfileImg { get; set; }
        public string? Timezone { get; set; }
        public string? UITheme { get; set; }
    }
}
