using Hris.Data.Extension;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class EmployeeDto
    {
    }

    public class EmployeeDtoRequest : BaseDtoRequest
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
        public string? Manual { get; set; }

        public string PagIbigId { get; set; }
        public string PhilHealthId { get; set; }
        public string SSSId { get; set; }
        public string TIN { get; set; }
        public Guid? ShiftScheduleId { get; set; }
        public virtual ICollection<SalaryHistoryDtoRequest>? SalaryHistory { get; set; }
        public virtual ICollection<AllowanceEntitlementDtoRequest>? AllowanceEntitlements { get; set; }
        public virtual ICollection<AddressDtoRequest>? Addresses { get; set; }
        public virtual ICollection<FamilyDtoRequest>? Families { get; set; }
    }

    public class EmployeeDtoResponse : BaseDtoResponse
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
        public DepartmentDtoResponse? Department { get; set; }
        public Guid? TeamId { get; set; }
        public TeamDtoResponse? Team { get; set; }
        public string BankNumber { get; set; }
        public List<TeamMemberDtoResponse>? TeamMembers { get; set; }
        public List<AddressDtoResponse>? Addresses { get; set; }
        public List<FamilyDtoResponse>? Families { get; set; }
        public List<SalaryHistoryDtoResponse>? SalaryHistory { get; set; }
        public List<AllowanceEntitlementDtoResponse>? AllowanceEntitlements { get; set; }
        public List<StatutoryDtoResponse>? Statutories { get; set; }
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

    public class CertificateOfEmploymentDto : BaseDtoRequest
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime? DateSeparated { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public SalaryHistory? LatestSalary { get; set; }
        public decimal TotalAllowance { get; set; }
        public LeaveApplicationDtoResponse UpcomingLeave { get; set; }
        public PositionDtoResponse Position { get; set; }
        public Gender Gender { get; set; }
        public Guid? ObjectId { get; set; }
    }

    public class EmployeePayrollRunSettingsInfo : BaseDtoResponse
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public Position Position { get; set; }
        public SalaryHistoryDtoResponse? Salary { get; set; }
        public IEnumerable<AllowanceEntitlementDtoResponse>? Allowances { get; set; }
        public EmployeeStatutoriesDtoResponse? EmployeeStatutories { get; set; }
        public ShiftSchedulesDtoResponse? ShiftSchedules { get; set; }
    }

    public class EmployeeBasicInfoDtoResponse : BaseDtoResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public Position Position { get; set; }
        public string Code { get; set; }

    }
    public class EmployeeNameDtoResponse : BaseDtoResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Code { get; set; }
    }

    //public class DepartmentDtoResponse : BaseDtoResponse
    //{
    //    public Guid Id { get; set; }
    //    public string Name { get; set; }
    //    public Guid ManagerId { get; set; }
    //    public EmployeeDtoResponse? Manager { get; set; }
    //    public string ManagerName { get; set; }
    //    public string TemplateUri { get; set; }
    //    public string TemplateName { get; set; }
    //    public List<TeamDtoResponse> Team { get; set; }
    //}

    public class TeamDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public Guid LeadId { get; set; }
        public EmployeeDtoResponse? Lead { get; set; }
        public string LeadName { get; set; }
        public Guid DepartmentId { get; set; }
        public DepartmentDtoResponse? Department { get; set; }
    }

    public class TeamMemberDtoResponse : BaseDtoResponse
    {
        public Guid EmployeeId { get; set; }
        public EmployeeDtoResponse? Employee { get; set; }
        public Guid? TeamId { get; set; }
        public TeamDtoResponse? Team { get; set; }
        public Guid? DepartmentId { get; set; }
        public DepartmentDtoResponse Department { get; set; }

    }

    public class TeamMemberManangementDtoInfoResponse
    {
        public List<EmployeeBasicInfoDtoResponse> DepartmentManager { get; set; }
        public List<EmployeeBasicInfoDtoResponse> TeamLead { get; set; }
    }

    public class AddressDtoResponse : BaseDtoResponse
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

    public class EmployeeEntitlementsDtoResponse : BaseDtoResponse
    {
        public EmployeeDtoResponse Employee { get; set; }
        public int EntitlementCount { get; set; }
        public List<AllowanceEntitlementDtoResponse>? Entitlements { get; set; }
    }

    public static class EmployeesExtenstion_
    {
        public static List<EmployeeBasicInfoDtoResponse> ToEmployeeDtoResponseList(this List<Employee> e)
            => e.Select(e => e.ToBasicEmployeeInfo()).ToList();

        public static EmployeePayrollRunSettingsInfo ToEmployeePayrollRunSettingsInfo(this Employee e)
        {
            var salaryResponse = e.SalaryHistory != null ? e.SalaryHistory.OrderByDescending(f => f.EffectivityDate).FirstOrDefault() : null;
            return new EmployeePayrollRunSettingsInfo
            {
                Id = e.Id,
                LastName = e.Lastname,
                FirstName = e.Firstname,
                MiddleName = e.Middlename,
                Code = e.Code,
                Email = e.Email,
                Position = e.Position,
                Salary = salaryResponse != null ? new SalaryHistoryDtoResponse
                {
                    Id = salaryResponse.Id,
                    BasePay = salaryResponse.BasePay,
                    EffectivityDate = salaryResponse.EffectivityDate
                } : null,
                Allowances = e.Allowances != null ? e.Allowances.Select(a => new AllowanceEntitlementDtoResponse
                {
                    Id = a.Id,
                    EmployeeId = a.EmployeeId,
                    AllowanceType = a.AllowanceType.ToAllowanceTypeResponse(),
                    Amount = a.Amount,
                    Period = a.Period,
                }) : null,
              //  EmployeeStatutories = e.EmployeeStatutories != null ? e.EmployeeStatutories.ToEmployeeStatutoriesResponse() : null,
                ShiftSchedules = e.ShiftSchedule != null ? e.ShiftSchedule.ToShiftSchedulesResponse() : null,
            };
        }

        public static IEnumerable<EmployeePayrollRunSettingsInfo> ToEmployeePayrollRunSettingsInfo(this IEnumerable<Employee> e)
            => e.Select(f => f.ToEmployeePayrollRunSettingsInfo());
        public static EmployeeBasicInfoDtoResponse ToBasicEmployeeInfo(this Employee e)
        {
            return new EmployeeBasicInfoDtoResponse
            {
                Id = e.Id,
                LastName = e.Lastname,
                FirstName = e.Firstname,
                MiddleName = e.Middlename,
                Email = e.Email,
                Position = e.Position,
                Code = e.Code
                
            };
        }
        public static EmployeeDtoResponse ToInitialEmployeeResponse_(this Employee e, string tz = "China Standard Time")
            => e is not null ? new EmployeeDtoResponse
            {
                Id = e.Id,
                Code = e.Code,
                Email = e.Email,
                Position = e.Position != null ? e.Position.Name : string.Empty,
                FirstName = e.Firstname,
                LastName = e.Lastname,
                MiddleName = e.Middlename,
                Gender = e.Gender,
                ContactNumber = e.Contact,
                PhoneNumber = e.HomePhone,
                DateHired = e.DateHired.ConvertToTimezone_(tz),
                EmployeeStatus = e.EmployeeStatus,
                ProfileUri = e.ProfileUri
            } : null;

        public static EmployeeNameDtoResponse ToEmployeeNameResponse_(this Employee e)
            => new EmployeeNameDtoResponse
            {
                Id = e.Id,
                FirstName = e.Firstname,
                MiddleName = e.Middlename,
                LastName = e.Lastname,
                Code = e.Code
            };

        public static EmployeeDtoResponse ToResponse_(this Employee e, string tz = "China Standard Time")
    => new EmployeeDtoResponse
    {
        Id = e.Id,
        Active = e.Active,
        Code = e.Code,
        FirstName = e.Firstname,
        LastName = e.Lastname,
        MiddleName = e.Middlename,
        Gender = e.Gender,
        Nickname = e.Nickname,
        DateOfBirth = e.DateOfBirth.ConvertToTimezone_(tz),
        Citizenship = e.Citizenship,
        CivilStatus = e.CivilStatus,
        BirthPlace = e.BirthPlace,
        BloodType = e.BloodType,
        Religion = e.Religion,
        Email = e.Email,
        ContactNumber = e.Contact,
        PhoneNumber = e.HomePhone,
        ProfileUri = e.ProfileUri,
        AvatarUri = e.AvatarUri,
        PolicyNo = e.PolicyNo,
        CardNo = e.CardNo,
        BankNumber = e.BankNo,
        PagIbigId = e.PagIbigId,
        PhilHealthId = e.PhilHealthId,
        SSSId = e.SSSId,
        TIN = e.TIN,
        EmployeeStatus = e.EmployeeStatus,
        DateHired = e.DateHired.ConvertToTimezone_(tz),
        DateSeparated = e.DateSeparated?.ConvertToTimezone_(tz),
        DateRendered = e.DateRendered?.ConvertToTimezone_(tz),
        PositionId = e.Position != null ? e.Position.Id : Guid.Empty,
        Position = e.Position != null ? e.Position.Name : string.Empty,
        Addresses = e.Addresses != null ?
            e.Addresses.Where(a => a.Active).Select(a =>
                new AddressDtoResponse
                {
                    Id = a.Id,
                    Country = a.Country,
                    State = a.State,
                    City = a.City,
                    Village = a.Village,
                    Street = a.Street,
                    PostalCode = a.PostalCode.ToString(),
                    IsRenting = a.IsRenting,
                    LandLord = a.LandLord,
                    Type = a.AddressType,
                    Active = a.Active
                }).ToList() : null,
        Families = e.Family != null ?
            e.Family.Where(f => f.Active).Select(f =>
                new FamilyDtoResponse
                {
                    Id = f.Id,
                    Name = f.Name,
                    RelationshipType = f.Relationship,
                    IsEmergencyContact = f.IsEmergencyContact,
                    DateOfBirth = f.DateOfBrith.ConvertToTimezone_(tz),
                    IsColleague = f.IsColleauge,
                    ContactNumber = f.ContactNumber,
                    ColleagueId = f.IsColleauge ? f.ColleagueId : null,
                    Active = f.Active,
                    AddressId = f.AddressId,
                    Address = f.Address != null ? new AddressDtoResponse
                    {
                        Id = f.Address.Id,
                        Country = f.Address.Country,
                        State = f.Address.State,
                        City = f.Address.City,
                        Village = f.Address.Village,
                        Street = f.Address.Street,
                        PostalCode = f.Address.PostalCode.ToString(),
                        IsRenting = f.Address.IsRenting,
                        LandLord = f.Address.LandLord,
                        Type = f.Address.AddressType,
                        Active = f.Active
                    } : null,
                }).ToList() : null,
        SalaryHistory = e.SalaryHistory != null ?
            e.SalaryHistory.Where(sh => sh.Active).Select(sh =>
                new SalaryHistoryDtoResponse
                {
                    Id = sh.Id,
                    EffectivityDate = sh.EffectivityDate.ConvertToTimezone_(tz),
                    BasePay = sh.BasePay,
                    Active = sh.Active
                }).ToList() : null,
        AllowanceEntitlements = e.Allowances != null ?
            e.Allowances.Where(a => a.Active).Select(a =>
                new AllowanceEntitlementDtoResponse
                {
                    Id = a.Id,
                    Active = a.Active,
                    AllowanceTypeId = a.AllowanceTypeId,
                    AllowanceType = a.AllowanceType != null ?
                        new AllowanceTypeDtoResponse
                        {
                            Name = a.AllowanceType.Name
                        } : null,
                    Amount = a.Amount,
                    Period = a.Period,
                    // EffectivityDate = a.EffectivityDate.ConvertToTimezone_(tz)
                }).ToList() : null,
        ShiftScheduleId = e.ShiftScheduleId,
        ShiftSchedules = e.ShiftSchedule != null ? e.ShiftSchedule.ToShiftSchedulesResponse() : null


        //Statutories = e.Statutories != null ?
        //    e.Statutories.Where(a => a.Active).Select(s =>
        //        new StatutoryDtoResponse
        //        {
        //            Id = s.Id,
        //            StatutoryType = s.StatutoryType,
        //            StatutoryId = s.StutoryId,
        //            Active = s.Active
        //        }).ToList() : null,
    };
    }
}
