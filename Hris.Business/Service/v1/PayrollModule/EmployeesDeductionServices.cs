using Hris.Data.DTO;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IEmployeesDeductionServices
    {
        //Task<IEnumerable<EmployeeBasicInfoDtoResponse>> GetAll();

        Task<IEnumerable<EmployeesDeductionDtoResponse>> GetDeductionByEmployeeId(Guid employeeId);
        Task<EmployeesDeductionDtoResponse> GetById(Guid Id);

        Task<EmployeesDeductionDtoResponse?> Add(EmployeesDeductionDtoRequest req, Guid ojbId);
        Task<EmployeesDeductionDtoResponse?> Update(EmployeesDeductionDtoRequest req, Guid ojbId);

        Task<EmployeesDeductionDtoResponse?> Delete(Guid empDeductId, Guid ojbId);

        Task<bool> isDeductionTypeExist(Guid employeeId, Guid deductionTypeId);

        Task<bool> IsExist(Expression<Func<EmployeesDeduction, bool>> predicate);
    }
    internal class EmployeesDeductionServices : IEmployeesDeductionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesDeductionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EmployeesDeductionDtoResponse?> Add(EmployeesDeductionDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._EmployeesDeduction.AddAsync(new Data.Models.Payroll.EmployeesDeduction
                {
                    EmployeeId = req.EmployeeId,
                    DeductionTypesId = req.DeductionTypesId,
                    Amount = req.Amount,
                    Active = true,
                    Period = req.Period,
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0
                    ? result.ToEmployeesDeductionResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<EmployeesDeductionDtoResponse?> Delete(Guid Id, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._EmployeesDeduction.GetByIdAsync(Id);
                if (result is null) return null;

                await _unitOfWork._EmployeesDeduction.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToEmployeesDeductionResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<EmployeesDeductionDtoResponse> GetById(Guid Id)
        {
            var result = await _unitOfWork._EmployeesDeduction.GetDbSet()
                .AsNoTracking()
                .Include(f => f.DeductionTypes)
                .Where(f => f.Id.Equals(Id))
                .FirstOrDefaultAsync();

            return result.ToEmployeesDeductionResponse();
        }

        public async Task<IEnumerable<EmployeesDeductionDtoResponse>> GetDeductionByEmployeeId(Guid employeeId)
        {
            var result = await _unitOfWork._EmployeesDeduction.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.DeductionTypes)
                 .Where(f => f.EmployeeId.Equals(employeeId))
                 .ToListAsync();

            return result != null ? result.ToEmployeesDeductionResponseList()
                : Enumerable.Empty<EmployeesDeductionDtoResponse>();
        }

        public async Task<bool> isDeductionTypeExist(Guid employeeId, Guid deductionTypeId)
        {
            var result = await _unitOfWork._EmployeesDeduction.GetDbSet()
                .AsNoTracking()
                .Where(f => f.EmployeeId.Equals(employeeId) && f.DeductionTypesId.Equals(deductionTypeId))
                .AnyAsync();

            return result;
        }

        public async Task<bool> IsExist(Expression<Func<EmployeesDeduction, bool>> predicate)
        {
            var result = await _unitOfWork._EmployeesDeduction.GetDbSet()
                 .AsNoTracking()
                 .Where(predicate)
                 .AnyAsync();

            return result;
        }

        public async Task<EmployeesDeductionDtoResponse?> Update(EmployeesDeductionDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._EmployeesDeduction.GetByIdAsync(req.Id);
                if (result is null) return null;

                result.Period = req.Period;
                result.Amount = req.Amount;
                result.DeductionTypesId = req.DeductionTypesId;
                result.EmployeeId = req.EmployeeId;

                await _unitOfWork._EmployeesDeduction.UpdateAsync(result);

                return await _unitOfWork.SaveChangeAsync(objId) > 0
                    ? result.ToEmployeesDeductionResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
