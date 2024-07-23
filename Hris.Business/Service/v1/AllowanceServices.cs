using Hris.Business.Extensions;
using Hris.Data.DTO;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using Hris.Data.UnitOfWork;
using Microsoft.Graph.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Hris.Business.Service.v1
{
    public interface IAllowanceServices
    {
        Task<IEnumerable<AllowanceType>> GetTypeResource(string? search);
        Task<(IEnumerable<AllowanceType> list, int total)> GetType(int? page = null, int? limit = null, string? search = null, PayrollPeriod? period = null);
        Task<AllowanceType> GetTypeById(Guid id);
        Task<AllowanceType?> SaveAllowanceType(AllowanceTypeDtoRequest req, Guid userId);
        Task<AllowanceType?> UpdateAllowanceType(AllowanceTypeDtoRequest req, Guid userId);
        Task<AllowanceType?> RemoveAllowanceType(Guid id, Guid userId);
    }
    internal class AllowanceServices : IAllowanceServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public AllowanceServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AllowanceType>> GetTypeResource(string? search)
        => string.IsNullOrEmpty(search) ? await _unitOfWork._AllowanceTypes.GetAllAsync()
            : await _unitOfWork._AllowanceTypes.FindListByConditionAsync(d => d.Name.ToLower().Contains(search.ToLower()));

        public async Task<(IEnumerable<AllowanceType> list, int total)> GetType(int? page = null, int? limit = null, string? search = null, PayrollPeriod? period = null)
        {
            var q = _unitOfWork._AllowanceTypes.GetDbSet()
                .AsEnumerable()
                .Where(d => d.Active)
                .Where(d => (!search.IsNullOrEmpty() ? d.Name.Has(search) : true)
                   );

            return (!page.HasValue && !limit.HasValue ? q :
                        q.Skip((page.Value - 1) * limit.Value)
                            .Take(limit.Value), q.Count());
        }

        public async Task<AllowanceType> GetTypeById(Guid id)
                => await _unitOfWork._AllowanceTypes.GetByIdAsync(id);

        public async Task<AllowanceType?> SaveAllowanceType(AllowanceTypeDtoRequest req, Guid userId)
        {
            try
            {
                var toAdd = await _unitOfWork._AllowanceTypes.AddAsync(new AllowanceType
                {
                    Name = req.Name,
                    Amount = req.Amount,
                    //Period = req.Period,
                    IsDefault = req.IsDefault,
                    Active = true
                });
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toAdd : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<AllowanceType?> UpdateAllowanceType(AllowanceTypeDtoRequest req, Guid userId)
        {
            try
            {
                var toUpdate = await GetTypeById(req.Id);
                if (toUpdate is null) throw new ArgumentNullException(nameof(toUpdate), "object result cannot be null.");

                toUpdate.Name = req.Name;
                toUpdate.Amount = req.Amount;
                // toUpdate.Period = req.Period;
                toUpdate.IsDefault = req.IsDefault;

                await _unitOfWork._AllowanceTypes.UpdateAsync(toUpdate);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toUpdate : null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<AllowanceType?> RemoveAllowanceType(Guid id, Guid userId)
        {
            try
            {
                var toDelete = await GetTypeById(id);
                if (toDelete is null) throw new ArgumentNullException(nameof(toDelete), "object result cannot be null.");

                await _unitOfWork._AllowanceTypes.DeleteAsync(toDelete);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toDelete : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
