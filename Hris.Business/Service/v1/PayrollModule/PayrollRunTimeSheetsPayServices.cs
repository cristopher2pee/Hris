using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Hris.Resource.PayrollRun;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static QuestPDF.Helpers.Colors;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IPayrollRunTimeSheetsPayServices
    {
        Task<PayrollRunTimeSheetsPayDtoResponse> GetPayrollRunTimeSheetsPay(Expression<Func<PayrollRunTimeSheetsPay, bool>> predicate);
        Task<IEnumerable<PayrollRunTimeSheetsPayDtoResponse>> GetPayrollRunTimeSheetsPayList(Expression<Func<PayrollRunTimeSheetsPay, bool>> predicate);
        Task<PagedResult_<PayrollRunTimeSheetsPayDtoResponse>> GetPayrollRunTimeSheetsPayListPage(Expression<Func<PayrollRunTimeSheetsPay, bool>> predicate, BaseFilter_ filter);
        Task<PayrollRunTimeSheetsPayDtoResponse?> Add(PayrollRunTimeSheetsPayDtoRequest req, Guid objId);
        Task<PayrollRunTimeSheetsPayDtoResponse?> Update(PayrollRunTimeSheetsPayDtoRequest req, Guid objId);
        Task<bool> Delete(Guid id, Guid objId);
        Task<bool> isExist(Expression<Func<PayrollRunTimeSheetsPay, bool>> predicate);

        Task<bool> ProcessPayrollRunTimeSheetsPay(Guid payrollRunId, Guid objId);

    }
    internal class PayrollRunTimeSheetsPayServices : IPayrollRunTimeSheetsPayServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PayrollRunTimeSheetsPayServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PayrollRunTimeSheetsPayDtoResponse?> Add(PayrollRunTimeSheetsPayDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunTimeSheetsPay.AddAsync(new PayrollRunTimeSheetsPay
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
                    OTOnRH = req.OTOnSHOnRH,
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
                    Active = true,
                    NSDonDSH = req.NSDonDSH,
                    OTOnDSH = req.OTOonDSH,
                    OTOnNSDOnDSH = req.OTOnNSDOnDSH
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunTimeSheetsPayDtoResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> ProcessPayrollRunTimeSheetsPay(Guid payrollRunId, Guid objId)
        {
            try
            {
                var list = new List<PayrollRunTimeSheetsPay>();
                var payrollRunTimeSheetsEmployee = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                    .AsNoTracking()
                    .Where(f => f.PayrollRunId.Equals(payrollRunId))
                    .ToListAsync();

                foreach (var item in payrollRunTimeSheetsEmployee)
                {
                    var exist = await isExist(f => f.EmployeeId.Equals(item.EmployeeId) && f.PayrollRunId.Equals(item.PayrollRunId));

                    if (exist)
                    {
                        var toUpdate = await GetPayrollRunTimeSheetsPay(f => f.EmployeeId.Equals(item.EmployeeId) && f.PayrollRunId.Equals(item.PayrollRunId));
                        await UpdatePayrollRuntimeSheetsPay(toUpdate.Id, item);
                    }
                    else
                    {
                        var processData = await ProcessPayrollRunTimeSheetsPayEmployee(item);
                        //list.Add(processData);
                        await _unitOfWork._PayrollRunTimeSheetsPay.AddAsync(processData);
                    }
                }

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private async Task<bool> UpdatePayrollRuntimeSheetsPay(Guid Id, PayrollRunTimeSheets data)
        {
            var result = await _unitOfWork._PayrollRunTimeSheetsPay.GetByIdAsync(Id);
            var req = await ProcessPayrollRunTimeSheetsPayEmployee(data);

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
            result.NSDonDSH = req.NSDonDSH;
            result.OTOnDSH = req.OTOnDSH;
            result.OTOnNSDOnDSH = req.OTOnNSDOnDSH;

            await _unitOfWork._PayrollRunTimeSheetsPay.UpdateAsync(result);
            return true;
        }


        private async Task<PayrollRunTimeSheetsPay> ProcessPayrollRunTimeSheetsPayEmployee(PayrollRunTimeSheets data)
        {
            var processData = new PayrollRunTimeSheetsPay();

            var employeeSalary = await _unitOfWork._SalaryHistory.GetDbSet()
                .Where(f => f.EmployeeId.Equals(data.EmployeeId))
                .OrderByDescending(f => f.EffectivityDate)
                .FirstOrDefaultAsync();

            if (employeeSalary is null) throw new ArgumentNullException(nameof(employeeSalary), "object result cannot be null.");

            var dailyRate = Rates.DailyRate(employeeSalary.BasePay);
            var hourlyRate = Rates.HourlyRate(dailyRate);

            processData.EmployeeId = data.EmployeeId;
            processData.PayrollRunId = data.PayrollRunId;

            //daily-rate
            if (data.OD > 0)
                processData.OD = data.OD * dailyRate * Rates.OD;
            if (data.RD > 0)
                processData.RD = data.RD * dailyRate * Rates.RD;
            if (data.SH > 0)
                processData.SH = data.SH * dailyRate * Rates.SH;
            if (data.RDOnSH > 0)
                processData.RDOnSH = data.RDOnSH * dailyRate * Rates.RDOnSH;
            if (data.DSH > 0)
                processData.DSH = data.DSH * dailyRate * Rates.DSH;
            if (data.RDOnDSH > 0)
                processData.RDOnDSH = data.RDOnDSH * dailyRate * Rates.RDOnDSH;
            if (data.RH > 0)
                processData.RH = data.RH * dailyRate * Rates.RH;
            if (data.RDOnRH > 0)
                processData.RDOnRH = data.RDOnRH * dailyRate * Rates.RDOnRH;
            if (data.DRH > 0)
                processData.DRH = data.DRH * dailyRate * Rates.DRH;
            if (data.RDOnDRH > 0)
                processData.RDOnDRH = data.RDOnDRH * dailyRate * Rates.RDOnDRH;

            //hourly-rate
            if (data.ODOnNSD > 0)
                processData.ODOnNSD = data.ODOnNSD * hourlyRate * Rates.ODOnNSD;
            if (data.NSDOnRD > 0)
                processData.NSDOnRD = data.NSDOnRD * hourlyRate * Rates.NSDOnRD;
            if (data.NSDOnSH > 0)
                processData.NSDOnSH = data.NSDOnSH * hourlyRate * Rates.NSDOnSH;
            if (data.NSDOnRDOnSH > 0)
                processData.NSDOnRDOnSH = data.NSDOnRDOnSH * hourlyRate * Rates.NSDOnRDOnSH;

            if (data.NSDOnRDOnDSH > 0)
                processData.NSDOnRDOnDSH = data.NSDOnRDOnDSH * hourlyRate * Rates.NSDOnRDOnDSH;
            if (data.NSDOnRH > 0)
                processData.NSDOnRH = data.NSDOnRH * hourlyRate * Rates.NSDOnRH;

            if (data.NSDOnRDOnRH > 0)
                processData.NSDOnRDOnRH = data.NSDOnRDOnRH * hourlyRate * Rates.NSDOnRDOnRH;
            //NSDOnDRH
            if (data.NSDOnDRH > 0)
                processData.NSDOnDRH = data.NSDOnDRH * hourlyRate * Rates.NSDOnDRH;
            //NSDOnRDOnDRH
            if (data.NSDOnRDOnDRH > 0)
                processData.NSDOnRDOnDRH = data.NSDOnRDOnDRH * hourlyRate * Rates.NSDOnRDOnDRH;
            //ODOnOT
            if (data.ODOnOT > 0)
                processData.ODOnOT = data.ODOnOT * hourlyRate * Rates.ODOnOT;
            //OTOnRD
            if (data.OTOnRD > 0)
                processData.OTOnRD = data.OTOnRD * hourlyRate * Rates.OTOnRD;
            //OTOnSH
            if (data.OTOnSH > 0)
                processData.OTOnSH = data.OTOnSH * hourlyRate * Rates.OTOnSH;
            //OTOnRDOnSH
            if (data.OTOnRDOnSH > 0)
                processData.OTOnRDOnSH = data.OTOnRDOnSH * hourlyRate * Rates.OTOnRDOnSH;
            //OTOnRDOnDSH
            if (data.OTOnRDOnDSH > 0)
                processData.OTOnRDOnDSH = data.OTOnRDOnDSH * hourlyRate * Rates.OTOnRDOnDSH;
            //OTOnSHOnRH
            if (data.OTOnRH > 0)
                processData.OTOnRH = data.OTOnRH * hourlyRate * Rates.OTOnSHOnRH;
            //OTOnRDOnRH
            if (data.OTOnRDOnRH > 0)
                processData.OTOnRDOnRH = data.OTOnRDOnRH * hourlyRate * Rates.OTOnRDOnRH;
            //OTOnDRH
            if (data.OTOnDRH > 0)
                processData.OTOnDRH = data.OTOnDRH * hourlyRate * Rates.OTOnDRH;
            //OTOnRDOnDRH
            if (data.OTOnRDOnDRH > 0)
                processData.OTOnRDOnDRH = data.OTOnRDOnDRH * hourlyRate * Rates.OTOnRDOnDRH;
            //ODOnOTOnNSD
            if (data.ODOnOTOnNSD > 0)
                processData.ODOnOTOnNSD = data.ODOnOTOnNSD * hourlyRate * Rates.ODOnOTOnNSD;
            //OTOnNSDOnRD
            if (data.OTOnNSDOnRD > 0)
                processData.OTOnNSDOnRD = data.OTOnNSDOnRD * hourlyRate * Rates.OTOnNSDOnRD;
            //OTOnNSDOnSH
            if (data.OTOnNSDOnSH > 0)
                processData.OTOnNSDOnSH = data.OTOnNSDOnSH * hourlyRate * Rates.OTOnNSDOnSH;

            //OTOnNSDOnRDOnSH
            if (data.OTOnNSDOnRDOnSH > 0)
                processData.OTOnNSDOnRDOnSH = data.OTOnNSDOnRDOnSH * hourlyRate * Rates.OTOnNSDOnRDOnSH;
            //OTOnNSDOnRDOnDSH
            if (data.OTOnNSDOnRDOnDSH > 0)
                processData.OTOnNSDOnRDOnDSH = data.OTOnNSDOnRDOnDSH * hourlyRate * Rates.OTOnNSDOnRDOnDSH;
            //OTOnNSDOnRH
            if (data.OTOnNSDOnRH > 0)
                processData.OTOnNSDOnRH = data.OTOnNSDOnRH * hourlyRate * Rates.OTOnNSDOnRH;
            //OTOnNSDOnRDOnRH
            if (data.OTOnNSDOnRDOnRH > 0)
                processData.OTOnNSDOnRDOnRH = data.OTOnNSDOnRDOnRH * hourlyRate * Rates.OTOnNSDOnRDOnRH;
            //OTOnNSDOnDRH
            if (data.OTOnNSDOnDRH > 0)
                processData.OTOnNSDOnDRH = data.OTOnNSDOnDRH * hourlyRate * Rates.OTOnNSDOnDRH;
            //OTOnNSDOnRDOnDRH
            if (data.OTOnNSDOnRDOnDRH > 0)
                processData.OTOnNSDOnRDOnDRH = data.OTOnNSDOnRDOnDRH * hourlyRate * Rates.OTOnNSDOnRDOnDRH;
            //NoPayLeave
            if (data.NoPayLeave > 0)
                processData.NoPayLeave = data.NoPayLeave * dailyRate * Rates.NoPayLeave;
            //Late
            if (data.Late > 0)
                processData.OTOnSH = data.Late * hourlyRate;
            if (data.NSDonDSH > 0)
                processData.NSDonDSH = data.NSDonDSH * hourlyRate * Rates.NSDonDSH;
            if (data.OTOnDSH > 0)
                processData.OTOnDSH = data.OTOnDSH * hourlyRate * Rates.OTOonDSH;
            if (data.OTOnNSDOnDSH > 0)
                processData.OTOnNSDOnDSH = data.OTOnNSDOnDSH * hourlyRate * Rates.OTOnNSDOnDSH;

            processData.Active = true;
            return processData;
        }


        public async Task<bool> Delete(Guid id, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunTimeSheetsPay.GetByIdAsync(id);
                if (result is null) throw new ArgumentNullException(nameof(result), "object result cannot be null.");
                await _unitOfWork._PayrollRunTimeSheetsPay.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }

        public async Task<PayrollRunTimeSheetsPayDtoResponse> GetPayrollRunTimeSheetsPay(Expression<Func<PayrollRunTimeSheetsPay, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunTimeSheetsPay.GetDbSet()
                                 .Include(f => f.Employee)
                 .Include(f => f.PayrollRun)
                 .AsNoTracking()
                 .Where(predicate)
                 .FirstOrDefaultAsync();

            return result.ToPayrollRunTimeSheetsPayDtoResponse();
        }

        public async Task<IEnumerable<PayrollRunTimeSheetsPayDtoResponse>> GetPayrollRunTimeSheetsPayList(Expression<Func<PayrollRunTimeSheetsPay, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunTimeSheetsPay.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.Employee)
                 .Include(f => f.PayrollRun)
                 .Where(predicate)
                 .ToListAsync();

            return result != null ? result.ToPayrollRunTimeSheetsPayDtoResponseList()
                : Enumerable.Empty<PayrollRunTimeSheetsPayDtoResponse>();
        }

        public async Task<PagedResult_<PayrollRunTimeSheetsPayDtoResponse>> GetPayrollRunTimeSheetsPayListPage(Expression<Func<PayrollRunTimeSheetsPay, bool>> predicate, BaseFilter_ filter_)
        {
            var result = await _unitOfWork._PayrollRunTimeSheetsPay.GetDbSet()
                  .AsNoTracking()
                  .Include(f => f.Employee)
                    .Include(f => f.PayrollRun)
                  .Where(predicate)
                  .OrderBy(f => f.Employee.Lastname)
                  .ThenBy(f => f.Employee.Firstname)
                  .ToListAsync();

            return result.ToPayrollRunTimeSheetsPayDtoResponseList().ToPagedList_(filter_.Page, filter_.Limit);
        }

        public async Task<bool> isExist(Expression<Func<PayrollRunTimeSheetsPay, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunTimeSheetsPay.GetDbSet()
                   .AsNoTracking()
                   .Where(predicate)
                   .AnyAsync();

            return result;
        }

        public async Task<PayrollRunTimeSheetsPayDtoResponse?> Update(PayrollRunTimeSheetsPayDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunTimeSheetsPay.GetByIdAsync(req.Id);

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
                result.OTOnRH = req.OTOnSHOnRH;
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
                result.NSDonDSH = req.NSDonDSH;
                result.OTOnDSH = req.OTOonDSH;
                result.OTOnNSDOnDSH = req.OTOnNSDOnDSH;

                await _unitOfWork._PayrollRunTimeSheetsPay.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunTimeSheetsPayDtoResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
