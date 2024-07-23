using Hris.Data.Models.Employee;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.EmployeeModule
{
    public interface ISalaryHistoryServices
    {
        Task<IEnumerable<SalaryHistory>> GetAll();
        Task<SalaryHistory> GetById(Guid id);

        Task Delete(SalaryHistory history, Guid id);

        Task<SalaryHistory> GetLatestSalary(Expression<Func<SalaryHistory, bool>> exp);

    }
    internal class SalaryHistoryServices : ISalaryHistoryServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public SalaryHistoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Delete(SalaryHistory history, Guid id)
        {
            try
            {
                await _unitOfWork._SalaryHistory.DeleteAsync(history);
                await _unitOfWork.SaveChangeAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<IEnumerable<SalaryHistory>> GetAll()
        {
            var result = await _unitOfWork._SalaryHistory.GetAllAsync();
            if (result is null) return Enumerable.Empty<SalaryHistory>();
            return result;
        }

        public async Task<SalaryHistory> GetById(Guid id)
        {
            return await _unitOfWork._SalaryHistory.GetByIdAsync(id);
        }

        public async Task<SalaryHistory> GetLatestSalary(Expression<Func<SalaryHistory, bool>> exp)
        {
           var result = await _unitOfWork._SalaryHistory.GetDbSet()
                .AsNoTracking()
                .Where(exp)
                .OrderByDescending(f => f.EffectivityDate)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
