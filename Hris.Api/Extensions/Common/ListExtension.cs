namespace Hris.Api.Extensions.Common
{
    public static class ListExtension
    {
        public static string ToString<T>(this List<T> list, string separator = ",")
            => string.Join(separator, list);

    }
}
