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
    public class FamilyService
    {
        private readonly IRepository<Family> repository;

        public FamilyService(IRepository<Family> repository)
        {
            this.repository = repository;
        }

        public async Task<DbSet<Family>> GetDbSet()
        {
            return await repository.GetDbSet();
        }

        public async Task<IEnumerable<Family>> GetAll()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Family> GetById(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task Delete(Family family)
        {
            await repository.Delete(family);
        }
        public async Task SaveChangesAsync(Guid userId)
        {
            await repository.SaveChangesAsync(userId);
        }
    }
}
