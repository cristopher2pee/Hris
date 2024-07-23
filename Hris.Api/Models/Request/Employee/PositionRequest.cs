using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Request.Employee
{
    public class PositionRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public PositionLevel Level { get; set; }
    }
}
