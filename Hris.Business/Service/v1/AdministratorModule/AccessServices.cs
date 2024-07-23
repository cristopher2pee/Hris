using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.AdministratorModule
{
    public interface IAccessServices
    {
        Task<PagedResult_<AccessDtoResponse>> GetAll(AccessFilter_ filter);
        Task<AccessDtoResponse?> Add(AccessDtoRequest accessRequest, Guid userId);
        Task<AccessDtoResponse?> Update(AccessDtoRequest accessRequest, Guid userId);
        Task<AccessDtoResponse?> Delete(Guid id, Guid userid);

    }
    internal class AccessServices : IAccessServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccessServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AccessDtoResponse?> Add(AccessDtoRequest request, Guid userId)
        {
            try
            {
                if (request == null) return null;
                var entity = await _unitOfWork._Access.AddAsync(new Data.Models.Administrator.Access
                {
                    Name = request.Name,
                    Path = request.Path,
                    Module = request.Module,
                    Roles = string.Join(",", request.Roles)
                });
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? entity.ToAccessResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<AccessDtoResponse?> Delete(Guid id, Guid userid)
        {
            try
            {
                var delete = await _unitOfWork._Access.GetByIdAsync(id);
                if (delete == null) return null;

                await _unitOfWork._Access.DeleteAsync(delete);
                return await _unitOfWork.SaveChangeAsync(userid) > 0 ? delete.ToAccessResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<PagedResult_<AccessDtoResponse>> GetAll(AccessFilter_ filter)
        {
            return _unitOfWork._Access.GetDbSet()
                    .AsEnumerable()
                   .Where(a => (!string.IsNullOrEmpty(filter.Search) ? a.Name.Contains(filter.Search, StringComparison.OrdinalIgnoreCase) : true)
                         && (!string.IsNullOrEmpty(filter.Module) ? a.Module.Contains(filter.Module, StringComparison.OrdinalIgnoreCase) : true)
                         && (!string.IsNullOrEmpty(filter.Role) ? a.Roles.Contains(filter.Role, StringComparison.OrdinalIgnoreCase) : true))
                   .Select(e => e.ToAccessResponse())
                   .ToList()
                   .OrderBy(e => e.Name)
                   .ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<AccessDtoResponse?> Update(AccessDtoRequest accessRequest, Guid userId)
        {
            try
            {
                var data = await _unitOfWork._Access.GetByIdAsync(accessRequest.Id);
                if (data is null) return null;

                data.Name = accessRequest.Name;
                data.Module = accessRequest.Module;
                data.Roles = string.Join(",", accessRequest.Roles);

                var result = await _unitOfWork._Access.UpdateAsync(data);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? result.ToAccessResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
