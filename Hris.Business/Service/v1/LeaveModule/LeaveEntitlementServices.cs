using Hris.Data.DTO;
using Hris.Data.Models.Leave;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.LeaveModule
{
    public interface ILeaveEntitlementServices
    {
        Task<IEnumerable<LeaveEntitlementDtoResponse>> GetListLeaveEntitlements(Expression<Func<LeaveEntitlement, bool>> predicate);
        Task<LeaveEntitlementDtoResponse> GetLeaveEntitlement(Expression<Func<LeaveEntitlement, bool>> predicate);
    }


    internal class LeaveEntitlementServices : ILeaveEntitlementServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public LeaveEntitlementServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<LeaveEntitlementDtoResponse> GetLeaveEntitlement(Expression<Func<LeaveEntitlement, bool>> predicate)
        {
            var leaveEntitlements = await _unitOfWork._LeaveEntitlements.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Employee)
                .Include(f => f.LeaveType)
                .Where(predicate)
                .FirstOrDefaultAsync();

            return leaveEntitlements.ToLeaveEntitlementDtoResponse();
        }

        public async Task<IEnumerable<LeaveEntitlementDtoResponse>> GetListLeaveEntitlements(Expression<Func<LeaveEntitlement, bool>> predicate)
        {
            var leaveEntitlements = await _unitOfWork._LeaveEntitlements.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Employee)
                .Include(f => f.LeaveType)
                .Where(predicate)
                .ToListAsync();

            if(leaveEntitlements is null)
                return Enumerable.Empty<LeaveEntitlementDtoResponse>();

            return leaveEntitlements.ToLeaveEntitlementDtoResponseList();
        }
    }
}
