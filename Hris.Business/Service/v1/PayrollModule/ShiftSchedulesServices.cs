using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuestPDF.Helpers.Colors;

namespace Hris.Business.Service.v1.PayrollModule
{
    public interface IShiftSchedulesServices
    {
        Task<PagedResult_<ShiftSchedulesDtoResponse>> GetAll(BaseFilter_ filter);
        Task<IEnumerable<ShiftSchedulesDtoResponse>> GetResources();
        Task<ShiftSchedulesDtoResponse?> GetById(Guid Id);
        Task<ShiftSchedulesDtoResponse?> Add(ShiftSchedulesDtoRequest req, Guid userId);
        Task<ShiftSchedulesDtoResponse?> Update(ShiftSchedulesDtoRequest req, Guid userId);
        Task<bool> Delete(Guid Id, Guid userId);
    }
    internal class ShiftSchedulesServices : IShiftSchedulesServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShiftSchedulesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ShiftSchedulesDtoResponse?> Add(ShiftSchedulesDtoRequest req, Guid userId)
        {
            try
            {
                var result = await _unitOfWork._ShiftSchedules.AddAsync(new Data.Models.Payroll.ShiftSchedule
                {
                    Name = req.Name,
                    TimeIn = req.TimeIn,
                    TimeOut = req.TimeOut,
                    BreakTime = req.BreakTime,
                    RestDays = req.RestDays,
                    Active = true
                });

                return await _unitOfWork.SaveChangeAsync(userId) > 0
                    ? result.ToShiftSchedulesResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Delete(Guid Id, Guid userId)
        {
            try
            {
                var result = await _unitOfWork._ShiftSchedules.GetByIdAsync(Id);
                if (result is null) return false;

                await _unitOfWork._ShiftSchedules.DeleteAsync(result);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResult_<ShiftSchedulesDtoResponse>> GetAll(BaseFilter_ filter)
        {
            var result = await _unitOfWork._ShiftSchedules.GetDbSet()
                .AsNoTracking()
                .Where(f => !string.IsNullOrEmpty(filter.Search)
                    ? f.Name.ToLower().Contains(filter.Search.ToLower()) : true)
                .ToListAsync();

            return result.ToShiftScheduleResponseList()
                .ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<ShiftSchedulesDtoResponse?> GetById(Guid Id)
        {
            var result = await _unitOfWork._ShiftSchedules.GetByIdAsync(Id);
            if (result is null) return null;

            return result.ToShiftSchedulesResponse();
        }

        public async Task<IEnumerable<ShiftSchedulesDtoResponse>> GetResources()
        {
            var result = await _unitOfWork._ShiftSchedules.GetAllAsync();
            return result != null ? result.ToShiftScheduleResponseList()
                : Enumerable.Empty<ShiftSchedulesDtoResponse>();
        }

        public async Task<ShiftSchedulesDtoResponse?> Update(ShiftSchedulesDtoRequest req, Guid userId)
        {
            try
            {
                var result = await _unitOfWork._ShiftSchedules.GetByIdAsync(req.Id);
                if (result is null) return null;

                result.Name = req.Name;
                result.TimeIn = req.TimeIn;
                result.TimeOut = req.TimeOut;
                result.BreakTime = req.BreakTime;
                result.RestDays = req.RestDays;

                await _unitOfWork._ShiftSchedules.UpdateAsync(result);
                return await _unitOfWork.SaveChangeAsync(userId) > 0
                    ? result.ToShiftSchedulesResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
