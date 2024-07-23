namespace Hris.Api.Models.Request.Client
{
    public class ClientRequest : BaseRequest
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
    }
}
