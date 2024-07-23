using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using QuestPDF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IEmployeeLoanServices
    {
        Task<EmployeeLoansDtoResponse?> Add(EmployeeLoansDtoRequest req, Guid objId);
        Task<EmployeeLoansDtoResponse?> Update(EmployeeLoansDtoRequest req, Guid objId);
        Task<bool> Delete(Guid Id, Guid objId);
        Task<EmployeeLoansDtoResponse> GetById(Guid Id);
        Task<PagedResult_<EmployeeLoansDtoResponse>> GetAll(EmployeeLoansFilter_ filter);
        Task<bool> isEmployeeLoanExist(Guid employeeId, Guid LoanTypeId);
        Task<bool> isExist(Expression<Func<EmployeeLoans, bool>> predicate);
    }
    internal class EmployeeLoanServices : IEmployeeLoanServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeLoanServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EmployeeLoansDtoResponse?> Add(EmployeeLoansDtoRequest req, Guid objId)
        {
            try
            {


                var result = await _unitOfWork._EmployeeLoans.AddAsync(new Data.Models.Payroll.EmployeeLoans
                {
                    EmployeeId = req.EmployeeId,
                    LoanTypesId = req.LoanTypesId,
                    LoanAmount = req.LoanAmount,
                    Period = req.Period,
                    Months = req.Months,
                    From = req.From,
                    To = req.To,
                    Amortization = req.Amortization,
                    Notes = req.Notes,
                    Status = req.Status,
                    Active = true
                });

                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToEmployeeLoansResponse() : null;
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
                var result = await _unitOfWork._EmployeeLoans.GetByIdAsync(Id);
                await _unitOfWork._EmployeeLoans.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResult_<EmployeeLoansDtoResponse>> GetAll(EmployeeLoansFilter_ filter)
        {
            try
            {
                var result = await _unitOfWork._EmployeeLoans.GetDbSet()
                    .AsNoTracking()
                    .Include(f => f.Employee)
                    .Include(f => f.LoanTypes)
                    .Where(f => filter.LoanTypesIds != null && filter.LoanTypesIds.Any() ? filter.LoanTypesIds.Contains(f.LoanTypesId) : true
                        && (f.Employee.Firstname.ToLower().Contains(filter.Search.ToLower())
                        || f.Employee.Lastname.ToLower().Contains(filter.Search.ToLower())
                        || f.Employee.Middlename.ToLower().Contains(filter.Search.ToLower())))
                    .ToListAsync();

                return result.ToEmployeeLoansResponseList().ToPagedList_(filter.Page, filter.Limit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<EmployeeLoansDtoResponse> GetById(Guid Id)
        {
            var result = await _unitOfWork._EmployeeLoans.GetByIdAsync(Id);
            return result.ToEmployeeLoansResponse();
        }

        public async Task<bool> isEmployeeLoanExist(Guid employeeId, Guid LoanTypeId)
        {
            var isExist = await _unitOfWork._EmployeeLoans.GetDbSet()
                .Where(f => f.EmployeeId.Equals(employeeId) && f.LoanTypesId.Equals(LoanTypeId))
                .AnyAsync();

            return isExist;
        }

        public async Task<bool> isExist(Expression<Func<EmployeeLoans, bool>> predicate)
        {
            return await _unitOfWork._EmployeeLoans.GetDbSet()
                .AsNoTracking()
                .Where(predicate)
                .AnyAsync();
        }

        public async Task<EmployeeLoansDtoResponse?> Update(EmployeeLoansDtoRequest req, Guid objId)
        {
            try
            {
                var result = await _unitOfWork._EmployeeLoans.GetByIdAsync(req.Id);
                result.EmployeeId = req.EmployeeId;
                result.LoanTypesId = req.LoanTypesId;
                result.LoanAmount = req.LoanAmount;
                result.Period = req.Period;
                result.Months = req.Months;
                result.From = req.From;
                result.To = req.To;
                result.Amortization = req.Amortization;
                result.Notes = req.Notes;
                result.Status = req.Status;

                await _unitOfWork._EmployeeLoans.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(objId) > 0 ? result.ToEmployeeLoansResponse() : null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }



        }
    }
}
