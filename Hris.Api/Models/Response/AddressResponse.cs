using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response
{
    public class AddressResponse : BaseResponse
    {
        public string Country { get; set; }
        public string State { get; set; } 
        public string City { get; set; }
        public string Village { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public bool IsRenting { get; set; }
        public string LandLord { get; set; }
        public AddressType Type { get; set; }
    }
}
