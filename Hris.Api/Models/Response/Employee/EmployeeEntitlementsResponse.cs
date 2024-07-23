namespace Hris.Api.Models.Response.Employee
{
    public class EmployeeEntitlementsResponse : BaseResponse
    {
        public EmployeeResponse Employee { get; set; }
        public int EntitlementCount { get; set; }
        public List<AllowanceEntitlementResponse>? Entitlements { get; set; }
    }
}
