using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class BaseDto
    {
    }

    public class BaseDtoRequest
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
    }

    public class BaseDtoResponse
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
    }
}
