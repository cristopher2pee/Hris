using Hris.Data.Models.Employee;
using Hris.Data.Repository;
using Hris.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.EmployeeModule
{
    public interface IAddressServices
    {
        Task DeleteRange(Address[] address);
        Task<IEnumerable<Address>> GetAll();
        Task<Address> GetById(Guid id);
        Task Delete(Address address, Guid userId);
    }
    internal class AddressServices : IAddressServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task DeleteRange(Address[] address)
        {
            try
            {
                await _unitOfWork._Address.DeleteRange(address);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            var address = await _unitOfWork._Address.GetAllAsync();
            if (address is null) return Enumerable.Empty<Address>();
            return address;
        }

        public async Task<Address> GetById(Guid id)
        {
            return await _unitOfWork._Address.GetByIdAsync(id);
        }

        public async Task Delete(Address address, Guid userId)
        {
            try
            {
                await _unitOfWork._Address.DeleteAsync(address);
                await _unitOfWork.SaveChangeAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }


    }
}
