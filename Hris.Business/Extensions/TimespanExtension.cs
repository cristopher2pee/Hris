using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Extensions
{
    public static class TimespanExtension
    {

        public static string ToTrackFormat(this TimeSpan span)
            => $"{span:hh}:{span:mm}:{span:ss}";

        public static long ToUnix(this DateTime dateTime)
            => (long)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;
    }
}
