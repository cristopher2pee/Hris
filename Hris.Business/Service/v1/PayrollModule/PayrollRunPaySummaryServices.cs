using Hris.Business.Extensions;
using Hris.Business.Helper;
using Hris.Business.Models.Common;
using Hris.Business.Service.Leave;
using Hris.Business.Service.v1.EmployeeModule;
using Hris.Business.Service.v1.Statutories;
using Hris.Data.DTO;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Hris.Resource.PayrollRun;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.DeviceManagement.ManagedDevices.Item.Retire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static QuestPDF.Helpers.Colors;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IPayrollRunPaySummaryServices
    {
        Task<PayrollRunPaySummaryDtoResponse> GetPayrollRunPaySummary(Expression<Func<PayrollRunPaySummary, bool>> predicate);
        Task<IEnumerable<PayrollRunPaySummaryDtoResponse>> GetPayrollRunPaySummaryList(Expression<Func<PayrollRunPaySummary, bool>> predicate);
        Task<PagedResult_<PayrollRunPaySummaryDtoResponse>> GetPayrollRunPaySummaryListPage(Expression<Func<PayrollRunPaySummary, bool>> predicate, BaseFilter_ filter);
        Task<PayrollRunPaySummaryDtoResponse?> Add(PayrollRunPaySummaryDtoRequest req, Guid objId);
        Task<PayrollRunPaySummaryDtoResponse?> Update(PayrollRunPaySummaryDtoRequest req, Guid objId);
        Task<bool> Delete(Guid id, Guid objId);
        Task<bool> isExist(Expression<Func<PayrollRunPaySummary, bool>> predicate);

        Task<bool> ProcessEmployeesPaySummary(Guid payrollId, Guid objId);

    }
    internal class PayrollRunPaySummaryServices : IPayrollRunPaySummaryServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatutoriesServices _statutoriesServices;
        private readonly IPayrollHelper _payrollHelper;
        private readonly IPayrollRunAllowanceServices _payrollRunAllowanceServices;
        private readonly IPayrollRunLoansServices _payrollRunLoansServices;
        private readonly IPayrollRunDeductionsServices _payrollRunDeductionsServices;
        private readonly ISalaryHistoryServices _salaryHistoryServices;
        private readonly IPayrollRunTimeSheetsServices _runSheetsServices;
        public PayrollRunPaySummaryServices(IUnitOfWork unitOfWork,
            IStatutoriesServices statutoriesServices,
            IPayrollRunAllowanceServices payrollRunAllowanceServices,
            IPayrollRunLoansServices payrollRunLoansServices,
            IPayrollRunDeductionsServices payrollRunDeductionsServices,
            ISalaryHistoryServices salaryHistoryServices,
            IPayrollHelper payrollHelper,
            IPayrollRunTimeSheetsServices runSheetsServices)
        {
            _unitOfWork = unitOfWork;
            _statutoriesServices = statutoriesServices;
            _payrollHelper = payrollHelper;
            _payrollRunAllowanceServices = payrollRunAllowanceServices;
            _payrollRunDeductionsServices = payrollRunDeductionsServices;
            _payrollRunLoansServices = payrollRunLoansServices;
            _salaryHistoryServices = salaryHistoryServices;
            _runSheetsServices = runSheetsServices;
        }
        public async Task<PayrollRunPaySummaryDtoResponse?> Add(PayrollRunPaySummaryDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunPaySummary.AddAsync(new PayrollRunPaySummary
                {
                    PayrollRunId = req.PayrollRunId,
                    EmployeeId = req.EmployeeId,
                    Basic = req.Basic,
                    TimeSheetsPay = req.TimeSheetsPay,
                    TimeSheetDeduction = req.TimeSheetDeduction,
                    Allowances = req.Allowances,
                    Deduction = req.Deduction,
                    Loan = req.Loan,
                    ThirteenMonthPay = req.ThirteenMonthPay,
                    LeaveConversion = req.LeaveConversion,
                    GrossPay = req.GrossPay,
                    SSSER = req.SSSER,
                    SSSEE = req.SSSEE,
                    SSSEC = req.SSSEC,
                    PHICER = req.PHICER,
                    PHICEE = req.PHICEE,
                    HDMFER = req.HDMFER,
                    HDMFEE = req.HDMFEE,
                    TaxCode = req.TaxCode,
                    TaxWitheld = req.TaxWitheld,
                    NetPay = req.NetPay,
                    Active = true
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunPaySummaryDtoResponse() : null;

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
                var result = await _unitOfWork._PayrollRunPaySummary.GetByIdAsync(id);
                if (result is null) throw new ArgumentNullException(nameof(result), "object result cannot be null."); ;

                await _unitOfWork._PayrollRunPaySummary.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PayrollRunPaySummaryDtoResponse> GetPayrollRunPaySummary(Expression<Func<PayrollRunPaySummary, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunPaySummary.GetDbSet()
                .AsNoTracking()
                                .Include(f => f.Employee)
                .Include(f => f.PayrollRun)
                .Where(predicate)
                .FirstOrDefaultAsync();

            return result.ToPayrollRunPaySummaryDtoResponse();
        }

        public async Task<IEnumerable<PayrollRunPaySummaryDtoResponse>> GetPayrollRunPaySummaryList(Expression<Func<PayrollRunPaySummary, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunPaySummary.GetDbSet()
                                .Include(f => f.Employee)
                .Include(f => f.PayrollRun)
                 .AsNoTracking()
                 .Where(predicate)
                 .ToListAsync();

            return result.ToPayrollRunPaySummaryDtoResponseList();
        }

        public async Task<PagedResult_<PayrollRunPaySummaryDtoResponse>> GetPayrollRunPaySummaryListPage(Expression<Func<PayrollRunPaySummary, bool>> predicate, BaseFilter_ filter)
        {
            var result = await _unitOfWork._PayrollRunPaySummary.GetDbSet()
                .Include(f => f.Employee)
                .Include(f => f.PayrollRun)
                 .AsNoTracking()
                 .Where(predicate)
                 .ToListAsync();

            return result.ToPayrollRunPaySummaryDtoResponseList().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<bool> isExist(Expression<Func<PayrollRunPaySummary, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRunPaySummary.GetDbSet()
                  .AsNoTracking()
                  .Where(predicate)
                  .AnyAsync();

            return result;
        }

        public async Task<PayrollRunPaySummaryDtoResponse?> Update(PayrollRunPaySummaryDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRunPaySummary.GetByIdAsync(req.Id);
                result.PayrollRunId = req.PayrollRunId;
                result.EmployeeId = req.EmployeeId;
                result.Basic = req.Basic;
                result.TimeSheetsPay = req.TimeSheetsPay;
                result.TimeSheetDeduction = req.TimeSheetDeduction;
                result.Allowances = req.Allowances;
                result.Deduction = req.Deduction;
                result.Loan = req.Loan;
                result.ThirteenMonthPay = req.ThirteenMonthPay;
                result.LeaveConversion = req.LeaveConversion;
                result.GrossPay = req.GrossPay;
                result.SSSER = req.SSSER;
                result.SSSEE = req.SSSEE;
                result.SSSEC = req.SSSEC;
                result.PHICER = req.PHICER;
                result.PHICEE = req.PHICEE;
                result.HDMFER = req.HDMFER;
                result.HDMFEE = req.HDMFEE;
                result.TaxCode = req.TaxCode;
                result.TaxWitheld = req.TaxWitheld;
                result.NetPay = req.NetPay;

                await _unitOfWork._PayrollRunPaySummary.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToPayrollRunPaySummaryDtoResponse() : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> ProcessEmployeesPaySummary(Guid payrollId, Guid objId)
        {
            try
            {
                var payrollRunTimeSheetsPay = await _unitOfWork._PayrollRunTimeSheetsPay.GetDbSet()
                    .AsNoTracking()
                    .Where(f => f.PayrollRunId.Equals(payrollId))
                    .ToListAsync();

                var payrollRun = await _unitOfWork._PayrollRun.GetDbSet()
                    .AsNoTracking()
                    .Include(f => f.PayrollConfig)
                    .Where(f => f.Id.Equals(payrollId))
                    .FirstOrDefaultAsync();

                if (payrollRun == null) throw new ArgumentNullException(nameof(payrollRun), "object result cannot be null.");

                foreach (var item in payrollRunTimeSheetsPay)
                {
                    var payrollTimeSheets = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                         .AsNoTracking()
                         .Where(f => f.EmployeeId.Equals(item.EmployeeId) && f.PayrollRunId.Equals(item.PayrollRunId))
                         .FirstOrDefaultAsync();

                    if (payrollTimeSheets is null) throw new ArgumentNullException(nameof(payrollTimeSheets), "object result cannot be null.");

                    var toAdd = await processPaySummaryByEmployee(item, payrollTimeSheets, payrollRun, objId);
                    var isExist = await _unitOfWork._PayrollRunPaySummary.GetDbSet()
                        .AsNoTracking()
                        .Where(f => f.PayrollRunId.Equals(item.PayrollRunId) && f.EmployeeId.Equals(item.EmployeeId))
                        .AnyAsync();

                    if (isExist)
                        await updatePaySummary(toAdd, item.PayrollRunId, item.EmployeeId);
                    else
                        await _unitOfWork._PayrollRunPaySummary.AddAsync(toAdd);

                }

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private async Task<bool> updatePaySummary(PayrollRunPaySummary req, Guid payrollRunId, Guid employeeId)
        {
            // var result = await _unitOfWork._PayrollRunPaySummary.GetByIdAsync(req.Id);
            var result = await _unitOfWork._PayrollRunPaySummary.GetDbSet()
                 .Where(f => f.PayrollRunId.Equals(payrollRunId) && f.EmployeeId.Equals(employeeId))
                 .FirstOrDefaultAsync();

            if (result == null) throw new ArgumentNullException(nameof(result), "Object result cannot be null.");

            result.PayrollRunId = req.PayrollRunId;
            result.EmployeeId = req.EmployeeId;
            result.Basic = req.Basic;
            result.TimeSheetsPay = req.TimeSheetsPay;
            result.TimeSheetDeduction = req.TimeSheetDeduction;
            result.Allowances = req.Allowances;
            result.Deduction = req.Deduction;
            result.Loan = req.Loan;
            result.ThirteenMonthPay = req.ThirteenMonthPay;
            result.LeaveConversion = req.LeaveConversion;
            result.GrossPay = req.GrossPay;
            result.SSSER = req.SSSER;
            result.SSSEE = req.SSSEE;
            result.SSSEC = req.SSSEC;
            result.PHICER = req.PHICER;
            result.PHICEE = req.PHICEE;
            result.HDMFER = req.HDMFER;
            result.HDMFEE = req.HDMFEE;
            result.TaxCode = req.TaxCode;
            result.TaxWitheld = req.TaxWitheld;
            result.NetPay = req.NetPay;

            await _unitOfWork._PayrollRunPaySummary.UpdateAsync(result);
            return true;
        }
        private async Task<PayrollRunPaySummary> processPaySummaryByEmployee(PayrollRunTimeSheetsPay sheetsPay, PayrollRunTimeSheets sheets, PayrollRun payrollRun, Guid objId)
        {
            var paySummary = new PayrollRunPaySummary();

            paySummary.EmployeeId = sheetsPay.EmployeeId;
            paySummary.PayrollRunId = sheetsPay.PayrollRunId;

            var employeeSalary = await _salaryHistoryServices.GetLatestSalary(f => f.EmployeeId.Equals(paySummary.EmployeeId));

            var payrollAllowance = await _payrollRunAllowanceServices.GetListPayrollRunAllowance
                (f => f.EmployeeId.Equals(paySummary.EmployeeId) && f.PayrollRunId.Equals(paySummary.PayrollRunId));

            var payrollDeduction = await _payrollRunDeductionsServices.GetListPayrllRunDeductions
                (f => f.EmployeeId.Equals(paySummary.EmployeeId) && f.PayrollRunId.Equals(paySummary.PayrollRunId));

            var payrollLoans = await _payrollRunLoansServices.GetListPayrollRunLoans
                (f => f.EmployeeId.Equals(paySummary.EmployeeId) && f.PayrollRunId.Equals(paySummary.PayrollRunId));

            if (employeeSalary is null) throw new ArgumentNullException(nameof(employeeSalary), "object result cannot be null.");

            var dataResult = _payrollHelper.ProcessTimeSheets(sheetsPay);

            paySummary.Basic = employeeSalary.BasePay / 2;
            paySummary.TimeSheetsPay = dataResult.TimeSheetsPay;
            paySummary.TimeSheetDeduction = dataResult.TimeSheetsDeduction;

            paySummary.Allowances = payrollAllowance != null && payrollAllowance.Any()
                ? payrollAllowance.Sum(f => f.Amount) : 0.0m;
            paySummary.Deduction = payrollDeduction != null && payrollDeduction.Any()
                ? payrollDeduction.Sum(f => f.Amount) : 0.0m;
            paySummary.Loan = payrollLoans != null && payrollLoans.Any()
                ? payrollLoans.Sum(f => f.Amount) : 0.0m;

            var contribution = await _statutoriesServices.ProcessContributionStatutories(employeeSalary.BasePay);

            paySummary.SSSER = contribution.SSSER;
            paySummary.SSSEE = contribution.SSSEE;
            paySummary.SSSEC = contribution.SSSEC;
            paySummary.PHICER = contribution.PHICER;
            paySummary.PHICEE = contribution.PHICEE;
            paySummary.HDMFER = contribution.HDMFER;
            paySummary.HDMFEE = contribution.HDMFEE;

            if (sheets.IsLeaveInclude || sheets.Is13MonthInclude)
            {
                var isPaymentCompleted = await _payrollHelper.IsPaymentBonusesCompleted(paySummary.EmployeeId, DateTime.Now.Year, paySummary.PayrollRunId);
                if (!isPaymentCompleted.ThirteenMonth && sheets.Is13MonthInclude)
                {
                    paySummary.ThirteenMonthPay = await _payrollHelper.ProcessThirteenMonthPay(paySummary.EmployeeId, paySummary.PayrollRunId,
                        employeeSalary.BasePay, paySummary.TimeSheetDeduction);
                }
                if (!isPaymentCompleted.LeaveConversion && sheets.IsLeaveInclude)
                {
                    paySummary.LeaveConversion = await _payrollHelper.ProcessLeaveConversion(paySummary.EmployeeId, employeeSalary.BasePay);
                }

                if (isPaymentCompleted.ThirteenMonth || isPaymentCompleted.LeaveConversion)
                {
                    var toUpdateSheets = await _runSheetsServices.GetPayrollRunTimeSheetsExp(f=>f.Id.Equals(sheets.Id));
                    if (toUpdateSheets != null)
                    {
                        toUpdateSheets.Is13MonthInclude = isPaymentCompleted.ThirteenMonth ? false : toUpdateSheets.Is13MonthInclude;
                        toUpdateSheets.IsLeaveInclude = isPaymentCompleted.LeaveConversion ? false : toUpdateSheets.IsLeaveInclude;

                        await _runSheetsServices.Update(toUpdateSheets, objId);
                    }
                }
            }

            paySummary.GrossPay = paySummary.Basic
                + paySummary.TimeSheetsPay
                + paySummary.Allowances
                + paySummary.ThirteenMonthPay
                + paySummary.LeaveConversion;

            var resultTax = await _payrollHelper.ProcessTaxwithHeld(paySummary, sheets.Is13MonthInclude, payrollRun);
            paySummary.TaxWitheld = resultTax.TaxAmount;
            paySummary.TaxCode = resultTax.TaxCode;

            var overallDeductions = paySummary.TimeSheetDeduction + paySummary.Loan + paySummary.Deduction
                + paySummary.HDMFEE + paySummary.PHICEE + paySummary.SSSEE + paySummary.TaxWitheld;

            paySummary.NetPay = paySummary.GrossPay - overallDeductions;
            return paySummary;
        }
    }
}
