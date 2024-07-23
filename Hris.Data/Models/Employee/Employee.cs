using EntityFrameworkCore.EncryptColumn.Attribute;
using Hris.Data.Models.Administrator;
using Hris.Data.Models.Clock;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Leave;
using Hris.Data.Models.Notification;
using Hris.Data.Models.Payroll;
using Hris.Data.Models.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.Models.Employee
{
    public class Employee : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string? Code { get; set; }
        public string Contact { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string? Middlename { get; set; }
        public string BirthPlace { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; } = Gender.Others;
        public CivilStatus CivilStatus { get; set; } = CivilStatus.Single;
        public string Citizenship { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public BloodType BloodType { get; set; } = BloodType.ABNegative;
        public DateTime DateHired { get; set; } = DateTime.Now;
        public DateTime? DateSeparated { get; set; }
        public DateTime? DateRendered { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; } = EmployeeStatus.Probationary;
        public Guid? PositionId { get; set; }
        public virtual Position Position { get; set; }
        [EncryptColumn]
        public string BankNo { get; set; }
        public Guid? ObjectId { get; set; }
        public string AvatarUri { get; set; } = string.Empty;
        public string? ProfileUri { get; set; }
        public string? Manual { get; set; }
        public string? PolicyNo { get; set; }
        public string? CardNo { get; set; }
        public UserSettings Settings { get; set; }
        public Permission Permission { get; set; }

        //GovernmentId
        public string PagIbigId { get; set; } = string.Empty;
        public string SSSId { get; set; } = string.Empty;
        public string PhilHealthId { get; set; } = string.Empty;
        public string TIN { get; set; } = string.Empty;

        //Shift
        public Guid? ShiftScheduleId { get; set; }
        public virtual ShiftSchedule ShiftSchedule { get; set; }
       // public virtual ShiftSchedule ShiftSchedule { get; set; }
        public virtual ICollection<EmploymentHistory> EmploymentHistory { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Family> Family { get; set; }
        public virtual ICollection<SalaryHistory> SalaryHistory { get; set; }
        public virtual ICollection<AllowanceEntitlement> Allowances { get; set; }
        //public virtual ICollection<Statutory> Statutories { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
        /*public virtual ICollection<LeaveApplication> LeaveApplications { get; set; }*/
        /*public virtual ICollection<Track> Tracks { get; set; }*/
        public virtual ICollection<AssignedProject> AssignedProjects { get; set; }
        public virtual ICollection<EmployeesDeduction> EmployeesDeduction { get; set; }
     //   public virtual EmployeeStatutories EmployeeStatutories { get; set; }
        public virtual ICollection <Models.Notification.Notification> Notifications { get; set; }

    }
}
       