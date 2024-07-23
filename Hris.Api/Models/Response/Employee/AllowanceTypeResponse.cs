using Hris.Data.Models.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hris.Api.Models.Response.Employee
{
    public class AllowanceTypeResponse : BaseResponse
    {
        public Decimal Amount { get; set; }
        public string Name { get; set; }

        public PayrollPeriod Period { get; set; }

        public bool IsDefault { get; set; }
    }
}
