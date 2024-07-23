using Hris.Data.Models.Employee;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.EmployeeModule
{
    public class StatutoryService
    {
        private readonly IRepository<Statutory> repository;

        public StatutoryService(IRepository<Statutory> repository)
        {
            this.repository = repository;
        }

        public async Task<DbSet<Statutory>> GetDbSet()
        {
            return await repository.GetDbSet();
        }

        public async Task<IEnumerable<Statutory>> GetAll()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Statutory> GetById(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task Delete(Statutory statutory)
        {
            await repository.Delete(statutory);
        }
        public async Task SaveChangesAsync(Guid userId)
        {
            await repository.SaveChangesAsync(userId);
        }
    }
}
