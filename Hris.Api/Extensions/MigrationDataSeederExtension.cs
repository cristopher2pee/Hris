using Hris.Data.DataContext;
using Hris.Data.Models.Administrator;
using Hris.Data.Models.Employee;

namespace Hris.Api.Extensions
{
    public static class MigrationDataSeederExtension
    {


        public static WebApplication SeedSuperUsers(this WebApplication webApplication)
        {
            using(var scope=webApplication.Services.CreateScope())
            {

                using(var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {

                    var employee1 = new Employee()
                    {
                        Id = Guid.NewGuid(),
                        Active = true,
                        Email = "chris@gemango.com",
                        Code = "GSSI036",
                        Contact = "9175503389",
                        HomePhone = "9175503389",
                        Firstname = "Chris",
                        Lastname = "Ponce",
                        Middlename = "Butaya",
                        BirthPlace = "Cebu",
                        Gender = Data.Models.Enum.Gender.Male,
                        CivilStatus = Data.Models.Enum.CivilStatus.Single,
                        Citizenship = "Filipino",
                        Religion = "Roman Catholic",
                        DateHired = new DateTime(2013, 06, 18),
                        ObjectId = new Guid("b7518368-d2ca-47e7-9144-69a7525b131c")

                    };

                    var emp1Address= new Address
                    {
                        Active = true,
                        AddressType = Data.Models.Enum.AddressType.HomeCurrent,
                        City = "Lapu-Lapu",
                        Country = "Philippines",
                        EmployeeId = employee1.Id,
                        Id = Guid.NewGuid(),
                        PostalCode = 6015,
                        State = "Cebu",
                        Street = "Calawisan",
                        Village = "Astana Subdivision"


                    };



                    var employee2 = new Employee()
                    {
                        Id = Guid.NewGuid(),
                        Active = true,
                        Email = "hr@gemango.com",
                        Code = "GSSI000",
                        Contact = "9175503389",
                        HomePhone = "9175503389",
                        Firstname = "Hr",
                        Lastname = "Admin",
                        Middlename = "A",
                        BirthPlace = "Cebu",
                        Gender = Data.Models.Enum.Gender.Male,
                        CivilStatus = Data.Models.Enum.CivilStatus.Single,
                        Citizenship = "Filipino",
                        Religion = "Roman Catholic",
                        DateHired = new DateTime(2008, 08, 01)                        

                    };

                    var emp2Address = new Address
                    {
                        Active = true,
                        AddressType = Data.Models.Enum.AddressType.HomeCurrent,
                        City = "Cebu",
                        Country = "Philippines",
                        EmployeeId = employee2.Id,
                        Id = Guid.NewGuid(),
                        PostalCode = 6015,
                        State = "Cebu",
                        Street = "Cebu",
                        Village = "IT Tower 1 14th Floor"


                    };



                    var employee1Perm = new Permission()
                    {
                        Id = Guid.NewGuid(),
                        Access = "Admin.Admin,Clock.Admin,Employees.Admin,Leave.Admin,Payroll.Admin",
                        Employee = employee1,
                        EmployeeId = employee1.Id
                    };


                    var employee2Perm = new Permission()
                    {
                        Id = Guid.NewGuid(),
                        Access = "Clock.Hr,Employees.Hr,Leave.Hr",
                        Employee = employee2,
                        EmployeeId = employee2.Id
                    };


                    var employeeExist = appContext.Employees.Where(e=>e.Email.ToUpper().Trim()==employee1.Email.ToUpper()).ToList();
                    var employee2Exist = appContext.Employees.Where(e => e.Email.ToUpper().Trim() == employee2.Email.ToUpper()).ToList();


                    if (!employeeExist.Any())
                    {
                        appContext.Employees.Add(employee1);
                        appContext.Addresses.Add(emp1Address);
                        appContext.Permissions.Add(employee1Perm);
                    }


                    if (!employee2Exist.Any())
                    {
                        appContext.Employees.Add(employee2);
                        appContext.Addresses.Add(emp2Address);
                        appContext.Permissions.Add(employee2Perm);
                    }


                    appContext.SaveChanges();

                }

            }


            return webApplication;
        }


    }
}
