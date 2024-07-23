using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    //internal class TaxTableDto
    //{
    //}

    public class TaxTableDtoRequest : BaseDtoRequest
    {
        public TaxPeriodType TaxPeriodType { get; set; }
        public string Code { get; set; }
        public decimal RangeFrom { get; set; }
        public decimal RangeTo { get; set; }
        public decimal FixRate { get; set; }
        public decimal TaxRate { get; set; }
        public decimal ExcessOver { get; set; }
    }

    public class TaxTableDtoResponse : BaseDtoResponse
    {
        public TaxPeriodType TaxPeriodType { get; set; }
        public string Code { get; set; }
        public decimal RangeFrom { get; set; }
        public decimal RangeTo { get; set; }
        public decimal FixRate { get; set; }
        public decimal TaxRate { get; set; }
        public decimal ExcessOver { get; set; }
    }

    public static class TaxTableExtension
    {
        public static TaxTableDtoResponse ToTaxTableResponse(this TaxTable e)
        {
            return new TaxTableDtoResponse
            {
                Id = e.Id,
                TaxPeriodType = e.TaxPeriodType,
                Code = e.Code,
                RangeFrom = e.RangeFrom,
                RangeTo = e.RangeTo,
                FixRate = e.FixRate,
                TaxRate = e.TaxRate,
                Active = e.Active,
                ExcessOver = e.ExcessOver,
                
            };
        }

        public static IEnumerable<TaxTableDtoResponse> ToTaxTableRespopnseList(this IEnumerable<TaxTable> e)
        {
            return e.Select(e => e.ToTaxTableResponse());
        }
    }
}
