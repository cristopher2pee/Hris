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
    public interface ITaxTableServices
    {
        Task<IEnumerable<TaxTableDtoResponse>> GetAll();
        Task<TaxTableDtoResponse?> GetById(Guid Id);
        Task<TaxTableDtoResponse?> Add(TaxTableDtoRequest req, Guid objId);
        Task<TaxTableDtoResponse?> Update(TaxTableDtoRequest req, Guid objId);
        Task<bool> Delete(Guid id, Guid objId);

        Task<decimal> ComputeTaxWithHeld(TaxPeriodType type, decimal netPay);
        Task<TaxTableDtoResponse?> GetTaxTable(Expression<Func<TaxTable, bool>> exp);

    }
    internal class TaxTableServices : ITaxTableServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaxTableServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TaxTableDtoResponse?> Add(TaxTableDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._TaxTable.AddAsync(new TaxTable
                {
                    Code = req.Code,
                    RangeFrom = req.RangeFrom,
                    RangeTo = req.RangeTo,
                    FixRate = req.FixRate,
                    TaxRate = req.TaxRate,
                    Active = true,
                    ExcessOver = req.ExcessOver,
                    TaxPeriodType = req.TaxPeriodType
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0
                    ? result.ToTaxTableResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<decimal> ComputeTaxWithHeld(TaxPeriodType type, decimal netPay)
        {
            decimal taxWithHeld = 0.00m;
            var TaxTableRow = await _unitOfWork._TaxTable.GetDbSet()
                .AsNoTracking()
                .Where(f => f.TaxPeriodType.Equals(type))
                .Where(f => netPay >= f.RangeFrom && netPay <= f.RangeTo)
                .FirstOrDefaultAsync();

            if (TaxTableRow != null)
            {
                if (TaxTableRow.TaxRate != 0)
                {
                    taxWithHeld = ((netPay - TaxTableRow.ExcessOver) * TaxTableRow.TaxRate) + TaxTableRow.FixRate;
                }
            }

            return taxWithHeld;
        }

        public async Task<bool> Delete(Guid id, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._TaxTable.GetByIdAsync(id);
                if (result is null) return false;

                await _unitOfWork._TaxTable.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<TaxTableDtoResponse>> GetAll()
        {
            var result = await _unitOfWork._TaxTable.GetAllAsync();
            return result != null ? result.ToTaxTableRespopnseList()
                : Enumerable.Empty<TaxTableDtoResponse>();
        }

        public async Task<TaxTableDtoResponse?> GetById(Guid Id)
        {
            var result = await _unitOfWork._TaxTable.GetByIdAsync(Id);
            return result != null ? result.ToTaxTableResponse() : null;
        }

        public async Task<TaxTableDtoResponse?> GetTaxTable(Expression<Func<TaxTable, bool>> exp)
        {
            var result = await _unitOfWork._TaxTable.GetDbSet()
                .AsNoTracking()
                .FirstOrDefaultAsync(exp);

            return result.ToTaxTableResponse();
        }

        public async Task<TaxTableDtoResponse?> Update(TaxTableDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._TaxTable.GetByIdAsync(req.Id);
                result.Code = req.Code;
                result.RangeFrom = req.RangeFrom;
                result.RangeTo = req.RangeTo;
                result.FixRate = req.FixRate;
                result.TaxRate = req.TaxRate;
                result.Active = req.Active;
                result.ExcessOver = req.ExcessOver;
                result.TaxPeriodType = req.TaxPeriodType;

                await _unitOfWork._TaxTable.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToTaxTableResponse() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
