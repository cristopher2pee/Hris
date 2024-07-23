using HarfBuzzSharp;
using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Business.Service.v1.CommonModule;
using Hris.Data.DTO;
using Hris.Data.Extension;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Hris.Resource.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Graph.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IPayrollRunServices
    {
        Task<PagedResult_<PayrollRunDtoResponse>> GetAll(PayrollRunFiler filter);
        Task<PayrollRunDtoResponse> GetById(Guid Id);
        Task<PayrollRunDtoResponse?> Add(PayrollRunDtoRequest req, Guid objId);
        Task<PayrollRunDtoResponse?> Update(PayrollRunDtoRequest req, Guid objId);
        Task<bool> Delete(Guid Id, Guid objId);
        Task<PayrollRunDtoResponse> GetPayrollRun(Expression<Func<PayrollRun, bool>> predicate);
        Task<IEnumerable<PayrollRunDtoResponse>> GetPayrollRunList(Expression<Func<PayrollRun, bool>> predicate);
        Task<PagedResult_<TrackDtoResponse>> GetPayrollTrackDetailsByEmployee(Guid payrollRunId,
            Guid employeeId, BaseFilter_ filter);
        Task<PagedResult_<CalendarDtoResponse>> GetPayrollRunHolidays(Guid payrollRunId, Guid payrollConfigId
            , Guid userId, BaseFilter_ filter);

        Task<PagedResult_<TrackDtoResponse>> GetPayrollRunTracks(Guid payrollRunId, Guid payrollConfigId
            , Guid userId, BaseFilter_ filter);

        Task<PagedResult_<LeaveApplicationDtoResponse>> GetPayrollRunLeaveApplications(Guid payrollRunId, Guid payrollConfigId
            , Guid userId, BaseFilter_ filter);

        Task<PagedResult_<EmployeePayrollRunSettingsInfo>> GetPayrollRunEmployeeSettingsInfo(Guid payrollRunId, Guid payrollConfigId
            , Guid userId, BaseFilter_ filter);

        Task<bool> isExist(Expression<Func<PayrollRun, bool>> predicate);

        Task<PagedResult_<PayrollRunEmployeeVerificationDto>> GetEmployeeVerificationPayrollRun(Guid payrollRunId, Guid payrollConfigId
            , Guid userId, BaseFilter_ filter);

        Task<PagedResult_<PayrollRunEmployeeDtoResponse>> GetEmployeeLoan(Guid payrollRunId, Guid payrollConfigId
            , Guid userId, BaseFilter_ filter);

        Task<PagedResult_<PayrollRunEmployeeDtoResponse>> GetEmployeeAllowance(Guid payrollRunId, Guid payrollConfigId, Guid userId, BaseFilter_ filter);

        Task<PagedResult_<PayrollRunEmployeeDtoResponse>> GetEmployeeDeduction(Guid payrollRunId, Guid payrollConfigId, Guid userId, BaseFilter_ filter);

        Task<PagedResult_<PayrollRunTimeSheetsDtoResponse>> GetPayrollRunTimeSheets(Guid payrollRunId, BaseFilter_ filter);

        Task<bool> ProcessEmployeeLoansByPayrollRun(Guid payrollRunId, Guid payrollConfigId, Guid userId);
        Task<bool> ProcessEmployeeAllowanceByPayrollRun(Guid payrollRunId, Guid payrollConfigId, Guid userId);
        Task<bool> ProcessEmployeeDeductionsByPayrollRun(Guid payrollRunId, Guid payrollConfigId, Guid userId);
        Task<bool> ProcessPayrollRunTimeSheets(Guid payrollRunId, Guid payrollConfigId, Guid userId);
    }
    internal class PayrollRunServices : IPayrollRunServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonServices _commonService;
        public PayrollRunServices(IUnitOfWork unitOfWork, ICommonServices commonServices)
        {
            _unitOfWork = unitOfWork;
            _commonService = commonServices;
        }
        public async Task<PayrollRunDtoResponse?> Add(PayrollRunDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRun.AddAsync(new Data.Models.Payroll.PayrollRun
                {
                    Month = req.Month,
                    Year = req.Year,
                    PayrollCode = req.PayrollCode,
                    PayrollConfigId = req.PayrollConfigId,
                    ApprovedById = req.ApprovedById.HasValue ? req.ApprovedById.Value : null,
                    PayrollRunStatus = req.PayrollRunStatus,
                    Notes = req.Notes,
                    Active = true,
                    IsLocked = req.IsLocked,
                    ApprovedDate = req.ApprovedDate,
                });

                var res = await _unitOfWork.SaveChangeAsync(objId);

                return res > 0 ? new PayrollRunDtoResponse
                {
                    Id = result.Id,
                    Month = result.Month,
                    Year = result.Year,
                    PayrollCode = result.PayrollCode,
                    ApprovedById = result.ApprovedById,
                    GeneratedId = result.ModifiedBy,
                    PayrollRunStatus = result.PayrollRunStatus,
                    PayrollConfigId = result.PayrollConfigId,
                    Notes = result.Notes,
                    IsLocked = result.IsLocked,
                    ApprovedDate = result.ApprovedDate
                } : null;
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
                var result = await _unitOfWork._PayrollRun.GetByIdAsync(Id);
                if (result == null) return false;
                await _unitOfWork._PayrollRun.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResult_<PayrollRunDtoResponse>> GetAll(PayrollRunFiler filter)
        {
            var result = await _unitOfWork._PayrollRun.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollConfig)
                .Include(f => f.ApprovedBy)
                .Where(f => f.PayrollCode.ToLower().Contains(filter.Search)
                 && filter.Year.HasValue ? f.Year == filter.Year.Value : true
                 && filter.Month.HasValue ? f.Month == filter.Month.Value : true)
                .ToListAsync();

            var resultData = result.Select(e =>
            {
                var generatedBy = _unitOfWork._Employees.GetDbSet().FirstOrDefault(f => f.ObjectId.Equals(e.ModifiedBy));
                return new PayrollRunDtoResponse
                {
                    Id = e.Id,
                    Month = e.Month,
                    Year = e.Year,
                    PayrollCode = e.PayrollCode,
                    PayrollConfigId = e.PayrollConfigId,
                    PayrollConfig = e.PayrollConfig != null ? e.PayrollConfig.ToPayrollConfigResponse() : null,
                    ApprovedById = e.ApprovedById,
                    ApprovedBy = e.ApprovedBy != null ? e.ApprovedBy.ToInitialEmployeeResponse_() : null,
                    PayrollRunStatus = e.PayrollRunStatus,
                    GeneratedBy = generatedBy.ToInitialEmployeeResponse_(),
                    GeneratedId = generatedBy.Id,
                    Notes = e.Notes,
                    Active = e.Active,
                    IsLocked = e.IsLocked,
                    ApprovedDate = e.ApprovedDate
                };
            });

            return resultData.ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<PayrollRunDtoResponse> GetById(Guid Id)
        {
            var result = await _unitOfWork._PayrollRun.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollConfig)
                .Include(f => f.ApprovedBy)
                .FirstOrDefaultAsync(f => f.Id.Equals(Id));

            var generatedBy = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.ObjectId.Equals(result.ModifiedBy));

            return new PayrollRunDtoResponse
            {
                Id = result.Id,
                Month = result.Month,
                Year = result.Year,
                PayrollCode = result.PayrollCode,
                PayrollConfigId = result.PayrollConfigId,
                PayrollConfig = result.PayrollConfig != null ? result.PayrollConfig.ToPayrollConfigResponse() : null,
                ApprovedById = result.ApprovedById,
                ApprovedBy = result.ApprovedBy != null ? result.ApprovedBy.ToInitialEmployeeResponse_() : null,
                PayrollRunStatus = result.PayrollRunStatus,
                GeneratedBy = generatedBy.ToInitialEmployeeResponse_(),
                GeneratedId = result.ModifiedBy,
                Notes = result.Notes,
                Active = result.Active,
                IsLocked = result.IsLocked,
                ApprovedDate = result.ApprovedDate
            };
        }

        public async Task<PagedResult_<PayrollRunEmployeeVerificationDto>> GetEmployeeVerificationPayrollRun(Guid payrollRunId, Guid payrollConfigId, Guid userId, BaseFilter_ filter)
        {
            var data = await GetEmployeePayrollRunInfo(payrollRunId, payrollConfigId, userId);
            var list = new List<PayrollRunEmployeeVerificationDto>();

            var payrollConfig = await _unitOfWork._PayrollConfig.GetByIdAsync(payrollConfigId);
            if (payrollConfig == null)
                throw new ArgumentNullException(nameof(payrollConfig), "object result cannot be null.");

            var allowanceType = await _unitOfWork._AllowanceTypes.GetDbSet()
                .AsNoTracking()
                .Where(f => f.IsDefault)
                .ToListAsync();

            foreach (var item in data)
            {
                var error = new List<string>();

                //employee Id
                if (item.Id == Guid.Empty || string.IsNullOrEmpty(item.Code))
                    error.Add("The Employee ID/Code is either null or empty.");

                //Basic Salary
                if (item.Salary is null)
                {
                    error.Add("Base Salary requires reassessment");
                }
                else
                {
                    if (item.Salary.BasePay == 0)
                        error.Add("Base Salary requires reassessment");
                }

                //Allowance

                var employeeAllowance = await _unitOfWork._AllowanceEntitlement.GetDbSet()
                    .AsNoTracking()
                    .Where(f => f.EmployeeId.Equals(item.Id))
                    .Where(f => f.Period.Equals(PayrollPeriod.EveryPayroll) || f.Period.Equals(payrollConfig.Period))
                    .ToListAsync();

                if (employeeAllowance is null)
                    error.Add("Employee Allowance requires reassessment");
                else
                {
                    if (employeeAllowance.Count() < allowanceType.Count)
                        error.Add("Employee Allowance requires reassessment");
                }



                ////Statutory Amount
                //if (item.EmployeeStatutories is null)
                //    error.Add("Contribution requires reassessment");
                //else
                //{
                //    if (item.EmployeeStatutories.SSSER == 0 || item.EmployeeStatutories.SSSEE == 0)
                //        error.Add("SSS contribution requires reassessment.");
                //    if (item.EmployeeStatutories.PHICER == 0 || item.EmployeeStatutories.PHICEE == 0)
                //        error.Add("PhilHealth contribution requires reassessment.");
                //    if (item.EmployeeStatutories.HDMFEE == 0 || item.EmployeeStatutories.HDMFER == 0)
                //        error.Add("PAGIBIG contribution requires reassessment.");

                //    if (item.EmployeeStatutories.TaxTableId is null || item.EmployeeStatutories.TaxTableId == Guid.Empty)
                //        error.Add("TaxCode requires reassessment");
                //}

                if (item.ShiftSchedules is null)
                    error.Add("Shift Schedules requires reassessment");

                if (error.Count > 0)
                {
                    list.Add(new PayrollRunEmployeeVerificationDto
                    {
                        Id = item.Id,
                        Code = item.Code,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        MiddleName = item.MiddleName,
                        Error = error
                    });
                }
            }


            return list.ToPagedList_(filter.Page, filter.Limit);
        }

        private async Task<IEnumerable<EmployeePayrollRunSettingsInfo>> GetEmployeePayrollRunInfo(Guid payrollRunId, Guid payrollConfigId, Guid userId)
        {
            var list = new List<PayrollRunEmployeeSettingsInfo>();

            var employee = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Settings)
                .Where(f => f.ObjectId.Equals(userId))
                .FirstOrDefaultAsync();

            var payrollRun = await _unitOfWork._PayrollRun.GetByIdAsync(payrollRunId);
            if (payrollRun == null)
                throw new ArgumentNullException(nameof(payrollRun), "object result cannot be null.");

            var payrollConfig = await _unitOfWork._PayrollConfig.GetByIdAsync(payrollConfigId);
            if (payrollConfig == null)
                throw new ArgumentNullException(nameof(payrollConfig), "object result cannot be null.");

            var payrollConfigDetails = await _unitOfWork._PayrollConfigDetails.GetDbSet()
                .AsNoTracking()
                .Where(f => f.PayrollConfigId.Equals(payrollConfigId))
                .ToListAsync();
            var employeeIds = payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

            var listOfEmployee = await _unitOfWork._Employees
                .GetDbSet()
                .AsNoTracking()
                .Include(f => f.ShiftSchedule)
                //  .Include(f => f.EmployeeStatutories)
                .Include(f => f.Position)
                .Include(f => f.SalaryHistory)
                .Where(f => employeeIds.Contains(f.Id))
                .OrderBy(f => f.Lastname)
                .ToListAsync();

            //var result = listOfEmployee.Select(e =>
            //{
            //    var result = e.ToEmployeePayrollRunSettingsInfo();

            //    return result;
            //});

            return listOfEmployee.ToEmployeePayrollRunSettingsInfo();
        }

        public async Task<PagedResult_<EmployeePayrollRunSettingsInfo>> GetPayrollRunEmployeeSettingsInfo(Guid payrollRunId, Guid payrollConfigId, Guid userId, BaseFilter_ filter)
        {
            var list = new List<PayrollRunEmployeeSettingsInfo>();

            var employee = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Settings)
                .Where(f => f.ObjectId.Equals(userId))
                .FirstOrDefaultAsync();

            var payrollRun = await _unitOfWork._PayrollRun.GetByIdAsync(payrollRunId);
            if (payrollRun == null)
                throw new ArgumentNullException(nameof(payrollRun), "object result cannot be null.");

            var payrollConfig = await _unitOfWork._PayrollConfig.GetByIdAsync(payrollConfigId);
            if (payrollConfig == null)
                throw new ArgumentNullException(nameof(payrollConfig), "object result cannot be null.");

            var payrollConfigDetails = await _unitOfWork._PayrollConfigDetails.GetDbSet()
                .AsNoTracking()
                .Where(f => f.PayrollConfigId.Equals(payrollConfigId))
                .ToListAsync();
            var employeeIds = payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

            var listOfEmployee = await _unitOfWork._Employees
                .GetDbSet()
                .AsNoTracking()
                .Include(f => f.ShiftSchedule)
                .Include(f => f.Allowances.Where(f => f.Period.Equals(payrollConfig.Period)))
                .ThenInclude(f => f.AllowanceType)
            //    .Include(f => f.EmployeeStatutories)
                .Include(f => f.Position)
                .Include(f => f.SalaryHistory)
                .Where(f => employeeIds.Contains(f.Id))
                .OrderBy(f => f.Lastname)
                .ToListAsync();

            //var result = listOfEmployee.Select(e =>
            //{
            //    var result = e.ToEmployeePayrollRunSettingsInfo();
            //    var taxtable = _unitOfWork._TaxTable.GetDbSet()
            //        .Where(f => result.Salary.BasePay >= f.RangeFrom && result.Salary.BasePay <= f.RangeTo).FirstOrDefault();
            //    result.TaxTable = taxtable.ToTaxTableResponse();
            //    return result;
            //});

            return listOfEmployee.ToEmployeePayrollRunSettingsInfo().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<PagedResult_<CalendarDtoResponse>> GetPayrollRunHolidays(Guid payrollRunId, Guid payrollConfigId, Guid userId, BaseFilter_ filter)
        {
            var payrollData = await GetPayrollRunDetails(payrollRunId, payrollConfigId, userId);
            var employeeIds = payrollData.payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

            var dateStart = new DateTime(payrollData.payrollRun.Year, payrollData.payrollRun.Month, payrollData.payrollConfig.FromDay);
            var dateEnd = new DateTime(payrollData.payrollRun.Year, payrollData.payrollRun.Month, payrollData.payrollConfig.ToDay);

            var calendarHoliday = await _unitOfWork._CalendarEvents.GetDbSet()
                .AsNoTracking()
                .Where(f => f.Date >= dateStart && f.Date <= dateEnd)
                .ToListAsync();

            return calendarHoliday.ToCalendarResponseList_(payrollData.employee.Settings.Timezone)
                .ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<PagedResult_<LeaveApplicationDtoResponse>> GetPayrollRunLeaveApplications(Guid payrollRunId, Guid payrollConfigId, Guid userId, BaseFilter_ filter)
        {
            var returnList = new List<Data.Models.Leave.LeaveApplication>();

            var payrollData = await GetPayrollRunDetails(payrollRunId, payrollConfigId, userId);
            var employeeIds = payrollData.payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

            var dateStart = new DateTime(payrollData.payrollRun.Year, payrollData.payrollRun.Month, payrollData.payrollConfig.FromDay);
            var dateEnd = new DateTime(payrollData.payrollRun.Year, payrollData.payrollRun.Month, payrollData.payrollConfig.ToDay);

            var leaveApplication = await _unitOfWork._LeaveApplication
                .GetDbSet()
                .AsNoTracking()
                .Include(f => f.Employee)
                .Include(f => f.LeaveType)
                .Where(f => employeeIds.Contains(f.EmployeeId))
                .Where(f => f.Status == Data.Models.Enum.LeaveStatus.Applied
                    || f.Status == LeaveStatus.LeadApproved
                    || f.Status == LeaveStatus.ApprovedCancelationRequest
                    || f.Status == LeaveStatus.NonApprovedCancelationRequest)
                .Where(f => f.From.Date >= dateStart.Date && f.From.Date <= dateEnd.Date)
                .ToListAsync();

            return leaveApplication.ToLeaveApplicatinResponseList(payrollData.employee.Settings.Timezone)
                .ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<PagedResult_<TrackDtoResponse>> GetPayrollRunTracks(Guid payrollRunId, Guid payrollConfigId, Guid userId, BaseFilter_ filter)
        {
            var payrollData = await GetPayrollRunDetails(payrollRunId, payrollConfigId, userId);
            var employeeIds = payrollData.payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

            var dateStart = new DateTime(payrollData.payrollRun.Year, payrollData.payrollRun.Month, payrollData.payrollConfig.FromDay);
            var dateEnd = new DateTime(payrollData.payrollRun.Year, payrollData.payrollRun.Month, payrollData.payrollConfig.ToDay);

            var tracks = await _unitOfWork._Track.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Employee)
                .Where(f => employeeIds.Contains(f.EmployeeId))
                .Where(f => f.ChangeStatus == Data.Models.Enum.ChangeStatus.Pending)
                .Where(f => f.Start.Date >= dateStart.Date && f.End.Value.Date <= dateEnd.Date)
                .ToListAsync();

            return tracks.ToTrackDtoResponseList().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<PagedResult_<TrackDtoResponse>> GetPayrollTrackDetailsByEmployee(Guid payrollRunId,
            Guid employeeId, BaseFilter_ filter)
        {
            var payrollRun = await _unitOfWork._PayrollRun.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollConfig)
                .Where(f => f.Id.Equals(payrollRunId))
                .FirstOrDefaultAsync();

            var dateStart = new DateTime(payrollRun.Year, payrollRun.Month, payrollRun.PayrollConfig.FromDay);
            var dateEnd = new DateTime(payrollRun.Year, payrollRun.Month, payrollRun.PayrollConfig.ToDay);

            var tracks = await _unitOfWork._Track.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Employee)
                .Where(f => f.EmployeeId.Equals(employeeId))
                .Where(f => f.Start.Date >= dateStart.Date && f.End.Value.Date <= dateEnd.Date)
                .Where(f => f.Tag.Equals(TrackTag.Office) || f.Tag.Equals(TrackTag.Wfh)
                || f.Tag.Equals(TrackTag.Overtime)
                && f.ParentTrackId == null)
                .ToListAsync();

            return tracks.ToTrackDtoResponseList().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<bool> isExist(Expression<Func<PayrollRun, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRun.GetDbSet()
                .AsNoTracking()
                .Where(predicate)
                .AnyAsync();

            return result;
        }

        public async Task<PayrollRunDtoResponse?> Update(PayrollRunDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._PayrollRun.GetByIdAsync(req.Id);
                if (result is null) throw new ArgumentNullException(nameof(result), "object result cannot be null.");

                result.Month = req.Month;
                result.Year = req.Year;
                result.PayrollCode = req.PayrollCode;
                result.PayrollConfigId = req.PayrollConfigId;
                result.ApprovedById = req.ApprovedById.HasValue ? req.ApprovedById.Value : null;
                result.PayrollRunStatus = req.PayrollRunStatus;
                result.Notes = req.Notes;
                result.Active = req.Active;
                result.IsLocked = req.IsLocked;
                result.ApprovedDate = req.ApprovedDate;

                await _unitOfWork._PayrollRun.UpdateAsync(result);
                var res = await _unitOfWork.SaveChangeAsync(objId);

                return res > 0 ? new PayrollRunDtoResponse
                {
                    Id = result.Id,
                    Month = result.Month,
                    Year = result.Year,
                    PayrollCode = result.PayrollCode,
                    PayrollConfigId = result.PayrollConfigId,
                    ApprovedById = result.ApprovedById.HasValue ? result.ApprovedById.Value : null,
                    GeneratedId = result.ModifiedBy,
                    PayrollRunStatus = result.PayrollRunStatus,
                    Notes = result.Notes,
                    IsLocked = result.IsLocked,
                    ApprovedDate = result.ApprovedDate
                } : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> ProcessEmployeeDeductionsByPayrollRun(Guid payrollRunId, Guid payrollConfigId, Guid userId)
        {
            try
            {
                var payrollData = await GetPayrollRunDetails(payrollRunId, payrollConfigId, userId);
                var employeeIds = payrollData.payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

                foreach (var id in employeeIds)
                {
                    var employeeDeductions = await _unitOfWork._EmployeesDeduction.GetDbSet()
                        .AsNoTracking()
                        .Where(f => f.EmployeeId.Equals(id))
                        .Where(f => f.Period.Equals(PayrollPeriod.EveryPayroll) || f.Period.Equals(payrollData.payrollConfig.Period))
                        .ToListAsync();

                    if (employeeDeductions != null && employeeDeductions.Count != 0)
                    {
                        foreach (var deductions in employeeDeductions)
                        {
                            var isExist = await _unitOfWork._PayrollRunDeductions.GetDbSet()
                                .AsNoTracking()
                                .Where(f => f.EmployeeId.Equals(id) && f.PayrollRunId.Equals(payrollRunId)
                                && f.DeductionTypesId.Equals(deductions.DeductionTypesId))
                                .AnyAsync();

                            if (!isExist)
                            {
                                await _unitOfWork._PayrollRunDeductions.AddAsync(new PayrollRunDeductions
                                {
                                    PayrollRunId = payrollData.payrollRun.Id,
                                    EmployeeId = id,
                                    DeductionTypesId = deductions.DeductionTypesId,
                                    Amount = deductions.Amount,
                                    PayrollPeriod = deductions.Period,
                                    Active = true
                                });
                            }
                            else
                            {
                                var toUpdate = await _unitOfWork._PayrollRunDeductions.GetDbSet()
                                    .AsNoTracking()
                                    .Where(f => f.EmployeeId.Equals(id) && f.PayrollRunId.Equals(payrollRunId)
                                    && f.DeductionTypesId.Equals(deductions.DeductionTypesId))
                                    .FirstOrDefaultAsync();

                                if (toUpdate is null) throw new ArgumentNullException(nameof(toUpdate), "object result cannot be null.");

                                toUpdate.PayrollRunId = payrollData.payrollRun.Id;
                                toUpdate.EmployeeId = id;
                                toUpdate.DeductionTypesId = deductions.DeductionTypesId;
                                toUpdate.Amount = deductions.Amount;
                                toUpdate.PayrollPeriod = deductions.Period;

                                await _unitOfWork._PayrollRunDeductions.UpdateAsync(toUpdate);
                            }
                        }
                    }
                }

                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }
        public async Task<bool> ProcessEmployeeAllowanceByPayrollRun(Guid payrollRunId, Guid payrollConfigId, Guid userId)
        {
            try
            {
                var payrollData = await GetPayrollRunDetails(payrollRunId, payrollConfigId, userId);
                var employeeIds = payrollData.payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

                foreach (var id in employeeIds)
                {
                    var employeeAllowance = await _unitOfWork._AllowanceEntitlement.GetDbSet()
                        .AsNoTracking()
                        .Where(f => f.EmployeeId.Equals(id))
                        .Where(f => f.Period.Equals(PayrollPeriod.EveryPayroll) || f.Period.Equals(payrollData.payrollConfig.Period))
                        .ToListAsync();

                    if (employeeAllowance != null && employeeAllowance.Count != 0)
                    {
                        foreach (var allowance in employeeAllowance)
                        {
                            var isExist = await _unitOfWork._PayrollRunAllowances.GetDbSet()
                                .AsNoTracking()
                                .Where(f => f.EmployeeId.Equals(id) && f.PayrollRunId.Equals(payrollRunId)
                                && f.AllowanceTypeId.Equals(allowance.AllowanceTypeId))
                                .AnyAsync();

                            if (!isExist)
                            {
                                await _unitOfWork._PayrollRunAllowances.AddAsync(new PayrollRunAllowances
                                {
                                    PayrollRunId = payrollData.payrollRun.Id,
                                    EmployeeId = id,
                                    AllowanceTypeId = allowance.AllowanceTypeId,
                                    Amount = allowance.Amount,
                                    PayrollPeriod = allowance.Period,
                                    Active = true
                                });
                            }
                            else
                            {
                                var toUpdate = await _unitOfWork._PayrollRunAllowances.GetDbSet()
                                              .Where(f => f.EmployeeId.Equals(id) && f.PayrollRunId.Equals(payrollRunId)
                                                 && f.AllowanceTypeId.Equals(allowance.AllowanceTypeId))
                                              .FirstOrDefaultAsync();

                                if (toUpdate is null) throw new ArgumentNullException(nameof(toUpdate), "object result cannot be null.");

                                toUpdate.PayrollRunId = payrollData.payrollRun.Id;
                                toUpdate.EmployeeId = id;
                                toUpdate.AllowanceTypeId = allowance.AllowanceTypeId;
                                toUpdate.Amount = allowance.Amount;
                                toUpdate.PayrollPeriod = allowance.Period;

                                await _unitOfWork._PayrollRunAllowances.UpdateAsync(toUpdate);

                            }
                        }
                    }
                }

                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<bool> ProcessEmployeeLoansByPayrollRun(Guid payrollRunId, Guid payrollConfigId, Guid userId)
        {
            try
            {
                var payrollData = await GetPayrollRunDetails(payrollRunId, payrollConfigId, userId);
                var employeeIds = payrollData.payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

                foreach (var item in employeeIds)
                {
                    var employeeLoans = await _unitOfWork._EmployeeLoans.GetDbSet()
                        .AsNoTracking()
                        .Include(f => f.Employee)
                        .Where(f => f.EmployeeId.Equals(item))
                        .Where(f => f.Period.Equals(PayrollPeriod.EveryPayroll) || f.Period.Equals(payrollData.payrollConfig.Period))
                        .Where(f => DateTime.Now.Date >= f.From.Date && DateTime.Now.Date <= f.To.Date)
                        .ToListAsync();

                    if (employeeLoans is not null && employeeLoans.Count != 0)
                    {
                        foreach (var loans in employeeLoans)
                        {
                            var isExist = await _unitOfWork._PayrollRunLoans.GetDbSet()
                                .AsNoTracking()
                                .Where(f => f.EmployeeId.Equals(item) && f.PayrollRunId.Equals(payrollRunId)
                                && f.LoanTypesId.Equals(loans.LoanTypesId))
                                .AnyAsync();

                            if (!isExist)
                            {
                                await _unitOfWork._PayrollRunLoans.AddAsync(new PayrollRunLoans
                                {
                                    PayrollRunId = payrollData.payrollRun.Id,
                                    EmployeeId = item,
                                    LoanTypesId = loans.LoanTypesId,
                                    Amount = loans.Amortization,
                                    PayrollPeriod = loans.Period,
                                    Active = true
                                });
                            }
                            else
                            {
                                var toUpdate = await _unitOfWork._PayrollRunLoans.GetDbSet()
                                    .AsNoTracking()
                                    .Where(f => f.EmployeeId.Equals(item) && f.PayrollRunId.Equals(payrollRunId)
                                    && f.LoanTypesId.Equals(loans.LoanTypesId))
                                    .FirstOrDefaultAsync();

                                if (toUpdate is null) throw new ArgumentNullException(nameof(toUpdate), "object result cannot be null.");

                                toUpdate.PayrollRunId = payrollData.payrollRun.Id;
                                toUpdate.EmployeeId = item;
                                toUpdate.LoanTypesId = loans.LoanTypesId;
                                toUpdate.Amount = loans.Amortization;
                                toUpdate.PayrollPeriod = loans.Period;

                                await _unitOfWork._PayrollRunLoans.UpdateAsync(toUpdate);
                            }

                        }
                    }

                }
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<PagedResult_<PayrollRunEmployeeDtoResponse>> GetEmployeeDeduction(Guid payrollRunId, Guid payrollConfigId, Guid userId, BaseFilter_ filter)
        {
            var listAllowance = new List<PayrollRunEmployeeDtoResponse>();
            var payrollData = await GetPayrollRunDetails(payrollRunId, payrollConfigId, userId);
            var employeeIds = payrollData.payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

            foreach (var id in employeeIds)
            {
                var employeeAllowance = await _unitOfWork._PayrollRunDeductions.GetDbSet()
                    .AsNoTracking()
                    .Include(f => f.Employee)
                    .Where(f => f.PayrollRunId.Equals(payrollRunId) && f.EmployeeId.Equals(id))
                    .ToListAsync();

                if (employeeAllowance != null && employeeAllowance.Count != 0)
                {
                    listAllowance.Add(new PayrollRunEmployeeDtoResponse
                    {
                        EmployeeId = employeeAllowance.First().EmployeeId,
                        TotalAmount = employeeAllowance.Sum(f => f.Amount),
                        Code = employeeAllowance.First().Employee.Code,
                        LastName = employeeAllowance.First().Employee.Lastname,
                        FirstName = employeeAllowance.First().Employee.Firstname,
                        payrollRunId = payrollRunId,

                    });
                };
            }

            return listAllowance.OrderBy(f => f.LastName)
             .ToPagedList_(filter.Page, filter.Limit);
        }
        public async Task<PagedResult_<PayrollRunEmployeeDtoResponse>> GetEmployeeAllowance(Guid payrollRunId, Guid payrollConfigId, Guid userId, BaseFilter_ filter)
        {
            var listAllowance = new List<PayrollRunEmployeeDtoResponse>();
            var payrollData = await GetPayrollRunDetails(payrollRunId, payrollConfigId, userId);
            var employeeIds = payrollData.payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

            foreach (var id in employeeIds)
            {
                var employeeAllowance = await _unitOfWork._PayrollRunAllowances.GetDbSet()
                    .AsNoTracking()
                    .Include(f => f.Employee)
                    .Where(f => f.PayrollRunId.Equals(payrollRunId) && f.EmployeeId.Equals(id))
                    .ToListAsync();

                if (employeeAllowance != null && employeeAllowance.Count != 0)
                {
                    listAllowance.Add(new PayrollRunEmployeeDtoResponse
                    {
                        EmployeeId = employeeAllowance.First().EmployeeId,
                        TotalAmount = employeeAllowance.Sum(f => f.Amount),
                        Code = employeeAllowance.First().Employee.Code,
                        LastName = employeeAllowance.First().Employee.Lastname,
                        FirstName = employeeAllowance.First().Employee.Firstname,
                        payrollRunId = payrollRunId,

                    });
                };
            }

            return listAllowance.OrderBy(f => f.LastName)
             .ToPagedList_(filter.Page, filter.Limit);
        }
        public async Task<PagedResult_<PayrollRunEmployeeDtoResponse>> GetEmployeeLoan(Guid payrollRunId, Guid payrollConfigId, Guid userId, BaseFilter_ filter)
        {
            var listLoanDeduction = new List<PayrollRunEmployeeDtoResponse>();
            var payrollData = await GetPayrollRunDetails(payrollRunId, payrollConfigId, userId);
            var employeeIds = payrollData.payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

            foreach (var item in employeeIds)
            {

                var employeeLoans = await _unitOfWork._PayrollRunLoans.GetDbSet()
                    .AsNoTracking()
                    .Include(f => f.Employee)
                    .Where(f => f.PayrollRunId.Equals(payrollRunId) && f.EmployeeId.Equals(item))
                    .ToListAsync();


                if (employeeLoans != null && employeeLoans.Count != 0)
                {
                    listLoanDeduction.Add(new PayrollRunEmployeeDtoResponse
                    {
                        EmployeeId = employeeLoans.First().EmployeeId,
                        TotalAmount = employeeLoans.Sum(f => f.Amount),
                        Code = employeeLoans.First().Employee.Code,
                        LastName = employeeLoans.First().Employee.Lastname,
                        FirstName = employeeLoans.First().Employee.Firstname,
                        payrollRunId = payrollRunId,
                    });

                }
            }


            return listLoanDeduction.OrderBy(f => f.LastName)
                .ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<PagedResult_<PayrollRunTimeSheetsDtoResponse>> GetPayrollRunTimeSheets(Guid payrollRunId, BaseFilter_ filter)
        {
            var result = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                 .AsNoTracking()
                 .Include(f => f.Employee)
                 .Include(f => f.PayrollRun)
                 .Where(f => f.PayrollRunId.Equals(payrollRunId))
                 .OrderBy(f => f.Employee.Lastname)
                 .ToListAsync();

            return result.ToPayrollRunTimeSheetsDtoResponseList().ToPagedList_(filter.Page, filter.Limit);

        }
        public async Task<bool> ProcessPayrollRunTimeSheets(Guid payrollRunId, Guid payrollConfigId, Guid userId)
        {
            try
            {
                var payrollData = await GetPayrollRunDetails(payrollRunId, payrollConfigId, userId);
                var employeeIds = payrollData.payrollConfigDetails.Select(f => f.EmployeeId).Distinct().ToList();

                var listPayrollRunTimeSheets = new List<PayrollRunTimeSheets>();

                foreach (var ids in employeeIds)
                {
                    var processData = await processPayrollRunTimeSheetsEmployee(payrollData.payrollRun, payrollData.payrollConfig, ids);
                    listPayrollRunTimeSheets.Add(processData);
                }

                foreach (var items in listPayrollRunTimeSheets)
                {

                    if (await IsExistInTimeSheets(items.PayrollRunId, items.EmployeeId))
                    {
                        await processTimeSheetsUpdate(items, userId);
                    }
                    else
                        await _unitOfWork._PayrollRunTimeSheets.AddAsync(items);
                }

                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }

        private async Task<bool> IsExistInTimeSheets(Guid payrollrunId, Guid employeeId)
        {
            return await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                .AsNoTracking()
                .Where(f => f.PayrollRunId.Equals(payrollrunId)
                    && f.EmployeeId.Equals(employeeId))
                .AnyAsync();
        }

        private async Task<bool> processTimeSheetsUpdate(PayrollRunTimeSheets req, Guid objId)
        {
            var result = await _unitOfWork._PayrollRunTimeSheets.GetDbSet()
                       .AsNoTracking()
                       .Where(f => f.PayrollRunId.Equals(req.PayrollRunId)
                        && f.EmployeeId.Equals(req.EmployeeId))
                       .FirstOrDefaultAsync();

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
            //  result.Is13MonthInclude = req.Is13MonthInclude;
            // result.IsLeaveInclude = req.IsLeaveInclude;

            await _unitOfWork._PayrollRunTimeSheets.UpdateAsync(result);
            //  return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            return true;
        }

        private async Task<PayrollRunTimeSheets> processPayrollRunTimeSheetsEmployee(PayrollRun payrollRun,
            PayrollConfig payrollConfig, Guid employeeId)
        {
            PayrollRunTimeSheets result = new();

            var dateStart = new DateTime(payrollRun.Year, payrollRun.Month, payrollConfig.FromDay);
            var dateEnd = new DateTime(payrollRun.Year, payrollRun.Month, payrollConfig.ToDay);

            var employee = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Include(f => f.ShiftSchedule)
                .Where(f => f.Id.Equals(employeeId))
                .FirstOrDefaultAsync();

            var defaultSettings = "Taipei Standard Time";

            if (employee is null) throw new ArgumentNullException(nameof(employee), "object result cannot be null.");

            result.EmployeeId = employee.Id;
            result.PayrollRunId = payrollRun.Id;

            var settings = await _unitOfWork._UserSettings.GetDbSet()
                .AsNoTracking()
                .Where(f => f.EmployeeId.Equals(employee.Id))
                .FirstOrDefaultAsync();

            if (settings is not null)
            {
                defaultSettings = settings.Timezone;
            }

            foreach (var date in _commonService.EachDay(dateStart, dateEnd))
            {
                var holidays = await _unitOfWork._CalendarEvents.GetDbSet()
                    .AsNoTracking().Where(f => f.Date.Date == date.Date)
                    .FirstOrDefaultAsync();

                var employeeTracks = await _unitOfWork._Track.GetDbSet()
                    .AsNoTracking()
                    .Include(f => f.Task)
                    .Where(f => f.Start.Date == date.Date && f.ParentTrackId == null
                        && (f.Task != null ? !f.Task.IsCustom : true) )
                    .OrderBy(f => f.Start.Date)
                    .ToListAsync();

                var isRestDays = employee.ShiftSchedule.RestDays.ToString().Contains(date.DayOfWeek.ToString());
                if (employeeTracks is not null && employeeTracks.Any())
                {
                    var processData = processTrackHours(employeeTracks, defaultSettings!, date);

                    if (holidays != null)
                    {
                        switch (holidays.Type)
                        {
                            case HolidayType.Special:
                                if (isRestDays)
                                {
                                    result.RDOnSH += 1;
                                    result.NSDOnRDOnSH += processData.NSD;
                                    result.OTOnNSDOnRDOnSH += processData.NSD_OT;
                                    result.OTOnRDOnSH += processData.OT;
                                }
                                else
                                {
                                    result.SH += 1;
                                    result.NSDOnSH += processData.NSD;
                                    result.OTOnNSDOnSH += processData.NSD_OT;
                                    result.OTOnSH += processData.OT;

                                }
                                break;
                            case HolidayType.Regular:
                                if (isRestDays)
                                {
                                    result.RDOnRH += 1;
                                    result.NSDOnRDOnRH += processData.NSD;
                                    result.OTOnRDOnRH += processData.OT;
                                    result.OTOnNSDOnRDOnRH += processData.NSD_OT;
                                }
                                else
                                {
                                    result.RH += 1;
                                    result.NSDOnRH += processData.NSD;
                                    result.OTOnRH += processData.OT;
                                    result.OTOnNSDOnRH += processData.NSD_OT;

                                }
                                break;
                            case HolidayType.DoubleSpecial:
                                if (isRestDays)
                                {
                                    result.RDOnDSH += 1;
                                    result.NSDOnRDOnDSH += processData.NSD;
                                    result.OTOnRDOnDSH += processData.OT;
                                    result.OTOnNSDOnRDOnDSH += processData.NSD_OT;
                                }
                                else
                                {
                                    result.DSH += 1;
                                    result.NSDonDSH += processData.NSD;
                                    result.OTOnDSH += processData.OT;
                                    result.OTOnNSDOnDSH += processData.NSD_OT;
                                }
                                break;
                            case HolidayType.DoubleRegular:
                                if (isRestDays)
                                {
                                    result.RDOnDRH += 1;
                                    result.NSDOnRDOnDRH += processData.NSD;
                                    result.OTOnRDOnDRH += processData.OT;
                                    result.OTOnNSDOnRDOnDRH += processData.NSD_OT;
                                }
                                else
                                {
                                    result.DRH += 1;
                                    result.NSDOnDRH += processData.NSD;
                                    result.OTOnDRH += processData.OT;
                                    result.OTOnNSDOnDRH += processData.NSD_OT;

                                }
                                break;

                        };
                    }
                    else
                    {
                        if (isRestDays)
                        {
                            result.RD += processData.Days;
                            result.NSDOnRD += processData.NSD;
                            result.OTOnNSDOnRD += processData.NSD_OT;
                            result.OTOnRD += processData.OT;
                        }
                        else
                        {
                            result.OD += processData.Days;
                            result.ODOnNSD += processData.NSD;
                            result.ODOnOT += processData.OT;
                            result.ODOnOTOnNSD += processData.NSD_OT;
                        }

                    }
                }
                else
                {
                    if (holidays != null)
                    {
                        switch (holidays.Type)
                        {
                            case HolidayType.Regular:
                                if (!isRestDays)
                                    result.RH += 1;
                                break;
                            case HolidayType.DoubleSpecial:
                                if (!isRestDays)
                                    result.DSH += 1;
                                break;
                            case HolidayType.DoubleRegular:
                                if (!isRestDays)
                                    result.DRH += 1;
                                break;
                        }
                    }
                    else
                    {
                        if (!isRestDays)
                        {
                            var leaveApplication = await _unitOfWork._LeaveApplication.GetDbSet()
                                .AsNoTracking()
                                .Where(f => f.From.Date >= dateStart && dateStart <= f.To.Date
                                    && f.EmployeeId.Equals(employeeId)
                                    && f.Status == LeaveStatus.HeadApproved)
                                .AnyAsync();

                            if (!leaveApplication)
                                result.NoPayLeave += 1;
                        }
                    }


                }

            }
            result.Active = true;
            return result;
        }

        private ProcessTrackHoursData processTrackHours(IEnumerable<Data.Models.Clock.Track> employeeTracks, string defaultSettings, DateTime date)
        {
            var result = new ProcessTrackHoursData();
            var noOfDays = employeeTracks.Where(f => f.Tag.Equals(TrackTag.Office)
            || f.Tag.Equals(TrackTag.Wfh) || f.Tag.Equals(TrackTag.PaidLeave)).Any();

            if (noOfDays)
                result.Days++;

            foreach (var track in employeeTracks)
            {
                var startTime = track.Start.ConvertToTimezone_(defaultSettings);
                var endTime = track.End.Value.ConvertToTimezone_(defaultSettings);
                //10pm to 6am NDS
                var ndsStartTime = new TimeSpan(22, 0, 0);
                var nightDiffStart = date.Add(ndsStartTime);

                if (track.Tag.Equals(TrackTag.Office) || track.Tag.Equals(TrackTag.Wfh))
                {

                    if (startTime.TimeOfDay >= nightDiffStart.TimeOfDay)
                    {
                        result.NSD = 8;
                    }
                }
                if (track.Tag.Equals(TrackTag.Overtime))
                {
                    if (endTime.TimeOfDay > nightDiffStart.TimeOfDay)
                    {
                        result.OT += (decimal)nightDiffStart.TimeOfDay.Subtract(startTime.TimeOfDay).TotalHours;
                        result.NSD_OT += (decimal)endTime.TimeOfDay.Subtract(nightDiffStart.TimeOfDay).TotalHours;
                    }
                    else if (endTime.TimeOfDay < nightDiffStart.TimeOfDay)
                    {
                        result.OT += (decimal)(endTime.TimeOfDay - startTime.TimeOfDay).TotalHours;
                    }

                }
            }

            return result;
        }


        private async Task<(Data.Models.Employee.Employee employee, Data.Models.Payroll.PayrollRun payrollRun,
            Data.Models.Payroll.PayrollConfig payrollConfig, List<Data.Models.Payroll.PayrollConfigDetails> payrollConfigDetails)>
            GetPayrollRunDetails(Guid payrollRunId, Guid payrollConfigId, Guid userId)
        {
            var employee = await _unitOfWork._Employees.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Settings)
                .Where(f => f.ObjectId.Equals(userId))
                .FirstOrDefaultAsync();

            var payrollRun = await _unitOfWork._PayrollRun.GetByIdAsync(payrollRunId);
            if (payrollRun == null)
                throw new ArgumentNullException(nameof(payrollRun), "object result cannot be null.");

            var payrollConfig = await _unitOfWork._PayrollConfig.GetByIdAsync(payrollConfigId);
            if (payrollConfig == null)
                throw new ArgumentNullException(nameof(payrollConfig), "object result cannot be null.");

            var payrollConfigDetails = await _unitOfWork._PayrollConfigDetails.GetDbSet()
                .AsNoTracking()
                .Where(f => f.PayrollConfigId.Equals(payrollConfigId))
                .ToListAsync();

            if (payrollConfigDetails is null)
                throw new ArgumentNullException(nameof(payrollConfig), "object result cannot be null.");

            return (employee, payrollRun, payrollConfig, payrollConfigDetails);
        }

        public async Task<PayrollRunDtoResponse> GetPayrollRun(Expression<Func<PayrollRun, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRun.GetDbSet()
                .AsNoTracking()
                .Where(predicate)
                .FirstOrDefaultAsync();

            return result.ToPayrollRunResponse();
        }

        public async Task<IEnumerable<PayrollRunDtoResponse>> GetPayrollRunList(Expression<Func<PayrollRun, bool>> predicate)
        {
            var result = await _unitOfWork._PayrollRun.GetDbSet()
                .AsNoTracking()
                .Include(f => f.PayrollConfig)
                .Where(predicate)
                .ToListAsync();

            return result != null ? result.ToPayrollRunResponseList()
                : Enumerable.Empty<PayrollRunDtoResponse>();
        }
    }
}
