using Hris.Data.Models.Statutory;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    public class StatutoriesTableDto
    {
        public class Calculated_Statutories
        {
            public decimal SSSER { get; set; } = 0.0m;
            public decimal SSSEE { get; set; } = 0.0m;
            public decimal SSSEC { get; set; } = 0.0m;
            public decimal PHICER { get; set; } = 0.0m;
            public decimal PHICEE { get; set; } = 0.0m;
            public decimal HDMFER { get; set; } = 0.0m;
            public decimal HDMFEE { get; set; } = 0.0m;
        }
    }
    public static class HDMFTableDto
    {
        public class HDMF_Response : BaseDtoResponse
        {
            public string Code { get; set; }
            public decimal RangeFrom { get; set; }
            public decimal RangeTo { get; set; }
            public decimal HDMFEE { get; set; }
            public decimal HDMFER { get; set; }
            public decimal HDMFEEMax { get; set; }
            public decimal HDMFERMax { get; set; }
        }
        public class HDMF_Request : BaseDtoRequest
        {
            public string Code { get; set; }
            public decimal RangeFrom { get; set; }
            public decimal RangeTo { get; set; }
            public decimal HDMFEE { get; set; }
            public decimal HDMFER { get; set; }
            public decimal HDMFEEMax { get; set; }
            public decimal HDMFERMax { get; set; }
        }
        public static HDMF_Response ToResponse(this HDMFTable e)
        {
            return new HDMF_Response
            {
                Id = e.Id,
                Code = e.Code,
                RangeFrom = e.RangeFrom,
                RangeTo = e.RangeTo,
                HDMFEE = e.HDMFEE,
                HDMFER = e.HDMFER,
                HDMFEEMax = e.HDMFEEMax,
                HDMFERMax = e.HDMFERMax,
                Active = e.Active,
            };
        }
        public static IEnumerable<HDMF_Response> ToResponseList(this IEnumerable<HDMFTable> e)
            => e.Select(e => e.ToResponse());
    }
    public static class PHICTableDto
    {
        public class PHIC_Response : BaseDtoResponse
        {
            public string Code { get; set; }
            public decimal RangeFrom { get; set; }
            public decimal RangeTo { get; set; }
            public decimal EEShare { get; set; }
            public decimal ERShare { get; set; }
        }

        public class PHIC_Request : BaseDtoRequest
        {
            public string Code { get; set; }
            public decimal RangeFrom { get; set; }
            public decimal RangeTo { get; set; }
            public decimal EEShare { get; set; }
            public decimal ERShare { get; set; }
        }

        public static PHIC_Response ToResponse(this PHICTable e)
        {
            return new PHIC_Response
            {
                Id = e.Id,
                Code = e.Code,
                RangeFrom = e.RangeFrom,
                RangeTo = e.RangeTo,
                EEShare = e.EEShare,
                ERShare = e.ERShare,
                Active = e.Active,
            };
        }

        public static IEnumerable<PHIC_Response> ToResponseList(this IEnumerable<PHICTable> e)
            => e.Select(e => e.ToResponse());
    }
    public static class SSSTableDto
    {
        public class SSS_Response : BaseDtoResponse
        {
            public string Code { get; set; }
            public decimal RangeFrom { get; set; }
            public decimal RangeTo { get; set; }
            public decimal EE { get; set; }
            public decimal ER { get; set; }
            public decimal EC { get; set; }
        }

        public class SSS_Request : BaseDtoRequest
        {
            public string Code { get; set; }
            public decimal RangeFrom { get; set; }
            public decimal RangeTo { get; set; }
            public decimal EE { get; set; }
            public decimal ER { get; set; }
            public decimal EC { get; set; }
        }

        public static SSS_Response ToResponse(this SSSTable e)
        {
            return new SSS_Response
            {
                Id = e.Id,
                Code = e.Code,
                RangeFrom = e.RangeFrom,
                RangeTo = e.RangeTo,
                EE = e.EE,
                ER = e.ER,
                EC = e.EC,
                Active = e.Active,
            };
        }

        public static IEnumerable<SSS_Response> ToResponseList(this IEnumerable<SSSTable> entities)
            => entities.Select(e => e.ToResponse());
    }
}
