using Hris.Business.Extensions;
using Hris.Business.Models.Common;
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
using static QuestPDF.Helpers.Colors;

namespace Hris.Business.Service.v1
{
    public interface IDeductionTypesServices
    {
        Task<PagedResult_<DeductionTypesDtoResponse>> GetAll(DeductionTypeFilters filters);

        Task<DeductionTypesDtoResponse> GetById(Guid id);

        Task<DeductionTypesDtoResponse?> Add(DeductionTypesDtoRequest req, Guid id);
        Task<DeductionTypesDtoResponse?> Update(DeductionTypesDtoRequest req, Guid id);

        Task<DeductionTypesDtoResponse?> Delete(Guid allowId, Guid id);
        Task<List<DeductionTypesDtoResponse>> Resources();

        Task<bool> IsExists(Expression<Func<DeductionTypes, bool>> predicate);
    }
    internal class DeductionTypesServices : IDeductionTypesServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeductionTypesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<DeductionTypesDtoResponse?> Update(DeductionTypesDtoRequest req, Guid id)
        {
           
            try
            {
                var result = await _unitOfWork._DeductionTypes.GetByIdAsync(req.Id);
                if (result is null) return null;

                result.Name = req.Name;
                result.IsDefault = req.IsDefault;
                result.Amount = req.Amount;

                await _unitOfWork._DeductionTypes.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(id) > 0 
                    ? result.ToDeductionTypesResponse() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message ,ex);
            }

        }
        public async Task<DeductionTypesDtoResponse?> Add(DeductionTypesDtoRequest req, Guid id)
        {
            try
            {
                var result = await _unitOfWork._DeductionTypes.AddAsync(new DeductionTypes
                {
                    Name = req.Name,
                    Amount = req.Amount,
                    IsDefault = req.IsDefault,
                    Active = true
                });

                return await _unitOfWork.SaveChangeAsync(id) > 0
                    ? result.ToDeductionTypesResponse() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<DeductionTypesDtoResponse?> Delete(Guid allowId, Guid id)
        {
            try
            {
                var result = await _unitOfWork._DeductionTypes.GetByIdAsync(allowId);
                if (result is null) return null;

                await _unitOfWork._DeductionTypes.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(id) > 0 
                    ? result.ToDeductionTypesResponse() : null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
          
            
        }

        public async Task<PagedResult_<DeductionTypesDtoResponse>> GetAll(DeductionTypeFilters filters)
        {
            var result = await _unitOfWork._DeductionTypes.GetDbSet()
                .AsNoTracking()
                .Where(f => (!string.IsNullOrEmpty(filters.Search) 
                    ? f.Name.ToLower().Contains(filters.Search.ToLower()) : true))
                .ToListAsync();

            return result.ToDeductionTypesResponseList().ToPagedList_(filters.Page, filters.Limit);
            
        }

        public async Task<DeductionTypesDtoResponse> GetById(Guid id)
        {
            var result = await _unitOfWork._DeductionTypes.GetByIdAsync(id);
            return result.ToDeductionTypesResponse();
        }

        public async Task<List<DeductionTypesDtoResponse>> Resources()
        {
            var result = await _unitOfWork._DeductionTypes.GetAllAsync();
            return result.ToDeductionTypesResponseList().ToList() ;
        }

        public async Task<bool> IsExists(Expression<Func<DeductionTypes, bool>> predicate)
        {
            var result = await _unitOfWork._DeductionTypes.GetDbSet()
                  .AsNoTracking()
                  .Where(predicate)
                  .AnyAsync();

            return result;
        }
    }
}
