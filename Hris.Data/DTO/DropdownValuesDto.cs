using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    public class DropdownValuesDto
    {
        public DropdownValuesDto(string value, string name, Object tag = null)
        {
            this.Name = name;
            this.Value = value;
            this.Tag = tag;
        }

        public DropdownValuesDto(Guid id, string name, Object tag = null)
        {
            this.Value = id.ToString();
            this.Value = name;
            this.Tag = tag;
        }


        public string Name { get; set; }
        public string Value { get; set; }
        public Object? Tag { get; set; }

    }
}
