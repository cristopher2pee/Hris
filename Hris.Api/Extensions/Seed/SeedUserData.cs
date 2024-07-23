using Hris.Data.DataContext;
using Hris.Data.Models.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hris.Api.Extensions.Seed
{
    public static class SeedUserDataExtension
    {
        public static WebApplication SeedUserTable(this WebApplication application)
        {
            using (var scope = application.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var employeeList = appContext.Employees.ToList();
                    var password = application.Configuration["Security:DefaultPassword"]!.ToString();

                    foreach (var emp in employeeList)
                    {
                        var exist = appContext.Users.Where(f => f.EmployeeId.Equals(emp.Id)).Any();
                        if (!exist)
                        {
                            var _userToSave = new Data.Models.IdentityServer.User
                            {
                                Email = emp.Email,
                                EmployeeId = emp.Id,
                                UserName = emp.Email,
                                PasswordHash = password
                            };

                            if (!string.IsNullOrEmpty(_userToSave.Email))
                                userManager.CreateAsync(_userToSave, _userToSave.PasswordHash).Wait();
                        }
                    }
                    appContext.SaveChanges();
                }
            }
            return application;
        }
    }

    public static class SeedUserSettingsExtension
    {
        public static WebApplication SeedUserSettings(this WebApplication application)
        {
            using (var scope = application.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    var employeeList = appContext.Employees.ToList();
                    var defaultSettings = "Taipei Standard Time";

                    foreach (var emp in employeeList)
                    {
                        var isExist = appContext.UserSettings.Where(f => f.EmployeeId.Equals(emp.Id)).Any();
                        if (!isExist)
                        {
                            var toSave = new Data.Models.Settings.UserSettings
                            {
                                EmployeeId = emp.Id,
                                Timezone = defaultSettings,
                                Active = true
                            };

                            appContext.UserSettings.Add(toSave);
                        }
                    }
                    appContext.SaveChanges();
                }

                return application;
            }
        }
    }
}
