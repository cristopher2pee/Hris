using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class SalaryHistoryDto
    {
    }

    public class SalaryHistoryDtoRequest : BaseDtoRequest
    {
        public decimal BasePay { get; set; }
        public DateTime EffectivityDate { get; set; }
    }

    public class SalaryHistoryDtoResponse : BaseDtoResponse
    {
        public decimal BasePay { get; set; }
        public DateTime EffectivityDate { get; set; }
    }
}
