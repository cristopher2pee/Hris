using Hris.Data.DTO;
using Hris.Data.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Extensions
{
    public static class EmployeesExtenstion_
    {
        public static EmployeeDtoResponse ToInitialEmployeeResponse(this Employee e, string tz = "China Standard Time")
            => new EmployeeDtoResponse
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

        public static EmployeeDtoResponse ToResponse(this Employee e, string tz = "China Standard Time")
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
                    DateOfBirth = f.DateOfBrith.ConvertToTimezone(tz),
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
                    EffectivityDate = sh.EffectivityDate.ConvertToTimezone(tz),
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
                  //  EffectivityDate = a.EffectivityDate.ConvertToTimezone(tz)
                }).ToList() : null,
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
