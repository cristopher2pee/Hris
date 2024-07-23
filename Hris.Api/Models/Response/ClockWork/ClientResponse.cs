namespace Hris.Api.Models.Response.ClockWork
{
    public class ClientResponse : BaseResponse
    {
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? ContactPerson { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Contact { get; set; } = string.Empty;
    }
}
