using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class FamilyDto
    {
    }

    public class FamilyDtoRequest : BaseDtoRequest
    {
        public string Name { get; set; }
        public RelationshipType RelationshipType { get; set; }
        public bool IsEmergencyContact { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsColleague { get; set; }
        public Guid? ColleagueId { get; set; }
        public Guid? AddressId { get; set; }
        public AddressDtoRequest? Address { get; set; }
        public string ContactNumber { get; set; }
        public string? PolicyNo { get; set; }
        public string? CardNo { get; set; }
    }

    public class FamilyDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public RelationshipType RelationshipType { get; set; }
        public bool IsEmergencyContact { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsColleague { get; set; }
        public Guid? ColleagueId { get; set; }
        public Guid? AddressId { get; set; }
        public AddressDtoResponse? Address { get; set; }
        public string ContactNumber { get; set; }
    }
}
