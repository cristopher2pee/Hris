using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Business.Service.v1.AdministratorModule;
using Hris.Data.DTO;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.EmployeeModule
{
    public interface ITeamMemberServices
    {
        Task Delete(TeamMember entity, Guid id);
        Task<IEnumerable<TeamMember>> GetAll();
        Task<TeamMember> GetById(Guid id);

        Task<TeamMember?> GetMemberById(Guid id);
        Task<TeamMember?> GetMemberById(Guid teamId, Guid employeeId);

        Task<TeamMember?> GetManagerById(Guid deptId, Guid employeeId);

        Task<(IEnumerable<TeamMember> list, int total)> GetByMemberId(int? page = null, int? limit = null, Guid? employeeId = null);

        Task<IEnumerable<TeamMember>> GetByTeamId(Guid teamId);

        Task<IEnumerable<TeamMember>> GetTeamMembersByManagerId(Guid id);

        Task<TeamMember> AddMember(Guid teamId, Guid employeeId, Guid userId);

        Task<TeamMember> AddManager(Guid deptId, Guid employeeId, Guid userId);

        Task<TeamMember> UpdateMember(TeamMember d, Guid userId);

        Task<TeamMember> RemoveMember(TeamMember d, Guid userId);

        Task<TeamMember> ReplaceManager(Guid deptId, Guid oldManagerId, Guid newManagerId, Guid userId);

        Task<TeamMember> ReplaceLead(Guid teamId, Guid oldLeadId, Guid newLeadId, Guid userId);
        Task<TeamMemberDtoResourcesResponse?> GetTeamMemberResources(Guid userId);
        Task<PagedResult_<TeamMemberDtoResponse>> GetTeamMemberList(TeamMemberFilters filters);
        Task<TeamMemberManangementDtoInfoResponse> GetTeamLeadManagerInfo(Guid employeeId);

        Task<TeamMemberDtoResourcesResponse> GetEmployeeTeamMemberInfo(Guid employeeId);
    }
    internal class TeamMemberServices : ITeamMemberServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionServices _permissionServices;

        public TeamMemberServices(IUnitOfWork unitOfWork, IPermissionServices permissionServices)
        {
            _unitOfWork = unitOfWork;
            _permissionServices = permissionServices;
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<TeamMember> RemoveMember(TeamMember d, Guid userId)
        {
            try
            {
                await _unitOfWork._TeamMember.DeleteAsync(d);
                await _unitOfWork.SaveChangeAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<TeamMember> UpdateMember(TeamMember d, Guid userId)
        {
            try
            {
                await _unitOfWork._TeamMember.UpdateAsync(d);
                await _unitOfWork.SaveChangeAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
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

                await _unitOfWork._TeamMember.AddAsync(tm);
                await _unitOfWork.SaveChangeAsync(userId);
                return tm;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<TeamMember> AddMember(Guid teamId, Guid employeeId, Guid userId)
        {
            try
            {
                var existing = await GetMemberById(teamId, employeeId);
                if (existing != null)
                    throw new Exception(Resource.Responses.TeamMember.EXISTING);

                var team = await _unitOfWork._Team.FindByConditionAsync(f => f.Id == teamId);

                var tm = new TeamMember
                {
                    TeamId = teamId,
                    EmployeeId = employeeId,
                    DepartmentId = team.DepartmentId,
                    Active = true
                };
                await _unitOfWork._TeamMember.AddAsync(tm);
                await _unitOfWork.SaveChangeAsync(userId);
                return tm;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task Delete(TeamMember entity, Guid id)
        {
            await _unitOfWork._TeamMember.DeleteAsync(entity);
            await _unitOfWork.SaveChangeAsync(id);
        }

        public async Task<IEnumerable<TeamMember>> GetAll()
        {
            var result = await _unitOfWork._TeamMember.GetAllAsync();
            if (result is null) return Enumerable.Empty<TeamMember>();
            return result;
        }

        public async Task<TeamMember> GetById(Guid id)
        {
            return await _unitOfWork._TeamMember.GetByIdAsync(id);
        }

        public async Task<TeamMember?> GetMemberById(Guid id)
        {
            return await _unitOfWork._TeamMember.GetDbSet()
                  .AsNoTracking()
                  .Include(d => d.Team)
                  .ThenInclude(d => d.Department)
                  .FirstOrDefaultAsync(f => f.Active && f.Id.Equals(id));
        }

        public async Task<TeamMember?> GetMemberById(Guid teamId, Guid employeeId)
        {
            return await _unitOfWork._TeamMember.GetDbSet()
                 .AsNoTracking()
                 .Where(d => d.Active && d.TeamId.Equals(teamId)
                     && d.EmployeeId.Equals(employeeId))
                 .FirstOrDefaultAsync();
        }

        public async Task<TeamMember?> GetManagerById(Guid deptId, Guid employeeId)
              => await _unitOfWork._TeamMember.GetDbSet()
                  .AsNoTracking()
                  .Where(d => d.Active && d.DepartmentId.Equals(deptId)
                    && d.EmployeeId.Equals(employeeId))
                    .FirstOrDefaultAsync();
        public async Task<(IEnumerable<TeamMember> list, int total)> GetByMemberId(int? page = null, int? limit = null, Guid? employeeId = null)
        {
            var q = await _unitOfWork._TeamMember.GetDbSet()
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
        {
            var result = await _unitOfWork._TeamMember.GetDbSet()
                .AsNoTracking()
                .Include(d => d.Employee)
                    .ThenInclude(t => t.Position)
                .Where(d => d.Active && d.TeamId.Equals(teamId))
                .ToListAsync();

            if (result is null) return Enumerable.Empty<TeamMember>();
            return result;
        }


        public async Task<IEnumerable<TeamMember>> GetTeamMembersByManagerId(Guid id)
        {
            var result = await _unitOfWork._TeamMember.GetDbSet()
                .AsNoTracking()
                .Include(d => d.Team)
                    .ThenInclude(t => t.Department)
                .Where(d => d.Active && (d.EmployeeId.Equals(id) || (d.Team.Department != null && d.Team.Department.ManagerId.Equals(id))))
                .ToListAsync();

            if (result is null) return Enumerable.Empty<TeamMember>();
            return result;
        }


        public async Task<TeamMemberManangementDtoInfoResponse> GetTeamLeadManagerInfo(Guid employeeId)
        {
            var data = new TeamMemberManangementDtoInfoResponse();
            var teamMember = await _unitOfWork._TeamMember.GetDbSet()
                .AsNoTracking()
                .Where(f => f.EmployeeId.Equals(employeeId))
                .ToListAsync();

            if (teamMember is not null)
            {
                var listOfDepIds = teamMember.Select(f => f.DepartmentId).Distinct();
                var listOfTeamIds = teamMember.Select(f => f.TeamId).Distinct();

                if (listOfDepIds != null && listOfDepIds.Any())
                {
                    var department = await GetDepartmentbyIds(listOfDepIds);
                    if (department is not null)
                    {
                        var employeeIds = department.Select(f => f.Manager.Id).Distinct();
                        if (employeeIds != null && employeeIds.Any())
                        {
                            var employeeInfos = await GetEmployeeInfo(employeeIds);
                            data.DepartmentManager = employeeInfos.ToList().ToEmployeeDtoResponseList();
                        }
                    }
                }

                if (listOfTeamIds != null && listOfTeamIds.Any())
                {
                    var teams = await GetTeamsByIds(listOfTeamIds);
                    if (teams is not null)
                    {
                        var employeeIds = teams.Select(f => f.Lead.Id).Distinct();
                        if (employeeIds != null && employeeIds.Any())
                        {
                            var employeeInfos = await GetEmployeeInfo(employeeIds);
                            data.TeamLead = employeeInfos.ToList().ToEmployeeDtoResponseList();
                        }
                    }
                }
            }
            return data;
        }

        public async Task<TeamMemberDtoResourcesResponse?> GetTeamMemberResources(Guid userId)
        {
            var employee = await _unitOfWork._Employees.GetDbSet()
                .Include(f => f.Position)
                .FirstOrDefaultAsync(f => f.ObjectId.Equals(userId));

            if (employee == null) return null;

            var isAdmin = await _permissionServices.GetRoleByModule(employee.Id, Modules.Leave);

            if (isAdmin.Equals(Roles.Admin))
                return await GetResouresAdmin();
            else
            {
                return employee.Position.Level == PositionLevel.Manager ?
                    await GetResouresManager(employee.Id)
                    : employee.Position.Level == PositionLevel.TeamLead ?
                        await GetResourcesTeamLead(employee.Id)
                    : null;
            }

        }

        public async Task<PagedResult_<TeamMemberDtoResponse>> GetTeamMemberList(TeamMemberFilters filters)
        {
            //var result = await _unitOfWork._TeamMember.GetDbSet()
            //    .Include(e => e.Employee)
            //    .Include(e => e.Team).ThenInclude(f => f.Department)
            //    .Where(e => filters.TeamId.HasValue && filters.TeamId != Guid.Empty
            //        ? e.TeamId.Equals(filters.TeamId) : true
            //            && filters.DepartmentId.HasValue && filters.DepartmentId != Guid.Empty
            //                ? e.DepartmentId.Equals(filters.DepartmentId) : true)
            //    .ToListAsync();

            var result = await _unitOfWork._TeamMember.GetDbSet()
                .Include(e => e.Employee)
                .Include(e => e.Team).ThenInclude(f => f.Department)
                .Where(e => filters.TeamId.HasValue && filters.TeamId != Guid.Empty
                    ? e.TeamId.Equals(filters.TeamId) : false)
                .ToListAsync();

            if (result is not null && result.Any())
            {
                result = result.Where(f =>
                    (f.Employee.Lastname.ToLower().Contains(filters.Search.ToLower())
                    || f.Employee.Firstname.ToLower().Contains(filters.Search.ToLower())
                    || f.Employee.Middlename.ToLower().Contains(filters.Search.ToLower())))
                        .ToList();
            }

            return result.ToTeamMemberResponseList()
                .ToPagedList_(filters.Page, filters.Limit);
        }

        public async Task<TeamMemberDtoResourcesResponse> GetEmployeeTeamMemberInfo(Guid employeeId)
        {
            var data = new TeamMemberDtoResourcesResponse();
            var employee = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Include(e => e.TeamMembers)
                    .ThenInclude(f => f.Team)
                .Include(e => e.Allowances)
                .FirstOrDefaultAsync(f => f.Id.Equals(employeeId));

            if (employee is not null)
            {
                //  data.Employee = employee.ToInitialEmployeeResponse_();
                data.TeamResources = employee.TeamMembers.Select(f => f.Team).ToList().ToListResponse_();

                var deptIds = employee.TeamMembers.Select(f => f.Team.DepartmentId).Distinct().ToList();
                var departments = await GetDepartmentbyIds(deptIds);
                data.DepartmentResources = departments.ToList().ToListResponse_();
            }

            return data;
        }



        private async Task<TeamMemberDtoResourcesResponse> GetResouresAdmin()
        {
            var teamResources = await _unitOfWork._Team.GetAllAsync();
            var departmentResources = await _unitOfWork._Department.GetAllAsync();

            return new TeamMemberDtoResourcesResponse
            {
                DepartmentResources = departmentResources.OrderBy(f => f.Name).ToListResponse_(),
                TeamResources = teamResources.OrderBy(f => f.Name).ToList().ToListResponse_()
            };
        }



        private async Task<TeamMemberDtoResourcesResponse> GetResouresManager(Guid employeeId)
        {
            var resources = new TeamMemberDtoResourcesResponse();

            var departmentResources = await _unitOfWork._Department.GetDbSet()
                .AsNoTracking()
                .Where(f => f.ManagerId.Equals(employeeId))
                .ToListAsync();

            var DepIds = departmentResources.Select(f => f.Id).ToList();
            resources.DepartmentResources = departmentResources
                .OrderBy(f => f.Name)
                .ToListResponse_();

            if (departmentResources != null && departmentResources.Any())
            {

                var data = await _unitOfWork._Team.GetDbSet().AsNoTracking()
                    .Where(c => DepIds.Contains(c.DepartmentId)).ToListAsync();

                if (data != null)
                    resources.TeamResources = data.OrderBy(f => f.Name).ToList().ToListResponse_();
            }
            return resources;
        }

        private async Task<TeamMemberDtoResourcesResponse> GetResourcesTeamLead(Guid emloyeeId)
        {
            var resources = new TeamMemberDtoResourcesResponse();

            var teams = await _unitOfWork._Team.GetDbSet()
                .AsNoTracking()
                .Where(f => f.LeadId.Equals(emloyeeId))
                .OrderBy(f => f.Name)
                .ToListAsync();

            if (teams != null && teams.Any())
            {
                resources.TeamResources = teams.ToListResponse_();

                var depIds = teams.Select(f => f.DepartmentId).ToList().Distinct();
                var departments = await _unitOfWork._Department.GetDbSet()
                     .Where(c => depIds.Contains(c.Id))
                     .OrderBy(f => f.Name)
                     .ToListAsync();

                if (departments != null && departments.Any())
                    resources.DepartmentResources = departments.ToListResponse_();
            }
            return resources;
        }

        private async Task<IEnumerable<Employee>> GetEmployeeInfo(IEnumerable<Guid> employeeIds)
        {
            return await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Where(f => employeeIds.Contains(f.Id))
                .ToListAsync();
        }


        private async Task<IEnumerable<Department>> GetDepartmentbyIds(IEnumerable<Guid> listOfDepIds)
        {
            var department = await _unitOfWork._Department
                       .GetDbSet()
                       .AsNoTracking()
                       .Include(f => f.Manager).ThenInclude(f => f.Position)
                       .Where(f => listOfDepIds.Contains(f.Id))
                       .ToListAsync();

            if(department is null) return Enumerable.Empty<Department>();

            return department;
        }

        private async Task<IEnumerable<Team>> GetTeamsByIds(IEnumerable<Guid?> listOfTeamIds)
        {
            var teams = await _unitOfWork._Team
                .GetDbSet()
                .AsNoTracking()
                .Include(f => f.Lead).ThenInclude(f => f.Position)
                .Where(f => listOfTeamIds.Contains(f.Id))
                .ToListAsync();

            if(teams is null) return Enumerable.Empty<Team>();
            return teams;
        }
    }
}
