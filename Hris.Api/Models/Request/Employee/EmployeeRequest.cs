using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Request.Employee
{
    public class EmployeeRequest : BaseRequest
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string? Middlename { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Others;
        public CivilStatus CivilStatus { get; set; } = CivilStatus.Single;
        public string Birthplace { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string? Religion { get; set; } = string.Empty;
        public BloodType BloodType { get; set; } 
        public string Email { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Code { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime? DateSeparated { get; set; }
        public DateTime? DateRendered { get; set; }
        public int EmployeeStatus { get; set; }
        public Guid? PositionId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? TeamId { get; set; }
        public decimal BaseSalary { get; set; }
        public string? BankNumber { get; set; }
        public string? PolicyNo { get; set; }
        public string? CardNo { get; set; }
        public virtual ICollection<SalaryHistoryRequest>? SalaryHistory { get; set; }
        public virtual ICollection<AllowanceEntitlementRequest>? AllowanceEntitlements { get; set; }
        public virtual ICollection<StatutoryRequest>? Statutories { get; set; }
        public virtual ICollection<AddressRequest>? Addresses { get; set; }
        public virtual ICollection<FamilyRequest>? Families { get; set; }
    }
}
