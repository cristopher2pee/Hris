using Hris.Data.DTO;
using Hris.Data.Models.Enum;
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
    public interface IPayrollRunDeductionsServices
    {
        Task<IEnumerable<PayrollRunDeductionsDtoResponse>> GetListByExpression(Expression<Func<PayrollRunDeductions, bool>> predicate);

        Task<PayrollRunDeductionsDtoResponse> GetByExpression(Expression<Func<PayrollRunDeductions, bool>> predicate);
        Task<PayrollRunDeductionsDtoResponse?> Add(PayrollRunDeductionsDtoRequest req, Guid objId);
        Task<PayrollRunDeductionsDtoResponse?> Update(PayrollRunDeductionsDtoRequest req, Guid objId);
        Task<bool> Delete(Guid id, Guid objId);
        Task<bool> isExist(Expression<Func<PayrollRunDeductions, bool>> predicate);

        Task<IEnumerable<PayrollRunDeductions>> GetListPayrllRunDeductions(Expression<Func<PayrollRunDeductions, bool>> predicate);
        Task<PayrollRunDeductions> GetPayrollRunDeduction(Expression<Func<PayrollRunDeductions, bool>> predicate);

    }
    internal class PayrollRunDeductionsServices : IPayrollRunDeductionsServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PayrollRunDeductionsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PayrollRunDeductionsDtoResponse?> Add(PayrollRunDeductionsDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunDeductions.AddAsync(new PayrollRunDeductions
                {
                    PayrollRunId = req.PayrollRunId,
                    EmployeeId = req.EmployeeId,
                    DeductionTypesId = req.DeductionTypesId,
                    Amount = req.Amount,
                    PayrollPeriod = req.PayrollPeriod,
                    Active = true,
                    Notes = req.Notes,
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunDeductionsResponse() : null;

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
                var result = await _unitOfWork._PayrollRunDeductions.GetByIdAsync(id);
                if (result is null) return false;

                await _unitOfWork._PayrollRunDeductions.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<IEnumerable<PayrollRunDeductionsDtoResponse>> GetListByExpression(Expression<Func<PayrollRunDeductions, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunDeductions.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .Include(f => f.DeductionTypes)
                 .Where(predicate)
                 .ToListAsync();

            return result != null ? result.ToPayrollRunDeductionsResponseList()
                : Enumerable.Empty<PayrollRunDeductionsDtoResponse>();
        }

        public async Task<PayrollRunDeductionsDtoResponse> GetByExpression(Expression<Func<PayrollRunDeductions, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunDeductions.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .Include(f => f.DeductionTypes)
                 .Where(predicate)
                 .FirstOrDefaultAsync();

            return result.ToPayrollRunDeductionsResponse();
        }

        public async Task<bool> isExist(Expression<Func<PayrollRunDeductions, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunDeductions.GetDbSet()
                 .AsNoTracking()
                 .Where(predicate)
                 .AnyAsync();

            return result;
        }

        public async Task<PayrollRunDeductionsDtoResponse?> Update(PayrollRunDeductionsDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunDeductions.GetByIdAsync(req.Id);
                if (result == null) return null;

                result.PayrollRunId = req.PayrollRunId;
                result.EmployeeId = req.EmployeeId;
                result.DeductionTypesId = req.DeductionTypesId;
                result.Amount = req.Amount;
                result.PayrollPeriod = req.PayrollPeriod;
                result.Notes = req.Notes;

                await _unitOfWork._PayrollRunDeductions.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunDeductionsResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<PayrollRunDeductions>> GetListPayrllRunDeductions(Expression<Func<PayrollRunDeductions, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunDeductions.GetDbSet()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .AsNoTracking()
                 .Where(predicate)
                 .ToListAsync();

            return result != null ? result : Enumerable.Empty<PayrollRunDeductions>();
        }

        public async Task<PayrollRunDeductions> GetPayrollRunDeduction(Expression<Func<PayrollRunDeductions, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunDeductions.GetDbSet()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .AsNoTracking()
                 .Where(predicate)
                 .FirstOrDefaultAsync();

            return result;
        }
    }
}
