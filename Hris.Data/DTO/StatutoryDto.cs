using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class StatutoryDto
    {
    }

    public class StatutoryDtoRequest : BaseDtoRequest
    {
        public StatutoryType StatutoryType { get; set; }
        public string StatutoryId { get; set; }
    }

    public class StatutoryDtoResponse : BaseDtoRequest
    {
        public StatutoryType StatutoryType { get; set; }
        public string StatutoryId { get; set; }
    }
}
