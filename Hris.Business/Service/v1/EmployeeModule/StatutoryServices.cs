using Hris.Data.Models.Employee;
using Hris.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.EmployeeModule
{
    public interface IStatutoryServices
    {
        Task<IEnumerable<Statutory>> GetAll();
        Task<Statutory> GetById(Guid id);
        Task Delete(Statutory statutory, Guid id);

    }
    internal class StatutoryServices : IStatutoryServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public StatutoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Delete(Statutory statutory, Guid id)
        {
            try
            {
                await _unitOfWork._Statutory.DeleteAsync(statutory);
                await _unitOfWork.SaveChangeAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Statutory>> GetAll()
        {
            var result = await _unitOfWork._Statutory.GetAllAsync();
            if (result is null) return Enumerable.Empty<Statutory>();

            return result;
        }

        public async Task<Statutory> GetById(Guid id)
        {
            return await _unitOfWork._Statutory.GetByIdAsync(id);
        }
    }
}
