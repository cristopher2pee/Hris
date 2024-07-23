
using Hris.Data.Models.Employee;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hris.Business.Service.v1.EmployeeModule
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            this.repository = repository;
        }

        public async Task<Employee?> GetByObjectId(Guid id)
            => await (await repository.GetDbSet()).Where(e => e.ObjectId.Equals(id)).FirstOrDefaultAsync();

        public async Task<Employee?> GetByObjectId(Guid id, bool includeSettings = false)
        {
            var set = (await repository.GetDbSet()).AsNoTracking();
            if (includeSettings)
                return await set.Where(e => e.ObjectId.Equals(id))
                    .Include(d => d.Settings)
                    .FirstOrDefaultAsync();

            return await set.Where(e => e.ObjectId.Equals(id))
                .FirstOrDefaultAsync();
        }

        public async Task<Employee?> GetProfile(Guid objectId)
            => await (await repository.GetDbSet()).AsNoTracking()
                .Where(d => d.ObjectId.Equals(objectId))
                .Include(d => d.Addresses)
                .Include(d => d.Family)
                .FirstOrDefaultAsync();
    }
}
