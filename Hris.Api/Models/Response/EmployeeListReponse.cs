using Hris.Data.Models.Employee;

namespace Hris.Api.Models.Response
{
    public class EmployeeListReponse
    {
        public IEnumerable<EmployeeResponse> Employees { get; set; }
    }
}
