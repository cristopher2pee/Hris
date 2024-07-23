namespace Hris.Api.Extensions
{
    public static class CommonExtension
    {
        public static bool Has(this string str, string str1)
            => str.Contains(str1, StringComparison.OrdinalIgnoreCase); 
    }
}
