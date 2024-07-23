using Hris.Data.Models.Payroll;
using Hris.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.PayrollModule
{
    public class AllowanceTypeService
    {
        private readonly IRepository<AllowanceType> repository;

        public AllowanceTypeService(IRepository<AllowanceType> repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<AllowanceType>> GetAll()
        {
            return await repository.GetAllAsync();
        }
        public async Task Add(AllowanceType allowanceType)
        {
            await repository.Add(allowanceType);
        }
        public async Task Update(AllowanceType allowanceType)
        {
            await repository.Update(allowanceType);
        }
        public async Task<AllowanceType> GetAllowanceById(Guid allowanceId)
        {
            return await repository.GetByIdAsync(allowanceId);
        }
        public async Task Delete(AllowanceType allowanceType)
        {
            await repository.Delete(allowanceType);
        }
        public async Task SaveChangesAsync(Guid userId)
        {
            await repository.SaveChangesAsync(userId);
        }
    }
}
