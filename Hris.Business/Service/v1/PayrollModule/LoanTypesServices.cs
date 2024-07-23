using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static QuestPDF.Helpers.Colors;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface ILoanTypeServices
    {
        Task<IEnumerable<LoanTypesDtoResponse>> GetResources();
        Task<PagedResult_<LoanTypesDtoResponse>> GetAll(BaseFilter_ filter);
        Task<LoanTypesDtoResponse> GetById(Guid id);
        Task<LoanTypesDtoResponse?> Add(LoanTypesDtoRequest req, Guid objId);
        Task<LoanTypesDtoResponse?> Update(LoanTypesDtoRequest req, Guid objId);
        Task<bool> Delete(Guid Id, Guid objId);

        Task<bool> isExists(Expression<Func<LoanTypes, bool>> predicate);
    }
    internal class LoanTypesServices : ILoanTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoanTypesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<LoanTypesDtoResponse?> Add(LoanTypesDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._LoanTypes.AddAsync(new Data.Models.Payroll.LoanTypes
                {
                    ShortCode = req.ShortCode,
                    Name = req.Name,
                    Description = req.Description,
                    Active = true
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToLoanTypesResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<bool> Delete(Guid Id, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._LoanTypes.GetByIdAsync(Id);
                await _unitOfWork._LoanTypes.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResult_<LoanTypesDtoResponse>> GetAll(BaseFilter_ filter)
        {
            var result = await _unitOfWork._LoanTypes.GetDbSet()
                .AsNoTracking()
                .Where(f => f.Name.ToLower().Contains(filter.Search.ToLower())
                  || f.ShortCode.ToLower().Contains(filter.Search.ToLower()))
                .ToListAsync();

            return result.ToLoanTypesResponseList().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<LoanTypesDtoResponse> GetById(Guid id)
        {
            var result = await _unitOfWork._LoanTypes.GetByIdAsync(id);
            return result.ToLoanTypesResponse();
        }

        public async Task<IEnumerable<LoanTypesDtoResponse>> GetResources()
        {
            var result = await _unitOfWork._LoanTypes.GetAllAsync();
            return result != null ? result.ToLoanTypesResponseList()
                : Enumerable.Empty<LoanTypesDtoResponse>();
        }

        public async Task<bool> isExists(Expression<Func<LoanTypes, bool>> predicate)
        {
            var result = await _unitOfWork._LoanTypes.GetDbSet()
                 .AsNoTracking()
                 .Where(predicate)
                 .AnyAsync();

            return result;
        }

        public async Task<LoanTypesDtoResponse?> Update(LoanTypesDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._LoanTypes.GetByIdAsync(req.Id);

                if (result is null) return null;

                result.ShortCode = req.ShortCode;
                result.Name = req.Name;
                result.Description = req.Description;
                result.Active = true;

                await _unitOfWork._LoanTypes.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToLoanTypesResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
