using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response
{
    public class FamilyResponse : BaseResponse
    {
        public string Name { get; set; }
        public RelationshipType RelationshipType { get; set; }
        public bool IsEmergencyContact { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsColleague { get; set; }
        public Guid? ColleagueId { get; set;}
        public Guid? AddressId { get; set; }
        public AddressResponse? Address { get; set; }
        public string ContactNumber { get; set; }
    }
}
