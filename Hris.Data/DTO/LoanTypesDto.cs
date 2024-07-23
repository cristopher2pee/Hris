using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    public class LoanTypesDtoRequest : BaseDtoRequest
    {
        public string ShortCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class LoanTypesDtoResponse : BaseDtoResponse
    {
        public string ShortCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public static class LoanTypesExtension
    {
        public static LoanTypesDtoResponse ToLoanTypesResponse(this LoanTypes e)
        {
            return new LoanTypesDtoResponse
            {
                Id = e.Id,
                ShortCode = e.ShortCode,
                Name = e.Name,
                Description = e.Description,
                Active = e.Active,
            };
        }

        public static IEnumerable<LoanTypesDtoResponse> ToLoanTypesResponseList(this IEnumerable<LoanTypes> e)
            => e.Select(e => e.ToLoanTypesResponse());
    }
}
