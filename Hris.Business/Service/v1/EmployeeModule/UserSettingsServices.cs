using Hris.Data.Models.Settings;
using Hris.Data.Repository;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.EmployeeModule
{
    public interface IUserSettingsServices
    {
        Task<UserSettings> GetById(Guid id);
        Task<UserSettings?> GetByEmployeeId(Guid id);
        Task<UserSettings> Add(UserSettings d, Guid userId);
        Task<UserSettings> Update(UserSettings d, Guid userId);
        Task<UserSettings?> Remove(Guid id, Guid userId);
        Task AddDefault(Guid employeeId, Guid userId);
        Task<bool> CreateUserSettingsDefault(Guid employeeId, Guid userId);
        Task<IEnumerable<UserSettings>> GetByCondition(Expression<Func<UserSettings, bool>> whereExp);


    }
    internal class UserSettingsServices : IUserSettingsServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserSettingsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateUserSettingsDefault(Guid employeeId, Guid userId)
        {
            try
            {
                UserSettings settings = new UserSettings
                {
                    EmployeeId = employeeId,
                    ProfileImg = string.Empty,
                    UITheme = "dark",
                    Timezone = "2020"
                };

                await _unitOfWork._UserSettings.AddAsync(settings);
                await _unitOfWork.SaveChangeAsync(userId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public async Task AddDefault(Guid employeeId, Guid userId)
        {
            try
            {
                var existing = await GetByEmployeeId(employeeId);
                if (existing != null)
                {
                    existing.Timezone = "China Standard Time";
                    await Update(existing, userId);
                }
                else
                    await _unitOfWork._UserSettings.AddAsync(new UserSettings
                    {
                        EmployeeId = employeeId,
                        Timezone = "China Standard Time"
                    });
                await _unitOfWork.SaveChangeAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public async Task<UserSettings?> Remove(Guid id, Guid userId)
        {
            try
            {
                var existing = await GetByEmployeeId(id);
                if (existing == null)
                    return null;

                await _unitOfWork._UserSettings.DeleteAsync(existing);
                await _unitOfWork.SaveChangeAsync(userId);
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<UserSettings> Update(UserSettings d, Guid userId)
        {
            try
            {
                var existing = await GetById(d.Id);

                if (existing == null)
                    throw new Exception();

                existing.Timezone = d.Timezone;
                existing.UITheme = d.UITheme;

                await _unitOfWork._UserSettings.UpdateAsync(existing);
                await _unitOfWork.SaveChangeAsync(userId);
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<UserSettings> Add(UserSettings d, Guid userId)
        {
            try
            {
                var existing = await GetById(d.Id);
                if (existing != null)
                    throw new Exception();

                d = await _unitOfWork._UserSettings.AddAsync(d);
                await _unitOfWork.SaveChangeAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<UserSettings?> GetByEmployeeId(Guid id)
        {
            return await _unitOfWork._UserSettings.GetDbSet()
                .AsNoTracking()
                .Where(f => f.EmployeeId.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<UserSettings> GetById(Guid id)
        {
            return await _unitOfWork._UserSettings.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserSettings>> GetByCondition(Expression<Func<UserSettings, bool>> whereExp)
        {
            var result = await _unitOfWork._UserSettings.GetDbSet()
                 .AsNoTracking()
                 .Where(whereExp)
                 .ToListAsync();

            if (result is null) return Enumerable.Empty<UserSettings>();

            return result;
        }
    }
}
