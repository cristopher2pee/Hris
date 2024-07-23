using Hris.Data.DataContext;
using Hris.Data.Models.Administrator;
using Microsoft.EntityFrameworkCore;

namespace Hris.Api.Extensions.Seed
{
    public static class SeedAccessDataExtension
    {

        public static  WebApplication SeedAccessData(this WebApplication application)
        {
            using (var scope = application.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    var accessList = new List<Access>();

                    var isDuplicate = appContext.Accesses
                        .Where(f => f.Name.ToLower().Equals("Employee") &&
                        f.Path.ToLower().Equals("Employee"))
                        .Count() > 1;

                    if (isDuplicate)
                    {
                        appContext.Accesses.RemoveRange(appContext.Accesses.Where(f => f.Active));
                        appContext.SaveChanges();
                    }

                    //Employees
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Employee",
                        Path = "Employee",
                        Module = "Employees",
                        Roles = "Admin,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Department",
                        Path = "Department",
                        Module = "Employees",
                        Roles = "Admin,Manager",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Position",
                        Path = "Position",
                        Module = "Employees",
                        Roles = "Admin,Manager",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Employee Reports",
                        Path = "Employee-Reports",
                        Module = "Employees",
                        Roles = "Admin,Manager,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Generate Employee COE",
                        Path = "Employee-Reports/Generate-Coe",
                        Module = "Employees",
                        Roles = "Admin,Manager,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    //Clock
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Project",
                        Path = "Project",
                        Module = "Clock",
                        Roles = "Admin,Manager",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Clients",
                        Path = "Clients",
                        Module = "Clock",
                        Roles = "Admin,Manager",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Track",
                        Path = "Track",
                        Module = "Clock",
                        Roles = "User,Admin,Manager",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()

                    });

                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Track Request",
                        Path = "Track-Request",
                        Module = "Clock",
                        Roles = "Admin,Manager",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "AssignProject",
                        Path = "AssignProject",
                        Module = "Clock",
                        Roles = "Admin,Manager",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Reports",
                        Path = "Reports",
                        Module = "Clock",
                        Roles = "Admin,Manager",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "ImportTracks",
                        Path = "Import-Tracks",
                        Module = "Clock",
                        Roles = "Admin,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    //Payroll
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "AllowanceType",
                        Path = "AllowanceType",
                        Module = "Payroll",
                        Roles = "Admin,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Entitlements",
                        Path = "Entitlements",
                        Module = "Payroll",
                        Roles = "Admin,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Deduction Type",
                        Path = "Deduction-Type",
                        Module = "Payroll",
                        Roles = "Admin,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Shift Schedules",
                        Path = "Shift-Schedules",
                        Module = "Payroll",
                        Roles = "Admin,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Loan Types",
                        Path = "Loan-Types",
                        Module = "Payroll",
                        Roles = "Admin",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Employee Loans",
                        Path = "Employee-Loans",
                        Module = "Payroll",
                        Roles = "Admin,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Payroll Configuration",
                        Path = "Payroll-Configuration",
                        Module = "Payroll",
                        Roles = "Admin,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Payroll Run",
                        Path = "Payroll-Run",
                        Module = "Payroll",
                        Roles = "Admin,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    //Admin
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Invite",
                        Path = "Invite",
                        Module = "Admin",
                        Roles = "Admin,Manager,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Access",
                        Path = "Access",
                        Module = "Admin",
                        Roles = "Admin,Manager",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()

                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Calendar",
                        Path = "Calendar",
                        Module = "Admin",
                        Roles = "Admin,Manager,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "Permission",
                        Path = "Permission",
                        Module = "Admin",
                        Roles = "Admin,Manager",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    //Leave
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "LeaveType",
                        Path = "Leave-Types",
                        Module = "Leave",
                        Roles = "Admin,Manager,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "LeaveEntitlement",
                        Path = "Leave-Entitlement",
                        Module = "Leave",
                        Roles = "Admin,Manager,Hr",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });

                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "LeaveApplication",
                        Path = "Leave-Application",
                        Module = "Leave",
                        Roles = "Admin,Manager,Hr,Lead,User",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "LeaveRequest",
                        Path = "Leave-Request",
                        Module = "Leave",
                        Roles = "Admin,Manager,Hr,Lead",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });
                    accessList.Add(new Access
                    {
                        Active = true,
                        Name = "My Department Team",
                        Path = "My-Department-Team",
                        Module = "Employees",
                        Roles = "Admin,Manager,Lead",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = Guid.NewGuid()
                    });


                    foreach(var item in accessList)
                    {
                        var isExist = appContext.Accesses
                            .Where(f => f.Name.Equals(item.Name) &&
                            f.Path.Equals(item.Path))
                            .Any();

                        if(!isExist)
                            appContext.Accesses.Add(item);
                    }

                    appContext.SaveChanges();


                }
            }

            return application;
        }

    }
}
