
using Hris.Api.Models.Response.Employee;
using Hris.Data.DTO;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response
{
    public class EmployeeResponse : BaseResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public Gender Gender { get; set; }
        public string Nickname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Citizenship { get; set; }
        public CivilStatus CivilStatus { get; set; }
        public string BirthPlace { get; set; }
        public BloodType BloodType { get; set; }
        public string Religion { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime? DateSeparated { get; set; }
        public DateTime? DateRendered { get; set; }
        public string? Code { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public Guid? PositionId { get; set; }
        public string Position { get; set; }
        public Guid? DepartmentId { get; set; }
        public DepartmentResponse? Department { get; set; }
        public Guid? TeamId { get; set; }
        public TeamResponse? Team { get; set; }
        public string BankNumber { get; set; }
        public List<TeamMemberResponse>? TeamMembers { get; set; }
        public List<AddressResponse>? Addresses { get; set; }
        public List<FamilyResponse>? Families { get; set; }
        public List<SalaryHistoryResponse>? SalaryHistory { get; set; }
        public List<AllowanceEntitlementResponse>? AllowanceEntitlements { get; set; }
        public List<StatutoryResponse>? Statutories { get; set; }
        public bool IsOnBoarding { get; set; } = false;
        public string AvatarUri { get; set; } = string.Empty;
        public string? ProfileUri { get; set; }
        public string? PolicyNo { get; set; }
        public string? CardNo { get; set; }
        public string PagIbigId { get; set; }
        public string PhilHealthId { get; set; }
        public string SSSId { get; set; }
        public string TIN { get; set; }

        public Guid? ShiftScheduleId { get; set; }
        public ShiftSchedulesDtoResponse? ShiftSchedules { get; set; }
    }

    public class EmployeeNameResponse : BaseResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
    }

    // Team
    public class TeamMemberResponse : BaseResponse
    {
        public Guid EmployeeId { get; set; }
        public EmployeeResponse? Employee { get; set; }
        public Guid? TeamId { get; set; }
        public TeamResponse? Team { get; set; }
        public Guid? DepartmentId { get; set; }
        public DepartmentResponse Department { get; set; }

    }

    public class UserSettingsResponse : BaseResponse
    {
        public Guid EmployeeId { get; set; }
        public string Timezone { get; set; }
        public string UITheme { get; set; }
    }
}
