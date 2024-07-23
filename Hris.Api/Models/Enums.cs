namespace Hris.Api.Models
{
    public class Enums
    {
        public string Name { get; set; } = string.Empty;
        public Dictionary<int,string> Values { get; set; }= new Dictionary<int, string>();
    }
}
