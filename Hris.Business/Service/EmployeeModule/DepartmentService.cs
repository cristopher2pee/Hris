using Hris.Business.Extensions;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using Microsoft.IdentityModel.Tokens;
using Team = Hris.Data.Models.Employee.Team;

namespace Hris.Business.Service.EmployeeModule
{
    public class DepartmentService
    {
        private readonly IRepository<Department> repository;
        private readonly TeamService tmService;

        public DepartmentService(IRepository<Department> repository,
            IRepository<Team> tRepository,
            IRepository<TeamMember> tmRepository)
        {
            this.repository = repository;
            this.tmService = new TeamService(tRepository, tmRepository);
        }

        public async Task<IEnumerable<Department>> GetResource()
            => await this.repository.GetAllAsync();

        public async Task<(IEnumerable<Department> list, int total)> Get(int? page = null, int? limit = null, string? search = null)
        {
            var q = (await repository.GetDbSet())
                .Where(d => d.Active)                
                .Where(d => (!search.IsNullOrEmpty() ? d.Name.Has(search) : true))
                .Include(d => d.Manager)
                .Include(d => d.Teams)
                .OrderBy(d => d.Name);

            return (!page.HasValue && !limit.HasValue ? q :
                        q.Skip((page.Value - 1) * limit.Value)
                            .Take(limit.Value), q.Count());
        }

        public async Task<bool> Add(Department d, Guid userId)
        {
            try
            {
                var existing = await GetById(d.Id);

                if (existing != null)
                    throw new Exception();

                d = await repository.Add(d);
                await SaveChangesAsync(userId);

                // Add Manager
                await tmService.AddManager(d.Id, d.ManagerId, userId);

                // Add Lead
                foreach (var t in d.Teams)
                    await tmService.AddMember(t.Id, t.LeadId, userId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(Department d, Guid userId)
        {
            try
            {
                var existing = await GetById(d.Id);

                if (existing == null)
                    throw new Exception();

                existing.Name = d.Name;
                existing.Active = d.Active;

                if (!existing.ManagerId.Equals(d.ManagerId))
                    await tmService.ReplaceManager(existing.Id, existing.ManagerId, d.ManagerId, userId);

                existing.ManagerId = d.ManagerId;

                if (d.Teams != null && d.Teams.Count > 0)
                {
                    var list = d.Teams.ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        var current = list[i];
                        if (current.Id.Equals(Guid.Empty) && current.Active)
                            existing.Teams.Add(current);
                        else if (existing.Teams.Any(d => d.Id.Equals(current.Id)))
                        {
                            var e = existing.Teams.FirstOrDefault(d => d.Id.Equals(current.Id));

                            if (e == null)
                                throw new NullReferenceException();

                            e.Active = current.Active;
                            e.Name = current.Name;

                            if(!e.LeadId.Equals(current.LeadId))
                                await tmService.ReplaceLead(e.Id, e.LeadId, current.LeadId, userId);

                            e.LeadId = current.LeadId;
                        }
                    }
                }

                d = await repository.Update(existing);
                await SaveChangesAsync(userId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Department?> GetById(Guid id)
            => (await repository.GetDbSet())
                .Include(d => d.Teams)
                    .ThenInclude(t => t.Lead)
                .Where(d => d.Id.Equals(id))
                .FirstOrDefault();

        public async Task<bool> IsNameExisting(string name)
            => (await repository.FindByConditionAsync(d => d.Name.ToLower().Equals(name.ToLower()))) != null;


        // Old

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await repository.GetAllAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var dept = await repository.GetDbSet();
            var departments = dept.Include(e => e.Manager).Include(e => e.Teams);

            return departments;
        }

        public async Task Add(Department entity)
        {
            await repository.Add(entity);
        }

        public async Task Delete(Department entity)
        {
            await repository.Delete(entity);
        }

        public async Task<bool> SaveChangesAsync(Guid userId)
        {
            return await repository.SaveChangesAsync(userId);
        }

        public async Task<Department> GetDepartmentById(Guid departmentId)
        {
            var deptSet = await repository.GetDbSet();
            var department = await deptSet.Include(e => e.Manager)
                .Include(e => e.Teams)
                .Where(e => e.Id == departmentId).FirstOrDefaultAsync();


            return department;
        }

        public async Task<Department> GetByDepartmentName(string departmentName)
        {
            var deptSet = await repository.GetDbSet();
            var department = await deptSet.Include(e => e.Manager)
                .Include(e => e.Teams)
                .Where(e => e.Name.ToUpper() == departmentName.ToUpper()).FirstOrDefaultAsync();


            return department;
        }
    }
}
