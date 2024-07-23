
using Hris.Data.DTO;
using Hris.Data.Models.Payroll;
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
    public interface IAllowanceEntitlementServices
    {
        Task<IEnumerable<AllowanceEntitlementDtoResponse>> GetAll();
        Task<AllowanceEntitlementDtoResponse?> Delete(Guid allowId, Guid id);

        Task<AllowanceEntitlement> GetById(Guid id);

        Task<AllowanceEntitlementDtoResponse?> Add(AllowanceEntitlementDtoRequest req, Guid id);
        Task<AllowanceEntitlementDtoResponse?> Update(AllowanceEntitlementDtoRequest request, Guid id);

        Task<bool> IsAllowanceTypeUsed(Guid allowanceType);

        Task<bool> IsAllowanceTypeUsed(Expression<Func<AllowanceEntitlement, bool>> predicate);

    }
    internal class AllowanceEntitlementServices : IAllowanceEntitlementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public AllowanceEntitlementServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AllowanceEntitlementDtoResponse?> Add(AllowanceEntitlementDtoRequest entitlement, Guid id)
        {
            try
            {
                var entity = await _unitOfWork._AllowanceEntitlement.AddAsync(new AllowanceEntitlement
                {
                    EmployeeId = entitlement.EmployeeId,
                    AllowanceTypeId = entitlement.AllowanceTypeId,
                    Amount = entitlement.Amount,
                    //  EffectivityDate = entitlement.EffectivityDate,
                    Period = entitlement.Period
                });

                var result = await _unitOfWork.SaveChangeAsync(id);
                return result > 0 ? entity.ToAllowanceEntitlement_() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<AllowanceEntitlementDtoResponse?> Delete(Guid allowId, Guid id)
        {
            try
            {
                var toBeDeleted = await GetById(allowId);
                if (toBeDeleted is null) return null;

                await _unitOfWork._AllowanceEntitlement.DeleteAsync(toBeDeleted);
                var res = await _unitOfWork.SaveChangeAsync(id);
                return res > 0 ? toBeDeleted.ToAllowanceEntitlement_() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<AllowanceEntitlementDtoResponse>> GetAll()
        {
            var result = await _unitOfWork._AllowanceEntitlement.GetDbSet()
                 .Select(a => new AllowanceEntitlementDtoResponse
                 {
                     Id = a.Id,
                     EmployeeId = a.EmployeeId,
                     AllowanceTypeId = a.AllowanceTypeId,
                     Amount = a.Amount,
                     // EffectivityDate = a.EffectivityDate,
                 }).ToListAsync();

            if (result is null) return Enumerable.Empty<AllowanceEntitlementDtoResponse>();
            return result;
        }

        public async Task<AllowanceEntitlement> GetById(Guid id)
        {
            return await _unitOfWork._AllowanceEntitlement.GetByIdAsync(id);
        }

        public async Task<bool> IsAllowanceTypeUsed(Guid allowanceType)
        {
            return await _unitOfWork._AllowanceEntitlement.GetDbSet()
                 .Include(f => f.AllowanceType)
                 .Where(f => f.AllowanceTypeId.Equals(allowanceType))
                 .AnyAsync();
        }

        public async Task<bool> IsAllowanceTypeUsed(Expression<Func<AllowanceEntitlement, bool>> predicate)
        {
            var result = await _unitOfWork._AllowanceEntitlement.GetDbSet()
                .AsNoTracking()
                .Where(predicate)
                .AnyAsync();

            return result;
        }

        public async Task<AllowanceEntitlementDtoResponse?> Update(AllowanceEntitlementDtoRequest request, Guid id)
        {
            try
            {
                var entitlementToUpdate = await GetById(request.Id);
                if (entitlementToUpdate == null) return null;

                entitlementToUpdate.EmployeeId = request.EmployeeId;
                entitlementToUpdate.AllowanceTypeId = request.AllowanceTypeId;
                entitlementToUpdate.Amount = request.Amount;
                //  entitlementToUpdate.EffectivityDate = request.EffectivityDate;
                entitlementToUpdate.Period = request.Period;

                await _unitOfWork._AllowanceEntitlement.UpdateAsync(entitlementToUpdate);
                var result = await _unitOfWork.SaveChangeAsync(id);
                return result > 0 ? entitlementToUpdate.ToAllowanceEntitlement_() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
