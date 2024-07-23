using Hris.Data.Models.Payroll;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.PayrollModule
{
    public class AllowanceEntitlementService
    {
        private readonly IRepository<AllowanceEntitlement> repository;

        public AllowanceEntitlementService(IRepository<AllowanceEntitlement> repository)
        {
            this.repository = repository;
        }

        public async Task<DbSet<AllowanceEntitlement>> GetDbSet()
        {
            return await repository.GetDbSet();
        }

        public async Task<IEnumerable<AllowanceEntitlement>> GetAll()
        {
            return await repository.GetAllAsync();
        }
        public async Task Add(AllowanceEntitlement allowance)
        {
            await repository.Add(allowance);
        }
        public async Task Update(AllowanceEntitlement allowance)
        {
            await repository.Update(allowance);
        }
        public async Task<AllowanceEntitlement> GetById(Guid allowanceId)
        {
            return await repository.GetByIdAsync(allowanceId);
        }
        public async Task Delete(AllowanceEntitlement allowance)
        {
            await repository.Delete(allowance);
        }
        public async Task SaveChangesAsync(Guid userId)
        {
            await repository.SaveChangesAsync(userId);
        }
    }
}
