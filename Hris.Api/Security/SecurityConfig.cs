namespace Hris.Api.Security
{
    public class SecurityConfig
    {
        public string? EncryptionKey { get; set; }
        public string? Name { get; set; }
        public string[]? AllowedHosts { get; set; }
    }
}
