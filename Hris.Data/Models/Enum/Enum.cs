using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Enum
{
    public enum Gender
    {
        [Description("Male")]
        Male = 1,
        [Description("Female")]
        Female = 2,
        [Description("Others")]
        Others = 3
    }

    public enum CivilStatus
    {
        [Description("Single")]
        Single = 1,
        [Description("Married")]
        Married = 2,
        [Description("Divorced")]
        Divorced = 3,
        [Description("Widowed")]
        Widowed = 4,
        [Description("Partner")]
        Partner = 5

    }

    public enum LoanStatus
    {
        Unpaid = 1,
        Ongoing = 2,
        FullPaid = 3,
        OverPaid = 4,
    }

    public enum EmployeeStatus
    {
        Probationary = 1,
        FullTime = 2,
        PartTime = 3,
        Project = 4,
        Resigned = 5,
        Separated = 6
    }

    public enum EducationLevel
    {
        [Description("Others")]
        Others = 0,
        [Description("High School")]
        HighSchool = 1,
        [Description("College")]
        College = 2,
        [Description("Master")]
        Master = 3,
        [Description("Phd / Doctoral")]
        Phd = 4

    }

    public enum LeaveStatus
    {
        Applied = 1,
        Withdrawn = 2,
        LeadApproved = 3,
        HeadApproved = 4,
        Rejected = 5,
        NonApprovedCancelationRequest = 6,
        Cancelled = 7,
        ApprovedCancelationRequest = 8
    }

    public enum AddressType
    {
        [Description("Home")]
        HomeCurrent = 1,
        [Description("Provincial")]
        Provincial = 2,
        [Description("Others")]
        Others
    }

    public enum RelationshipType
    {
        [Description("Mother")]
        Mother = 1,
        [Description("Father")]
        Father = 2,
        [Description("Wife")]
        Wife = 3,
        [Description("Husband")]
        Husband = 4,
        [Description("Son")]
        Son = 5,
        [Description("Daughter")]
        Daughter = 6,
        [Description("Brother")]
        Brother = 7,
        [Description("Sister")]
        Sister = 8,
        [Description("Auntie")]
        Auntie = 9,
        [Description("Uncle")]
        Uncle = 10,
        [Description("Cousin")]
        Cousin = 11,
        [Description("Grand Father")]
        GrandFather = 12,
        [Description("Grand Mother")]
        GrandMother = 13,
        [Description("Others")]
        Others = 14
    }

    public enum PayrollPeriod
    {
        //[Description("Daily")]
        //Daily =1,
        //[Description("Bi Monthly")]
        //BiMonthly =2,
        //[Description("Monthly")]
        //Monthly =3,
        //[Description("Quarterly")]
        //Quarterly =4,
        //[Description("Semi Annually")]
        //SemiAnnually =5,
        //[Description("Annually")]
        //Annually =6

        [Description("Every Payroll")]
        EveryPayroll = 1,
        [Description("Payroll 1")]
        Payroll1 = 2,
        [Description("Payroll 2")]
        Payroll2 = 3,
        [Description("Only This Payroll")]
        OnlyThisPayroll = 4,
        //[Description("Semi Annually")]
        //SemiAnnually = 5,
        //[Description("Annually")]
        //Annually = 6

    }

    public enum TaxPeriodType
    {
        Daily = 1,
        Weekly = 2,
        SemiMonthly = 3,
        Monthly = 4,
        Anually = 5
    }

    public enum StatutoryType
    {
        [Description("Social Security System")]
        SSS = 1,
        [Description("Pagibig")]
        Pagibig = 2,
        [Description("PhilHealth")]
        PhilHealth = 3,
        [Description("Tax Identification Number")]
        TIN = 4
    }

    [Flags]
    public enum WeekDays
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64,
    }

    public enum PositionLevel
    {
        [Description("Associate")]
        Associate = 1,
        [Description("Intermediate")]
        Intermediate = 2,
        [Description("Senior")]
        Senior = 3,
        [Description("Team Leader")]
        TeamLead = 4,
        [Description("Manager")]
        Manager = 5,
        [Description("Director")]
        Director = 6,
        [Description("Executive")]
        Executive = 7

    }

    public enum BloodType
    {
        [Description("O-")]
        ONegative = 1,
        [Description("O+")]
        OPositive = 2,
        [Description("A-")]
        ANegative = 3,
        [Description("A+")]
        APositive = 4,
        [Description("B-")]
        BNegative = 5,
        [Description("B+")]
        BPositive = 6,
        [Description("AB-")]
        ABNegative = 7,
        [Description("AB+")]
        ABPositive = 8,
    }

    public enum TrackType
    {
        Clock = 1,
        Manual = 2,
        Import = 3
    }

    public enum TrackTag
    {
        Office = 1,
        Wfh = 2,
        OfficialBusiness = 3,
        PaidLeave = 4,
        Overtime = 5
    }

    public enum TrackStatus
    {
        None = 0,
        Start = 1,
        Pause = 2,
        Resume = 3,
        Stop = 4
    }

    public enum BreakStatus
    {
        Start = 1,
        Stop = 2
    }

    public enum Modules
    {
        Employees = 1,
        Leave = 2,
        Payroll = 3,
        Request = 4,
        Document = 5,
        Clock = 6,
        Admin = 7
    }

    public enum Roles
    {
        Admin = 1,
        Manager = 2,
        Hr = 3,
        Lead = 4,
        User = 5
    }

    public enum ChangeStatus
    {
        Pending = 1,
        Approved = 2,
        Declined = 3
    }

    public enum ReportType
    {
        Clients = 1,
        Daily = 2,
    }

    public enum LeaveClass
    {
        Basic = 1,
        Special = 2
    }

    public enum HolidayType
    {
        Regular = 1,
        Special = 2,
        DoubleRegular = 3,
        DoubleSpecial = 4
    }

    public enum PayrollRunStatusEnum
    {
        [Description("Select the Payroll settings to be used in the generation of Payroll")]
        PayrollRun = 1,
        [Description("Verify the basic settings needed for an employee in order for a payroll to be generated")]
        EmployeeSettings = 2,
        [Description("Verify and Confirm if holidays are properly added / updated with the correct type (Special , Regular)")]
        Holidays = 3,
        [Description("Check if there are Overtime requests that are pending")]
        Overtime = 4,
        [Description("Check if there are Leave Applications that are pending")]
        LeaveApplications = 5,
        [Description("Verify and Add allowances if needed employee allowances")]
        Allowances = 6,
        [Description("Verify and Add Deduction is needed employee deductions")]
        Deductions = 7,
        [Description("Verify and Add Employee Loan Payments if needed")]
        Loans = 8,
        [Description("Timesheet summary of all employees")]
        Timesheet = 9,
        [Description("Payroll Summary computed")]
        PayrollSummary = 10,
        [Description("Gert needs to Approve before it is finalized and locked")]
        Approval = 11,
        [Description("Means this is final and ready or Disbursement")]
        Locked = 12,
    }

    public enum PayrollRunTypeNotification
    {
        LeaveApplicationNotification = 1,
        TrackRequestNotification = 2
    }

    public enum ProjectTaskRate
    {
        Default = 0,
        Hourly = 1,
        PlusToBasicPay = 2,
    }
}
