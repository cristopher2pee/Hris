using Hris.Data.Models.Administrator;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.Administrator
{
    public class AccessService
    {
        private readonly IRepository<Access> repository;

        public AccessService(IRepository<Access> repository)
        {
            this.repository = repository;
        }

        public async Task<DbSet<Access>> GetDbSet()
        {
            return await this.repository.GetDbSet();
        }

        public async Task<IEnumerable<Access>> GetAll()
        {
            var entities = (await this.repository.GetDbSet());
            return entities;
        }

        public async Task Add(Access entity)
        {
            await this.repository.Add(entity);
        }

        public async Task Update(Access entity)
        {
            await this.repository.Update(entity);
        }

        public async Task<Access> GetById(Guid id)
        {
            var entity = (await this.repository.GetDbSet())
                    .Where(e => e.Id == id)
                    .FirstOrDefault();
            return entity;
        }

        public async Task Delete(Access entity)
        {
            await repository.Delete(entity);
        }

        public async Task SaveChangesAsync(Guid id)
        {
            await repository.SaveChangesAsync(id);
        }

        public async Task<IEnumerable<Access>> GetByCondition(Expression<Func<Access, bool>> whereExp)
            => await (await this.repository.GetDbSet())
                .AsNoTracking()
                .Where(whereExp)
                .ToListAsync();
    }
}
