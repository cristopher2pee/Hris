using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Business.Service.EmployeeModule;
using Hris.Data.DTO;
using Hris.Data.Models.Employee;
using Hris.Data.Repository;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.EmployeeModule
{
    public interface IDepartmentServices
    {
        Task<IEnumerable<Department>> GetResource();
        Task<Department> GetById(Guid id);
        Task<PagedResult_<DepartmentDtoResponse>> GetAll(DepartmentFilter_ filter);
        Task<bool> IsNameExisting(string name);
        Task<DepartmentDtoResponse?> AddDepartment(DepartmentDtoRequest request, Guid userId);
        Task<DepartmentDtoResponse?> UpdateDepartment(DepartmentDtoRequest request, Guid userId);

        Task<Department?> GetDepartmentById(Guid departmentId);
        Task<bool> Update(Department d, Guid userId);
        Task<IEnumerable<DepartmentDtoResponse>?> GetDepartmentByManagerId(Guid? managerId);

    }
    internal class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeamMemberServices _teamServices;
        public DepartmentServices(IUnitOfWork unitOfWork, ITeamMemberServices teamServices)
        {
            _unitOfWork = unitOfWork;
            _teamServices = teamServices;

        }

        public async Task<bool> IsNameExisting(string name)
            => (await _unitOfWork._Department.FindByConditionAsync(d => d.Name.ToLower().Equals(name.ToLower()))) != null;

        public async Task<PagedResult_<DepartmentDtoResponse>> GetAll(DepartmentFilter_ filter)
        {
            var result = _unitOfWork._Department
                .GetDbSet()
                .AsNoTracking()
                .Include(d => d.Manager)
                .Include(d => d.Teams)
                .ToListResponse_()
                .ToPagedList_(filter.Page, filter.Limit);

            return result;
        }

        public async Task<Department> GetById(Guid id)
        {
            var result = _unitOfWork._Department
                .GetDbSet()
                .AsNoTracking()
                .Include(d => d.Teams)
                    .ThenInclude(d => d.Lead)
                .Where(d => d.Id.Equals(id))
                .FirstOrDefault();

            return result;
        }

        public async Task<IEnumerable<Department>> GetResource()
        {
            var department = await _unitOfWork._Department.GetAllAsync();
            if(department is null) return Enumerable.Empty<Department>();
            return department;
        }

        public async Task<bool> Add(Department d, Guid userId)
        {
            try
            {
                var existing = await GetById(d.Id);

                if (existing != null)
                    throw new Exception();

                d = await _unitOfWork._Department.AddAsync(d);
                await _unitOfWork.SaveChangeAsync(userId);

                // Add Manager
                //await _teamServices.AddManager(d.Id, d.ManagerId, userId);

                // Add Lead
                //foreach (var t in d.Teams)
                //    await _teamServices.AddMember(t.Id, t.LeadId, userId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<DepartmentDtoResponse?> AddDepartment(DepartmentDtoRequest request, Guid userId)
        {
            var d = new Department
            {
                Name = request.Name,
                ManagerId = request.ManagerId,
                Teams = request.Team != null ? request.Team.Select(t => new Data.Models.Employee.Team
                {
                    Id = t.Id,
                    Active = true,
                    Name = t.Name,
                    LeadId = t.LeadId
                }).ToList() : null,
                Active = true
            };
            var result = await Add(d, userId);
            return result ? d.ToResponse_() : null;
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
                existing.TemplateUri = d.TemplateUri;
                existing.TemplateName = d.TemplateName;

                if (!existing.ManagerId.Equals(d.ManagerId))
                    await _teamServices.ReplaceManager(existing.Id, existing.ManagerId, d.ManagerId, userId);

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

                            if (!e.LeadId.Equals(current.LeadId))
                                await _teamServices.ReplaceLead(e.Id, e.LeadId, current.LeadId, userId);

                            e.LeadId = current.LeadId;
                        }
                    }
                }

                d = await _unitOfWork._Department.UpdateAsync(existing);
                await _unitOfWork.SaveChangeAsync(userId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<DepartmentDtoResponse?> UpdateDepartment(DepartmentDtoRequest request, Guid userId)
        {
            try
            {
                var d = new Department
                {
                    Id = request.Id,
                    Name = request.Name,
                    ManagerId = request.ManagerId,
                    Teams = request.Team != null ? request.Team.Select(t => new Data.Models.Employee.Team
                    {
                        Id = t.Id,
                        Active = t.Active,
                        Name = t.Name,
                        LeadId = t.LeadId
                    }).ToList() : null,
                    Active = true
                };

                var res = await Update(d, userId);

                return res ? d.ToResponse_() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Department?> GetDepartmentById(Guid departmentId)
        {
            var result = await _unitOfWork._Department.GetDbSet()
                 .AsNoTracking()
                 .Include(e => e.Manager)
                 .Include(e => e.Teams)
                 .Where(e => e.Id.Equals(departmentId))
                 .FirstOrDefaultAsync();

            return result != null ? result : null;
        }

        public async Task<IEnumerable<DepartmentDtoResponse>?> GetDepartmentByManagerId(Guid? managerId)
        {

            var result = await _unitOfWork._Department
                .GetDbSet()
                .Include (e => e.Manager)
                .Include(e => e.Teams)
                .AsNoTracking()
                .Where(f=>f.ManagerId.Equals(managerId))
                .ToListAsync();

            if(result is null) return Enumerable.Empty<DepartmentDtoResponse>();
            return result.ToListResponse_();
        }
    }
}
