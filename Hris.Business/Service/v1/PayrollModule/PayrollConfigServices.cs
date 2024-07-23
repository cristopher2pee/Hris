using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IPayrollConfigServices
    {
        //PayrollConfig
        Task<PayrollConfigDtoResponse?> AddPayrollConfig(PayrollConfigDtoRequest req, Guid objId);
        Task<PayrollConfigDtoResponse?> UpdatePayrollConfig(PayrollConfigDtoRequest req, Guid objId);
        Task<PayrollConfigDtoResponse?> UpdatePayrollConfig(PayrollConfig req, Guid objId);
        Task<bool> DeletePayrollConfig(Guid Id, Guid objId);
        Task<PayrollConfigDtoResponse> GetPayrollConfigById(Guid Id);
        Task<PagedResult_<PayrollConfigDtoResponse>> GetAllPayrollConfig(BaseFilter_ filter);
        //PayrollConfig Details
        Task<PayrollConfigDetailsDtoResponse?> AddPayrollConfigDetails(PayrollConfigDetailsDtoRequest req, Guid objId);
        Task<PayrollConfigDetailsDtoResponse?> UpdatePayrollConfigDetails(PayrollConfigDetailsDtoRequest req, Guid objId);

        Task<bool> DeletePayrollConfigDetails(Guid Id, Guid objId);
        Task<PayrollConfigDetailsDtoResponse> GetPayrollConfigDetailsById(Guid Id);
        Task<PagedResult_<PayrollConfigDetailsDtoResponse>> GetAllPayrollConfigDetails(PayrollConfigDetailsFilter filter);

        Task<bool> isConfigDetailsExist(Expression<Func<PayrollConfigDetails, bool>> predicate);

        Task<bool> isPayrollConfigExist(Expression<Func<PayrollConfig, bool>> predicate);

        Task<PayrollConfig?> GetPayrollConfig(Expression<Func<PayrollConfig, bool>> predicate);
        Task<bool> AddBatchPayrollConfigDetails(BatchEmployeePayrollConfigDetailsRequest req, Guid objId);

        Task<PayrollConfigDetails?> GetPayrollConfigDetails(Expression<Func<PayrollConfigDetails, bool>> predicate);
    }
    internal class PayrollConfigServices : IPayrollConfigServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PayrollConfigServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddBatchPayrollConfigDetails(BatchEmployeePayrollConfigDetailsRequest req, Guid objId)
        {
            try
            {
                var toAdd = new List<PayrollConfigDetails>();
                foreach (var Id in req.EmployeeIds)
                {
                    var config = await GetPayrollConfigDetails(f => f.PayrollConfigId.Equals(req.PayrollConfigId) && f.EmployeeId.Equals(Id));
                    if (config != null) continue;

                    toAdd.Add(new PayrollConfigDetails
                    {
                        Id = Guid.NewGuid(),
                        EmployeeId = Id,
                        PayrollConfigId = req.PayrollConfigId,
                        Active = true
                    });
                };

                if (toAdd.Any())
                {
                    await _unitOfWork._PayrollConfigDetails.AddRangeAsync(toAdd.ToArray());
                    return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task<PayrollConfigDetails?> AddPayrollConfigDetailsAsync(PayrollConfigDetails req, Guid objId)
        {
            try
            {
                var config = await _unitOfWork._PayrollConfigDetails.AddAsync(req);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? config : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task<PayrollConfigDetails?> UpdatePayrollConfigDetailsAsync(PayrollConfigDetails req, Guid objId)
        {
            try
            {
                var config = await _unitOfWork._PayrollConfigDetails.UpdateAsync(req);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? config : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PayrollConfigDtoResponse?> AddPayrollConfig(PayrollConfigDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollConfig.AddAsync(new Data.Models.Payroll.PayrollConfig
                {
                    Name = req.Name,
                    Period = req.Period,
                    FromDay = req.FromDay,
                    ToDay = req.ToDay,
                    PayOutDay = req.PayOutDay,
                    Active = true,
                    LeaveConversionId = req.LeaveConversionId,
                    ThirteenMonthId = req.ThirteenMonthId,
                    TaxTypePeriod = req.TaxTypePeriod,
                    Template = req.Template,
                    TemplateUri = req.TemplateUri,
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollConfigResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PayrollConfigDetailsDtoResponse?> AddPayrollConfigDetails(PayrollConfigDetailsDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollConfigDetails.AddAsync(new Data.Models.Payroll.PayrollConfigDetails
                {
                    PayrollConfigId = req.PayrollConfigId,
                    EmployeeId = req.EmployeeId,
                    Active = true,
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollConfigDetailsResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeletePayrollConfig(Guid Id, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollConfig.GetByIdAsync(Id);
                await _unitOfWork._PayrollConfig.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeletePayrollConfigDetails(Guid Id, Guid objId)
        {
            try
            {
                var res = await _unitOfWork._PayrollConfigDetails.GetByIdAsync(Id);
                await _unitOfWork._PayrollConfigDetails.DeleteAsync(res);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<PagedResult_<PayrollConfigDtoResponse>> GetAllPayrollConfig(BaseFilter_ filter)
        {
            var result = await _unitOfWork._PayrollConfig.GetDbSet()
                .AsNoTracking()
                .Include(f => f.ThirteenMonth)
                .Include(f => f.LeaveConversion)
                .Where(f => (f.Name.ToLower().Contains(filter.Search.ToLower())))
                .ToListAsync();

            return result.ToPayrollConfigResponseList().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<PagedResult_<PayrollConfigDetailsDtoResponse>> GetAllPayrollConfigDetails(PayrollConfigDetailsFilter filter)
        {
            var result = await _unitOfWork._PayrollConfigDetails.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Employee)
                .Include(f => f.PayrollConfig)
                .Where(f => filter.PayrollConfigId.HasValue ? f.PayrollConfigId.Equals(filter.PayrollConfigId) : true)
                .ToListAsync();

            return result.ToPayrollConfigDetailsResponseList().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<PayrollConfig?> GetPayrollConfig(Expression<Func<PayrollConfig, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollConfig.GetDbSet()
                .AsNoTracking()
                .Where(predicate)
                .FirstOrDefaultAsync();

            return result ?? null;
        }

        public async Task<PayrollConfigDtoResponse> GetPayrollConfigById(Guid Id)
        {
            var result = await _unitOfWork._PayrollConfig.GetDbSet()
                .AsNoTracking()
                .Include(f => f.LeaveConversion)
                .Include(f => f.ThirteenMonth)
                .Where(f => f.Id.Equals(Id))
                .FirstOrDefaultAsync();

            return result.ToPayrollConfigResponse();
        }

        public async Task<PayrollConfigDetailsDtoResponse> GetPayrollConfigDetailsById(Guid Id)
        {
            var result = await _unitOfWork._PayrollConfigDetails.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Employee)
                .Include(f => f.PayrollConfig)
                .FirstOrDefaultAsync(f => f.Id.Equals(Id));

            return result.ToPayrollConfigDetailsResponse();
        }

        public async Task<bool> isConfigDetailsExist(Expression<Func<PayrollConfigDetails, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollConfigDetails.GetDbSet()
                .AsNoTracking()
                .Where(predicate)
                .AnyAsync();

            return result;
        }

        public async Task<bool> isPayrollConfigExist(Expression<Func<PayrollConfig, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollConfig.GetDbSet()
                 .AsNoTracking()
                 .Where(predicate)
                 .AnyAsync();

            return result;
        }

        public async Task<PayrollConfigDtoResponse?> UpdatePayrollConfig(PayrollConfigDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollConfig.GetByIdAsync(req.Id);
                if (result is null) return null;

                result.Name = req.Name;
                result.Period = req.Period;
                result.FromDay = req.FromDay;
                result.ToDay = req.ToDay;
                result.PayOutDay = req.PayOutDay;
                result.LeaveConversionId = req.LeaveConversionId;
                result.ThirteenMonthId = req.ThirteenMonthId;
                result.TaxTypePeriod = req.TaxTypePeriod;
                result.Template = req.Template;
                result.TemplateUri = req.TemplateUri;

                await _unitOfWork._PayrollConfig.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollConfigResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PayrollConfigDtoResponse?> UpdatePayrollConfig(PayrollConfig req, Guid objId)
        {
            try
            {
                await _unitOfWork._PayrollConfig.UpdateAsync(req);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? req.ToPayrollConfigResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PayrollConfigDetailsDtoResponse?> UpdatePayrollConfigDetails(PayrollConfigDetailsDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollConfigDetails.GetByIdAsync(req.Id);
                result.PayrollConfigId = req.PayrollConfigId;
                result.EmployeeId = req.EmployeeId;

                await _unitOfWork._PayrollConfigDetails.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollConfigDetailsResponse() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PayrollConfigDetails?> GetPayrollConfigDetails(Expression<Func<PayrollConfigDetails, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollConfigDetails.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Employee)
                .Include(f => f.PayrollConfig)
                .Where(predicate)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
