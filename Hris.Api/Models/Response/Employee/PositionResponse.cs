using Hris.Data.Models.Enum;

namespace Hris.Api.Models.Response.Employee
{
    public class PositionResponse : BaseResponse
    {
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public PositionLevel Level { get; set; }
    }
}
