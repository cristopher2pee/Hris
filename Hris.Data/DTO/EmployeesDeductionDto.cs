using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    public class EmployeesDeductionDtoRequest : BaseDtoRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid DeductionTypesId { get; set; }
        public decimal Amount { get; set; }
        public PayrollPeriod Period { get; set; }

    }

    public class EmployeesDeductionDtoResponse : BaseDtoResponse
    {
        public Guid EmployeeId { get; set; }
        public EmployeeDtoResponse Employees { get; set; }
        public Guid DeductionTypesId { get; set; }
        public DeductionTypesDtoResponse DeductionTypes { get; set; }
        public decimal Amount { get; set; }
        public PayrollPeriod Period { get; set; }
    }



    public static class EmployeesDeductionExtenstion
    {
        public static EmployeesDeductionDtoResponse ToEmployeesDeductionResponse(this EmployeesDeduction entity)
        {
            return new EmployeesDeductionDtoResponse
            {
                Id= entity.Id,
                EmployeeId = entity.EmployeeId,
                DeductionTypes = entity.DeductionTypes != null 
                    ? entity.DeductionTypes.ToDeductionTypesResponse() : null,
                DeductionTypesId = entity.DeductionTypesId,
                Amount = entity.Amount,
                Period = entity.Period,
            };
        }

        public static IEnumerable<EmployeesDeductionDtoResponse> ToEmployeesDeductionResponseList(this IEnumerable<EmployeesDeduction> entities)
            => entities.Select(e => e.ToEmployeesDeductionResponse());
    }


}

