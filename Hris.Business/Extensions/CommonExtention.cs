using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Extensions
{
    public static class CommonExtention
    {
        public static bool Has(this string str, string str1)
            => str.Contains(str1, StringComparison.OrdinalIgnoreCase);
    }
}
