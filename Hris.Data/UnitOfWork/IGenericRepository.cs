using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.UnitOfWork
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<int> GetCount();
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task<T> AddAsync(T entity);

        Task AddRangeAsync(T[] entities);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(T entity);
        public Task DeleteRange(T[] entities);
        //public Task<bool> SaveChangesAsync(Guid userId);
        public Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T>> FindListByConditionAsync(Expression<Func<T, bool>> predicate);
        public DbSet<T> GetDbSet();
        public Task<IQueryable<T>> FindAll(Expression<Func<T, bool>> predicate);
    }
}
