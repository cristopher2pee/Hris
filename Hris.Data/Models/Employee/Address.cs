using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Employee
{
    public class Address : BaseEntity
    {
        public Guid? EmployeeId { get; set; }
        public Guid? FamilyId { get; set; }
        public string Country { get; set; }
        public string State { get; set;}
        public string City { get; set; }
        public string? Village { get; set; }
        public string? HouseNo { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public bool IsRenting { get; set; }
        public string LandLord { get; set; }
        public AddressType  AddressType { get; set; }
    }
}
