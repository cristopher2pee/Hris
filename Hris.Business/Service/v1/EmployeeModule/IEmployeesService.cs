using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Leave;
using Hris.Data.Repository;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Education.Classes.Item.Assignments.Item.Submissions.Item.Return;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.EmployeeModule
{
    public interface IEmployeesService
    {
        Task<Employee?> GetByObjectId(Guid id);
        Task<Employee?> GetByObjectId(Guid id, bool isFull = false);
        Task<Employee?> GetDetailsById(int req, Guid id, bool isObjectId = false);
        Task<IEnumerable<Employee>> GetResources(string? search);
        Task<IEnumerable<Employee>> GetEmployeeByPosition(PositionLevel? param);
        Task<int> GetCount();
        Task<Employee?> GetById(Guid id, bool isFull = false);
        Task<(IEnumerable<Employee> list, int total)> Get(int? page = null,
            int? limit = null, string? search = null,
            Guid? positionId = null, EmployeeStatus? status = null);
        Task<Employee?> GetByEmail(string email);
        Task<Employee> Delete(Guid id, Guid userId);
        Task<Employee> Add(EmployeeDtoRequest entity, Guid userId);

        Task<Employee> Register(EmployeeDtoRequest req, Guid userId, Guid objId);

        Task<Employee> Update(Employee entity, Guid userId);
        Task<Employee?> DeleteEmployee(Guid id, Guid userId);
        Employee ProcessEmployeeRequest(EmployeeDtoRequest entity);

        //  Task<IEnumerable<EmployeeEntitlementsDtoResponse>> GetEmployeeEntitlements(string search);
        Task<PagedResult_<EmployeeEntitlementsDtoResponse>> GetEmployeeEntitlements(EmployeeEntitlementsFilter_ filter);

        Task<IEnumerable<Employee>> GetByCondition(Expression<Func<Employee, bool>> whereExp);

        Task<Employee?> GetProfile(Guid objectId);

        Task<CertificateOfEmploymentDto?> GetCertificateEmploymentResponse(Guid emplyeeId);
        Task<Employee?> GetProfileForCertificate(Guid objectId);

        Task<Employee> GetEmployee(Expression<Func<Employee, bool>> whereExp);
        Task<Employee> CreateDummy(string email);

    }

    internal class EmployeesService : IEmployeesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Employee?> GetProfile(Guid objectId)
        {
            return await _unitOfWork._Employees.GetDbSet().
                AsNoTracking()
                        .Where(d => d.ObjectId.Equals(objectId))
                .Include(d => d.Addresses)
                .Include(d => d.Family)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetByCondition(Expression<Func<Employee, bool>> whereExp)
        {
            var employees = await _unitOfWork._Employees.GetDbSet().Include(e => e.Position)
                .Include(e => e.Addresses)
                .Include(e => e.Family)
                .Where(whereExp)
                .ToListAsync();

            if(employees is null) return Enumerable.Empty<Employee>();
            return employees;
        }

        public async Task<Employee> Update(Employee d, Guid userId)
        {
            try
            {
                var existing = await GetById(d.Id, true);
                if (existing == null)
                    throw new Exception(Resource.Responses.Employee.NOT_FOUND);

                existing.Email = d.Email;
                existing.Firstname = d.Firstname;
                existing.Middlename = d.Middlename;
                existing.Lastname = d.Lastname;
                existing.Nickname = d.Nickname;
                existing.DateOfBirth = d.DateOfBirth;
                existing.Gender = d.Gender;
                existing.HomePhone = d.HomePhone;
                existing.Contact = d.Contact;
                existing.BloodType = d.BloodType;
                existing.Citizenship = d.Citizenship;
                existing.CivilStatus = d.CivilStatus;
                existing.BirthPlace = d.BirthPlace;
                existing.Religion = d.Religion;
                existing.Code = d.Code;
                existing.DateHired = d.DateHired;
                existing.DateSeparated = d.DateSeparated;
                existing.DateRendered = d.DateRendered;
                existing.EmployeeStatus = (EmployeeStatus)d.EmployeeStatus;
                existing.PositionId = d.PositionId;
                existing.BankNo = d.BankNo;
                existing.PolicyNo = d.PolicyNo;
                existing.CardNo = d.CardNo;
                existing.Manual = d.Manual;
                existing.PagIbigId = d.PagIbigId;
                existing.PhilHealthId = d.PhilHealthId;
                existing.SSSId = d.SSSId;
                existing.TIN = d.TIN;
                existing.ShiftScheduleId = d.ShiftScheduleId;

                if (d.Addresses != null && d.Addresses.Count > 0)
                {
                    var list = d.Addresses.ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        var current = list[i];
                        if (current.Id.Equals(Guid.Empty) && current.Active)
                            existing.Addresses.Add(current);
                        else if (existing.Addresses.Any(d => d.Id.Equals(current.Id)))
                        {
                            var e = existing.Addresses.FirstOrDefault(d => d.Id.Equals(current.Id));

                            if (e == null)
                                throw new Exception();

                            e.Country = current.Country;
                            e.State = current.State;
                            e.City = current.City;
                            e.Village = current.Village;
                            e.Street = current.Street;
                            e.PostalCode = current.PostalCode;
                            e.IsRenting = current.IsRenting;
                            e.LandLord = current.IsRenting ? current.LandLord : string.Empty;
                            e.AddressType = current.AddressType;
                            e.Active = current.Active;
                            e.HouseNo = current.HouseNo;
                        }
                    }
                }

                if (d.Family != null && d.Family.Count > 0)
                {
                    var list = d.Family.ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        var current = list[i];
                        if (current.Id.Equals(Guid.Empty) && current.Active)
                            existing.Family.Add(current);
                        else if (existing.Family.Any(d => d.Id.Equals(current.Id)))
                        {
                            var e = existing.Family.FirstOrDefault(d => d.Id.Equals(current.Id));

                            if (e == null)
                                throw new Exception();

                            e.Name = current.Name;
                            e.Active = current.Active;
                            e.Relationship = current.Relationship;
                            e.IsEmergencyContact = current.IsEmergencyContact;
                            e.DateOfBrith = current.DateOfBrith;
                            e.IsColleauge = current.IsColleauge;
                            e.ColleagueId = current.ColleagueId;
                            e.ContactNumber = current.ContactNumber;
                            e.AddressId = current.AddressId;
                            e.Address = current.AddressId == null && current.Address != null ? new Address
                            {
                                Country = current.Address.Country,
                                State = current.Address.State,
                                City = current.Address.City,
                                Village = current.Address.Village,
                                Street = current.Address.Street,
                                PostalCode = current.Address.PostalCode,
                                IsRenting = current.Address.IsRenting,
                                LandLord = current.Address.LandLord,
                                HouseNo = current.Address.HouseNo,
                            } : null;
                        }
                    }
                }

                if (d.SalaryHistory != null && d.SalaryHistory.Count > 0)
                {
                    var list = d.SalaryHistory.ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        var current = list[i];
                        if (current.Id.Equals(Guid.Empty) && current.Active)
                            existing.SalaryHistory.Add(current);
                        else if (existing.SalaryHistory.Any(d => d.Id.Equals(current.Id)))
                        {
                            var e = existing.SalaryHistory.FirstOrDefault(d => d.Id.Equals(current.Id));

                            if (e == null)
                                throw new Exception();

                            e.EffectivityDate = current.EffectivityDate;
                            e.BasePay = current.BasePay;
                            e.PositionId = current.PositionId;
                        }
                    }
                }

                if (d.Allowances != null && d.Allowances.Count > 0)
                {
                    var list = d.Allowances.ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        var current = list[i];
                        if (current.Id.Equals(Guid.Empty) && current.Active)
                            existing.Allowances.Add(current);
                        else if (existing.Allowances.Any(d => d.Id.Equals(current.Id)))
                        {
                            var e = existing.Allowances.FirstOrDefault(d => d.Id.Equals(current.Id));

                            if (e == null)
                                throw new Exception();

                            e.AllowanceTypeId = current.AllowanceTypeId;
                            e.Amount = current.Amount;
                            // e.EffectivityDate = current.EffectivityDate;
                            e.Period = current.Period;
                        }
                    }
                }

                //if (d.Statutories != null && d.Statutories.Count > 0)
                //{
                //    var list = d.Statutories.ToList();
                //    for (int i = 0; i < list.Count; i++)
                //    {
                //        var current = list[i];
                //        if (current.Id.Equals(Guid.Empty) && current.Active)
                //            existing.Statutories.Add(current);
                //        else if (existing.Statutories.Any(d => d.Id.Equals(current.Id)))
                //        {
                //            var e = existing.Statutories.FirstOrDefault(d => d.Id.Equals(current.Id));

                //            if (e == null)
                //                throw new Exception();

                //            e.StatutoryType = current.StatutoryType;
                //            e.StutoryId = current.StutoryId;
                //        }
                //    }
                //}
                d = await _unitOfWork._Employees.UpdateAsync(existing);
                await _unitOfWork.SaveChangeAsync(userId);
                return d;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Employee> Add(Employee entity, Guid userId)
        {
            try
            {
                var existing = await GetById(entity.Id);
                if (existing == null)
                    throw new Exception(Resource.Responses.Employee.EXISTING);

                entity = await _unitOfWork._Employees.AddAsync(entity);
                await _unitOfWork.SaveChangeAsync(userId);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<Employee> Delete(Guid id, Guid userId)
        {
            try
            {
                var existing = await GetById(id);
                if (existing == null)
                    throw new Exception(Resource.Responses.Employee.NOT_FOUND);

                await _unitOfWork._Employees.DeleteAsync(existing);
                await _unitOfWork.SaveChangeAsync(userId);

                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public async Task<(IEnumerable<Employee> list, int total)> Get(int? page = null,
            int? limit = null, string? search = null, Guid? positionId = null, EmployeeStatus? status = null)
        {
            var res = _unitOfWork._Employees.GetDbSet()
                .AsEnumerable()
                .Where(f => (!search.IsNullOrEmpty() ? f.Firstname.Has(search)
                    || f.Lastname.Has(search)
                    : true)
                    && (positionId != null ? f.PositionId.Equals(positionId) : true)
                    && (status != null ? f.EmployeeStatus.Equals(status) : true))
                .AsQueryable();

            return (!page.HasValue && !limit.HasValue ? res :
                res.Skip((page.Value - 1) * limit.Value)
                .Take(limit.Value)
                .OrderBy(d => d.Lastname), res.Count());
        }
        public async Task<Employee?> GetByEmail(string email)
        {
            return await _unitOfWork._Employees.GetDbSet()
                .Where(f => f.Email.ToLower().Equals(email.ToLower()))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        public async Task<Employee?> GetById(Guid id, bool isFull = false)
        {
            return isFull ?
               await _unitOfWork._Employees
                    .GetDbSet()
                    .AsNoTracking()
                    .Where(d => d.Id.Equals(id))
                    .Include(d => d.Position)
                    .Include(d => d.Addresses)
                    .Include(d => d.ShiftSchedule)
                    .Include(d => d.Family)
                        .ThenInclude(d => d.Address)
                    .Include(d => d.SalaryHistory)
                    .Include(d => d.Allowances)
                        .ThenInclude(a => a.AllowanceType)
                    // .Include(d => d.Statutories)
                    .FirstOrDefaultAsync() :
               await _unitOfWork._Employees
                    .GetDbSet()
                    .AsNoTracking()
                    .Where(d => d.Id.Equals(id))
                    .FirstOrDefaultAsync();
        }
        public async Task<Employee?> GetByObjectId(Guid id)
        {
            return await _unitOfWork._Employees
                .GetDbSet()
                .AsNoTracking()
                .Where(f => f.ObjectId.Equals(id))
                .FirstOrDefaultAsync();
        }
        public async Task<Employee?> GetByObjectId(Guid id, bool isFull = false)
        {
            return isFull ?
              await _unitOfWork._Employees.GetDbSet()
                  .AsNoTracking()
                  .Include(e => e.Position)
                  .Include(e => e.ShiftSchedule)
                  .Include(e => e.Addresses)
                  .Include(e => e.Family)
                  .Include(e => e.SalaryHistory)
                  .Include(e => e.Allowances)
                  //  .Include(e => e.Statutories)
                  .Where(e => e.ObjectId == id)
                  .FirstOrDefaultAsync() :
              await _unitOfWork._Employees.GetDbSet()
                  .AsNoTracking()
                  .Where(e => e.ObjectId == id)
                  .Include(d => d.Settings)
                  .FirstOrDefaultAsync();
        }
        public async Task<int> GetCount()
        {
            return await _unitOfWork._Employees.GetCount();
        }

        public async Task<Employee?> GetDetailsById(int req, Guid id, bool isObjectId = false)
        {
            switch (req)
            {
                case 1:
                    return await _unitOfWork._Employees.GetDbSet()
                        .Where(d => isObjectId ? d.ObjectId.Equals(id) : d.Id.Equals(id))
                        .FirstOrDefaultAsync();
                case 2:
                    return await _unitOfWork._Employees.GetDbSet()
                         .Where(d => isObjectId ? d.ObjectId.Equals(id) : d.Id.Equals(id))
                         .Include(d => d.Addresses)
                         .Include(d => d.Family)
                         .FirstOrDefaultAsync();
                case 3:
                    return await _unitOfWork._Employees.GetDbSet()
                        .Where(d => isObjectId ? d.ObjectId.Equals(id) : d.Id.Equals(id))
                        .Include(d => d.Settings)
                        .Include(d => d.Position)
                        .Include(d => d.ShiftSchedule)
                        .FirstOrDefaultAsync();
                default:
                    return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetEmployeeByPosition(PositionLevel? param)
        {
            var result = param != null ?
              await _unitOfWork._Employees
                .GetDbSet()
                .AsNoTracking()
                .Include(e => e.Position)
                .Where(f => f.Position != null && f.Position.Level == param)
                .ToListAsync() :
              await _unitOfWork._Employees
                .GetDbSet()
                .AsNoTracking()
                .Include(f => f.Position)
                .ToListAsync();

            if(result is null) return Enumerable.Empty<Employee>();
            return result;
        }
        public async Task<IEnumerable<Employee>> GetResources(string? search)
        {

            var result = string.IsNullOrEmpty(search) ?
                  await _unitOfWork._Employees
                     .GetDbSet()
                     .AsNoTracking()
                     .ToListAsync() :
                 await _unitOfWork._Employees.GetDbSet().AsNoTracking()
                     .Where(d => d.Firstname.ToLower().Contains(search.ToLower())
                     || d.Lastname.ToLower().Contains(search.ToLower())
                     || d.Middlename.ToLower().Contains(search.ToLower()))
                     .ToListAsync();

            if(result is null) return Enumerable.Empty<Employee>();
            return result;
        }

        public async Task<Employee?> DeleteEmployee(Guid id, Guid userId)
        {
            try
            {
                var employee = await _unitOfWork._Employees.GetDbSet()
                        .Include(d => d.Position)
                        .Include(d => d.Settings)
                        .Include(d => d.Permission)
                        .Include(d => d.Addresses)
                        .Include(d => d.Family)
                        .Include(d => d.SalaryHistory)
                        .Include(d => d.Allowances)
                        //   .Include(d => d.Statutories)
                        .Include(d => d.TeamMembers)
                        .Include(d => d.AssignedProjects)
                    .FirstOrDefaultAsync(f => f.Id.Equals(id));

                if (employee == null) return null;

                if (employee.Addresses != null && employee.Addresses.Count > 0)
                {
                    await _unitOfWork._Address.DeleteRange(employee.Addresses.ToArray());
                    await _unitOfWork.SaveChangeAsync(userId);
                }

                if (employee.Family != null && employee.Family.Count > 0)
                {
                    await _unitOfWork._Family.DeleteRange(employee.Family.ToArray());
                    await _unitOfWork.SaveChangeAsync(userId);
                }

                if (employee.SalaryHistory != null && employee.SalaryHistory.Count > 0)
                {
                    await _unitOfWork._SalaryHistory.DeleteRange(employee.SalaryHistory.ToArray());
                    await _unitOfWork.SaveChangeAsync(userId);
                }

                if (employee.Allowances != null && employee.Allowances.Count > 0)
                {
                    await _unitOfWork._AllowanceEntitlement.DeleteRange(employee.Allowances.ToArray());
                    await _unitOfWork.SaveChangeAsync(userId);
                }

                //if (employee.Statutories != null && employee.Statutories.Count > 0)
                //{
                //    await _unitOfWork._Statutory.DeleteRange(employee.Statutories.ToArray());
                //    await _unitOfWork.SaveChangeAsync(userId);
                //}

                if (employee.TeamMembers != null && employee.TeamMembers.Count > 0)
                {
                    await _unitOfWork._TeamMember.DeleteRange(employee.TeamMembers.ToArray());
                    await _unitOfWork.SaveChangeAsync(userId);
                }

                if (employee.AssignedProjects != null && employee.AssignedProjects.Count > 0)
                {
                    await _unitOfWork._AssignedProject.DeleteRange(employee.AssignedProjects.ToArray());
                    await _unitOfWork.SaveChangeAsync(userId);
                }

                if (employee.Permission != null)
                {
                    await _unitOfWork._Permission.DeleteAsync(employee.Permission);
                    await _unitOfWork.SaveChangeAsync(userId);
                }

                if (employee.Settings != null)
                {
                    await _unitOfWork._UserSettings.DeleteAsync(employee.Settings);
                    await _unitOfWork.SaveChangeAsync(userId);
                }

                var leaveApplication = await _unitOfWork._LeaveApplication.GetDbSet()
                    .Where(f => f.EmployeeId.Equals(id)).ToListAsync();

                if (leaveApplication != null && leaveApplication.Count > 0)
                {
                    await _unitOfWork._LeaveApplication.DeleteRange(leaveApplication.ToArray());
                    await _unitOfWork.SaveChangeAsync(userId);
                }

                var track = await _unitOfWork._Track.GetDbSet().Where(f => f.EmployeeId.Equals(id)).ToListAsync();
                if (track != null && track.Count > 0)
                {
                    await _unitOfWork._Track.DeleteRange(track.ToArray());
                    await _unitOfWork.SaveChangeAsync(userId);
                }

                await _unitOfWork._Employees.DeleteAsync(employee);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? employee : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<Employee?> Add(EmployeeDtoRequest request, Guid userId)
        {
            try
            {
                var employee = new Employee
                {
                    Id = request.Id,
                    Email = request.Email,
                    Firstname = request.Firstname,
                    Middlename = request.Middlename,
                    Lastname = request.Lastname,
                    DateOfBirth = request.DateOfBirth,
                    Gender = request.Gender,
                    BloodType = request.BloodType,
                    Citizenship = request.Citizenship,
                    CivilStatus = request.CivilStatus,
                    BirthPlace = request.Birthplace,
                    Contact = request.ContactNumber,
                    HomePhone = request.PhoneNumber,
                    Nickname = request.Nickname,
                    Religion = request.Religion,
                    Code = request.Code,
                    DateHired = request.DateHired,
                    DateSeparated = request.DateSeparated,
                    DateRendered = request.DateRendered,
                    EmployeeStatus = (EmployeeStatus)request.EmployeeStatus,
                    PositionId = request.PositionId.HasValue && request.PositionId.Equals(Guid.Empty) ? null : request.PositionId,
                    BankNo = request.BankNumber,
                    PolicyNo = request.PolicyNo,
                    CardNo = request.CardNo,
                    PagIbigId = request.PagIbigId,
                    PhilHealthId = request.PhilHealthId,
                    SSSId = request.SSSId,
                    TIN = request.TIN,
                    Addresses = request.Addresses.Any() ?
                        request.Addresses.Select(d => new Address
                        {
                            Id = d.Id,
                            Country = d.Country,
                            State = d.State,
                            City = d.City,
                            Village = d.Village,
                            Street = d.Street,
                            PostalCode = d.PostalCode,
                            IsRenting = d.IsRenting,
                            LandLord = d.IsRenting ? d.LandLord : null,
                            AddressType = (AddressType)d.Type,
                            HouseNo = d.HouseNo,
                            Active = d.Active
                        }).ToList() : null,
                    Family = request.Families.Any() ?
                        request.Families.Select(d => new Family
                        {
                            Id = d.Id,
                            Active = d.Active,
                            Name = d.Name,
                            Relationship = d.RelationshipType,
                            DateOfBrith = d.DateOfBirth,
                            ContactNumber = d.ContactNumber,
                            IsEmergencyContact = d.IsEmergencyContact,
                            IsColleauge = d.IsColleague,
                            ColleagueId = d.ColleagueId,
                            AddressId = d.AddressId,
                            Address = d.AddressId == null && d.Address != null ? new Address
                            {
                                Country = d.Address.Country,
                                State = d.Address.State,
                                City = d.Address.City,
                                Village = d.Address.Village,
                                Street = d.Address.Street,
                                PostalCode = d.Address.PostalCode,
                                IsRenting = d.Address.IsRenting,
                                LandLord = d.Address.IsRenting ? d.Address.LandLord : null,
                                HouseNo = d.Address.HouseNo,
                            } : null
                        }).ToList() : null,
                    SalaryHistory = request.SalaryHistory.Any() ?
                        request.SalaryHistory.Select(d => new SalaryHistory
                        {
                            Id = d.Id,
                            Active = d.Active,
                            EffectivityDate = d.EffectivityDate,
                            BasePay = d.BasePay,
                            PositionId = request.PositionId.Value
                        }).ToList() : null,
                    Allowances = request.AllowanceEntitlements.Any() ?
                        request.AllowanceEntitlements.Select(d => new Data.Models.Payroll.AllowanceEntitlement
                        {
                            Id = d.Id,
                            Active = d.Active,
                            AllowanceTypeId = d.AllowanceTypeId,
                            Amount = d.Amount,
                            //EffectivityDate = d.EffectivityDate,
                            Period = d.Period
                        }).ToList() : null,
                    //Statutories = request.Statutories.Any() ?
                    //    request.Statutories.Select(d => new Statutory
                    //    {
                    //        Id = d.Id,
                    //        Active = d.Active,
                    //        StatutoryType = d.StatutoryType,
                    //        StutoryId = d.StatutoryId
                    //    }).ToList() : null,
                    Active = request.Active,
                    ShiftScheduleId = request.ShiftScheduleId,
                };

                await _unitOfWork._Employees.AddAsync(employee);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? employee : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Employee ProcessEmployeeRequest(EmployeeDtoRequest request)
        {
            var d = new Employee
            {
                Id = request.Id,
                Email = request.Email,
                Firstname = request.Firstname,
                Middlename = request.Middlename,
                Lastname = request.Lastname,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                BloodType = request.BloodType,
                Citizenship = request.Citizenship,
                CivilStatus = request.CivilStatus,
                BirthPlace = request.Birthplace,
                Contact = request.ContactNumber,
                HomePhone = request.PhoneNumber,
                Nickname = request.Nickname,
                Religion = request.Religion,
                Code = request.Code,
                DateHired = request.DateHired,
                DateSeparated = request.DateSeparated,
                DateRendered = request.DateRendered,
                EmployeeStatus = (EmployeeStatus)request.EmployeeStatus,
                PositionId = request.PositionId.HasValue && request.PositionId.Equals(Guid.Empty) ? null : request.PositionId,
                BankNo = request.BankNumber,
                PolicyNo = request.PolicyNo,
                CardNo = request.CardNo,
                PagIbigId = request.PagIbigId,
                PhilHealthId = request.PhilHealthId,
                SSSId = request.SSSId,
                TIN = request.TIN,
                Addresses = request.Addresses != null && request.Addresses.Any() ?
          request.Addresses.Select(d => new Address
          {
              Id = d.Id,
              Country = d.Country,
              State = d.State,
              City = d.City,
              Village = d.Village,
              Street = d.Street,
              PostalCode = d.PostalCode,
              IsRenting = d.IsRenting,
              LandLord = d.IsRenting ? d.LandLord : null,
              AddressType = (AddressType)d.Type,
              Active = d.Active,
              HouseNo = d.HouseNo,
          }).ToList() : null,
                Family = request.Families != null && request.Families.Any() ?
          request.Families.Select(d => new Family
          {
              Id = d.Id,
              Active = d.Active,
              Name = d.Name,
              Relationship = d.RelationshipType,
              DateOfBrith = d.DateOfBirth,
              ContactNumber = d.ContactNumber,
              IsEmergencyContact = d.IsEmergencyContact,
              IsColleauge = d.IsColleague,
              ColleagueId = d.ColleagueId,
              AddressId = d.AddressId,
              Address = d.AddressId == null && d.Address != null ? new Address
              {
                  Country = d.Address.Country,
                  State = d.Address.State,
                  City = d.Address.City,
                  Village = d.Address.Village,
                  Street = d.Address.Street,
                  PostalCode = d.Address.PostalCode,
                  IsRenting = d.Address.IsRenting,
                  LandLord = d.Address.IsRenting ? d.Address.LandLord : null,
                  HouseNo = d.Address.HouseNo,
              } : null
          }).ToList() : null,
                SalaryHistory = request.SalaryHistory != null && request.SalaryHistory.Any() ?
          request.SalaryHistory.Select(d => new SalaryHistory
          {
              Id = d.Id,
              Active = d.Active,
              EffectivityDate = d.EffectivityDate,
              BasePay = d.BasePay,
              PositionId = request.PositionId.Value
          }).ToList() : null,
                Allowances = request.AllowanceEntitlements != null && request.AllowanceEntitlements.Any() ?
          request.AllowanceEntitlements.Select(d => new Data.Models.Payroll.AllowanceEntitlement
          {
              Id = d.Id,
              Active = d.Active,
              AllowanceTypeId = d.AllowanceTypeId,
              Amount = d.Amount,
              //EffectivityDate = d.EffectivityDate,
              Period = d.Period
          }).ToList() : null,
                //      Statutories = request.Statutories != null && request.Statutories.Any() ?
                //request.Statutories.Select(d => new Statutory
                //{
                //    Id = d.Id,
                //    Active = d.Active,
                //    StatutoryType = d.StatutoryType,
                //    StutoryId = d.StatutoryId
                //}).ToList() : null,
                Active = request.Active,
                ShiftScheduleId = request.ShiftScheduleId
            };

            return d;
        }

        public async Task<PagedResult_<EmployeeEntitlementsDtoResponse>> GetEmployeeEntitlements(EmployeeEntitlementsFilter_ filter)
        {
            var result = _unitOfWork._Employees.GetDbSet()
                .Include(f => f.Allowances)
                .ThenInclude(f => f.AllowanceType)
                .AsEnumerable()
                .Where(e => e.Allowances != null && e.Allowances.Any()
                  && (e.Firstname.Contains(filter.Search, StringComparison.OrdinalIgnoreCase)
                || e.Middlename.Contains(filter.Search, StringComparison.OrdinalIgnoreCase)
                || e.Lastname.Contains(filter.Search, StringComparison.OrdinalIgnoreCase)))
                .Select(e => new EmployeeEntitlementsDtoResponse
                {
                    Employee = e.ToInitialEmployeeResponse(),
                    EntitlementCount = e.Allowances != null ? e.Allowances.Count : 0,
                    Entitlements = e.Allowances != null ? e.Allowances.Select(a => new AllowanceEntitlementDtoResponse
                    {
                        Id = a.Id,
                        EmployeeId = a.EmployeeId,
                        Amount = a.Amount,
                        //  EffectivityDate = a.EffectivityDate,
                        Period = a.Period,
                        AllowanceTypeId = a.AllowanceTypeId,
                        AllowanceType = new AllowanceTypeDtoResponse
                        {
                            Id = a.AllowanceType.Id,
                            Name = a.AllowanceType.Name,
                            Amount = a.AllowanceType.Amount,
                            // Period = a.AllowanceType.Period,
                            IsDefault = a.AllowanceType.IsDefault
                        }
                    }).ToList() : null
                })
                .OrderBy(e => e.Id)
                .ToPagedList_(filter.Page, filter.Limit);

            return result;
        }

        public async Task<CertificateOfEmploymentDto?> GetCertificateEmploymentResponse(Guid emplyeeId)
        {
            var employee = await _unitOfWork._Employees.GetDbSet()
                .Include(f => f.SalaryHistory)
                .Include(f => f.Allowances)
                .Include(f => f.Position)
                // .Include(f=>f.ShiftSchedule)
                .Where(f => f.Id.Equals(emplyeeId))
                .Select(e => new CertificateOfEmploymentDto
                {
                    Id = e.Id,
                    LatestSalary = e.SalaryHistory != null && e.SalaryHistory.Any() ?
                        e.SalaryHistory.OrderByDescending(f => f.EffectivityDate).FirstOrDefault() : null,
                    TotalAllowance = e.Allowances != null && e.Allowances.Any() ? e.Allowances.Sum(e => e.Amount) : 0,
                    FirstName = e.Firstname,
                    MiddleName = e.Middlename,
                    LastName = e.Lastname,
                    DateHired = e.DateHired,
                    DateSeparated = e.DateSeparated,
                    EmployeeStatus = e.EmployeeStatus,
                    Gender = e.Gender,
                    Position = e.Position != null ? e.Position.ToPisitionResponse() : null,
                    ObjectId = e.ObjectId
                })
                .FirstOrDefaultAsync();


            if (employee is null) return null;

            var latestLeaveApplication = await _unitOfWork._LeaveApplication.GetDbSet()
                .Include(f => f.LeaveType)
                .Include(f => f.ApprovedByLead)
                .Include(f => f.ApprovedByManager)
                .Where(f => f.EmployeeId.Equals(employee.Id)
                    && f.From >= DateTime.Now
                    && (f.Status == LeaveStatus.HeadApproved
                        || f.Status == LeaveStatus.LeadApproved))
                .OrderByDescending(f => f.From)
                .FirstOrDefaultAsync();

            if (latestLeaveApplication is not null)
                employee.UpcomingLeave = latestLeaveApplication.ToLeaveApplicationDtoResponse();

            return employee;
        }

        public async Task<Employee?> GetProfileForCertificate(Guid objectId)
            => await _unitOfWork._Employees
                .GetDbSet()
                .AsNoTracking()
                .Where(d => d.ObjectId.Equals(objectId))
                .Include(d => d.Settings)
                .Include(d => d.Position)
                .FirstOrDefaultAsync();

        public async Task<Employee> GetEmployee(Expression<Func<Employee, bool>> whereExp)
        {
            var result = await _unitOfWork._Employees.GetDbSet()
                 .AsNoTracking()
                 .Where(whereExp)
                 .FirstOrDefaultAsync();

            return result;
        }

        public async Task<Employee> Register(EmployeeDtoRequest request, Guid userId, Guid objId)
        {
            try
            {
                var employee = new Employee
                {
                    Id = request.Id,
                    Email = request.Email,
                    Firstname = request.Firstname,
                    Middlename = request.Middlename,
                    Lastname = request.Lastname,
                    DateOfBirth = request.DateOfBirth,
                    Gender = request.Gender,
                    BloodType = request.BloodType,
                    Citizenship = request.Citizenship,
                    CivilStatus = request.CivilStatus,
                    BirthPlace = request.Birthplace,
                    Contact = request.ContactNumber,
                    HomePhone = request.PhoneNumber,
                    Nickname = request.Nickname,
                    Religion = request.Religion,
                    Code = request.Code,
                    DateHired = request.DateHired,
                    DateSeparated = request.DateSeparated,
                    DateRendered = request.DateRendered,
                    EmployeeStatus = (EmployeeStatus)request.EmployeeStatus,
                    PositionId = request.PositionId.HasValue && request.PositionId.Equals(Guid.Empty) ? null : request.PositionId,
                    BankNo = request.BankNumber,
                    PolicyNo = request.PolicyNo,
                    CardNo = request.CardNo,
                    PagIbigId = request.PagIbigId,
                    PhilHealthId = request.PhilHealthId,
                    SSSId = request.SSSId,
                    TIN = request.TIN,
                    Addresses = request.Addresses.Any() ?
                        request.Addresses.Select(d => new Address
                        {
                            Id = d.Id,
                            Country = d.Country,
                            State = d.State,
                            City = d.City,
                            Village = d.Village,
                            Street = d.Street,
                            PostalCode = d.PostalCode,
                            IsRenting = d.IsRenting,
                            LandLord = d.IsRenting ? d.LandLord : null,
                            AddressType = (AddressType)d.Type,
                            HouseNo = d.HouseNo,
                            Active = d.Active
                        }).ToList() : null,
                    Family = request.Families.Any() ?
                        request.Families.Select(d => new Family
                        {
                            Id = d.Id,
                            Active = d.Active,
                            Name = d.Name,
                            Relationship = d.RelationshipType,
                            DateOfBrith = d.DateOfBirth,
                            ContactNumber = d.ContactNumber,
                            IsEmergencyContact = d.IsEmergencyContact,
                            IsColleauge = d.IsColleague,
                            ColleagueId = d.ColleagueId,
                            AddressId = d.AddressId,
                            Address = d.AddressId == null && d.Address != null ? new Address
                            {
                                Country = d.Address.Country,
                                State = d.Address.State,
                                City = d.Address.City,
                                Village = d.Address.Village,
                                Street = d.Address.Street,
                                PostalCode = d.Address.PostalCode,
                                IsRenting = d.Address.IsRenting,
                                LandLord = d.Address.IsRenting ? d.Address.LandLord : null,
                                HouseNo = d.Address.HouseNo,
                            } : null
                        }).ToList() : null,
                    SalaryHistory = request.SalaryHistory.Any() ?
                        request.SalaryHistory.Select(d => new SalaryHistory
                        {
                            Id = d.Id,
                            Active = d.Active,
                            EffectivityDate = d.EffectivityDate,
                            BasePay = d.BasePay,
                            PositionId = request.PositionId.Value
                        }).ToList() : null,
                    Allowances = request.AllowanceEntitlements.Any() ?
                        request.AllowanceEntitlements.Select(d => new Data.Models.Payroll.AllowanceEntitlement
                        {
                            Id = d.Id,
                            Active = d.Active,
                            AllowanceTypeId = d.AllowanceTypeId,
                            Amount = d.Amount,
                            //EffectivityDate = d.EffectivityDate,
                            Period = d.Period
                        }).ToList() : null,
                    //Statutories = request.Statutories.Any() ?
                    //    request.Statutories.Select(d => new Statutory
                    //    {
                    //        Id = d.Id,
                    //        Active = d.Active,
                    //        StatutoryType = d.StatutoryType,
                    //        StutoryId = d.StatutoryId
                    //    }).ToList() : null,
                    Active = request.Active,
                    ShiftScheduleId = request.ShiftScheduleId,
                    ObjectId = userId
                };

                var result = await _unitOfWork._Employees.AddAsync(employee);
                await _unitOfWork.SaveChangeAsync(userId);

                return
                    result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Employee> CreateDummy(string email)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = Guid.NewGuid(),
                    Active = true,
                    Email = email,
                    Code = string.Empty,
                    Contact = string.Empty,
                    HomePhone = string.Empty,
                    Firstname = string.Empty,
                    Lastname = string.Empty,
                    Middlename = string.Empty,
                    BirthPlace = string.Empty,
                    Gender = Data.Models.Enum.Gender.Others,
                    CivilStatus = Data.Models.Enum.CivilStatus.Single,
                    Citizenship = string.Empty,
                    Religion = string.Empty,
                    DateHired = DateTime.UtcNow,
                };

                var result = await _unitOfWork._Employees.AddAsync(employee);
                await _unitOfWork.SaveChangeAsync(Guid.Empty);
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
