using Hris.Business.Service.v1.Statutories;
using Hris.Data.DTO;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.Report
{
    public interface IReportServices
    {
        Task<EmployeePayslipInfo> GenerateEmployeePayslip(Guid employeeId, Guid payrollRunId);
    }
    internal class ReportServices : IReportServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatutoriesServices _statutoriesService;
        public ReportServices(IUnitOfWork unitOfWork, IStatutoriesServices statutoriesServices)
        {
            _unitOfWork = unitOfWork;
            _statutoriesService = statutoriesServices;
        }
        public async Task<EmployeePayslipInfo> GenerateEmployeePayslip(Guid employeeId, Guid payrollRunId)
        {
            var data = new EmployeePayslipInfo();

            var employee = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Include(f => f.SalaryHistory)
               // .Include(f => f.EmployeeStatutories)
              //  .ThenInclude(f => f.TaxTable)
                .Where(f => f.Id.Equals(employeeId))
                .FirstOrDefaultAsync();

            if (employee == null) throw new ArgumentNullException(nameof(employee), Resource.Responses.Common.ARGUMENT_NULL_MESSAGE);
            data.Employee = employee.ToBasicEmployeeInfo();

            if (employee.SalaryHistory != null)
            {
                var result_salary = employee.SalaryHistory.OrderByDescending(f => f.EffectivityDate).FirstOrDefault();
                if (result_salary != null)
                {
                    data.EmployeeSalary = new SalaryHistoryDtoResponse
                    {
                        BasePay = result_salary.BasePay,
                        EffectivityDate = result_salary.EffectivityDate,
                        Id = result_salary.Id
                    };
                }
            }

            //if (employee.EmployeeStatutories != null)
            //    data.EmployeeStatutories = employee.EmployeeStatutories.ToEmployeeStatutoriesResponse();

            var result_payrollrun = await _unitOfWork._PayrollRun.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollConfig)
                .Include(f => f.ApprovedBy)
                .Where(f => f.Id.Equals(payrollRunId))
                .FirstOrDefaultAsync();

            if (result_payrollrun != null)
            {
                var generatedBy = await _unitOfWork._Employees.GetDbSet()
                    .AsNoTracking()
                    .Where(f => f.ObjectId.Equals(result_payrollrun.ModifiedBy))
                    .FirstOrDefaultAsync();

                data.PayrollRun = result_payrollrun.ToPayrollRunResponse();
                if (generatedBy != null)
                {
                    data.PayrollRun.GeneratedBy = generatedBy.ToInitialEmployeeResponse_();
                    data.PayrollRun.GeneratedId = generatedBy.Id;
                }
            }

            var result_payrollAllowance = await _unitOfWork._PayrollRunAllowances.GetDbSet()
                .AsNoTracking()
                .Include(f => f.AllowanceType)
                .Where(f => f.EmployeeId.Equals(employeeId) && f.PayrollRunId.Equals(payrollRunId))
                .ToListAsync();
            data.EmployeePayrollRunAllowance = result_payrollAllowance.ToPayrollRunAllowanceResponseList().ToList() ?? null;

            var result_payrollDeductions = await _unitOfWork._PayrollRunDeductions.GetDbSet()
                .AsNoTracking()
                .Include(f => f.DeductionTypes)
                .Where(f => f.EmployeeId.Equals(employeeId) && f.PayrollRunId.Equals(payrollRunId))
                .ToListAsync();
            data.EmployeePayrollRunDeductions = result_payrollDeductions.ToPayrollRunDeductionsResponseList().ToList() ?? null;

            var result_loans = await _unitOfWork._PayrollRunLoans.GetDbSet()
                .AsNoTracking()
                .Include(f => f.LoanTypes)
                .Where(f => f.EmployeeId.Equals(employeeId) && f.PayrollRunId.Equals(payrollRunId))
                .ToListAsync();
            data.EmployeePayrollRunLoans = result_loans.ToPayrollRunDeductionsResponseList().ToList() ?? null;

            var result_timeSheets = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                 .AsNoTracking()
                   .Where(f => f.EmployeeId.Equals(employeeId) && f.PayrollRunId.Equals(payrollRunId))
                   .FirstOrDefaultAsync();
            data.EmployeePayrollRunTimeSheets = result_timeSheets.ToPayrollRunTimeSheetsDtoResponse() ?? null;

            var result_timesheetPay = await _unitOfWork._PayrollRunTimeSheetsPay.GetDbSet()
                .AsNoTracking()
                .Where(f => f.EmployeeId.Equals(employeeId) && f.PayrollRunId.Equals(payrollRunId))
                .FirstOrDefaultAsync();
            data.EmployeePayrollRunTimeSheetsPay = result_timesheetPay.ToPayrollRunTimeSheetsPayDtoResponse() ?? null;

            var result_summaryPay = await _unitOfWork._PayrollRunPaySummary.GetDbSet()
                .AsNoTracking()
                 .Where(f => f.EmployeeId.Equals(employeeId) && f.PayrollRunId.Equals(payrollRunId))
                .FirstOrDefaultAsync();
            data.EmployeePayrollRunPaySummary = result_summaryPay.ToPayrollRunPaySummaryDtoResponse() ?? null;

            var result_leaveEntitlements = await _unitOfWork._LeaveEntitlements.GetDbSet()
                .AsNoTracking()
                .Include(f => f.LeaveType)
                .Where(f => f.EmployeeId.Equals(employeeId))
                .Where(f => f.Year == data.PayrollRun.Year)
                .ToListAsync();

            data.EmployeeLeaveEntitlements = result_leaveEntitlements.ToLeaveEntitlementDtoResponseList().ToList() ?? null;
            data.EmployeeStatutories = await _statutoriesService.ProcessContributionStatutories(data.EmployeeSalary.BasePay);
            return data;
        }
    }
}
