using Hris.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Repository
{
    public  interface IRepository<T> where T : BaseEntity
    {
        public Task<int> GetCount();
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(T entity);
        public Task DeleteRange(T[] entities);
        public Task<bool> SaveChangesAsync(Guid userId);
        public Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T>> FindListByConditionAsync(Expression<Func<T, bool>> predicate);
        public Task<DbSet<T>> GetDbSet();
    }
}
