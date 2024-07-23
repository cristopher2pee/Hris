using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IPayrollCustomRateServices
    {
        Task<PayrollRunCustomRate?> Add(PayrollRunCustomRate req, Guid objId);
        Task<PayrollRunCustomRate?> Update(PayrollRunCustomRate req, Guid objId);
        Task<bool> Delete(Guid id, Guid objId);
        Task<PayrollRunCustomRate?> Get(Expression<Func<PayrollRunCustomRate, bool>> exp);
        Task<IEnumerable<PayrollRunCustomRate>> GetList(Expression<Func<PayrollRunCustomRate, bool>> exp);
    }
    internal class PayrollRunCustomRateServices : IPayrollCustomRateServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PayrollRunCustomRateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PayrollRunCustomRate?> Add(PayrollRunCustomRate req, Guid objId)
        {
            try
            {
                var toAdd = await _unitOfWork._PayrollRunCustomRate.AddAsync(req);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? toAdd : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<bool> Delete(Guid id, Guid objId)
        {
            try
            {
                var toDelete = await _unitOfWork._PayrollRunCustomRate.GetByIdAsync(id);
                await _unitOfWork._PayrollRunCustomRate.DeleteAsync(toDelete);

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PayrollRunCustomRate?> Get(Expression<Func<PayrollRunCustomRate, bool>> exp)
        {
            var result = await _unitOfWork._PayrollRunCustomRate.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollRun)
                .Include(f => f.Employee)
                .Where(exp)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<PayrollRunCustomRate>> GetList(Expression<Func<PayrollRunCustomRate, bool>> exp)
        {
            var result = await _unitOfWork._PayrollRunCustomRate.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollRun)
                .Include(f => f.Employee)
                .Where(exp)
                .ToListAsync();

            return result != null ? result : Enumerable.Empty<PayrollRunCustomRate>();
        }

        public async Task<PayrollRunCustomRate?> Update(PayrollRunCustomRate req, Guid objId)
        {
            try
            {
                var toUpdate = await _unitOfWork._PayrollRunCustomRate.UpdateAsync(req);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? toUpdate : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
