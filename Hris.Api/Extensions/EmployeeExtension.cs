using Hris.Api.Extensions.Payroll;
using Hris.Api.Models.LeaveResponse;
using Hris.Api.Models.Response;
using Hris.Api.Models.Response.Employee;
using Hris.Api.Utilities;
using Hris.Business.Extensions;
using Hris.Data.DTO;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Leave;
using Hris.Data.Models.Settings;
using System.Drawing.Text;

namespace Hris.Api.Extensions
{
    public static class EmployeeExtension
    {
        public static IEnumerable<EmployeeResponse> ToResponseList(this IEnumerable<Employee> d, bool full)
            => d.Select(d => d.ToInitialResponse());

        public static EmployeeResponse ToInitialResponse(this Employee e, string tz = "China Standard Time")
            => new EmployeeResponse
            {
                Id = e.Id,
                Code = e.Code,
                Email = e.Email,
                FirstName = e.Firstname,
                LastName = e.Lastname,
                MiddleName = e.Middlename,
                Gender = e.Gender,
                ContactNumber = e.Contact,
                PhoneNumber = e.HomePhone,
                DateHired = e.DateHired.ConvertToTimezone(tz),
                EmployeeStatus = e.EmployeeStatus,
                ProfileUri = e.ProfileUri
            };

        public static EmployeeResponse ToResponse(this Employee e, string tz = "China Standard Time")
            => new EmployeeResponse
            {
                Id = e.Id,
                Active = e.Active,
                Code = e.Code,
                FirstName = e.Firstname,
                LastName = e.Lastname,
                MiddleName = e.Middlename,
                Gender = e.Gender,
                Nickname = e.Nickname,
                DateOfBirth = e.DateOfBirth.ConvertToTimezone(tz),
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
                EmployeeStatus = e.EmployeeStatus,
                DateHired = e.DateHired.ConvertToTimezone(tz),
                DateSeparated = e.DateSeparated?.ConvertToTimezone(tz),
                DateRendered = e.DateRendered?.ConvertToTimezone(tz),
                PositionId = e.PositionId,
                Position = e.Position != null ? e.Position.Name : string.Empty,
                PagIbigId = e.PagIbigId,
                SSSId = e.SSSId,
                PhilHealthId = e.PhilHealthId,
                TIN = e.TIN,
                Addresses = e.Addresses != null ?
                    e.Addresses.Where(a => a.Active).Select(a =>
                        new AddressResponse
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
                        new FamilyResponse
                        {
                            Id = f.Id,
                            Name = f.Name,
                            RelationshipType = f.Relationship,
                            IsEmergencyContact = f.IsEmergencyContact,
                            DateOfBirth = f.DateOfBrith.ConvertToTimezone(tz),
                            IsColleague = f.IsColleauge,
                            ContactNumber = f.ContactNumber,
                            ColleagueId = f.IsColleauge ? f.ColleagueId : null,
                            Active = f.Active,
                            AddressId = f.AddressId,
                            Address = f.Address != null ? new AddressResponse
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
                        new SalaryHistoryResponse
                        { 
                            Id = sh.Id,
                            EffectivityDate = sh.EffectivityDate.ConvertToTimezone(tz),
                            BasePay = sh.BasePay,
                            Active = sh.Active
                        }).ToList() : null,
                AllowanceEntitlements = e.Allowances != null ?
                    e.Allowances.Where(a => a.Active).Select(a =>
                        new AllowanceEntitlementResponse
                        {
                            Id = a.Id,
                            Active = a.Active,
                            AllowanceTypeId = a.AllowanceTypeId,
                            AllowanceType = a.AllowanceType != null ?
                                new AllowanceTypeResponse { 
                                    Name = a.AllowanceType.Name
                                } : null,
                            Amount = a.Amount,
                            Period = a.Period,
                           // EffectivityDate = a.EffectivityDate.ConvertToTimezone(tz)
                        }).ToList() : null,
                ShiftScheduleId = e.ShiftScheduleId,
                ShiftSchedules = e.ShiftSchedule != null ? e.ShiftSchedule.ToShiftSchedulesResponse() : null,
            };

        /* Old */
        public static List<EmployeeResponse> ToListResponse(this List<Employee> employee)
        {

            var eeResponse = employee.Select(e => e.ToResponse()).ToList();

            return eeResponse;
        }

        public static IEnumerable<EmployeeResponse> ToEmployeeListResponse(this IEnumerable<Employee> employee)
            => employee.Select(e => e.ToInitialEmployeeResponse()).ToList();

        public static EmployeeNameResponse ToEmployeeNameResponse(this Employee e)
            => new EmployeeNameResponse
            {
                Id = e.Id,
                FirstName = e.Firstname,
                MiddleName = e.Middlename,
                LastName = e.Lastname
            };

        public static EmployeeResponse ToInitialEmployeeResponse(this Employee e, string tz = "China Standard Time")
            => new EmployeeResponse
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
                DateHired = e.DateHired.ConvertToTimezone(tz),
                EmployeeStatus = e.EmployeeStatus,
                ProfileUri = e.ProfileUri
            };

