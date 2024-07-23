using Hris.Data.Models.Employee;
using Hris.Data.Repository;
using Hris.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.EmployeeModule
{
    public interface ITeamServices
    {
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetById(Guid id);
        Task<Team?> Save(Team team, Guid userId);
        Task<Team?> Update(Team team, Guid userId);
        Task<Team?> Delete(Guid teamId, Guid userId);
        Task<IEnumerable<Team>> GetResources();
        Task<IEnumerable<Team>?> GetTeamsByDepartmentId(Guid? departmentId);
        Task<IEnumerable<Team>?> GetTeamsByLeadId(Guid? leadId);


    }
    internal class TeamServices : ITeamServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeamServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Team>> GetResources()
        {
            var result = await _unitOfWork._Team.GetAllAsync();
            if(result is null) return Enumerable.Empty<Team>();
            return result;
        }

        public async Task<Team?> Delete(Guid teamId, Guid userId)
        {
            try
            {
                var toBeDeleted = await GetById(teamId);
                if (toBeDeleted != null) { return null; }

                await _unitOfWork._Team.DeleteAsync(toBeDeleted);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toBeDeleted : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            var result = await _unitOfWork._Team.GetAllAsync();
            if (result is null) return Enumerable.Empty<Team>();
            return result;
        }

        public Task<Team> GetById(Guid id)
        {
            return _unitOfWork._Team.GetByIdAsync(id);
        }

        public async Task<Team?> Save(Team team, Guid userId)
        {
            try
            {
                var res = await _unitOfWork._Team.AddAsync(team);
                if (res is null) return null;
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? res : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Team?> Update(Team team, Guid userId)
        {
            try
            {
                var toBeUpdated = await GetById(team.Id);
                if (toBeUpdated is null) return null;

                toBeUpdated.Name = team.Name;
                toBeUpdated.LeadId = team.LeadId;
                toBeUpdated.DepartmentId = team.DepartmentId;

                await _unitOfWork._Team.UpdateAsync(team);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toBeUpdated : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public async Task<IEnumerable<Team>?> GetTeamsByDepartmentId(Guid? departmentId)
        {
            var result = await _unitOfWork._Team
                .FindListByConditionAsync(f => departmentId.HasValue && departmentId
                    != Guid.Empty ? f.DepartmentId.Equals(departmentId) : true);

            if (result is null) 
                return Enumerable.Empty<Team>();

            return result;
        }

        public async Task<IEnumerable<Team>?> GetTeamsByLeadId(Guid? leadId)
        {
            var result = await _unitOfWork._Team
            .FindListByConditionAsync(f => leadId.HasValue && leadId
                != Guid.Empty ? f.LeadId.Equals(leadId) : true);

            if (result is null)
                return Enumerable.Empty<Team>();

            return result;
        }
    }
}
