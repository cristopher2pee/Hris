using System.ComponentModel.DataAnnotations;

namespace Hris.Api.Models.Filters
{
    public class BaseFilter
    {
        [Range(1, int.MaxValue, ErrorMessage = "Current Page must be a positive number larger or equal to 1")]
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 50;
        public string Search { get; set; } = string.Empty;
    }
}
