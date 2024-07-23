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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IPayrollRunLoansServices
    {
        Task<IEnumerable<PayrollRunLoansDtoResponse>> GetListByExpression(Expression<Func<PayrollRunLoans, bool>> predicate);
        Task<PayrollRunLoansDtoResponse?> Add(PayrollRunLoansDtoRequest req, Guid objId);
        Task<PayrollRunLoansDtoResponse?> Update(PayrollRunLoansDtoRequest req, Guid objId);
        Task<bool> Delete(Guid id, Guid objId);
        Task<bool> isExist(Expression<Func<PayrollRunLoans, bool>> predicate);
        Task<PayrollRunLoansDtoResponse> GetByExpression(Expression<Func<PayrollRunLoans, bool>> predicate);

        Task<IEnumerable<PayrollRunLoans>> GetListPayrollRunLoans(Expression<Func<PayrollRunLoans, bool>> predicate);
        Task<PayrollRunLoans> GetPayrollRunLoans(Expression<Func<PayrollRunLoans, bool>> predicate);
    }
    internal class PayrollRunLoansServices : IPayrollRunLoansServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PayrollRunLoansServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PayrollRunLoansDtoResponse?> Add(PayrollRunLoansDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunLoans.AddAsync(new PayrollRunLoans
                {
                    PayrollRunId = req.PayrollRunId,
                    EmployeeId = req.EmployeeId,
                    LoanTypesId = req.LoanTypesId,
                    Amount = req.Amount,
                    PayrollPeriod = req.PayrollPeriod,
                    Active = true,
                    Notes = req.Notes,
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunLoansResponse() : null;
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
                var result = await _unitOfWork._PayrollRunLoans.GetByIdAsync(id);
                if (result is null) throw new ArgumentNullException(nameof(result), "object result cannot be null.");

                await _unitOfWork._PayrollRunLoans.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PayrollRunLoansDtoResponse> GetByExpression(Expression<Func<PayrollRunLoans, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunLoans.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .Include(f => f.LoanTypes)
                 .Where(predicate)
                 .FirstOrDefaultAsync();

            return result.ToPayrollRunLoansResponse();
        }

        public async Task<IEnumerable<PayrollRunLoansDtoResponse>> GetListByExpression(Expression<Func<PayrollRunLoans, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunLoans.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .Include(f => f.LoanTypes)
                 .Where(predicate)
                 .ToListAsync();

            return result.ToPayrollRunDeductionsResponseList();
        }

        public async Task<IEnumerable<PayrollRunLoans>> GetListPayrollRunLoans(Expression<Func<PayrollRunLoans, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunLoans.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .Include(f => f.LoanTypes)
                 .Where(predicate)
                 .ToListAsync();

            return result != null ? result : Enumerable.Empty<PayrollRunLoans>();
        }

        public async Task<PayrollRunLoans> GetPayrollRunLoans(Expression<Func<PayrollRunLoans, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunLoans.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .Include(f => f.LoanTypes)
                 .Where(predicate)
                 .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> isExist(Expression<Func<PayrollRunLoans, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunLoans.GetDbSet()
             .AsNoTracking()
             .Where(predicate)
             .AnyAsync();

            return result;
        }

        public async Task<PayrollRunLoansDtoResponse?> Update(PayrollRunLoansDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunLoans.GetByIdAsync(req.Id);
                if (result is null) throw new ArgumentNullException(nameof(result), "object result cannot be null.");

                result.PayrollRunId = req.PayrollRunId;
                result.EmployeeId = req.EmployeeId;
                result.LoanTypesId = req.LoanTypesId;
                result.Amount = req.Amount;
                result.PayrollPeriod = req.PayrollPeriod;
                result.Notes = req.Notes;

                await _unitOfWork._PayrollRunLoans.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunLoansResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
