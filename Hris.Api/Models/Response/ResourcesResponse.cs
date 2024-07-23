using Hris.Api.Models.Common;
using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response
{
    public class ResourcesResponse
    {
        public List<DropdownValues> Status { get; set; }
        public List<DropdownValues> Department { get; set; }
        public List<DropdownValues> Team { get; set; }
        public List<DropdownValues> Position { get; set; }
        public List<DropdownValues> Gender { get; set; }
        public List<DropdownValues> CivilStatus { get; set; }
        public List<DropdownValues> BloodType { get; set; }
        public List<DropdownValues> AddressType { get; set; }
        public List<DropdownValues> RelationshipType { get; set; }
        public List<DropdownValues> AllowanceType { get; set; }
        public List<DropdownValues> AllowancePeriod { get; set; }
        public List<DropdownValues> StatutoryType { get; set; }
        public List<DropdownValues> PositionLevel { get; set; }
        public List<DropdownValues> Clients { get; set; }
        public List<DropdownValues> Modules { get; set; }
        public List<DropdownValues> Roles { get; set; }
        public List<DropdownValues> ChangeStatus { get; set; }


        public ResourcesResponse()
        {
            this.Status = new List<DropdownValues>();
            this.Department = new List<DropdownValues>();
            this.Team = new List<DropdownValues>();
            this.Position = new List<DropdownValues>();
        }
    }

    public class ProjectResourceResponse
    {
        public List<DropdownValues> Projects { get; set; }
        public ProjectResourceResponse()
        {
            Projects = new List<DropdownValues>();
        }
    }

    public class TrackingResources
    {
        public List<DropdownValues> Projects { get; set; }
        public TrackingResources()
        {
            Projects = new List<DropdownValues>();
        }
    }

    public class AssignProjectResourcesResponse
    {
        public List<DropdownValues> Clients { get; set; }
        public List<DropdownValues> Projects { get; set; }
        //public List<DropdownValues> Task { get; set; }

        public AssignProjectResourcesResponse()
        {
            Clients = new List<DropdownValues>();
            Projects = new List<DropdownValues>();   
        }
    }

    public class ChangeRequestResourcesResponse
    {
        public List<DropdownValues> ChangeStatus { get; set; }
    }

    public class ReportsResourcesResponse
    {
        public IEnumerable<DropdownValues> Employees { get; set; }
        public IEnumerable<DropdownValues> Clients { get; set; }
        public IEnumerable<DropdownValues> DepartmentTemplates { get; set; }
    }
}
