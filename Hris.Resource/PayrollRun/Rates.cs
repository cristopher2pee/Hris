using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Resource.PayrollRun
{
    public static class Default
    {
        public static decimal ThirteenMonthPayMinimum = 90000;
        public static DateTime FirstMonthOfTheYear = new DateTime(DateTime.Now.Year, 1, 1);
    }
    public static class Rates
    {
        public static decimal OD = 1; // Ordinary days 
        public static decimal RD = 1.3m;
        public static decimal SH = 1.3m;
        public static decimal RDOnSH = 1.5m; // Special (non-working) day falling on rest day
        public static decimal DSH = 1.5m; //Double special (non-working) days
        public static decimal RDOnDSH = 1.95m; //Double special (non-working) days falling on rest day
        public static decimal RH = 2; //Regular ho liday
        public static decimal RDOnRH = 2.6m; //Regular holiday falling on rest day
        public static decimal DRH = 3; //Double holiday
        public static decimal RDOnDRH = 3.9m; //Double holiday falling on rest day


        public static decimal ODOnNSD = 1.1m; //Ordinary day, night shift
        public static decimal NSDOnRD = 1.43m; //Rest day, night shift
        public static decimal NSDOnSH = 1.43m; //Special (non-working) day, night shift
        public static decimal NSDOnRDOnSH = 1.65m; // Special (non-working) day, rest day, night shift
        public static decimal NSDOnRDOnDSH = 2.145m;//  Double special(non-working) days, rest day, night shift
        public static decimal NSDOnRH = 2.2m;//Regular holiday, night shift 
        public static decimal NSDOnRDOnRH = 2.86m;//Regular holiday, rest day, night shift 
        public static decimal NSDOnDRH = 3.3m;//Double holiday, night shift
        public static decimal NSDOnRDOnDRH = 4.29m;//Double holiday, rest day, night shift
        public static decimal ODOnOT = 1.25m;//Ordinary day, overtime (OT)
        public static decimal OTOnRD = 1.69m;//Rest day, OT

        //
        public static decimal OTOnSH = 1.69m;//Special (non-working), OT
        public static decimal OTOnRDOnSH = 1.95m;//Special (non-working) day, rest day, OT 
        public static decimal OTOnRDOnDSH = 2.535m;//Double special (non-working) days, rest day, OT
        public static decimal OTOnSHOnRH = 2.6m;//Regular holiday, OT 
        public static decimal OTOnRDOnRH = 3.38m;//Regular holiday, rest day, OT
        public static decimal OTOnDRH = 3.9m;//Double holiday, OT
        public static decimal OTOnRDOnDRH = 5.07m;//Double holiday, rest day, OT
        public static decimal ODOnOTOnNSD = 1.375m;//Ordinary day, night shift, OT 
        public static decimal OTOnNSDOnRD = 1.859m;//Rest day, night shift, OT 
        public static decimal OTOnNSDOnSH = 1.859m;//Special (non-working) day, night shift, OT
        public static decimal OTOnNSDOnRDOnSH = 2.145m;//Special (non-working) day, rest day, night shift, OT
        public static decimal OTOnNSDOnRDOnDSH = 2.7885m;//Double special (non-working) days, rest day, night shift, OT
        public static decimal OTOnNSDOnRH = 2.86m;//Regular holiday, night shift, OT 
        public static decimal OTOnNSDOnRDOnRH = 3.718m;//Reg. holiday, rest day, night shift, OT 
        public static decimal OTOnNSDOnDRH = 4.29m;//Double holiday, night shift, OT
        public static decimal OTOnNSDOnRDOnDRH = 5.577m;//Double holiday, rest day, night shift, OT
        public static decimal NoPayLeave = 1;//Leave Without Pay
        public static decimal Late = 0;//Late
        public static decimal NSDonDSH = 1.65m; //Night Shift Diff on Double Special
        public static decimal OTOonDSH = 1.875m; //over time on double special
        public static decimal OTOnNSDOnDSH = 2.0625m;

        public static int totalWorkingDays = 261;
        public static int totalMonths = 12;
        public static int totalWorkingHours = 8;

        public static decimal DailyRate(decimal basePay)
        {
            return (basePay * totalMonths) / totalWorkingDays;
        }

        public static decimal HourlyRate(decimal dailyRate)
        {
            return dailyRate / totalWorkingHours;
        }
    }
}
