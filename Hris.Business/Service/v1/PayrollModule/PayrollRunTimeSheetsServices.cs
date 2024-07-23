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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tavis.UriTemplates;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IPayrollRunTimeSheetsServices
    {
        Task<PayrollRunTimeSheetsDtoResponse> GetPayrollRunTimeSheets(Expression<Func<PayrollRunTimeSheets, bool>> predicate);
        Task<IEnumerable<PayrollRunTimeSheetsDtoResponse>> GetPayrollRunTimeSheetsList(Expression<Func<PayrollRunTimeSheets, bool>> predicate);
        Task<PagedResult_<PayrollRunTimeSheetsDtoResponse>> GetPayrollRunTimeSheetsPagedList(BaseFilter_ filter);
        Task<PayrollRunTimeSheetsDtoResponse?> Add(PayrollRunTimeSheetsDtoRequest req, Guid objId);
        Task<PayrollRunTimeSheets?> Add(PayrollRunTimeSheets req, Guid objId);
        Task<PayrollRunTimeSheetsDtoResponse?> Update(PayrollRunTimeSheetsDtoRequest req, Guid objId);
        Task<PayrollRunTimeSheets?> Update(PayrollRunTimeSheets req, Guid objId);
        Task<bool> Delete(Guid id, Guid objId);
        Task<bool> isExist(Expression<Func<PayrollRunTimeSheets, bool>> predicate);

        Task<bool> UpdateIncludedPayByEmployee(Expression<Func<PayrollRunTimeSheets, bool>> predicate,
                   PayrollRunIncludeRequest req, Guid objId);
        Task<bool> UpdateAllIncludeEmployee(Expression<Func<PayrollRunTimeSheets, bool>> predicate, bool is13MonthPay,
            PayrollRunIncludeRequest req, Guid objId);
        Task<IEnumerable<PayrollRunTimeSheets>> GetListPayrollRunTimeSheets(Expression<Func<PayrollRunTimeSheets, bool>> predicate);
        Task<PayrollRunTimeSheets> GetPayrollRunTimeSheetsExp(Expression<Func<PayrollRunTimeSheets, bool>> predicate);

    }

    internal class PayrollRunTimeSheetsServices : IPayrollRunTimeSheetsServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PayrollRunTimeSheetsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PayrollRunTimeSheetsDtoResponse?> Add(PayrollRunTimeSheetsDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunTimeSheets.AddAsync(new PayrollRunTimeSheets
                {
                    PayrollRunId = req.PayrollRunId,
                    EmployeeId = req.EmployeeId,
                    OD = req.OD,
                    RD = req.RD,
                    SH = req.SH,
                    RDOnSH = req.RDOnSH,
                    DSH = req.DSH,
                    RDOnDSH = req.RDOnDSH,
                    RH = req.RH,
                    RDOnRH = req.RDOnRH,
                    DRH = req.DRH,
                    RDOnDRH = req.RDOnDRH,
                    ODOnNSD = req.ODOnNSD,
                    NSDOnRD = req.NSDOnRD,
                    NSDOnSH = req.NSDOnSH,
                    NSDOnRDOnSH = req.NSDOnRDOnSH,
                    NSDOnRDOnDSH = req.NSDOnRDOnDSH,
                    NSDOnRH = req.NSDOnRH,
                    NSDOnRDOnRH = req.NSDOnRDOnRH,
                    NSDOnDRH = req.NSDOnDRH,
                    NSDOnRDOnDRH = req.NSDOnRDOnDRH,
                    ODOnOT = req.ODOnOT,
                    OTOnRD = req.OTOnRD,
                    OTOnSH = req.OTOnSH,
                    OTOnRDOnSH = req.OTOnRDOnSH,
                    OTOnRDOnDSH = req.OTOnRDOnDSH,
                    OTOnRH = req.OTOnRH,
                    OTOnRDOnRH = req.OTOnRDOnRH,
                    OTOnDRH = req.OTOnDRH,
                    OTOnRDOnDRH = req.OTOnRDOnDRH,
                    ODOnOTOnNSD = req.ODOnOTOnNSD,
                    OTOnNSDOnRD = req.OTOnNSDOnRD,
                    OTOnNSDOnSH = req.OTOnNSDOnSH,
                    OTOnNSDOnRDOnSH = req.OTOnNSDOnRDOnSH,
                    OTOnNSDOnRDOnDSH = req.OTOnNSDOnRDOnDSH,
                    OTOnNSDOnRH = req.OTOnNSDOnRH,
                    OTOnNSDOnRDOnRH = req.OTOnNSDOnRDOnRH,
                    OTOnNSDOnDRH = req.OTOnNSDOnDRH,
                    OTOnNSDOnRDOnDRH = req.OTOnNSDOnRDOnDRH,
                    NoPayLeave = req.NoPayLeave,
                    Late = req.Late,
                    Notes = req.Notes,
                    Active = true,
                    NSDonDSH = req.NSDonDSH,
                    OTOnDSH = req.OTOnDSH,
                    OTOnNSDOnDSH = req.OTOnNSDOnDSH,
                    Is13MonthInclude = req.Is13MonthInclude,
                    IsLeaveInclude = req.IsLeaveInclude,
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunTimeSheetsDtoResponse() : null;

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
                var result = await _unitOfWork._PayrollRunTimeSheets.GetByIdAsync(id);
                if (result == null) return false;

                await _unitOfWork._PayrollRunTimeSheets.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<PayrollRunTimeSheetsDtoResponse> GetPayrollRunTimeSheets(Expression<Func<PayrollRunTimeSheets, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .Where(predicate)
                 .FirstOrDefaultAsync();

            return result.ToPayrollRunTimeSheetsDtoResponse();
        }

        public async Task<IEnumerable<PayrollRunTimeSheetsDtoResponse>> GetPayrollRunTimeSheetsList(Expression<Func<PayrollRunTimeSheets, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .Where(predicate)
                 .ToListAsync();

            return result != null ? result.ToPayrollRunTimeSheetsDtoResponseList()
                : Enumerable.Empty<PayrollRunTimeSheetsDtoResponse>();
        }

        public async Task<PagedResult_<PayrollRunTimeSheetsDtoResponse>> GetPayrollRunTimeSheetsPagedList(BaseFilter_ filter)
        {
            var result = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Employee)
                .Include(f => f.PayrollRun)
                .Where(f => f.Employee.Firstname.ToLower().Contains(filter.Search.ToLower())
                    || f.Employee.Lastname.ToLower().Contains(filter.Search.ToLower()))
                .ToListAsync();

            return result.ToPayrollRunTimeSheetsDtoResponseList().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<bool> isExist(Expression<Func<PayrollRunTimeSheets, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.PayrollRun)
                 .Include(f => f.Employee)
                 .Where(predicate)
                 .AnyAsync();

            return result;
        }

        public async Task<PayrollRunTimeSheetsDtoResponse?> Update(PayrollRunTimeSheetsDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunTimeSheets.GetByIdAsync(req.Id);

                if (result is null) throw new ArgumentNullException(nameof(result), "object result cannot be null.");
                result.PayrollRunId = req.PayrollRunId;
                result.EmployeeId = req.EmployeeId;
                result.OD = req.OD;
                result.RD = req.RD;
                result.SH = req.SH;
                result.RDOnSH = req.RDOnSH;
                result.DSH = req.DSH;
                result.RDOnDSH = req.RDOnDSH;
                result.RH = req.RH;
                result.RDOnRH = req.RDOnRH;
                result.DRH = req.DRH;
                result.RDOnDRH = req.RDOnDRH;
                result.ODOnNSD = req.ODOnNSD;
                result.NSDOnRD = req.NSDOnRD;
                result.NSDOnSH = req.NSDOnSH;
                result.NSDOnRDOnSH = req.NSDOnRDOnSH;
                result.NSDOnRDOnDSH = req.NSDOnRDOnDSH;
                result.NSDOnRH = req.NSDOnRH;
                result.NSDOnRDOnRH = req.NSDOnRDOnRH;
                result.NSDOnDRH = req.NSDOnDRH;
                result.NSDOnRDOnDRH = req.NSDOnRDOnDRH;
                result.ODOnOT = req.ODOnOT;
                result.OTOnRD = req.OTOnRD;
                result.OTOnSH = req.OTOnSH;
                result.OTOnRDOnSH = req.OTOnRDOnSH;
                result.OTOnRDOnDSH = req.OTOnRDOnDSH;
                result.OTOnRH = req.OTOnRH;
                result.OTOnRDOnRH = req.OTOnRDOnRH;
                result.OTOnDRH = req.OTOnDRH;
                result.OTOnRDOnDRH = req.OTOnRDOnDRH;
                result.ODOnOTOnNSD = req.ODOnOTOnNSD;
                result.OTOnNSDOnRD = req.OTOnNSDOnRD;
                result.OTOnNSDOnSH = req.OTOnNSDOnSH;
                result.OTOnNSDOnRDOnSH = req.OTOnNSDOnRDOnSH;
                result.OTOnNSDOnRDOnDSH = req.OTOnNSDOnRDOnDSH;
                result.OTOnNSDOnRH = req.OTOnNSDOnRH;
                result.OTOnNSDOnRDOnRH = req.OTOnNSDOnRDOnRH;
                result.OTOnNSDOnDRH = req.OTOnNSDOnDRH;
                result.OTOnNSDOnRDOnDRH = req.OTOnNSDOnRDOnDRH;
                result.NoPayLeave = req.NoPayLeave;
                result.Late = req.Late;
                result.Notes = req.Notes;
                result.NSDonDSH = req.NSDonDSH;
                result.OTOnDSH = req.OTOnDSH;
                result.OTOnNSDOnDSH = req.OTOnNSDOnDSH;
                result.IsLeaveInclude = req.IsLeaveInclude;
                result.Is13MonthInclude = req.Is13MonthInclude;
                await _unitOfWork._PayrollRunTimeSheets.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunTimeSheetsDtoResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateIncludedPayByEmployee(Expression<Func<PayrollRunTimeSheets, bool>> predicate,
           PayrollRunIncludeRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                     .AsNoTracking()
                     .Where(predicate)
                     .FirstOrDefaultAsync();

                if (result is null) throw new ArgumentNullException(nameof(result), "object result cannot be null.");
                result.Is13MonthInclude = req.Is13thMonthInclude;
                result.IsLeaveInclude = req.IsLeaveInclude;

                await _unitOfWork._PayrollRunTimeSheets.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }

        public async Task<bool> UpdateAllIncludeEmployee(Expression<Func<PayrollRunTimeSheets, bool>> predicate, bool is13MonthPay,
            PayrollRunIncludeRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                     .AsNoTracking()
                     .Where(predicate)
                     .ToListAsync();

                if (!result.Any()) return false;

                foreach (var item in result)
                {
                    if (is13MonthPay)
                        item.Is13MonthInclude = req.Is13thMonthInclude;
                    else
                        item.IsLeaveInclude = req.IsLeaveInclude;

                    await _unitOfWork._PayrollRunTimeSheets.UpdateAsync(item);
                }

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<PayrollRunTimeSheets?> Add(PayrollRunTimeSheets req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunTimeSheets.AddAsync(req);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PayrollRunTimeSheets?> Update(PayrollRunTimeSheets req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunTimeSheets.UpdateAsync(req);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<PayrollRunTimeSheets>> GetListPayrollRunTimeSheets(Expression<Func<PayrollRunTimeSheets, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollRun)
                .Include(f => f.Employee)
                .Where(predicate)
                .ToListAsync();

            return result != null ? result : Enumerable.Empty<PayrollRunTimeSheets>();
        }

        public async Task<PayrollRunTimeSheets> GetPayrollRunTimeSheetsExp(Expression<Func<PayrollRunTimeSheets, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollRun)
                .Include(f => f.Employee)
                .Where(predicate)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}