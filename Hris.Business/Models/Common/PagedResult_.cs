using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Models.Common
{
    public class PagedResult_<T>
    {
        public PagedResult_(int page, int limit, int count)
        {
            var lastPage = (int)Math.Ceiling((decimal)count / limit);
            Meta = new PagedMeta
            {
                Page = lastPage <= 0 ? 1 : lastPage < page ? lastPage : page,
                Total = count,
                Limit = limit,
                LastPage = lastPage
            };

        }
        public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();
        public PagedMeta Meta { get; set; }
    }

    public class PagedMeta
    {
        public int Total { get; set; } = 0;
        public int Limit { get; set; } = 10;
        public int Page { get; set; } = 1;
        public int LastPage { get; set; }
    }
}
