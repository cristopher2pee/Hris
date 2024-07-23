using Hris.Data.Models.Clock;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.Clock
{
    public class AssignedProjectService
    {
        private readonly IRepository<AssignedProject> repository;

        public AssignedProjectService(IRepository<AssignedProject> repository)
        {
            this.repository = repository;
        }

        public async Task<DbSet<AssignedProject>> GetDbSet()
        {
            return await this.repository.GetDbSet();
        }

        public async Task<IEnumerable<AssignedProject>> GetAll()
        {
            var projectDb = await this.repository.GetDbSet();
            var project = await projectDb
                    .ToListAsync();
            return project;
        }

        public async Task Add(AssignedProject entity)
        {
            await this.repository.Add(entity);
        }

        public async Task Update(AssignedProject entity)
        {
            await this.repository.Update(entity);
        }

        public async Task<AssignedProject> GetById(Guid id)
        {
            var entity = (await this.repository.GetDbSet())
/*                    .Include(p => p.Client)
                    .Include(p => p.Tasks)*/
                    .Where(e => e.Id == id)
                    .FirstOrDefault();
            return entity;
        }

        public async Task Delete(AssignedProject entity)
        {
            await repository.Delete(entity);
        }

        public async Task SaveChangesAsync(Guid id)
        {
            await repository.SaveChangesAsync(id);
        }
    }
}
