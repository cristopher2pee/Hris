using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ConvertToTimezone(this DateTime utcTime, string timeZone = "China Standard Time")
        {
            var toUtcOffset = TimeZoneInfo.FindSystemTimeZoneById(timeZone).GetUtcOffset(utcTime);
            var convertedTime = DateTime.SpecifyKind(utcTime.Add(toUtcOffset), DateTimeKind.Unspecified);
            var offset = new DateTimeOffset(convertedTime, toUtcOffset);
            return offset.DateTime;
        }
    }
}
