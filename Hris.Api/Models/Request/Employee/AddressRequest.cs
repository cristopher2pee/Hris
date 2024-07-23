using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Request.Employee
{
    public class AddressRequest : BaseRequest
    {
        public string Country { get; set; }
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Village { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public bool IsRenting { get; set; }
        public string? LandLord { get; set; }
        public AddressType Type { get; set; }
    }
}
