using Hris.Business.Extensions;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.EmployeeModule
{
    public class PositionService
    {
        private readonly IRepository<Position> repository;

        public async Task<IEnumerable<Position>> GetResource()
            => await this.repository.GetAllAsync();

        public async Task<int> GetCount()
            => await repository.GetCount();

        public async Task<Position?> GetById(Guid id)
            => (await repository.GetDbSet())
                .Where(d => d.Id.Equals(id))
                .FirstOrDefault();

        public async Task<(IEnumerable<Position> list, int total)> Get(int? page = null, int? limit = null, string? search = null, PositionLevel? level = null)
        {
            var q = (await repository.GetDbSet())
                .AsEnumerable()
                .Where(d => d.Active)
                .Where(d => (!search.IsNullOrEmpty() ? d.Name.Has(search) : true)
                    && (level != null ? d.Level.Equals(level) : true));

            return (!page.HasValue && !limit.HasValue ? q :
                q.Skip((page.Value - 1) * limit.Value)
                    .Take(limit.Value)
                    .OrderBy(d => d.Name), q.Count());
        }

        public async Task<Position> Add(Position d, Guid userId)
        {
            try
            {
                d = await repository.Add(d);
                await SaveChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Position> Update(Position d, Guid userId)
        {
            try
            {
                d = await repository.Update(d);
                await SaveChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Position> Deactivate(Position d, Guid userId)
        {
            try
            {
                d.Active = false;
                return await Update(d, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveChangesAsync(Guid projectId)
            => await repository.SaveChangesAsync(projectId);

        // Old

        public PositionService(IRepository<Position> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Position>> GetAll()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Position?> GetPositionId(Guid positionId)
        {
            var posSet = await repository.GetByIdAsync(positionId);
            return posSet;
        }
        public async Task Delete(Position position)
        {
            await repository.Delete(position);
        }
    }
}
