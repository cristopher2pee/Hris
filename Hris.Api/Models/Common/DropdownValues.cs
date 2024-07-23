namespace Hris.Api.Models.Common
{
    public class DropdownValues
    {
        public DropdownValues(string value,string name, Object tag = null)
        {
            this.Value = value;
            this.Name = name;
            this.Tag = tag;
        }

        public DropdownValues(Guid id, string name, Object tag = null)
        {
            this.Value = id.ToString();
            this.Name = name;
            this.Tag = tag;
        }

        public string Name { get; set; }
        public string Value { get; set; }
        public Object? Tag { get; set; }

    }
}
