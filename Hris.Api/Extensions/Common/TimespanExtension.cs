namespace Hris.Api.Extensions.Common
{
    public static class TimespanExtension
    {
        public static string ToFullString(this TimeSpan span)
            => $"{span:hh}:{span:mm}:{span:ss}";

        public static long ToUnixTimestamp(this DateTime dateTime)
            => (long)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;
    }
}
