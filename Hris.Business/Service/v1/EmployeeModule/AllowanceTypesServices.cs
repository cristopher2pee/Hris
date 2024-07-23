using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.EmployeeModule
{
    public interface IAllowanceTypeServices
    {
        Task<IEnumerable<AllowanceTypeDtoResponse>> GetResources();
        Task<AllowanceTypeDtoResponse?> Add(AllowanceTypeDtoRequest req, Guid id);
        Task<AllowanceTypeDtoResponse?> Update(AllowanceTypeDtoRequest req, Guid id);

        Task<AllowanceTypeDtoResponse?> GetById(Guid id);
        Task<PagedResult_<AllowanceTypeDtoResponse>> GetAll(AllowanceTypeFilter_ filter);
        Task<AllowanceTypeDtoResponse?> Delete(Guid Id, Guid userId);

        Task<bool> isAllowanceTypeExist(Expression<Func<AllowanceType, bool>> predicate);

    }
    internal class AllowanceTypesServices : IAllowanceTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public AllowanceTypesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AllowanceTypeDtoResponse?> Add(AllowanceTypeDtoRequest req, Guid id)
        {
            try
            {
                var resultEntity = await _unitOfWork._AllowanceTypes
                    .AddAsync(new Data.Models.Payroll.AllowanceType
                    {
                        Name = req.Name,
                        Amount = req.Amount,
                        //  Period = req.Period,
                        IsDefault = req.IsDefault,
                        IsTaxable = req.isTaxable,
                        Limit = req.Limit
                    });

                if (resultEntity is null) return null;

                var res = await _unitOfWork.SaveChangeAsync(id);
                return res > 0 ? resultEntity.ToAllowanceTypeResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<AllowanceTypeDtoResponse?> Delete(Guid Id, Guid userId)
        {
            try
            {
                var toBeDeleted = await _unitOfWork._AllowanceTypes.GetByIdAsync(Id);
                if (toBeDeleted is null) return null;

                await _unitOfWork._AllowanceTypes.DeleteAsync(toBeDeleted);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toBeDeleted.ToAllowanceTypeResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<PagedResult_<AllowanceTypeDtoResponse>> GetAll(AllowanceTypeFilter_ filter)
        {
            return _unitOfWork._AllowanceTypes.GetDbSet()
                          .AsNoTracking()
                           .Where(a => (!string.IsNullOrEmpty(filter.Search) ?
                              a.Name.Contains(filter.Search, StringComparison.OrdinalIgnoreCase) : true)
                             )
                           .ToAllowanceTypeResponseList()
                           .ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<AllowanceTypeDtoResponse?> GetById(Guid id)
        {
            var result = await _unitOfWork._AllowanceTypes.GetByIdAsync(id);
            if (result is null) return null;

            return result.ToAllowanceTypeResponse();
        }

        public async Task<IEnumerable<AllowanceTypeDtoResponse>> GetResources()
        {
            var result = await _unitOfWork._AllowanceTypes.GetAllAsync();

            if (result is null) Enumerable.Empty<AllowanceTypeDtoResponse>();
            return result.ToAllowanceTypeResponseList();
        }

        public async Task<bool> isAllowanceTypeExist(Expression<Func<AllowanceType, bool>> predicate)
        {
            var result = await _unitOfWork._AllowanceTypes.GetDbSet()
                .AsNoTracking()
                .Where(predicate)
                .AnyAsync();

            return result;
        }

        public async Task<AllowanceTypeDtoResponse?> Update(AllowanceTypeDtoRequest req, Guid id)
        {
            try
            {
                var toBeUpdated = await _unitOfWork._AllowanceTypes.GetByIdAsync(req.Id);
                if (toBeUpdated is null) return null;

                toBeUpdated.Name = req.Name;
                toBeUpdated.Amount = req.Amount;
                //toBeUpdated.Period = req.Period;
                toBeUpdated.IsDefault = req.IsDefault;
                toBeUpdated.IsTaxable = req.isTaxable;
                toBeUpdated.Limit = req.Limit;

                await _unitOfWork._AllowanceTypes.UpdateAsync(toBeUpdated);
                return await _unitOfWork.SaveChangeAsync(id) > 0 ? toBeUpdated.ToAllowanceTypeResponse() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
