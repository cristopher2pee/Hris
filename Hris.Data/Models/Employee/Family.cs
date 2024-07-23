using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Employee
{
    public class Family:BaseEntity
    {
        public string Name { get; set; }
        public string ContactNumber { get; set;}
        public RelationshipType Relationship { get; set; }
        public DateTime DateOfBrith { get; set; }
        public bool IsEmergencyContact { get; set; }
        public bool IsColleauge { get; set; }
        public Guid? ColleagueId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string? PolicyNo { get; set; }
        public string? CardNo { get; set; }
    }
}
