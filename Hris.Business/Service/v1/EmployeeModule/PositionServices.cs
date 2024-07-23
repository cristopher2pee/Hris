using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Employee;
using Hris.Data.UnitOfWork;
using Microsoft.Graph.DeviceManagement.ManagedDevices.Item.Retire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.EmployeeModule
{
    public interface IPositionServices
    {
        Task<IEnumerable<PositionDtoResponse>> GetResources();
        Task<PagedResult_<PositionDtoResponse>> GetAll(PositionFilter_ filter);

        Task<Position> GetById(Guid id);
        Task<PositionDtoResponse> GetByIdResponse(Guid id);

        Task<PositionDtoResponse?> Add(PositionDtoRequest req, Guid userId);

        Task<PositionDtoResponse?> Update(PositionDtoRequest req, Guid userId);

        Task<PositionDtoResponse?> Delete(Guid PisitionId, Guid userId);
    }
    internal class PositionServices : IPositionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PositionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PositionDtoResponse?> Add(PositionDtoRequest request, Guid userId)
        {
            try
            {
                var result = await _unitOfWork._Positions.AddAsync(new Position
                {
                    Name = request.Name,
                    JobDescription = request.JobDescription,
                    Level = request.Level,
                    Active = true
                });

                if (result is null) return null;
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? result.ToPisitionResponse() : null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PositionDtoResponse?> Delete(Guid positionId, Guid userId)
        {
            try
            {
                var toBeDeleted = await GetById(positionId);
                if (toBeDeleted is null) return null;

                await _unitOfWork._Positions.DeleteAsync(toBeDeleted);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toBeDeleted.ToPisitionResponse() : null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResult_<PositionDtoResponse>> GetAll(PositionFilter_ filter)
        {
            var result = await _unitOfWork._Positions.GetAllAsync();
            return result.ToPositionList().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<Position> GetById(Guid id)
        {
            return await _unitOfWork._Positions.GetByIdAsync(id);
        }

        public async Task<PositionDtoResponse> GetByIdResponse(Guid id)
        {
            var result = await _unitOfWork._Positions.GetByIdAsync(id);
            return result.ToPisitionResponse();
        }

        public async Task<IEnumerable<PositionDtoResponse>> GetResources()
        {
            var result = await _unitOfWork._Positions.GetAllAsync();

            if(result is null) return Enumerable.Empty<PositionDtoResponse>();
            return result.ToPositionList();
        }

        public async Task<PositionDtoResponse?> Update(PositionDtoRequest request, Guid userId)
        {
            try
            {
                var toBeUpdated = await GetById(request.Id);

                if (toBeUpdated is null) return null;

                toBeUpdated.Name = request.Name;
                toBeUpdated.JobDescription = request.JobDescription;
                toBeUpdated.Level = request.Level;

                await _unitOfWork._Positions.UpdateAsync(toBeUpdated);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toBeUpdated.ToPisitionResponse() : null;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
