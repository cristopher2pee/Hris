using Hris.Data.Models.Administrator;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Settings;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserSettings = Hris.Data.Models.Settings.UserSettings;

namespace Hris.Business.Service
{
    public class UserSettingsService
    {
        private readonly IRepository<UserSettings> repository;

        public UserSettingsService(IRepository<UserSettings> repository)
        {
            this.repository = repository;
        }


        public async Task<UserSettings> GetById(Guid id)
            => await repository.GetByIdAsync(id);

        public async Task<UserSettings?> GetByEmployeeId(Guid id)
            => (await repository.GetDbSet())
                .AsNoTracking()
                .Where(s => s.EmployeeId.Equals(id))
                .FirstOrDefault();

        public async Task<UserSettings> Add(UserSettings d, Guid userId)
        {
            try
            {
                var existing = await GetById(d.Id);

                if (existing != null)
                    throw new Exception();

                d = await repository.Add(d);
                await SaveChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

                await repository.Update(existing);
                await SaveChangesAsync(userId);
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserSettings?> Remove(Guid id, Guid userId)
        {
            try
            {
                var existing = await GetByEmployeeId(id);

                if (existing == null)
                    return null;

                await repository.Delete(existing);
                await SaveChangesAsync(userId);
                return existing;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddDefault(Guid employeeId, Guid userId)
        {
            var existing = await GetByEmployeeId(employeeId);

            if (existing != null)
            {
                existing.Timezone = "China Standard Time";
                await Update(existing, userId);
            }
            else
                await this.repository.Add(new UserSettings
                {
                    EmployeeId = employeeId,
                    Timezone = "China Standard Time"
                });
            await repository.SaveChangesAsync(userId);
        }

        /* OLD */
        public async Task<bool> CreateUserSettingsDefault(Guid employeeId,Guid userId)
        {

            UserSettings settings = new UserSettings
            {
                EmployeeId = employeeId,
                ProfileImg = string.Empty,
                UITheme = "dark",
                Timezone = "2020"
            };

            this.repository.Add(settings);

            await this.repository.SaveChangesAsync(userId); 

            return true;
        }

        public async Task<IEnumerable<UserSettings>> GetByCondition(Expression<Func<UserSettings, bool>> whereExp)
            => await (await this.repository.GetDbSet())
                .AsNoTracking()
                .Where(whereExp)
                .ToListAsync();

        public async Task SaveChangesAsync(Guid userId)
            => await repository.SaveChangesAsync(userId);
    }
}
