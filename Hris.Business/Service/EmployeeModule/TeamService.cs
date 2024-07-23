using Hris.Data.Models.Employee;
using Hris.Data.Repository;
using Hris.Resource.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team = Hris.Data.Models.Employee.Team;
using TeamMember = Hris.Data.Models.Employee.TeamMember;

namespace Hris.Business.Service.EmployeeModule
{
    public class TeamService
    {
        private readonly IRepository<Team> repository;
        private readonly IRepository<TeamMember> tmRepository;

        public TeamService(IRepository<Team> repository,
            IRepository<TeamMember> tmRepository)
        {
            this.repository = repository;
            this.tmRepository = tmRepository;
        }
        public async Task<TeamMember> AddMember(Guid teamId, Guid employeeId, Guid userId)
        {
            try
            {
                var existing = await GetMemberById(teamId, employeeId);
                if (existing != null)
                    throw new Exception(Resource.Responses.TeamMember.EXISTING);

                var tm = new TeamMember
                {
                    TeamId = teamId,
                    EmployeeId = employeeId,
                    Active = true
                };
                await tmRepository.Add(tm);
                await SaveMemberChangesAsync(userId);
                return tm;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TeamMember> AddManager(Guid deptId, Guid employeeId, Guid userId)
        {
            try
            {
                var existing = await GetMemberById(deptId, employeeId);
                if (existing != null)
                    throw new Exception();

                var tm = new TeamMember
                {
                    DepartmentId = deptId,
                    EmployeeId = employeeId,
                    Active = true
                };

                await tmRepository.Add(tm);
                await SaveMemberChangesAsync(userId);
                return tm;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TeamMember> ReplaceManager(Guid deptId, Guid oldManagerId, Guid newManagerId, Guid userId)
        {
            try
            {
                var existing = await GetManagerById(deptId, oldManagerId);
                if (existing == null)
                    return await AddManager(deptId, newManagerId, userId);

                existing.EmployeeId = newManagerId;
                                
                await UpdateMember(existing, userId);
                return existing;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TeamMember> ReplaceLead(Guid teamId, Guid oldLeadId, Guid newLeadId, Guid userId)
        {
            try
            {
                var existing = await GetMemberById(teamId, oldLeadId);
                if (existing == null)
                    return await AddMember(teamId, newLeadId, userId);

                existing.EmployeeId = newLeadId;

                await UpdateMember(existing, userId);
                return existing;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TeamMember> UpdateMember(TeamMember d, Guid userId)
        {
            try
            {
                await tmRepository.Update(d);
                await SaveMemberChangesAsync(userId);
                return d;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TeamMember> RemoveMember(TeamMember d, Guid userId)
        {
            try
            {
                await tmRepository.Delete(d);
                await SaveMemberChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<IEnumerable<Team>> GetResources()
            => await repository.GetAllAsync();

        public async Task<TeamMember?> GetMemberById(Guid id)
            => await (await tmRepository.GetDbSet())
                .AsNoTracking()
                .Include(d => d.Team)
                    .ThenInclude(t => t.Department)
                .Where(d => d.Active && d.Id.Equals(id)).FirstOrDefaultAsync();

        public async Task<TeamMember?> GetMemberById(Guid teamId, Guid employeeId)
            => await(await tmRepository.GetDbSet())
                .AsNoTracking()
                .Where(d => d.Active && d.TeamId.Equals(teamId) && d.EmployeeId.Equals(employeeId)).FirstOrDefaultAsync();

        public async Task<TeamMember?> GetManagerById(Guid deptId, Guid employeeId)
            => await (await tmRepository.GetDbSet())
                .AsNoTracking()
                .Where(d => d.Active && d.DepartmentId.Equals(deptId) && d.EmployeeId.Equals(employeeId)).FirstOrDefaultAsync();


        public async Task<(IEnumerable<TeamMember> list, int total)> GetByMemberId(int? page = null, int? limit = null, Guid? employeeId = null)
        { 
            var q = await (await tmRepository.GetDbSet())
                .AsNoTracking()
                .Where(d => d.Active && d.TeamId != null && d.EmployeeId.Equals(employeeId))
                .Include(d => d.Team)
                    .ThenInclude(t => t.Lead)
                .Include(d => d.Team)
                    .ThenInclude(t => t.Department)
                        .ThenInclude(t => t.Manager)
                .ToListAsync();
            return (!page.HasValue && !limit.HasValue ? q :
                        q.Skip((page.Value - 1) * limit.Value)
                        .Take(limit.Value), q.Count());
        }

        public async Task<IEnumerable<TeamMember>> GetByTeamId(Guid teamId)
            => await (await tmRepository.GetDbSet())
                .AsNoTracking()
                .Include(d => d.Employee)
                    .ThenInclude(t => t.Position)
                .Where(d => d.Active && d.TeamId.Equals(teamId))
                .ToListAsync();

        public async Task<IEnumerable<TeamMember>> GetTeamMembersByManagerId(Guid id)
            => await (await tmRepository.GetDbSet())
                .AsNoTracking()
                .Include(d => d.Team)
                    .ThenInclude(t => t.Department)
                .Where(d => d.Active && (d.EmployeeId.Equals(id) || (d.Team.Department != null && d.Team.Department.ManagerId.Equals(id))))
                .ToListAsync();

        #region Lead
        public async Task<IEnumerable<TeamMember>> GetTeamMembersByLeadId(Guid id)
            => await (await tmRepository.GetDbSet())
                .AsNoTracking()
                .Include(d => d.Team)
                .Where(d => d.Active && d.Team != null && d.Team.LeadId.Equals(id))
                .ToListAsync();

        public async Task<TeamMember> RemoveLead(Guid teamId, Guid id, Guid userId)
        {
            var existing = await GetMemberById(teamId, id);
            if (existing == null)
                throw new NullReferenceException();
            return await RemoveMember(existing, userId);
        }

        #endregion


        

        public async Task SaveChangesAsync(Guid projectId)
            => await repository.SaveChangesAsync(projectId);

        public async Task SaveMemberChangesAsync(Guid projectId)
            => await tmRepository.SaveChangesAsync(projectId);

        // Old

        public async Task<IEnumerable<Team>> GetAll()
            => await repository.GetAllAsync();
    }
}
