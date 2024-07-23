using Hris.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.UnitOfWork
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetCount()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            var res = await _dbContext.Set<T>().AddAsync(entity);
            return res.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var res = _dbContext.Set<T>().Update(entity);
            return res.Entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
           var res = _dbContext.Set<T>().Remove(entity).Entity;
           return res;
        }

        public async Task DeleteRange(T[] entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public async Task AddRangeAsync(T[] entities)
        {
           await _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> FindListByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public DbSet<T> GetDbSet()
        {
            return _dbContext.Set<T>();
        }

        public async Task<IQueryable<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            return  _dbContext.Set<T>().Where(predicate);
        }
    }
}
