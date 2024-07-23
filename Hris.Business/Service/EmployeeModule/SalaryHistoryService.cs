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
    public class SalaryHistoryService
    {
        private readonly IRepository<SalaryHistory> repository;

        public SalaryHistoryService(IRepository<SalaryHistory> repository)
        {
            this.repository = repository;
        }

        public async Task<DbSet<SalaryHistory>> GetDbSet()
        {
            return await repository.GetDbSet();
        }

        public async Task<IEnumerable<SalaryHistory>> GetAll()
        {
            return await repository.GetAllAsync();
        }

        public async Task<SalaryHistory> GetById(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task Delete(SalaryHistory history)
        {
            await repository.Delete(history);
        }
        public async Task SaveChangesAsync(Guid userId)
        {
            await repository.SaveChangesAsync(userId);
        }
    }
}
