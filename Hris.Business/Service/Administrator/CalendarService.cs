using Hris.Business.Extensions;
using Hris.Data.Models.Administrator;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Leave;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.Administrator
{
    public class CalendarService
    {
        private readonly IRepository<Calendar> repository;

        public CalendarService(IRepository<Calendar> repository)
        {
            this.repository = repository;
        }

/*        public async Task<IEnumerable<LeaveType>> GetTypesResource()
            => await typeRepository.GetAllAsync();*/

        public async Task<IEnumerable<Calendar>> Get(string tz, int page, int limit, string? search, IEnumerable<int>? years)
            => (await this.repository.GetDbSet())
                .AsEnumerable()
                .Where(d => (search != null && !string.IsNullOrEmpty(search) ? d.Name.ToLower().Contains(search.ToLower()) : true)
                    && (years != null && years.Any() ? years.Any(y => y == d.Date.ConvertToTimezone(tz).Year) : d.Date.ConvertToTimezone(tz).Year == DateTime.UtcNow.Year))
                .Skip((page - 1) * limit).Take(limit);

        public async Task<Calendar> GetById(Guid id)
            => await repository.GetByIdAsync(id);

        public async Task<bool> Save(Calendar data, Guid userId)
        {
            try
            {
                await repository.Add(data);
                await SaveChanges(userId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Calendar data, Guid userId)
        {
            try
            {
                await repository.Update(data);
                await SaveChanges(userId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Remove(Calendar d, Guid userId)
        {
            try
            {
                await repository.Delete(d);
                await SaveChanges(userId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Duplicate(Guid userId)
        {
            try
            {
                var events = (await repository.GetDbSet())
                    .AsNoTracking()
                    .Where(d => d.Date.Year == DateTime.UtcNow.Year)
                    .AsEnumerable();

                foreach (var e in events)
                {
                    var existing = (await repository.FindByConditionAsync(d => d.Name.Equals(e.Name) && d.Date.Year == DateTime.UtcNow.Year + 1));

                    if (existing != null)
                        continue;

                    await repository.Add(new Calendar
                    {
                        Name = e.Name,
                        Description = e.Description,
                        Date = e.Date.AddYears(1),
                        Type = e.Type
                    });
                }
                await SaveChanges(userId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SaveChanges(Guid clientId)
            => await this.repository.SaveChangesAsync(clientId);
    }
}
