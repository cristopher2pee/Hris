using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Clock;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.ClockModule
{
    public interface IClientServices
    {
        Task<IEnumerable<Client>> GetResources();
        Task<PagedResult_<ClientDtoResponse>> GetAll(BaseFilter_ filter);
        Task<ClientDtoResponse> GetById(Guid id);
        Task<ClientDtoResponse?> Add(ClientDtoRequest req, Guid userId);
        Task<ClientDtoResponse?> Update(ClientDtoRequest req, Guid userId);
        Task<ClientDtoResponse?> Delete(Guid clientId, Guid userId);

    }
    internal class ClientServices : IClientServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ClientDtoResponse?> Add(ClientDtoRequest req, Guid userId)
        {
            try
            {
                var entity = await _unitOfWork._Client.AddAsync(new Data.Models.Clock.Client
                {
                    Name = req.Name,
                    Address = req.Address,
                    Contact = req.Contact,
                    ContactPerson = req.ContactPerson,
                    Email = req.Email,
                    Active = true,
                });

                if (entity is null) return null;
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? entity.ToClientDtoResponse() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ClientDtoResponse?> Delete(Guid clientId, Guid userId)
        {
            try
            {
                var toBeDelted = await _unitOfWork._Client.GetByIdAsync(clientId);
                if(toBeDelted is null) return null;

                await _unitOfWork._Client.DeleteAsync(toBeDelted);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toBeDelted.ToClientDtoResponse() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResult_<ClientDtoResponse>> GetAll(BaseFilter_ filter)
        {
            var result = await _unitOfWork._Client.GetAllAsync();
            return result.ToClientDtoResponseList().ToPagedList_(filter.Page, filter.Limit);     
           
        }

        public async Task<ClientDtoResponse> GetById(Guid id)
        {
            var result = await _unitOfWork._Client.GetByIdAsync(id);
            return result.ToClientDtoResponse();
        }

        public async Task<IEnumerable<Client>> GetResources()
        {
            return await _unitOfWork._Client
             .GetDbSet()
             .AsNoTracking()
             .ToListAsync();
        }

        public async Task<ClientDtoResponse?> Update(ClientDtoRequest req, Guid userId)
        {
            try
            {
                var toBeUpdated = await _unitOfWork._Client.GetByIdAsync(req.Id);
                if(toBeUpdated is null) return null;

                toBeUpdated.Name = req.Name;
                toBeUpdated.Address = req.Address;
                toBeUpdated.ContactPerson = req.ContactPerson;
                toBeUpdated.Email = req.Email;
                toBeUpdated.Contact = req.Contact;

                await _unitOfWork._Client.UpdateAsync(toBeUpdated);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toBeUpdated.ToClientDtoResponse() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }



}
