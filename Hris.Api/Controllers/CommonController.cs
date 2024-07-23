using Hris.Api.Models;
using Hris.Api.Models.Common;
using Hris.Api.Models.Response;
using Hris.Api.Models.Response.Employee;
using Hris.Api.Security;
using Hris.Business.Service.Common;
using Hris.Business.Service.EmployeeModule;
using Hris.Business.Service.PayrollModule;
using Hris.Data.Models.Employee;
using Hris.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Hris.Api.Extensions;
using Hris.Api.Models.Filters;
using Microsoft.EntityFrameworkCore;
using Hris.Api.Middleware;
using Azure;
using Hris.Api.Models.Request.Common;
using Hris.Data.Models.Clock;
using Hris.Business.Service.Clock;
using Hris.Data.Models.Payroll;
using Hris.Api.Utilities;

namespace Hris.Api.Controllers
{
    public class CommonController : BaseController<CommonController>
    {
        private readonly EnumService _enumService;
        private readonly PositionService _positionService;
        private readonly DepartmentService _departmentService;
        private readonly TeamService _teamService;
        private readonly AllowanceTypeService _allowanceTypeService;
        private readonly ClientService _clientService;
        private readonly ProjectService _projectService;
        private readonly AssignedProjectService _apService;
        private readonly StorageCloudService _storageCloudService;
        private readonly EmployeeService _employeeService;
        private readonly ICustomClaimPrincipal _custom;

        public CommonController(EnumService enumService,
                IRepository<Position> positionRepository,
                IRepository<Department> departmentRepository,
                IRepository<Team> teamRepository,
                IRepository<TeamMember> tmRepository,
                IRepository<AllowanceType> allowanceTypeRepository,
                IRepository<Client> clientRepository,
                IRepository<Project> projectRepository,
                IRepository<AssignedProject> apRepository,
                IRepository<Employee> employeeRepository,
                IRepository<ProjectTask> taskRepository,
                ICustomClaimPrincipal custom)
        {
            _enumService = enumService;
            _positionService = new PositionService(positionRepository);
            _departmentService = new DepartmentService(departmentRepository, teamRepository, tmRepository);
            _teamService = new TeamService(teamRepository, tmRepository);
            _allowanceTypeService = new AllowanceTypeService(allowanceTypeRepository);
            _clientService = new ClientService(clientRepository);
            _projectService = new ProjectService(projectRepository, taskRepository, apRepository);
            _apService = new AssignedProjectService(apRepository);
            _employeeService = new EmployeeService(employeeRepository);
            _custom = custom;
        }

        [HrisAuthorize]
        [HttpGet("enumeration")]
        public async Task<IActionResult> GetEnums([FromQuery] string values)
        {
            List<Enums> enums = new List<Enums>();
            if (!string.IsNullOrEmpty(values))
            {
                var enumNames = values.Split(',');

                foreach (var enumName in enumNames) {

                    var enumValues = await _enumService.GetEnumValues(enumName);

                    if (enumValues == null || enumValues.Count > 0)
                        enums.Add(new Enums { Name = enumName, Values = enumValues ?? new Dictionary<int, string>() });
                }
            }

            return HrisOk(enums);
        }

        [HrisAuthorize]
        [HttpGet("resources")]
        public async Task<IActionResult> GetResource()
        {
            var response = new ResourcesResponse();

            response.Status = (await _enumService.GetEnumValues("EMPLOYEESTATUS"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();

            response.Department = (await _departmentService.GetAll())
                 .Select(d => new DropdownValues(d.Id.ToString(), d.Name))
                 .ToList();

            response.Team = (await _teamService.GetAll())
                .Select(t => new DropdownValues(t.Id.ToString(), t.Name))
                .ToList();

            response.Position = (await _positionService.GetAll())
                .Select(p => new DropdownValues(p.Id.ToString(), p.Name))
                .ToList();

            response.Gender = (await _enumService.GetEnumValues("GENDER"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();

            response.CivilStatus = (await _enumService.GetEnumValues("CIVILSTATUS"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();

            response.BloodType = (await _enumService.GetEnumValues("BLOODTYPE"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();

            response.AddressType = (await _enumService.GetEnumValues("ADDRESSTYPE"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();

            response.RelationshipType = (await _enumService.GetEnumValues("RELATIONSHIPTYPE"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();

            response.AllowancePeriod = (await _enumService.GetEnumValues("ALLOWANCE"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();

            response.StatutoryType = (await _enumService.GetEnumValues("STATUTORY"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();

            response.AllowanceType = (await _allowanceTypeService.GetAll())
                 .Select(a => new DropdownValues(a.Id.ToString(), a.Name,
                        new AllowanceTypeResponse {
                            Amount = a.Amount,
                            Id = a.Id,
                            IsDefault = a.IsDefault,
                            Name = a.Name,
                          //  Period = a.Period,
                        }))
                 .ToList();

            response.PositionLevel = (await _enumService.GetEnumValues("POSITIONLEVEL"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();

            response.Clients = (await _clientService.Get())
                .list
                .Select(c => new DropdownValues(c.Id.ToString(), c.Name))
                .ToList();

            response.Modules = (await _enumService.GetEnumValues("MODULES"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();

            response.Roles = (await _enumService.GetEnumValues("ROLES"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();

            response.ChangeStatus = (await _enumService.GetEnumValues("CHANGESTATUS"))
                .Select(e => new DropdownValues(e.Key.ToString(), e.Value))
                .ToList();
            return HrisOk(response);
        }

        [HrisAuthorize]
        [HttpGet("resources/project")]
        public async Task<IActionResult> GetProjectResource()
        {
            var response = new ProjectResourceResponse();
            response.Projects = (await _projectService.GetAll())
                        .Select(p => new DropdownValues(p.Id.ToString(), p.Name, p.Tasks))
                        .ToList();
            return HrisOk(response);
        }

        [HrisAuthorize]
        [HttpGet("resources/track")]
        public async Task<IActionResult> GetTrackResource()
        {
            var response = new TrackingResources();

            try
            {
                var employee = await _employeeService.GetByObjectId(await _custom.GetUserObjectId(User));

                if (employee == null)
                    return HrisError("Resource", "Employee not found.");

                var assignedProjects = (await _apService.GetDbSet())
                    .Include(a => a.Project)
                    .Include(a => a.Task)
                    .Where(a => a.EmployeeId == employee.Id)
                    .AsEnumerable();

                response.Projects = (await _projectService.GetDbSet())
                    .Where(p => assignedProjects.Where(a => a.ProjectId.Equals(p.Id)).Any())
                    .Include(p => p.Tasks)
                    .Select(p => new DropdownValues(p.Id.ToString(), p.Name, p.Tasks != null ? p.Tasks.Where(t => assignedProjects.Any(a => a.TaskId.Equals(t.Id))) : null))
                    .ToList();

                return HrisOk(response);
            }
            catch (Exception ex)
            {
                return HrisError("Exception", ex.Message);
            }
        }

        //ASSIGNPROJECT
        [HrisAuthorize]
        [HttpGet("resources/assignedProject")]
        public async Task<IActionResult> GetAssignProjectResource()
        {
            var response = new AssignProjectResourcesResponse();
            response.Clients = (await _clientService.Get())
                .list
               .Select(c => new DropdownValues(c.Id.ToString(), c.Name))
               .ToList();

            response.Projects = (await _projectService.GetAll())
                .Select(p => new DropdownValues(p.Id.ToString(), p.Name, p.Tasks.Select(p => new DropdownValues(p.Id, p.Name)).ToList()))
                .ToList();

            return HrisOk(response);
        }
    }
}
