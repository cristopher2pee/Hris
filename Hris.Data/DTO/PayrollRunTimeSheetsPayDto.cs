using Hris.Data.Models.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class PayrollRunTimeSheetsPayDto
    {
    }

    public class PayrollRunTimeSheetsPayDtoResponse:BaseDtoResponse
    {
        public Guid PayrollRunId { get; set; }
        public PayrollRunDtoResponse? PayrollRun { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeBasicInfoDtoResponse? Employee { get; set; }
        public decimal OD { get; set; } // Ordinary days 
        public decimal RD { get; set; } // rest days 
        public decimal SH { get; set; } // Special (non-working) day
        public decimal RDOnSH { get; set; } // Special (non-working) day falling on rest day
        public decimal DSH { get; set; } //Double special (non-working) days
        public decimal RDOnDSH { get; set; } //Double special (non-working) days falling on rest day
        public decimal RH { get; set; } //Regular holiday
        public decimal RDOnRH { get; set; } //Regular holiday falling on rest day
        public decimal DRH { get; set; } //Double holiday
        public decimal RDOnDRH { get; set; } //Double holiday falling on rest day
        public decimal ODOnNSD { get; set; } //Ordinary day, night shift
        public decimal NSDOnRD { get; set; } //Rest day, night shift
        public decimal NSDOnSH { get; set; } //Special (non-working) day, night shift
        public decimal NSDOnRDOnSH { get; set; } // Special (non-working) day, rest day, night shift
        public decimal NSDOnRDOnDSH { get; set; }//  Double special(non-working) days, rest day, night shift
        public decimal NSDOnRH { get; set; }//Regular holiday, night shift 
        public decimal NSDOnRDOnRH { get; set; }//Regular holiday, rest day, night shift 
        public decimal NSDOnDRH { get; set; }//Double holiday, night shift
        public decimal NSDOnRDOnDRH { get; set; }//Double holiday, rest day, night shift
        public decimal ODOnOT { get; set; }//Ordinary day, overtime (OT)
        public decimal OTOnRD { get; set; }//Rest day, OT
        public decimal OTOnSH { get; set; }//Special (non-working), OT
        public decimal OTOnRDOnSH { get; set; }//Special (non-working) day, rest day, OT 
        public decimal OTOnRDOnDSH { get; set; }//Double special (non-working) days, rest day, OT
        public decimal OTOnRH { get; set; }//Regular holiday, OT 
        public decimal OTOnRDOnRH { get; set; }//Regular holiday, rest day, OT
        public decimal OTOnDRH { get; set; }//Double holiday, OT
        public decimal OTOnRDOnDRH { get; set; }//Double holiday, rest day, OT
        public decimal ODOnOTOnNSD { get; set; }//Ordinary day, night shift, OT 
        public decimal OTOnNSDOnRD { get; set; }//Rest day, night shift, OT 
        public decimal OTOnNSDOnSH { get; set; }//Special (non-working) day, night shift, OT
        public decimal OTOnNSDOnRDOnSH { get; set; }//Special (non-working) day, rest day, night shift, OT
        public decimal OTOnNSDOnRDOnDSH { get; set; }//Double special (non-working) days, rest day, night shift, OT
        public decimal OTOnNSDOnRH { get; set; }//Regular holiday, night shift, OT 
        public decimal OTOnNSDOnRDOnRH { get; set; }//Reg. holiday, rest day, night shift, OT 
        public decimal OTOnNSDOnDRH { get; set; }//Double holiday, night shift, OT
        public decimal OTOnNSDOnRDOnDRH { get; set; }//Double holiday, rest day, night shift, OT
        public decimal NoPayLeave { get; set; }//Leave Without Pay
        public decimal Late { get; set; }//Late
        public decimal NSDonDSH { get; set; } //Night Shift Diff on Double Special
        public decimal OTOnDSH { get; set; } //over time on double special
        public decimal OTOnNSDOnDSH { get; set; } // overtime, night diff in double special holiday

    }
    public class PayrollRunTimeSheetsPayDtoRequest : BaseDtoRequest
    {
        public Guid PayrollRunId { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal OD { get; set; } // Ordinary days 
        public decimal RD { get; set; } // rest days 
        public decimal SH { get; set; } // Special (non-working) day
        public decimal RDOnSH { get; set; } // Special (non-working) day falling on rest day
        public decimal DSH { get; set; } //Double special (non-working) days
        public decimal RDOnDSH { get; set; } //Double special (non-working) days falling on rest day
        public decimal RH { get; set; } //Regular holiday
        public decimal RDOnRH { get; set; } //Regular holiday falling on rest day
        public decimal DRH { get; set; } //Double holiday
        public decimal RDOnDRH { get; set; } //Double holiday falling on rest day
        public decimal ODOnNSD { get; set; } //Ordinary day, night shift
        public decimal NSDOnRD { get; set; } //Rest day, night shift
        public decimal NSDOnSH { get; set; } //Special (non-working) day, night shift
        public decimal NSDOnRDOnSH { get; set; } // Special (non-working) day, rest day, night shift
        public decimal NSDOnRDOnDSH { get; set; }//  Double special(non-working) days, rest day, night shift
        public decimal NSDOnRH { get; set; }//Regular holiday, night shift 
        public decimal NSDOnRDOnRH { get; set; }//Regular holiday, rest day, night shift 
        public decimal NSDOnDRH { get; set; }//Double holiday, night shift
        public decimal NSDOnRDOnDRH { get; set; }//Double holiday, rest day, night shift
        public decimal ODOnOT { get; set; }//Ordinary day, overtime (OT)
        public decimal OTOnRD { get; set; }//Rest day, OT
        public decimal OTOnSH { get; set; }//Special (non-working), OT
        public decimal OTOnRDOnSH { get; set; }//Special (non-working) day, rest day, OT 
        public decimal OTOnRDOnDSH { get; set; }//Double special (non-working) days, rest day, OT
        public decimal OTOnSHOnRH { get; set; }//Regular holiday, OT 
        public decimal OTOnRDOnRH { get; set; }//Regular holiday, rest day, OT
        public decimal OTOnDRH { get; set; }//Double holiday, OT
        public decimal OTOnRDOnDRH { get; set; }//Double holiday, rest day, OT
        public decimal ODOnOTOnNSD { get; set; }//Ordinary day, night shift, OT 
        public decimal OTOnNSDOnRD { get; set; }//Rest day, night shift, OT 
        public decimal OTOnNSDOnSH { get; set; }//Special (non-working) day, night shift, OT
        public decimal OTOnNSDOnRDOnSH { get; set; }//Special (non-working) day, rest day, night shift, OT
        public decimal OTOnNSDOnRDOnDSH { get; set; }//Double special (non-working) days, rest day, night shift, OT
        public decimal OTOnNSDOnRH { get; set; }//Regular holiday, night shift, OT 
        public decimal OTOnNSDOnRDOnRH { get; set; }//Reg. holiday, rest day, night shift, OT 
        public decimal OTOnNSDOnDRH { get; set; }//Double holiday, night shift, OT
        public decimal OTOnNSDOnRDOnDRH { get; set; }//Double holiday, rest day, night shift, OT
        public decimal NoPayLeave { get; set; }//Leave Without Pay
        public decimal Late { get; set; }//Late
        public decimal NSDonDSH { get; set; } //Night Shift Diff on Double Special
        public decimal OTOonDSH { get; set; } //over time on double special
        public decimal OTOnNSDOnDSH { get; set; } // overtime, night diff in double special holiday
    }

    public static class PayrollRunTimeSheetsPayExtension
    {
        public static IEnumerable<PayrollRunTimeSheetsPayDtoResponse> ToPayrollRunTimeSheetsPayDtoResponseList(this IEnumerable<PayrollRunTimeSheetsPay> e)
            => e.Select(f => f.ToPayrollRunTimeSheetsPayDtoResponse());
        public static PayrollRunTimeSheetsPayDtoResponse ToPayrollRunTimeSheetsPayDtoResponse(this PayrollRunTimeSheetsPay e)
        {
            return new PayrollRunTimeSheetsPayDtoResponse
            {
                Id = e.Id,
                PayrollRunId = e.PayrollRunId,
                PayrollRun = e.PayrollRun != null ? e.PayrollRun.ToPayrollRunResponse() : null,
                EmployeeId = e.EmployeeId,
                Employee = e.Employee != null ? e.Employee.ToBasicEmployeeInfo() : null,
                OD = e.OD,
                RD = e.RD,
                SH = e.SH,
                RDOnSH = e.RDOnSH,
                DSH = e.DSH,
                RDOnDSH = e.RDOnDSH,
                RH = e.RH,
                RDOnRH = e.RDOnRH,
                DRH = e.DRH,
                RDOnDRH = e.RDOnDRH,
                ODOnNSD = e.ODOnNSD,
                NSDOnRD = e.NSDOnRD,
                NSDOnSH = e.NSDOnSH,
                NSDOnRDOnSH = e.NSDOnRDOnSH,
                NSDOnRDOnDSH = e.NSDOnRDOnDSH,
                NSDOnRH = e.NSDOnRH,
                NSDOnRDOnRH = e.NSDOnRDOnRH,
                NSDOnDRH = e.NSDOnDRH,
                NSDOnRDOnDRH = e.NSDOnRDOnDRH,
                ODOnOT = e.ODOnOT,
                OTOnRD = e.OTOnRD,
                OTOnSH = e.OTOnSH,
                OTOnRDOnSH = e.OTOnRDOnSH,
                OTOnRDOnDSH = e.OTOnRDOnDSH,
                OTOnRH = e.OTOnRH,
                OTOnRDOnRH = e.OTOnRDOnRH,
                OTOnDRH = e.OTOnDRH,
                OTOnRDOnDRH = e.OTOnRDOnDRH,
                ODOnOTOnNSD = e.ODOnOTOnNSD,
                OTOnNSDOnRD = e.OTOnNSDOnRD,
                OTOnNSDOnSH = e.OTOnNSDOnSH,
                OTOnNSDOnRDOnSH = e.OTOnNSDOnRDOnSH,
                OTOnNSDOnRDOnDSH = e.OTOnNSDOnRDOnDSH,
                OTOnNSDOnRH = e.OTOnNSDOnRH,
                OTOnNSDOnRDOnRH = e.OTOnNSDOnRDOnRH,
                OTOnNSDOnDRH = e.OTOnNSDOnDRH,
                OTOnNSDOnRDOnDRH = e.OTOnNSDOnRDOnDRH,
                NoPayLeave = e.NoPayLeave,
                Late = e.Late,
                NSDonDSH = e.NSDonDSH,
                OTOnNSDOnDSH = e.OTOnNSDOnDSH,
                OTOnDSH = e.OTOnDSH
            };
        }
    }
}
