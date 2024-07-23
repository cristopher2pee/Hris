using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class AddressDto
    {
    }

    public class AddressDtoRequest : BaseDtoRequest
    {
        public string Country { get; set; }
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Village { get; set; } = string.Empty;
        public string? HouseNo { get; set; } = string.Empty;
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public bool IsRenting { get; set; }
        public string? LandLord { get; set; }
        public AddressType Type { get; set; }
    }
}
