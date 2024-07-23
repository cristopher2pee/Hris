namespace Hris.Api.Models.Response.Setting
{
    public class UserSettingsResponse: BaseResponse
    {
        public Guid? EmployeeId { get; set; }
        public string? ProfileImg { get; set; }
        public string? Timezone { get; set; }
        public string? UITheme { get; set; }
    }
}
