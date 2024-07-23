using Hris.Data.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class TeamMemberDto
    {
    }

    public class TeamMemberDtoResourcesResponse
    {
        public List<TeamDtoResponse> TeamResources { get; set; } = new List<TeamDtoResponse>();
        public List<DepartmentDtoResponse> DepartmentResources { get; set; } = new List<DepartmentDtoResponse>();
    }

 }
