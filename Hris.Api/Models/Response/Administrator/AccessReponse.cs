namespace Hris.Api.Models.Response.Administrator
{
    public class AccessReponse : BaseResponse
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Module { get; set; }
        public List<string> Roles { get; set; }
    }
}
