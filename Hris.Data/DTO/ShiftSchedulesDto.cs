using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{

    public class ShiftSchedulesDtoRequest : BaseDtoRequest
    {
        public string Name { get; set; }
        public long TimeIn { get; set; }
        public long TimeOut { get; set; }
        public int BreakTime { get; set; }
        public WeekDays RestDays { get; set; }
    }

    public class ShiftSchedulesDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public long TimeIn { get; set; }
        public long TimeOut { get; set; }
        public int BreakTime { get; set; }
        public WeekDays RestDays { get; set; }
    }

    public static class ShiftSchedulesExtension
    {
        public static ShiftSchedulesDtoResponse ToShiftSchedulesResponse(this ShiftSchedule entity)
        {
            return new ShiftSchedulesDtoResponse
            {
                Name = entity.Name,
                Id = entity.Id,
                Active = entity.Active,
                TimeIn = entity.TimeIn,
                TimeOut = entity.TimeOut,
                BreakTime = entity.BreakTime,
                RestDays = entity.RestDays,
            };
        }

        public static IEnumerable<ShiftSchedulesDtoResponse> ToShiftScheduleResponseList(this IEnumerable<ShiftSchedule> entities)
        {
            return entities.Select(e => e.ToShiftSchedulesResponse());
        }
    }
}
