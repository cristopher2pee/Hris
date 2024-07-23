using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Notification
{
    public class Notification : BaseEntity
    {
        public Guid? EmployeeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public string RedirectToUrl { get; set; }
        public DateTime Expiration { get; set; }
        public string Meta { get; set; }
    }
}
