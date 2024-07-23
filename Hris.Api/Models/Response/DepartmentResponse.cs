namespace Hris.Api.Models.Response
{
    public class DepartmentResponse : BaseResponse
    {
        public string Name { get; set; }
        public Guid ManagerId { get; set; }
        public EmployeeResponse? Manager { get; set; }
        public string ManagerName { get; set; }
        public string TemplateUri { get; set; }
        public string TemplateName { get; set; }
        public List<TeamResponse> Team { get; set; }
    }


    public class TeamResponse : BaseResponse
    {
        public string Name { get; set; }
        public Guid LeadId { get; set; }
        public EmployeeResponse? Lead { get; set; }
        public string LeadName { get; set;}
        public Guid DepartmentId { get; set; }
        public DepartmentResponse? Department { get; set; }
    }
}
