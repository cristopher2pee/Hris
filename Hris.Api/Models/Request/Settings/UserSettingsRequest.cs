namespace Hris.Api.Models.Request.Settings
{
    public class UserSettingsRequest: BaseRequest
    {
        public Guid EmployeeId { get; set; }
        public string? ProfileImg { get; set; }
        public string? Timezone { get; set; }
        public string? UITheme { get; set; }
    }
}
