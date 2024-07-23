using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class ResourceDto
    {
    }

    public class ChangeRequestResourcesDtoResponse
    {
        public List<DropdownValuesDto> ChangeStatus { get; set; }
    }

    public class ReportsResourcesDtoResponse
    {
        public IEnumerable<DropdownValuesDto> Employees { get; set; }
        public IEnumerable<DropdownValuesDto> Clients { get; set; }
        public IEnumerable<DropdownValuesDto> DepartmentTemplates { get; set; }
    }
}