        public static EmployeeResponse ToEmployeeResponse(this Employee e, string tz = "China Standard Time")
            => new EmployeeResponse
            {   
                AvatarUri = e.AvatarUri,
                IsOnBoarding= (e.ObjectId==null || e.ObjectId == Guid.Empty),
                Id = e.Id,
                Code = e.Code,
                FirstName = e.Firstname,
                LastName = e.Lastname,
                MiddleName = e.Middlename,
                Gender = e.Gender,
                Nickname = e.Nickname,
                DateOfBirth = e.DateOfBirth.ConvertToTimezone(tz),
                Citizenship = e.Citizenship,
                CivilStatus = e.CivilStatus,
                BirthPlace = e.BirthPlace,
                BloodType = e.BloodType,
                Religion = e.Religion,
                Email = e.Email,
                ContactNumber = e.Contact,
                PhoneNumber = e.HomePhone,
                ProfileUri = e.ProfileUri,
                Addresses = e.Addresses != null ? 
                    e.Addresses.Select(a => 
                        new AddressResponse { 
                            Id = a.Id,
                            Country = a.Country,
                            State = a.State,
                            City = a.City,
                            Village = a.Village,
                            Street = a.Street,
                            PostalCode = a.PostalCode.ToString(),
                            IsRenting = a.IsRenting,
                            LandLord = a.LandLord,
                            Type = a.AddressType
                        }).ToList() : null,
                Families = e.Family != null ? 
                    e.Family.Select(f =>
                        new FamilyResponse { 
                            Id = f.Id,
                            Name = f.Name,
                            RelationshipType = f.Relationship,
                            IsEmergencyContact = f.IsEmergencyContact,
                            DateOfBirth = f.DateOfBrith.ConvertToTimezone(tz),
                            IsColleague = f.IsColleauge,
                            ContactNumber = f.ContactNumber,
                            ColleagueId = f.IsColleauge ? f.ColleagueId : null,
                            Address = f.Address != null ? new AddressResponse 
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
                                    Type = f.Address.AddressType
                            } : null,
                        }).ToList() : null,
                EmployeeStatus = e.EmployeeStatus,
                DateHired = e.DateHired.ConvertToTimezone(tz),
                DateSeparated = e.DateSeparated != null ? e.DateSeparated.Value.ConvertToTimezone(tz) : null,
                DateRendered = e.DateRendered != null ? e.DateRendered.Value.ConvertToTimezone(tz) : null,
                PositionId = e.Position != null ? e.Position.Id : Guid.Empty,
                Position = e.Position != null ? e.Position.Name : string.Empty,
                PolicyNo = e.PolicyNo,
                CardNo = e.CardNo,
                BankNumber = e.BankNo,
                PagIbigId = e.PagIbigId,
                SSSId = e.SSSId,
                PhilHealthId = e.PhilHealthId,
                TIN = e.TIN,
                SalaryHistory = e.SalaryHistory != null ? e.SalaryHistory.Select(s => 
                    new SalaryHistoryResponse {
                            Id = s.Id,
                            BasePay = s.BasePay,
                            EffectivityDate = s.EffectivityDate.ConvertToTimezone(tz),
                        }).ToList() : null,
                AllowanceEntitlements = e.Allowances != null ? e.Allowances.Select(a =>
                    new AllowanceEntitlementResponse {
                        Id = a.Id,
                        EmployeeId = a.EmployeeId,
                        AllowanceTypeId = a.AllowanceTypeId,
                        AllowanceType = a.AllowanceType != null ? new AllowanceTypeResponse {
                                    Id = a.AllowanceType.Id,
                                    Name = a.AllowanceType.Name,
                                    Amount = a.AllowanceType.Amount,
                                   // Period = a.AllowanceType.Period,
                                    IsDefault = a.AllowanceType.IsDefault
                                } : null,
                        Amount = a.Amount,
                        Period = a.Period,
                       // EffectivityDate = a.EffectivityDate.ConvertToTimezone(tz),
                    }).ToList() : null,
                //Statutories = e.Statutories != null ? e.Statutories.Select(s => 
                //    new StatutoryResponse { 
                //            Id = s.Id,
                //            StatutoryId = s.StutoryId,
                //            StatutoryType = s.StatutoryType
                //        }).ToList() : null
                ShiftScheduleId = e.ShiftScheduleId,
                ShiftSchedules = e.ShiftSchedule != null ? e.ShiftSchedule.ToShiftSchedulesResponse() : null,
            };
        public static PositionResponse ToResponse(this Position d)
            => new PositionResponse
            {
                Id = d.Id,
                Name = d.Name,
                Level = d.Level,
                JobDescription = d.JobDescription
            };

        public static IEnumerable<PositionResponse> ToList(this IEnumerable<Position> list)
            => list.Select(d => d.ToResponse());


        // Team
        public static TeamMemberResponse ToResponse(this TeamMember d)
            => new TeamMemberResponse
            {
                Id = d.Id,
                EmployeeId = d.EmployeeId,
                Employee = d.Employee != null ? d.Employee.ToInitialEmployeeResponse() : null,
                TeamId = d.TeamId.Value,
                Team = d.Team != null ? d.Team.ToResponse() : null,
                DepartmentId = d.Team != null ? d.Team.DepartmentId : null,
                Department = d.Team != null && d.Team.Department != null ? new DepartmentResponse()
                {
                    Id = d.Team.Department.Id,
                    Name = d.Team.Department.Name,
                    ManagerId = d.Team.Department.ManagerId,
                    Manager = d.Team.Department.Manager.ToInitialEmployeeResponse()
                } : null

            };

        public static IEnumerable<TeamMemberResponse> ToList(this IEnumerable<TeamMember> list)
            => list.Select(d => d.ToResponse());

        public static UserSettingsResponse ToResponse(this UserSettings d)
            => new UserSettingsResponse
            {
                Id = d.Id,
                EmployeeId = d.EmployeeId.Value,
                Timezone = d.Timezone,
                UITheme = d.UITheme
            };

    }
}
