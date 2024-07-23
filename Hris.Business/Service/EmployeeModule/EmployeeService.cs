using Hris.Business.Extensions;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Settings;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using Employee = Hris.Data.Models.Employee.Employee;
using UserSettings = Hris.Data.Models.Settings.UserSettings;

namespace Hris.Business.Service.EmployeeModule
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetResource(string? search)
            => string.IsNullOrEmpty(search) ? await this.repository.GetAllAsync()
                : await this.repository.FindListByConditionAsync(d => d.Firstname.ToLower().Contains(search.ToLower()) 
                    || d.Lastname.ToLower().Contains(search.ToLower())
                    || d.Middlename.ToLower().Contains(search.ToLower()));

        public async Task<IEnumerable<Employee>> GetResourceByManager()
            => await this.repository.FindListByConditionAsync(d => d.Position != null && d.Position.Level == PositionLevel.Manager);

        public async Task<IEnumerable<Employee>> GetResourceByLead()
            => await this.repository.FindListByConditionAsync(d => d.Position != null && d.Position.Level == PositionLevel.TeamLead);

        public async Task<IEnumerable<Employee>> GetResourceByMember()
            => (await this.repository.GetDbSet())
                .AsNoTracking()
                .Include(d => d.Position)
                .ToList();

        public async Task<int> GetCount()
            => await repository.GetCount();

        public async Task<Employee?> GetById(Guid id, bool full = false)
            => full ? (await repository.GetDbSet())
                .Where(d => d.Id.Equals(id))
                .Include(d => d.Position)
                .Include(d => d.Addresses)
                .Include(d => d.Family)
                    .ThenInclude(d => d.Address)
                .Include(d => d.SalaryHistory)
                .Include(d => d.Allowances)
                    .ThenInclude(a => a.AllowanceType)
               // .Include(d => d.Statutories)
                .FirstOrDefault()
            : (await repository.GetDbSet())
                .Where(d => d.Id.Equals(id))
                .FirstOrDefault();

        public async Task<Employee?> GetByObjectId(Guid id, bool full = true)
            => full ? 
            await (await repository.GetDbSet())
                .AsNoTracking()
                .Include(e => e.Position)
                .Include(e => e.Addresses)
                .Include(e => e.Family)
                .Include(e => e.SalaryHistory)
                .Include(e => e.Allowances)
               // .Include(e => e.Statutories)
                .Where(e => e.ObjectId == id)
                .FirstOrDefaultAsync()
            : await (await repository.GetDbSet())
                .AsNoTracking()
                .Where(e => e.ObjectId == id)
                .Include(d => d.Settings)
                .FirstOrDefaultAsync();

        public async Task<Employee?> GetDetailsById(int req, Guid id, bool isObjectId = false)
        {
            var set = await repository.GetDbSet();
            switch(req)
            {
                case 1: // No Includes
                    return await set.AsNoTracking()
                        .Where(d => !isObjectId ? d.Id.Equals(id) : d.ObjectId.Equals(id))
                        .FirstOrDefaultAsync();
                case 2: // Profile
                    return await set.AsNoTracking()
                        .Where(d => !isObjectId ? d.Id.Equals(id) : d.ObjectId.Equals(id))
                        .Include(d => d.Addresses)
                        .Include(d => d.Family)
                        .FirstOrDefaultAsync();
                case 3: // Employment Details
                    return await set.AsNoTracking()
                        .Where(d => !isObjectId ? d.Id.Equals(id) : d.ObjectId.Equals(id))
                        .Include(d => d.Settings)
                        .Include(d => d.Position)
                        .FirstOrDefaultAsync();
                default:
                    return null;
            }
        }

        public async Task<(IEnumerable<Employee> list, int total)> Get(int? page = null, int? limit = null, string? search = null, Guid? positionId = null, EmployeeStatus? status = null)
        {
            var q = (await repository.GetDbSet())
                .AsNoTracking()
                .AsEnumerable()
                .Where(d => d.Active)
                .Where(d => (!search.IsNullOrEmpty() ? d.Firstname.Has(search)
                     /*   || (d.Middlename != null ? d.Middlename.Has(search) : true)*/
                        || d.Lastname.Has(search)
                        : true)
                    && (positionId != null ? d.PositionId.Equals(positionId) : true)
                    && (status != null ? d.EmployeeStatus.Equals(status) : true));

            return (!page.HasValue && !limit.HasValue ? q :
                        q.Skip((page.Value - 1) * limit.Value)
                            .Take(limit.Value)
                            .OrderBy(d => d.Lastname), q.Count());
        }

        public async Task<Employee?> GetByEmail(string email)
            => (await repository.GetDbSet())
                .AsNoTracking()
                .Where(d => d.Email.ToLower().Equals(email.ToLower()))
                .FirstOrDefault();

        /*        public async Task<UserSettings> UpdateSettings(UserSettings d, Guid userId)
                {
                    try
                    {
                        var existing = await GetSettingsById(d.Id);

                        if (existing == null)
                            throw new NullReferenceException();

                        existing.Timezone = d.Timezone;
                        existing.UITheme = d.UITheme;

                        await settingsRepository.Update(existing);
                        await SaveSettingsChangesAsync(userId);
                        return d;

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }*/

        public async Task<Employee> Delete(Guid id, Guid userId)
        {
            try
            {
                var existing = await GetById(id);

                if (existing == null)
                    throw new Exception(Resource.Responses.Employee.NOT_FOUND);

                await repository.Delete(existing);
                await SaveChangesAsync(userId);
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee> Add(Employee d, Guid userId)
        {
            try
            {
                var existing = await GetById(d.Id);

                if (existing != null)
                    throw new Exception(Resource.Responses.Employee.EXISTING);

                d = await repository.Add(d);
                await SaveChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                existing.DateOfBirth = d.DateOfBirth;
                existing.Gender = d.Gender;
                existing.BloodType = d.BloodType;
                existing.Citizenship = d.Citizenship;
                existing.CivilStatus = d.CivilStatus;
                existing.BirthPlace = d.BirthPlace;
                existing.Religion = d.Religion;
                existing.Code = d.Code;
                existing.DateHired = d.DateHired;
                existing.DateSeparated = d.DateSeparated;
                existing.DateRendered = d.DateRendered;
                existing.EmployeeStatus = d.EmployeeStatus;
                existing.PositionId = d.PositionId;
                existing.BankNo = d.BankNo;
                existing.PolicyNo = d.PolicyNo;
                existing.CardNo = d.CardNo;
                existing.Manual = d.Manual;

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
                          //  e.EffectivityDate = current.EffectivityDate;
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

                d = await repository.Update(existing);
                await SaveChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveChangesAsync(Guid userId)
            => await repository.SaveChangesAsync(userId);

        #region OLD

        public async Task<DbSet<Employee>> GetDbSet()
            => await repository.GetDbSet();

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employeeDb = await repository.GetDbSet();
            var employees = await employeeDb.Include(e => e.Position)
                .Include(e => e.Addresses)
                .Include(e => e.Family)
                .ToListAsync();

            return employees;
        }

        public async Task<IEnumerable<Employee>> GetByCondition(Expression<Func<Employee, bool>> whereExp)
        {
            var employeeDb = await repository.GetDbSet();
            var employees = await employeeDb.Include(e => e.Position)
                .Include(e => e.Addresses)
                .Include(e => e.Family)
                .Where(whereExp)
                .ToListAsync();

            return employees;
        }


        public async Task Add(Employee entity)
        {
            await repository.Add(entity);
        }
        public async Task Update(Employee entity)
        {
            await repository.Update(entity);
        }

        public async Task Delete(Employee entity)
        {
            await repository.Delete(entity);
        }


        #endregion
    }
}
