using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Administrator;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuestPDF.Helpers.Colors;
using Calendar = Hris.Data.Models.Administrator.Calendar;

namespace Hris.Business.Service.v1.AdministratorModule
{
    public interface ICalendarServices
    {
        Task<IEnumerable<CalendarDtoResponse>> GetResources(Guid userId);
        Task<PagedResult_<CalendarDtoResponse>> GetAll(CalendarFilter_ filter, Guid userId);
        Task<IEnumerable<CalendarDtoResponse>> GetByRange(DateTime from, DateTime to, Guid userId);
        Task<CalendarDtoResponse> GetById(Guid id, Guid userId);

        Task<bool> Save(CalendarDtoRequest req, Guid userId);

        Task<bool> Update(CalendarDtoRequest req, Guid userId);
        Task<bool> Remove(Guid id, Guid userId);

        Task<bool> Duplicate(Guid userId);
    }
    internal class CalendarServices : ICalendarServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CalendarServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Duplicate(Guid userId)
        {
            try
            {
                var events = await _unitOfWork._CalendarEvents
                    .GetDbSet()
                    .AsNoTracking()
                    .Where(d => d.Date.Year == DateTime.UtcNow.Year)
                    .ToListAsync();

                foreach (var item in events)
                {
                    var existing = await _unitOfWork._CalendarEvents.FindByConditionAsync(d => d.Name.Equals(item.Name)
                        && d.Date.Year == DateTime.UtcNow.Year + 1);

                    if (existing != null)
                        continue;

                    await _unitOfWork._CalendarEvents.AddAsync(new Calendar
                    {
                        Name = item.Name,
                        Description = item.Description,
                        Date = item.Date.AddYears(1),
                        Type = item.Type
                    });
                }
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResult_<CalendarDtoResponse>> GetAll(CalendarFilter_ filter, Guid userId)
        {
            var employee = await _unitOfWork._Employees.GetDbSet()
                .Include(f => f.Settings)
                .Where(e => e.ObjectId == userId)
                .FirstOrDefaultAsync();

            if (employee is null) throw new ArgumentNullException(nameof(employee), "object result cannot be null.");

            return _unitOfWork._CalendarEvents.GetDbSet()
                .AsEnumerable()
                .Where(d => (filter.Search != null && !string.IsNullOrEmpty(filter.Search) ? d.Name.ToLower().Contains(filter.Search.ToLower()) : true)
                        && (filter.Years != null && filter.Years.Any() ? filter.Years.Any(y => y == d.Date.ConvertToTimezone(employee.Settings.Timezone).Year) : d.Date.ConvertToTimezone(employee.Settings.Timezone).Year == DateTime.UtcNow.Year))
                .ToCalendarResponseList_(employee.Settings.Timezone)
                .ToPagedList_(filter.Page, filter.Limit);

        }

        public async Task<CalendarDtoResponse> GetById(Guid id, Guid userId)
        {
            try
            {
                var employee = await _unitOfWork._Employees
                    .GetDbSet()
                    .Include(f => f.Settings)
                    .FirstOrDefaultAsync(f => f.ObjectId == userId);
                if (employee is null) throw new ArgumentNullException(nameof(employee), "object result cannot be null.");

                var calendar = await _unitOfWork._CalendarEvents.GetByIdAsync(id);
                if (calendar is null) throw new ArgumentNullException(nameof(calendar), "object result cannot be null.");

                return calendar.ToCalendarResponse_(employee.Settings.Timezone);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<CalendarDtoResponse>> GetByRange(DateTime from, DateTime to, Guid userId)
        {
            var employee = await _unitOfWork._Employees.GetDbSet()
                .Include(f => f.Settings)
                .Where(e => e.ObjectId == userId)
                .FirstOrDefaultAsync();

            if (employee is null) throw new ArgumentNullException(nameof(employee), "object result cannot be null.");

            return _unitOfWork._CalendarEvents.GetDbSet()
                .AsEnumerable()
                .Where(d => d.Date >= from.ToUniversalTime() && d.Date <= to.ToUniversalTime())
                .ToCalendarResponseList_(employee.Settings.Timezone);
        }

        public async Task<IEnumerable<CalendarDtoResponse>> GetResources(Guid userId)
        {
            var employee = await _unitOfWork._Employees.GetDbSet()
            .Include(f => f.Settings)
                .Where(e => e.ObjectId == userId)
                .FirstOrDefaultAsync();

            if (employee is null) throw new ArgumentNullException(nameof(employee), "object result cannot be null.");

            return _unitOfWork._CalendarEvents.GetDbSet()
                .AsEnumerable()
                .ToCalendarResponseList_(employee.Settings.Timezone);
        }

        public async Task<bool> Remove(Guid id, Guid userId)
        {
            try
            {
                var entity = await _unitOfWork._CalendarEvents.GetByIdAsync(id);
                if (entity is null) return false;

                await _unitOfWork._CalendarEvents.DeleteAsync(entity);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Save(CalendarDtoRequest req, Guid userId)
        {
            try
            {
                var result = await _unitOfWork._CalendarEvents.AddAsync(new Calendar
                {
                    Name = req.Name,
                    Description = req.Description,
                    Date = req.Date,
                    Type = req.Type
                });
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Update(CalendarDtoRequest req, Guid userId)
        {
            try
            {
                var entity = await _unitOfWork._CalendarEvents.GetByIdAsync(req.Id);
                if (entity is null) return false;

                entity.Id = req.Id;
                entity.Name = req.Name;
                entity.Description = req.Description;
                entity.Date = req.Date;
                entity.Type = req.Type;

                await _unitOfWork._CalendarEvents.UpdateAsync(entity);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
