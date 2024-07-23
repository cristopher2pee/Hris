using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Request.Employee
{
    public class FamilyRequest : BaseRequest
    {
        public string Name { get; set; }
        public RelationshipType RelationshipType { get; set; }
        public bool IsEmergencyContact { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsColleague { get; set; }
        public Guid? ColleagueId { get; set; }
        public Guid? AddressId { get; set; }
        public AddressRequest? Address { get; set; }
        public string ContactNumber { get; set; }
        public string? PolicyNo { get; set; }
        public string? CardNo { get; set; }
    }
}
