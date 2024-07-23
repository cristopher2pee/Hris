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
    public interface IFamilyServices
    {
        Task<IEnumerable<Family>> GetAll();
        Task<Family> GetById(Guid id);
        Task Delete(Family family, Guid userId);
    }
    internal class FamilyServices : IFamilyServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public FamilyServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Family>> GetAll()
        {
            var result = await _unitOfWork._Family.GetAllAsync();
            if(result is null) return Enumerable.Empty<Family>();
            return result;
        }

        public async Task<Family> GetById(Guid id)
        {
            return await _unitOfWork._Family.GetByIdAsync(id);
        }

        public async Task Delete(Family family, Guid id)
        {
            try
            {
                await _unitOfWork._Family.DeleteAsync(family);
                await _unitOfWork.SaveChangeAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
