namespace Hris.Api.Models.Request.Administrator
{
    public class AccessRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Module { get; set; }
        public List<string> Roles { get; set; }
    }
}
