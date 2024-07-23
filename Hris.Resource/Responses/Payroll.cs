using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Resource.Responses
{
    public static class AllowanceType
    {
        public static string ALLOWANCE_TYPE = "Allowance Type";
        public static string NOT_FOUND = ALLOWANCE_TYPE + " not found";
        public static string ID_NOT_FOUND = ALLOWANCE_TYPE + " ID not found.";
        public static string ID_REQUIRED = ALLOWANCE_TYPE + " ID is required.";
    }

    public static class AllowanceEntitlement
    {
        public static string ALLOWANCE_ENTITLEMENT = "Allowance Entitlement";
        public static string NOT_FOUND = ALLOWANCE_ENTITLEMENT + " not found";
        public static string ID_NOT_FOUND = ALLOWANCE_ENTITLEMENT + " ID not found.";
        public static string ID_REQUIRED = ALLOWANCE_ENTITLEMENT + " ID is required.";
    }

    public static class PayrollRunMessage
    {
        public static string PAYROLL_RUN = "Payroll Run";
        public static string LOCKED_MESSAGE = "Unable to process data due to the payroll run being locked.";
    }

    public static class PaySlipMessage
    {
        public static string PAYSLIP = "Generate Payslip";
        public static string EMPLOYEE_NOT_FOUND = "Unable to process data due to employee not found.";
        public static string PAYROLL_RUN_NOT_FOUND = "Unable to process data due to payroll run not found";
    }
}
