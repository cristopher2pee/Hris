using Hris.Api.Models.Common;

namespace Hris.Api.Extensions
{
    public static class PagedResultExtension
    {
        public static PagedResult<T> ToPagedList<T>(this IEnumerable<T> query, int page, int limit)
        {
           var result = new PagedResult<T>(page,limit, query.Count());
           
            result.Data = query.Skip((page-1)*limit).Take(limit).ToList();

            return result;
        }

        public static PagedResult<T> ToListResponse<T>(this IEnumerable<T> query, int page, int limit)
        {
            var result = new PagedResult<T>(page, limit, query.Count());
            result.Data = query;
            return result;
        }

        public static PagedResult<T> ToListResponse<T>(this IEnumerable<T> query, int page, int limit, int total)
        {
            var result = new PagedResult<T>(page, limit, total);
            result.Data = query;
            return result;
        }
    }
}
