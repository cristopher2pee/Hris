using Hris.Data.Models.Employee;
using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    public class EmployeeStatutoriesDtoRequest : BaseDtoRequest
    {
        public Guid EmployeeId { get; set; }
        public decimal SSSER { get; set; }

        public decimal SSSEE { get; set; }

        public decimal SSSEC { get; set; }

        public decimal PHICER { get; set; }

        public decimal PHICEE { get; set; }

        public decimal HDMFER { get; set; }

        public decimal HDMFEE { get; set; }

        public Guid? TaxTableId { get; set; }
    }

    public class EmployeeStatutoriesDtoResponse : BaseDtoResponse
    {
        public Guid EmployeeId { get; set; }
        public decimal SSSER { get; set; }
        public decimal SSSEE { get; set; }
        public decimal SSSEC { get; set; }
        public decimal PHICER { get; set; }
        public decimal PHICEE { get; set; }
        public decimal HDMFER { get; set; }
        public decimal HDMFEE { get; set; }
        public Guid? TaxTableId { get; set; }
        public TaxTableDtoResponse? TaxTable { get; set; }
    }

    public static class EmployeeStatutoriesExtenstion
    {
        //public static EmployeeStatutoriesDtoResponse ToEmployeeStatutoriesResponse(this EmployeeStatutories entity)
        //{
        //    return new EmployeeStatutoriesDtoResponse
        //    {
        //        EmployeeId = entity.EmployeeId,
        //        SSSER = entity.SSSER,
        //        SSSEE = entity.SSSEE,
        //        SSSEC = entity.SSSEC,
        //        PHICER = entity.PHICER,
        //        PHICEE = entity.PHICEE,
        //        HDMFER = entity.HDMFER,
        //        HDMFEE = entity.HDMFEE,
        //        TaxTableId = entity.TaxTableId,
        //        Id = entity.Id,
        //        Active = entity.Active,
        //        TaxTable = entity.TaxTable != null ? entity.TaxTable.ToTaxTableResponse() : null,
        //    };
        //}

        //public static IEnumerable<EmployeeStatutoriesDtoResponse> ToEmployeeStatutoriesResponseList(this IEnumerable<EmployeeStatutories> entities)
        //    => entities.Select(e => e.ToEmployeeStatutoriesResponse());
    }

}
