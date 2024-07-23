using Hris.Business.Extensions;
using Hris.Data.DTO;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Hris.Resource.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.DeviceManagement.ManagedDevices.Item.Retire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IPayrollRunAllowanceServices
    {
        Task<IEnumerable<PayrollRunAllowanceDtoResponse>> GetByEmployeeId(Guid employeeId);
        Task<IEnumerable<PayrollRunAllowanceDtoResponse>> GetByPayrollRunData(Guid employeeId, Guid payrollRunId, PayrollPeriod payrollPeriod);
        Task<PayrollRunAllowanceDtoResponse?> Add(PayrollRunAllowanceDtoRequest req, Guid objId);
        Task<PayrollRunAllowanceDtoResponse?> Update(PayrollRunAllowanceDtoRequest req, Guid objId);
        Task<bool> Delete(Guid id, Guid objId);
        Task<bool> isExist(Expression<Func<PayrollRunAllowances, bool>> predicate);

        Task<IEnumerable<PayrollRunAllowanceDtoResponse>> GetListByExpression(Expression<Func<PayrollRunAllowances, bool>> predicate);
        Task<PayrollRunAllowanceDtoResponse> GetByExpression(Expression<Func<PayrollRunAllowances, bool>> predicate);

        Task<IEnumerable<PayrollRunAllowances>> GetListPayrollRunAllowance(Expression<Func<PayrollRunAllowances, bool>> predicate);
        Task<PayrollRunAllowances> GetPayrollRunAllowance(Expression<Func<PayrollRunAllowances, bool>> predicate);

    }
    internal class PayrollRunAllowanceServices : IPayrollRunAllowanceServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PayrollRunAllowanceServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PayrollRunAllowanceDtoResponse?> Add(PayrollRunAllowanceDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunAllowances.AddAsync(new PayrollRunAllowances
                {
                    PayrollRunId = req.PayrollRunId,
                    EmployeeId = req.EmployeeId,
                    AllowanceTypeId = req.AllowanceTypeId,
                    Amount = req.Amount,
                    PayrollPeriod = req.PayrollPeriod,
                    Active = true,
                    Notes = req.Notes,
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunAllowanceResponse() : null;
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
                var result = await _unitOfWork._PayrollRunAllowances.GetByIdAsync(id);
                await _unitOfWork._PayrollRunAllowances.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<PayrollRunAllowanceDtoResponse>> GetByEmployeeId(Guid employeeId)
        {
            var result = await _unitOfWork._PayrollRunAllowances.GetDbSet()
                .AsNoTracking()
                .Where(f => f.EmployeeId.Equals(employeeId))
                .ToListAsync();

            return result != null ? result.ToPayrollRunAllowanceResponseList() : Enumerable.Empty<PayrollRunAllowanceDtoResponse>();
        }

        public async Task<PayrollRunAllowanceDtoResponse> GetByExpression(Expression<Func<PayrollRunAllowances, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunAllowances.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .Include(f => f.AllowanceType)
                 .Where(predicate)
                 .FirstOrDefaultAsync();

            return result.ToPayrollRunAllowanceResponse();
        }

        public async Task<IEnumerable<PayrollRunAllowanceDtoResponse>> GetByPayrollRunData(Guid employeeId, Guid payrollRunId, PayrollPeriod payrollPeriod)
        {
            var result = await _unitOfWork._PayrollRunAllowances.GetDbSet()
                .AsNoTracking()
                .Where(f => f.EmployeeId.Equals(employeeId)
                    && f.PayrollRunId.Equals(payrollRunId)
                    && f.PayrollPeriod.Equals(payrollPeriod))
                .ToListAsync();

            return result != null ? result.ToPayrollRunAllowanceResponseList()
                : Enumerable.Empty<PayrollRunAllowanceDtoResponse>();
        }

        public async Task<IEnumerable<PayrollRunAllowanceDtoResponse>> GetListByExpression(Expression<Func<PayrollRunAllowances, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunAllowances.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollRun)
                .Include(f => f.Employee)
                .Include(f => f.AllowanceType)
                .Where(predicate)
                .ToListAsync();

            return result != null ? result.ToPayrollRunAllowanceResponseList() 
                : Enumerable.Empty<PayrollRunAllowanceDtoResponse>();
        }

        public async Task<IEnumerable<PayrollRunAllowances>> GetListPayrollRunAllowance(Expression<Func<PayrollRunAllowances, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunAllowances.GetDbSet()
                .Include(f => f.PayrollRun)
                .Include(f => f.Employee)
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();

            return result != null ? result : Enumerable.Empty<PayrollRunAllowances>();
        }

        public async Task<PayrollRunAllowances> GetPayrollRunAllowance(Expression<Func<PayrollRunAllowances, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunAllowances.GetDbSet()
                .Include(f => f.PayrollRun)
                .Include(f => f.Employee)
                .AsNoTracking()
                .Where(predicate)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> isExist(Expression<Func<PayrollRunAllowances, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunAllowances.GetDbSet()
                .Where(predicate)
                .AnyAsync();
            return result;
        }

        public async Task<PayrollRunAllowanceDtoResponse?> Update(PayrollRunAllowanceDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunAllowances.GetByIdAsync(req.Id);
                result.PayrollRunId = req.PayrollRunId;
                result.EmployeeId = req.EmployeeId;
                result.AllowanceTypeId = req.AllowanceTypeId;
                result.Amount = req.Amount;
                result.PayrollPeriod = req.PayrollPeriod;
                result.Notes = req.Notes;

                await _unitOfWork._PayrollRunAllowances.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunAllowanceResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
