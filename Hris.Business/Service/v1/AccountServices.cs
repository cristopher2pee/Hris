using Hris.Business.Service.v1.EmployeeModule;
using Hris.Data.DTO;
using Hris.Data.Models;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.UnitOfWork;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.CallRecords;
using Microsoft.Graph.Models.TermStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hris.Business.Service.v1
{
    public interface IAccountServices
    {
        Task<Employee?> OnBoardingUser(EmployeeDtoRequest employee, Guid objId);
    }
    internal class AccountServices : IAccountServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeesService _employeesService;
        private readonly IAuthInviteService _authInviteService;

        public AccountServices(IUnitOfWork unitOfWork,
            IEmployeesService employeesService,
            IAuthInviteService authInviteService)
        {
            _unitOfWork = unitOfWork;
            _employeesService = employeesService;
            _authInviteService = authInviteService;
        }


        public async Task<Employee?> OnBoardingUser(EmployeeDtoRequest employee, Guid objId)
        {
            try
            {
                var existingEmployee = await _employeesService.GetByEmail(employee.Email);

                if (existingEmployee == null)
                    throw new NullReferenceException();

                existingEmployee.ObjectId = objId;
                existingEmployee.Email = employee.Email;
                existingEmployee.Firstname = employee.Firstname;
                existingEmployee.Lastname = employee.Lastname;
                existingEmployee.Middlename = employee.Middlename;
                existingEmployee.DateOfBirth = employee.DateOfBirth;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.BloodType = employee.BloodType;
                existingEmployee.Citizenship = employee.Citizenship;
                existingEmployee.CivilStatus = employee.CivilStatus;
                existingEmployee.BirthPlace = employee.Birthplace;
                existingEmployee.Contact = employee.ContactNumber;
                existingEmployee.HomePhone = employee.ContactNumber;
                existingEmployee.DateHired = employee.DateHired;
                existingEmployee.Nickname = employee.Nickname;
                existingEmployee.Religion = employee.Religion;
                existingEmployee.Addresses = employee.Addresses?
                    .Select(a => new Hris.Data.Models.Employee.Address
                    {
                        Active = true,
                        Country = a.Country,
                        State = a.State,
                        City = a.City,
                        Village = a.Village,
                        Street = a.Street,
                        PostalCode = a.PostalCode,
                        IsRenting = a.IsRenting,
                        LandLord = a.IsRenting ? a.LandLord : string.Empty,
                        AddressType = a.Type,
                        HouseNo = a.HouseNo,
                    }).ToList();
                existingEmployee.Family = employee.Families?
                    .Select(f => new Family
                    {
                        Active = true,
                        Name = f.Name,
                        Relationship = f.RelationshipType,
                        IsEmergencyContact = f.IsEmergencyContact,
                        DateOfBrith = f.DateOfBirth,
                        IsColleauge = f.IsColleague,
                        ContactNumber = f.ContactNumber,
                        Address = f.Address != null ? new Data.Models.Employee.Address
                        {
                            Country = f.Address.Country,
                            State = f.Address.State,
                            City = f.Address.City,
                            Village = f.Address.Village,
                            Street = f.Address.Street,
                            PostalCode = f.Address.PostalCode,
                            IsRenting = f.Address.IsRenting,
                            LandLord = f.Address.IsRenting ? f.Address.LandLord : string.Empty,
                            HouseNo = f.Address?.HouseNo,
                        } : null,
                    }).ToList();
                existingEmployee.Code = string.Empty;
                existingEmployee.EmployeeStatus = EmployeeStatus.Probationary;
                existingEmployee.BankNo = string.Empty;
                existingEmployee.Settings = new Hris.Data.Models.Settings.UserSettings
                {
                    Timezone = "China Standard Time"
                };
                existingEmployee.Active = true;

                await _unitOfWork._Employees.UpdateAsync(existingEmployee);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? existingEmployee : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
