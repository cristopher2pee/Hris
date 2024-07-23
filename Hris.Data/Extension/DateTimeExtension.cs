using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hris.Data.Extension
{
    public static class DateTimeExtension_
    {
        public static DateTime ConvertToTimezone_(this DateTime utcTime, string timeZone = "China Standard Time")
        {
            var toUtcOffset = TimeZoneInfo.FindSystemTimeZoneById(timeZone).GetUtcOffset(utcTime);
            var convertedTime = DateTime.SpecifyKind(utcTime.Add(toUtcOffset), DateTimeKind.Unspecified);
            var offset = new DateTimeOffset(convertedTime, toUtcOffset);
            return offset.DateTime;
        }

        public static DateTime GetUTCFromTimezone(this DateTime dt, string tz)
        {
            var tmOffset = TimeZoneInfo.FindSystemTimeZoneById(tz).GetUtcOffset(DateTime.UtcNow);
            return new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, tmOffset).UtcDateTime;
        }

        public static string ToFullString_(this TimeSpan span)
            => $"{span:hh}:{span:mm}:{span:ss}";
        public static long ToUnixTimestamp_(this DateTime dateTime)
            => (long)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;
    }
}
