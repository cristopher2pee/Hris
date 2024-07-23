using Hris.Business.Service.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Enum;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.CommonModule
{
    public interface ICommonServices
    {
        Task<IEnumerable<DropdownValuesDto>?> GetTeamByDepartmentDropDown(Guid departmentId);
        Task<ChangeRequestResourcesDtoResponse?> GetChangeStatusDropDown();
        Task<ReportsResourcesDtoResponse?> GetReportsResources();
        Task<IEnumerable<DropdownValuesDto>> GetProjectsByClients(string ids);
        Task<bool> IsHolidayOrWeekend(DateTime date);
        Task<List<Guid>> GetEmployeeIdsByDepartment(List<Guid> deparmentIds);
        Task<List<Guid>> GetEmployeeIdsByTeam(List<Guid> TeamIds);

        IEnumerable<DateTime> EachDay(DateTime from, DateTime thru);
    }
    internal class CommonServices : ICommonServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EnumService _enumService;
        public CommonServices(IUnitOfWork unitOfWork, EnumService enumService)
        {
            _unitOfWork = unitOfWork;
            _enumService = enumService;
        }

        public async Task<ChangeRequestResourcesDtoResponse?> GetChangeStatusDropDown()
        {
            var response = new ChangeRequestResourcesDtoResponse();
            var result = _enumService.GetEnumValues("CHANGESTATUS").Result
                 .Select(e => new DropdownValuesDto(e.Key.ToString(), e.Value))
                 .ToList();

            response.ChangeStatus = result;
            return response;
        }

        public async Task<IEnumerable<DropdownValuesDto>> GetProjectsByClients(string ids)
        {
            var listIds = new List<string>(ids.Split(','));
            var result = _unitOfWork._Project.GetDbSet()
                 .Include(f => f.Tasks)
                 .AsEnumerable()
                 .Where(p => listIds.Any(id => string.Equals(id, p.ClientId.ToString())))
                 .Select(p => new DropdownValuesDto(p.Id, p.Name, p.Tasks.ToList()
                 .Select(t => new DropdownValuesDto(t.Id, t.Name)).ToList()))
                 .ToList();

            return result;
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public async Task<ReportsResourcesDtoResponse?> GetReportsResources()
        {
            var result = new ReportsResourcesDtoResponse();
            var employess = await _unitOfWork._Employees.GetAllAsync();
            var clients = await _unitOfWork._Client.GetAllAsync();
            var departmentTemplate = await _unitOfWork._Department.GetAllAsync();

            if (employess != null && employess.Any())
                result.Employees = employess.Select(e => new DropdownValuesDto(e.Id, $"{e.Lastname}, {e.Firstname}"
                    + (!string.IsNullOrEmpty(e.Middlename) ? $" {e.Middlename[0]}." : string.Empty)));

            if (clients != null && clients.Any())
                result.Clients = clients.Select(c => new DropdownValuesDto(c.Id.ToString(), c.Name));

            if (departmentTemplate != null && departmentTemplate.Any())
                result.DepartmentTemplates = departmentTemplate.Where(f => f.TemplateUri != null)
                    .Select(d => new DropdownValuesDto(d.Id.ToString(), d.Name, d.TemplateUri));

            return result;
        }

        public async Task<IEnumerable<DropdownValuesDto>?> GetTeamByDepartmentDropDown(Guid departmentId)
        {
            var existingDepartment = await _unitOfWork._Department.GetDbSet()
                 .Include(e => e.Manager)
                 .Include(e => e.Teams)
                 .Where(e => e.Id.Equals(departmentId))
                 .FirstOrDefaultAsync();

            if (existingDepartment is null) return null;
            return existingDepartment.Teams.Select(e => new DropdownValuesDto(e.Id, e.Name)).ToList();

        }

        public async Task<List<Guid>> GetEmployeeIdsByDepartment(List<Guid> deparmentIds)
        {
            var result = await _unitOfWork._TeamMember.GetDbSet()
                .AsNoTracking()
                .Where(f => deparmentIds.Contains(f.DepartmentId))
                .ToListAsync();

            return result.Select(r => r.EmployeeId).Distinct().ToList();
        }

        public async Task<List<Guid>> GetEmployeeIdsByTeam(List<Guid> TeamIds)
        {
            var result = await _unitOfWork._TeamMember.GetDbSet()
                .AsNoTracking()
                .Include(f => f.Team)
                .Where(f => TeamIds.Contains(f.Team.Id))
                .ToListAsync();

            return result.Select(r => r.EmployeeId).Distinct().ToList();
        }

        public async Task<bool> IsHolidayOrWeekend(DateTime date)
        {
            var holidays = await _unitOfWork._CalendarEvents.GetDbSet()
                .Where(f => f.Date.Date == date.Date.Date && f.Type == HolidayType.Regular)
                .ToListAsync();

            if ((holidays != null && holidays.Any()) || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return true;
            else
                return false;
        }
    }
}
