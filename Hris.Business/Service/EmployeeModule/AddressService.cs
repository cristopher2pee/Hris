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
    public class AddressService
    {
        private readonly IRepository<Address> repository;

        public AddressService(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public async Task<DbSet<Address>> GetDbSet()
        {
            return await repository.GetDbSet();
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Address> GetById(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task Delete(Address address)
        {
            await repository.Delete(address);
        }
        public async Task SaveChangesAsync(Guid userId)
        {
            await repository.SaveChangesAsync(userId);
        }
    }
}
