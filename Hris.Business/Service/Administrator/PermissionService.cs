using Azure;
using Hris.Business.Service.EmployeeModule;
using Hris.Data.Models.Administrator;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Settings;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.Administrator
{
    public class PermissionService
    {
        private readonly IRepository<Permission> repository;
        private readonly EmployeeService employeeService;
        public PermissionService(IRepository<Permission> repository, 
            IRepository<Employee> employeeRepo)
        {
            this.repository = repository;
            employeeService = new EmployeeService(employeeRepo);
        }

        public async Task<IQueryable<Permission>> GetAllByEmpId(Guid id)
            => (await repository.GetDbSet())
                .AsNoTracking()
                .Where(d => d.Employee.Id.Equals(id));

        public async Task<Roles?> GetRoleByModule(Guid id, Modules module)
        {
            try
            {
                var d = await GetAllByEmpId(id);

                if (d == null || !d.Any())
                    throw new NullReferenceException();

                foreach (var p in d)
                {
                    var roles = p.Access.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var role in roles)
                    {
                        var split = role.Split('.', StringSplitOptions.RemoveEmptyEntries);

                        if (split == null)
                            continue;

                        if (((Modules)Enum.Parse(typeof(Modules), split[0])).Equals(module))
                            return (Roles)Enum.Parse(typeof(Roles), split[1]);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Old

        public async Task<List<string>> GetPermissionsAsync(Guid userId)
        {   
            var permissions = new List<string>();

            var employee = await employeeService.GetByObjectId(userId, false);

            if (employee != null)
            {
                var user = await (await this.repository.GetDbSet())
                    .AsNoTracking()
                    .Where(e => e.EmployeeId == employee.Id)
                    .FirstOrDefaultAsync();

                if (user != null)
                {

                    if (!string.IsNullOrEmpty(user.Access))
                    {
                        permissions.AddRange(user.Access.Split(',',StringSplitOptions.RemoveEmptyEntries));
                    }

                }

            }
            return permissions;
        }

        public async Task<List<string>> GetById(Guid id)
        {
            var permissions = new List<string>();


            var d = await (await this.repository.GetDbSet())
                .AsNoTracking()
                .Where(e => e.EmployeeId.Equals(id))
                .FirstOrDefaultAsync();

            if (d != null && !string.IsNullOrEmpty(d.Access))
                permissions.AddRange(d.Access.Split(',', StringSplitOptions.RemoveEmptyEntries));

            return permissions;
        }

        public async Task<bool> HasRights(string module,string role,Guid userId)
        {
            var permission = await this.GetPermissionsAsync(userId);

            if(permission.Count>0)
            {
                var rights = permission.Where(e => e.Contains(module, StringComparison.InvariantCultureIgnoreCase)).ToList();

                if (rights !=null && rights.Any())
                {
                    var roles = rights.Where(e => e.Trim().Contains($"{module}.{role}", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                    return !string.IsNullOrEmpty(roles);

                }
            }
            return false;
        }

        public async Task<bool> HasAdminRights(string module, Guid userId)
        {
            bool hasRights = false;
            var permission = await this.GetPermissionsAsync(userId);

            if (permission.Count > 0)
            {
                var rights = permission.Where(e => e.Contains(module, StringComparison.InvariantCultureIgnoreCase)).ToList();

                if (rights != null && rights.Any())
                {
                    var adminRights = rights.Where(e => e.Contains("admin", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                    return !string.IsNullOrEmpty(adminRights);

                }
            }
            return hasRights;
        }

        public async Task<bool> HasManagementRights(string module, Guid userId)
        {
            bool hasRights = false;
            var permission = await this.GetPermissionsAsync(userId);

            if (permission.Count > 0)
            {
                var rights = permission.Where(e => e.Contains(module, StringComparison.InvariantCultureIgnoreCase)).ToList();

                if (rights != null && rights.Any())
                {
                    var managerRights = rights.Where(e => e.Contains("manager", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                    return !string.IsNullOrEmpty(managerRights);

                }
            }
            return hasRights;
        }

        public async Task ManagePermission(Guid objectId, Employee employee, string module, string role)
        {
            var permission = await this.repository.FindByConditionAsync(e => e.EmployeeId == employee.Id);
            var newPermission = $"{module}.{role}";

            if (permission != null) 
            {
                var existingPermissions = await this.GetPermissions(employee.Id);

                if (existingPermissions.Contains(newPermission))
                {
                    throw new Exception("Permission already exist.");
                }
                if(role=="admin" || role == "Admin")
                {
                    if (existingPermissions.Contains($"{module}.User"))
                        existingPermissions.Remove(module + ".User");
                }

                existingPermissions.Add(newPermission);
                permission.Access = string.Join(",", existingPermissions);
                await this.repository.Update(permission);
            }
            else
                await this.repository.Add(new Permission()
                {
                    EmployeeId = employee.Id,
                    Access = newPermission
                });

            await this.repository.SaveChangesAsync(objectId);
        }

        public async Task ManagePermission(Guid objectId, Guid employeeId, string module, string role)
        {
            var permission = await this.repository.FindByConditionAsync(e => e.EmployeeId == employeeId);
            var newPermission = $"{module}.{role}";

            if (permission != null)
            {
                var existingPermissions = await this.GetPermissions(employeeId);

                if (existingPermissions.Contains(newPermission))
                {
                    throw new Exception("Permission already exist.");
                }
                if (role == "admin" || role == "Admin")
                {
                    if (existingPermissions.Contains($"{module}.User"))
                        existingPermissions.Remove(module + ".User");
                }

                existingPermissions.Add(newPermission);
                permission.Access = string.Join(",", existingPermissions);
                await this.repository.Update(permission);
            }
            else
                await this.repository.Add(new Permission()
                {
                    EmployeeId = employeeId,
                    Access = newPermission
                });

            await this.repository.SaveChangesAsync(objectId);
        }

        public async Task RemoveRights(Guid userId, Employee employee, string module, string role)
        {
            var permission = await this.repository.FindByConditionAsync(e => e.EmployeeId == employee.Id);

            if (permission != null)
            {
                var removedPermission = $"{module}.{role}";
                var existingPermissions = await this.GetPermissions(employee.Id);
                existingPermissions.Remove(removedPermission);
                permission.Access = string.Join(",", existingPermissions);
                await this.repository.Update(permission);
                await this.repository.SaveChangesAsync(userId);
            }
            else
                throw new Exception("Permission not found.");
        }

        public async Task UpdateRights(Guid objectId, Employee employee, string module, string role, string newModule, string newRole)
        {
            var permission = await this.repository.FindByConditionAsync(e => e.EmployeeId == employee.Id);
            if (permission != null)
            {
                var permissionToUpdate = $"{module}.{role}";
                var permissionToReplace = $"{newModule}.{newRole}";
                var existingPermissions = await this.GetPermissions(employee.Id);

                existingPermissions.Remove(permissionToUpdate);
                existingPermissions.Add(permissionToReplace);

                permission.Access = string.Join(",", existingPermissions);
                await this.repository.Update(permission);
                await this.repository.SaveChangesAsync(objectId);
            }
            else
                throw new Exception("Permission not found.");
        }

        public async Task<List<string>> GetPermissions(Guid id)
        {
            var permissions = new List<string>();
            var employee = await this.repository.GetDbSet().Result.Where(e => e.EmployeeId == id).FirstOrDefaultAsync();

            if (employee != null)
                if (!string.IsNullOrEmpty(employee.Access))
                    permissions.AddRange(employee.Access.Split(',', StringSplitOptions.RemoveEmptyEntries));
            return permissions;
        }

        public async Task<DbSet<Permission>> GetDbSet()
        {
            return await this.repository.GetDbSet();
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            var permissionDb = await this.repository.GetDbSet();
            var permission = await permissionDb.Include(p=>p.Employee)
                .ToListAsync();
            
            return permission;
        }

        public async Task SetNewEmployeePermissions(Guid objectId, Guid employeeId)
        {
            await this.ManagePermission(objectId, employeeId, "Clock", "User");
            await this.ManagePermission(objectId, employeeId, "Leave", "User");
            await this.ManagePermission(objectId, employeeId, "Payroll", "User");

        }
    }
}
