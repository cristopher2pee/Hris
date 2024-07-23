using EntityFrameworkCore.EncryptColumn.Attribute;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hris.Api.Models.Request.Employee
{
    public class AllowanceEntitlementRequest : BaseRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid AllowanceTypeId { get; set; }
        public decimal Amount { get; set; }
        public PayrollPeriod Period { get; set; }
        public DateTime EffectivityDate { get; set; }
    }
}
