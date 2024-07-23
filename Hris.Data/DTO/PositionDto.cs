using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class PositionDto
    {
    }

    public class PositionDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public PositionLevel Level { get; set; }
    }

    public class PositionDtoRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public PositionLevel Level { get; set; }
    }

    public static class PositionExtension_
    {
        public static PositionDtoResponse ToPisitionResponse(this Position d)
                        => new PositionDtoResponse
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Level = d.Level,
                            JobDescription = d.JobDescription
                        };

        public static IEnumerable<PositionDtoResponse> ToPositionList(this IEnumerable<Position> list)
            => list.Select(d => d.ToPisitionResponse());
    }
}
