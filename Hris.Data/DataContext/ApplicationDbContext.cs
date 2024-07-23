//using Azure.Core.Cryptography;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Hris.Data.Models;
using Hris.Data.Models.Administrator;
using Hris.Data.Models.Clock;
using Hris.Data.Models.Employee;
using Hris.Data.Models.IdentityServer;
using Hris.Data.Models.Leave;using Hris.Data.Models.Notification;
using Hris.Data.Models.Payroll;
//using Hris.Data.Models.Leave;
using Hris.Data.Models.Settings;
using Hris.Data.Models.Statutory;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//using Hris.Data.Models.Tracker;
using Microsoft.EntityFrameworkCore;
//using Task = Hris.Data.Models.Tracker.Task;

namespace Hris.Data.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    //   public  class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        // private GenerateEncryptionProvider _provider;
        private readonly IEncryptionProvider _provider;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this._provider = new GenerateEncryptionProvider("hrms-development");
        }

        public async Task<int> SaveChangesAsync(Guid userObjectId)
        {
            return await SaveChanges(userObjectId);
        }

        public async Task<int> SaveChanges(Guid userObjectId)
        {
            var selectedEntityList = ChangeTracker.Entries().
                Where(x => x.Entity is BaseEntity && (x.State == EntityState.Modified || x.State == EntityState.Added));


            foreach (var entity in selectedEntityList)
            {
                ((BaseEntity)entity.Entity).ModifiedBy = userObjectId;
                ((BaseEntity)entity.Entity).Modified = DateTime.Now.ToUniversalTime();

                if (entity.State == EntityState.Added)
                    ((BaseEntity)entity.Entity).Id = Guid.NewGuid();
            }

            return await base.SaveChangesAsync();
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmploymentHistory> EmploymentHistory { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<SalaryHistory> SalaryHistory { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        //public DbSet<Statutory> Statutories { get; set; }
        public DbSet<AllowanceEntitlement> AllowanceEntitlements { get; set; }
        public DbSet<AllowanceType> AllowanceTypes { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<AssignedProject> AssignedProjects { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveEntitlement> LeaveEntitlements { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
        public DbSet<Calendar> CalendarEvents { get; set; }
        public DbSet<DeductionTypes> DeductionTypes { get; set; }
        public DbSet<EmployeesDeduction> EmployeesDeduction { get; set; }
        // public DbSet<EmployeeStatutories> EmployeeStatutories { get; set; }
        public DbSet<ShiftSchedule> ShiftSchedules { get; set; }
        public DbSet<TaxTable> TaxTable { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<LoanTypes> LoanTypes { get; set; }
        public DbSet<EmployeeLoans> EmployeeLoans { get; set; }

        public DbSet<PayrollConfig> PayrollConfig { get; set; }
        public DbSet<PayrollConfigDetails> PayrollConfigDetails { get; set; }
        public DbSet<PayrollRun> PayrollRun { get; set; }
        public DbSet<PayrollRunAllowances> PayrollRunAllowances { get; set; }
        public DbSet<PayrollRunDeductions> PayrollRunDeductions { get; set; }
        public DbSet<PayrollRunLoans> PayrollRunLoans { get; set; }
        public DbSet<Data.Models.Payroll.PayrollRunTimeSheets> PayrollRunTimeSheets { get; set; }
        public DbSet<Data.Models.Payroll.PayrollRunTimeSheetsPay> PayrollRunTimeSheetsPay { get; set; }
        public DbSet<PayrollRunPaySummary> PayrollRunPaySummary { get; set; }
        public DbSet<AuthenticationInvite> AuthenticationInvites { get; set; }

        public DbSet<PayrollRunCustomRate> PayrollRunCustomRate { get; set; }

        //statutory
        public DbSet<SSSTable> SSSTable { get; set; }
        public DbSet<HDMFTable> HDMFTable { get; set; }
        public DbSet<PHICTable> PHICTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.UseEncryption(this._provider);
            //modelBuilder.UseEncryption(_provider);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Address>().HasKey(e => e.Id);
            modelBuilder.Entity<Department>().HasKey(e => e.Id);
            //modelBuilder.Entity<Education>().HasKey(e => e.Id);
            modelBuilder.Entity<EmploymentHistory>().HasKey(e => e.Id);
            modelBuilder.Entity<Family>().HasKey(e => e.Id);
            modelBuilder.Entity<Position>().HasKey(e => e.Id);
            modelBuilder.Entity<SalaryHistory>().HasKey(e => e.Id);
            modelBuilder.Entity<Team>().HasKey(e => e.Id);

            modelBuilder.Entity<Permission>().HasKey(e => e.Id);

            modelBuilder.Entity<Employee>().HasOne(e => e.Position).WithMany().HasForeignKey(e => e.PositionId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Employee>().HasMany(e => e.Addresses).WithOne().HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Employee>().HasMany(e => e.Family).WithOne().HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Employee>().HasMany(e => e.SalaryHistory).WithOne().HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            //  modelBuilder.Entity<Employee>().HasMany(e => e.Statutories).WithOne().HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Employee>().HasMany(e => e.Allowances).WithOne().HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Employee>().HasMany(e => e.EmploymentHistory).WithOne(e => e.Employee).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            /*            modelBuilder.Entity<Family>().HasOne(e => e.Address).HasForeignKey<Address>(e => e.FamilyId).OnDelete(DeleteBehavior.NoAction);*/

            modelBuilder.Entity<Department>().HasOne(e => e.Manager).WithMany().HasForeignKey(e => e.ManagerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Department>().HasMany(e => e.Teams);
            modelBuilder.Entity<Team>().HasOne(e => e.Lead).WithMany().HasForeignKey(e => e.LeadId).OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Access>().HasData(
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Employee", Path = "Employee", Module = "Employees", Roles = "Admin,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Department", Path = "Department", Module = "Employees", Roles = "Admin,Manager", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Position", Path = "Position", Module = "Employees", Roles = "Admin,Manager", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Employee Reports", Path = "Employee-Reports", Module = "Employees", Roles = "Admin,Manager,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Generate Employee COE", Path = "Employee-Reports/Generate-Coe", Module = "Employees", Roles = "Admin,Manager,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },

            //    new { Id = Guid.NewGuid(), Active = true, Name = "Project", Path = "Project", Module = "Clock", Roles = "Admin,Manager", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Clients", Path = "Clients", Module = "Clock", Roles = "Admin,Manager", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Track", Path = "Track", Module = "Clock", Roles = "User,Admin,Manager", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Track Request", Path = "Track-Request", Module = "Clock", Roles = "Admin,Manager", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "AssignProject", Path = "AssignProject", Module = "Clock", Roles = "Admin,Manager", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Reports", Path = "Reports", Module = "Clock", Roles = "Admin,Manager", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "ImportTracks", Path = "Import-Tracks", Module = "Clock", Roles = "Admin,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },

            //    new { Id = Guid.NewGuid(), Active = true, Name = "AllowanceType", Path = "AllowanceType", Module = "Payroll", Roles = "Admin,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Entitlements", Path = "Entitlements", Module = "Payroll", Roles = "Admin,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Deduction Type", Path = "Deduction-Type", Module = "Payroll", Roles = "Admin,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Shift Schedules", Path = "Shift-Schedules", Module = "Payroll", Roles = "Admin,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Loan Types", Path = "Loan-Types", Module = "Payroll", Roles = "Admin", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Employee Loans", Path = "Employee-Loans", Module = "Payroll", Roles = "Admin,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Payroll Configuration", Path = "Payroll-Configuration", Module = "Payroll", Roles = "Admin,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Payroll Run", Path = "Payroll-Run", Module = "Payroll", Roles = "Admin,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },

            //    new { Id = Guid.NewGuid(), Active = true, Name = "Invite", Path = "Invite", Module = "Admin", Roles = "Admin,Manager,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Access", Path = "Access", Module = "Admin", Roles = "Admin,Manager", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Calendar", Path = "Calendar", Module = "Admin", Roles = "Admin,Manager,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "Permission", Path = "Permission", Module = "Admin", Roles = "Admin,Manager", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },

            //    new { Id = Guid.NewGuid(), Active = true, Name = "LeaveType", Path = "Leave-Types", Module = "Leave", Roles = "Admin,Manager,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "LeaveEntitlement", Path = "Leave-Entitlement", Module = "Leave", Roles = "Admin,Manager,Hr", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "LeaveApplication", Path = "Leave-Application", Module = "Leave", Roles = "Admin,Manager,Hr,Lead,User", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //    new { Id = Guid.NewGuid(), Active = true, Name = "LeaveRequest", Path = "Leave-Request", Module = "Leave", Roles = "Admin,Manager,Hr,Lead", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() },
            //     new { Id = Guid.NewGuid(), Active = true, Name = "My Department Team", Path = "My-Department-Team", Module = "Employees", Roles = "Admin,Manager,Lead", Modified = DateTime.UtcNow, ModifiedBy = Guid.NewGuid() }
            //);
        }

    }
}
