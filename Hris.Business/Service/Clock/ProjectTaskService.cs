using Hris.Data.Models.Clock;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.Clock
{
    public class ProjectTaskService
    {
        private readonly IRepository<ProjectTask> repository;

        public ProjectTaskService(IRepository<ProjectTask> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ProjectTask>> GetByCondition(Expression<Func<ProjectTask, bool>> whereExp)
            => await (await repository.GetDbSet())
                .Where(whereExp)
                .ToListAsync();

        public async Task<ProjectTask> GetById(Guid clientId)
            => await repository.GetByIdAsync(clientId);

        public async Task Update(ProjectTask projectTask)
        {
            await repository.Update(projectTask);
        }

        public async Task Delete(ProjectTask task)
            => await repository.Delete(task);

        public async Task SaveChangesAsync(Guid id)
            => await repository.SaveChangesAsync(id);
    }
}
