using Hris.Business.Models.Common;

namespace Hris.Business.Extensions
{
    public static class PagedResultExtension
    {
        public static PagedResult_<T> ToPagedList_<T>(this IEnumerable<T> query, int page, int limit)
        {
            var result = new PagedResult_<T>(page, limit, query.Count());

            result.Data = query.Skip((page - 1) * limit).Take(limit).ToList();

            return result;
        }

        public static PagedResult_<T> ToListResponse_<T>(this IEnumerable<T> query, int page, int limit)
        {
            var result = new PagedResult_<T>(page, limit, query.Count());
            result.Data = query;
            return result;
        }

        public static PagedResult_<T> ToListResponse_<T>(this IEnumerable<T> query, int page, int limit, int total)
        {
            var result = new PagedResult_<T>(page, limit, total);
            result.Data = query;
            return result;
        }
    }
}
