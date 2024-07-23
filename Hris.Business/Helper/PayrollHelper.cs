using Hris.Business.Service.v1.PayrollModule;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Hris.Resource.PayrollRun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Helper
{
    public interface IPayrollHelper
    {
        PayrollHelper.TimeSheets ProcessTimeSheets(PayrollRunTimeSheetsPay sheetsPay);
        Task<PayrollHelper.BonusType> IsPaymentBonusesCompleted(Guid employeeId, int year, Guid payrollRunId);
        Task<decimal> ProcessLeaveConversion(Guid employeeId, decimal basePay);
        Task<decimal> ProcessThirteenMonthPay(Guid employeeId, Guid payrollId, decimal basePay, decimal currentDeductions);
        Task<PayrollHelper.TaxInformation> ProcessTaxwithHeld(PayrollRunPaySummary summary, bool isFlag13MonthPay, PayrollRun payrollRun);
    }
    public class PayrollHelper : IPayrollHelper
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaxTableServices _taxTableServices;
        public record TimeSheets(decimal TimeSheetsPay, decimal TimeSheetsDeduction);
        public record BonusType(bool ThirteenMonth, bool LeaveConversion);
        public record TaxInformation(decimal TaxAmount,  string TaxCode);

        public PayrollHelper(IUnitOfWork unitOfWork,
            ITaxTableServices taxTableServices)
        {
            _unitOfWork = unitOfWork;
            _taxTableServices = taxTableServices;
        }

        public TimeSheets ProcessTimeSheets(PayrollRunTimeSheetsPay pay)
        {
            var timesheetsPay = 0.0m;
            var timesheetdeductions = 0.0m;

            timesheetsPay += pay.RD;
            timesheetsPay += pay.SH;
            timesheetsPay += pay.RDOnSH;
            timesheetsPay += pay.DSH;
            timesheetsPay += pay.RDOnDSH;
            //public decimal RH { get; set; } //Regular holiday
            timesheetsPay += pay.RH;
            //public decimal RDOnRH { get; set; } //Regular holiday falling on rest day
            timesheetsPay += pay.RDOnRH;
            //public decimal DRH { get; set; } //Double holiday
            timesheetsPay += pay.DRH;
            //public decimal RDOnDRH { get; set; } //Double holiday falling on rest day
            timesheetsPay += pay.RDOnDRH;
            //public decimal ODOnNSD { get; set; } //Ordinary day, night shift
            timesheetsPay += pay.ODOnNSD;
            //public decimal NSDOnRD { get; set; } //Rest day, night shift
            timesheetsPay += pay.NSDOnRD;
            //public decimal NSDOnSH { get; set; } //Special (non-working) day, night shift
            timesheetsPay += pay.NSDOnSH;
            //public decimal NSDOnRDOnSH { get; set; } // Special (non-working) day, rest day, night shift
            timesheetsPay += pay.NSDOnRDOnSH;
            //public decimal NSDOnRDOnDSH { get; set; }//  Double special(non-working) days, rest day, night shift
            timesheetsPay += pay.NSDOnRDOnDSH;
            //public decimal NSDOnRH { get; set; }//Regular holiday, night shift 
            timesheetsPay += pay.NSDOnRH;
            //public decimal NSDOnRDOnRH { get; set; }//Regular holiday, rest day, night shift 
            timesheetsPay += pay.NSDOnRDOnRH;
            //public decimal NSDOnDRH { get; set; }//Double holiday, night shift
            timesheetsPay += pay.NSDOnDRH;
            //public decimal NSDOnRDOnDRH { get; set; }//Double holiday, rest day, night shift
            timesheetsPay += pay.NSDOnRDOnDRH;
            //public decimal ODOnOT { get; set; }//Ordinary day, overtime (OT)
            timesheetsPay += pay.ODOnOT;
            //public decimal OTOnRD { get; set; }//Rest day, OT
            timesheetsPay += pay.OTOnRD;
            //public decimal OTOnSH { get; set; }//Special (non-working), OT
            timesheetsPay += pay.OTOnSH;
            //public decimal OTOnRDOnSH { get; set; }//Special (non-working) day, rest day, OT 
            timesheetsPay += pay.OTOnRDOnSH;
            //public decimal OTOnRDOnDSH { get; set; }//Double special (non-working) days, rest day, OT
            timesheetsPay += pay.OTOnRDOnDSH;
            //public decimal OTOnSHOnRH { get; set; }//Regular holiday, OT 
            timesheetsPay += pay.OTOnRH;
            //public decimal OTOnRDOnRH { get; set; }//Regular holiday, rest day, OT
            timesheetsPay += pay.OTOnRDOnRH;
            //public decimal OTOnDRH { get; set; }//Double holiday, OT
            timesheetsPay += pay.OTOnDRH;
            //public decimal OTOnRDOnDRH { get; set; }//Double holiday, rest day, OT
            timesheetsPay += pay.OTOnRDOnDRH;
            //public decimal ODOnOTOnNSD { get; set; }//Ordinary day, night shift, OT 
            timesheetsPay += pay.ODOnOTOnNSD;
            //public decimal OTOnNSDOnRD { get; set; }//Rest day, night shift, OT 
            timesheetsPay += pay.OTOnNSDOnRD;
            //public decimal OTOnNSDOnSH { get; set; }//Special (non-working) day, night shift, OT
            timesheetsPay += pay.OTOnNSDOnSH;
            //public decimal OTOnNSDOnRDOnSH { get; set; }//Special (non-working) day, rest day, night shift, OT
            timesheetsPay += pay.OTOnNSDOnRDOnSH;
            //public decimal OTOnNSDOnRDOnDSH { get; set; }//Double special (non-working) days, rest day, night shift, OT
            timesheetsPay += pay.OTOnNSDOnRDOnDSH;
            //public decimal OTOnNSDOnRH { get; set; }//Regular holiday, night shift, OT 
            timesheetsPay += pay.OTOnNSDOnRH;
            //public decimal OTOnNSDOnRDOnRH { get; set; }//Reg. holiday, rest day, night shift, OT 
            timesheetsPay += pay.OTOnNSDOnRDOnRH;
            //public decimal OTOnNSDOnDRH { get; set; }//Double holiday, night shift, OT
            timesheetsPay += pay.OTOnNSDOnDRH;
            //public decimal OTOnNSDOnRDOnDRH { get; set; }//Double holiday, rest day, night shift, OT
            timesheetsPay += pay.OTOnNSDOnRDOnDRH;
            //public decimal NSDonDSH { get; set; } //Night Shift Diff on Double Special
            timesheetsPay += pay.NSDonDSH;
            //public decimal OTOonDSH { get; set; } //over time on double special
            timesheetsPay += pay.OTOnDSH;
            //public decimal OTOnNSDOnDSH { get; set; } // overtime, night diff in double special holiday
            timesheetsPay += pay.OTOnNSDOnDSH;

            timesheetdeductions += pay.NoPayLeave;
            timesheetdeductions += pay.Late;

            return new TimeSheets(timesheetsPay, timesheetdeductions);

        }

        public async Task<BonusType> IsPaymentBonusesCompleted(Guid employeeId, int year, Guid payrollRunId)
        {
            var payrollTimeSheets = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollRun)
                .Where(f => f.PayrollRun.Year.Equals(year))
                .Where(f => f.EmployeeId.Equals(employeeId) && f.PayrollRunId != payrollRunId)
                .ToListAsync();

            var thirteenMonth = payrollTimeSheets.Any(f => f.Is13MonthInclude);
            var leaveConversion = payrollTimeSheets.Any(f => f.IsLeaveInclude);

            return new BonusType(thirteenMonth, leaveConversion);
        }

        public async Task<decimal> ProcessLeaveConversion(Guid employeeId, decimal basePay)
        {
            var data = 0.0m;

            var employee = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Where(f => f.Id.Equals(employeeId))
                .FirstOrDefaultAsync();

            var dailyRate = Rates.DailyRate(basePay);

            if (employee == null) throw new ArgumentNullException(nameof(employee), "object result cannot be null.");
            if (employee.EmployeeStatus == Data.Models.Enum.EmployeeStatus.Probationary
                || employee.EmployeeStatus == Data.Models.Enum.EmployeeStatus.PartTime
                || employee.EmployeeStatus == Data.Models.Enum.EmployeeStatus.Project) return data;


            if (employee.EmployeeStatus == Data.Models.Enum.EmployeeStatus.FullTime)
            {
                var emloyeeEntitlements = await _unitOfWork._LeaveEntitlements.GetDbSet()
                    .AsNoTracking()
                    .Where(f => f.EmployeeId.Equals(employee.Id) && f.Year == DateTime.Now.Year - 1)
                    .ToListAsync();

                var balance = emloyeeEntitlements.Sum(f => f.Balance);
                if (balance > 0)
                {
                    if (balance > 10)
                        data = 10 * dailyRate;
                    else
                        data = balance * dailyRate;
                }

            }
            else
            {
                var entitlements = await _unitOfWork._LeaveEntitlements.GetDbSet()
                    .AsNoTracking()
                    .Include(f => f.LeaveType)
                    .Where(f => f.EmployeeId.Equals(employeeId) && f.Year.Equals(DateTime.Now.Year))
                    .Where(f => f.LeaveType.Class == Data.Models.Enum.LeaveClass.Basic)
                    .ToListAsync();

                var sumOfEntitleDays = entitlements.Sum(f => f.LeaveType.EntitledDays);
                var totalMonthsRendered = employee.DateSeparated.Value.Month - Default.FirstMonthOfTheYear.Month;

                var employeeCredits = (sumOfEntitleDays / 12) * totalMonthsRendered;
                var usedLeave = entitlements.Sum(f => f.Used);

                if (usedLeave > 0)
                    data = (usedLeave - employeeCredits) * dailyRate;
                else
                    data = employeeCredits * dailyRate;
            }
            return data;
        }

        public async Task<decimal> ProcessThirteenMonthPay(Guid employeeId, Guid payrollId, decimal basePay, decimal currentDeductions)
        {
            var data = 0.0m;
            var employee = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Where(f => f.Id.Equals(employeeId))
                .FirstOrDefaultAsync();

            int monthOfService = Rates.totalMonths;
            decimal totalDeductions = 0.0m;

            if (employee == null) throw new ArgumentNullException(nameof(employee), "object result cannot be null.");
            if (employee.EmployeeStatus == Data.Models.Enum.EmployeeStatus.Project) return data;

            if (employee.EmployeeStatus == Data.Models.Enum.EmployeeStatus.Resigned)
            {
                if (employee.DateSeparated.Value.Year == DateTime.Now.Year)
                    monthOfService = employee.DateSeparated.Value.Month - Default.FirstMonthOfTheYear.Month;
            }

            //get pay summary of the employee by current year
            var payrollPaySummary = await _unitOfWork._PayrollRunPaySummary.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollRun)
                .Where(f => f.EmployeeId.Equals(employeeId))
                .Where(f => f.PayrollRun.Year.Equals(DateTime.Now.Year))
                .ToListAsync();

            //sum all deductions
            if (payrollPaySummary.Any())
                totalDeductions = payrollPaySummary.Sum(f => f.TimeSheetDeduction);
            totalDeductions += currentDeductions;

            //compute 13month pay
            var total = basePay * monthOfService;
            if (total != 0)
                data = (total - totalDeductions) / 12;

            return data;
        }

        public async Task<TaxInformation> ProcessTaxwithHeld(PayrollRunPaySummary summary, bool isFlag13MonthPay, PayrollRun payrollRun)
        {
            var data = 0.0m;
            string taxCode = string.Empty;
            var thirteenMonthPayExceed = 0.0m;

            if (isFlag13MonthPay)
            {
                if (summary.ThirteenMonthPay >= Default.ThirteenMonthPayMinimum)
                    thirteenMonthPayExceed = summary.ThirteenMonthPay - Default.ThirteenMonthPayMinimum;
            }
            var totalAmount = summary.Basic + summary.TimeSheetsPay + thirteenMonthPayExceed;
            totalAmount = totalAmount - (summary.HDMFEE + summary.PHICEE + summary.SSSEE);

            var tax = await _taxTableServices.GetTaxTable(f => f.TaxPeriodType.Equals(payrollRun.PayrollConfig.TaxTypePeriod) &&
                totalAmount >= f.RangeFrom && totalAmount <= f.RangeTo);

            taxCode = tax is null ? string.Empty : tax.Code;
            data = await _taxTableServices.ComputeTaxWithHeld(payrollRun.PayrollConfig.TaxTypePeriod, totalAmount);
            return new TaxInformation(data, taxCode);
        }
    }
}
