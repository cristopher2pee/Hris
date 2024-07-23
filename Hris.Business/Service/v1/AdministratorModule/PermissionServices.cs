using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Business.Service.Administrator;
using Hris.Data.DTO;
using Hris.Data.Models.Administrator;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.UnitOfWork;
using Hris.Resource.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hris.Business.Service.v1.AdministratorModule
{
    public interface IPermissionServices
    {
        Task Delete(Data.Models.Administrator.Permission entity, Guid id);
        Task<Data.Models.Administrator.Permission> GetById(Guid id);
        Task<IEnumerable<Data.Models.Administrator.Permission>> GetAll();

        Task<IQueryable<Data.Models.Administrator.Permission>> GetAllByEmpId(Guid id);
        Task<Roles?> GetRoleByModule(Guid id, Modules module);
        Task<List<string>> GetPermissionsAsync(Guid userId);

        Task ManagePermission(Guid objectId, Data.Models.Employee.Employee employee, string module, string role);
        Task ManagePermission(Guid objectId, Data.Models.Employee.Employee employee, params Hris.Business.Models.Common.Permission[] permission);
        Task<List<string>> GetPermissions(Guid id);
        Task<List<PermissionDtoResponse>?> GetUserAccess(Guid id);
        Task<PagedResult_<PermissionDtoResponse>> GetAll(PermissionFilter_ filter);

        Task<List<PermissionAccessDtoResponse>?> GetUserPermissionAccess(Guid userId);
        Task<bool> UpdateRights(Guid objectId, Data.Models.Employee.Employee employee, string module, string role, string newModule, string newRole);

        Task<bool> RemoveRights(Guid userId, Data.Models.Employee.Employee employee, string module, string role);

        Task SetNewEmployeePermissions(Guid objectId, Guid employeeId);
    }
    internal class PermissionServices : IPermissionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermissionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Delete(Data.Models.Administrator.Permission entity, Guid id)
        {
            await _unitOfWork._Permission.DeleteAsync(entity);
            await _unitOfWork.SaveChangeAsync(id);
        }

        public async Task<IEnumerable<Data.Models.Administrator.Permission>> GetAll()
        {
            var permission = await _unitOfWork._Permission.GetAllAsync();
            if (permission is null) return Enumerable.Empty<Data.Models.Administrator.Permission>();
            return permission;
        }

        public async Task<IQueryable<Data.Models.Administrator.Permission>> GetAllByEmpId(Guid id)
        {
            return _unitOfWork._Permission
               .GetDbSet()
               .Where(f => f.EmployeeId.Equals(id))
               .AsQueryable();

        }
        public async Task<Data.Models.Administrator.Permission> GetById(Guid id)
        {
            return await _unitOfWork._Permission.GetByIdAsync(id);
        }

        public async Task<Roles?> GetRoleByModule(Guid id, Modules module)
        {
            try
            {
                var employeeList = await GetAllByEmpId(id);
                if (employeeList == null || !employeeList.Any())
                    throw new NullReferenceException();

                foreach (var item in employeeList)
                {
                    var roles = item.Access.Split(',', StringSplitOptions.RemoveEmptyEntries);
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
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<string>> GetPermissionsAsync(Guid userId)
        {
            var permissions = new List<string>();
            var employee = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(userId));

            if (employee != null)
            {
                var perm = await _unitOfWork._Permission.GetDbSet()
                    .AsNoTracking()
                    .Where(f => f.EmployeeId.Equals(employee.Id))
                    .FirstOrDefaultAsync();

                if (perm != null)
                {
                    if (!string.IsNullOrEmpty(perm.Access))
                    {
                        permissions.AddRange(perm.Access.Split(',', StringSplitOptions.RemoveEmptyEntries));
                    }
                }
            }
            return permissions;
        }

        public async Task ManagePermission(Guid objectId, Data.Models.Employee.Employee employee, string module, string role)
        {
            try
            {
                var permission = await _unitOfWork._Permission.FindByConditionAsync(e => e.EmployeeId == employee.Id);
                var newPermission = $"{module}.{role}";

                if (permission != null)
                {
                    var existingPermissions = await GetPermissions(employee.Id);

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
                    await _unitOfWork._Permission.UpdateAsync(permission);
                }
                else
                    await _unitOfWork._Permission.AddAsync(new Data.Models.Administrator.Permission()
                    {
                        EmployeeId = employee.Id,
                        Access = newPermission
                    });

                await _unitOfWork.SaveChangeAsync(objectId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task ManagePermission(Guid objectId, Data.Models.Employee.Employee employee, params Hris.Business.Models.Common.Permission[] permission)
        {
            try
            {
                var employeePermission = await _unitOfWork._Permission.FindByConditionAsync(e => e.EmployeeId == employee.Id);

                foreach (var perm in permission)
                {

                    var newPermission = $"{perm.Module.ToString()}.{perm.Role.ToString()}";

                    if (employeePermission != null)
                    {
                        var existingPermissions = await GetPermissions(employee.Id);

                        if (existingPermissions.Contains(newPermission))
                        {
                            throw new Exception("Permission already exist.");
                        }
                        if (perm.Role.ToString() == "admin" || perm.Role.ToString() == "Admin")
                        {
                            if (existingPermissions.Contains($"{perm.Module.ToString()}.User"))
                                existingPermissions.Remove(perm.Module.ToString() + ".User");
                        }

                        existingPermissions.Add(newPermission);
                        employeePermission.Access = string.Join(",", existingPermissions);
                        await _unitOfWork._Permission.UpdateAsync(employeePermission);
                    }
                    else
                        await _unitOfWork._Permission.AddAsync(new Data.Models.Administrator.Permission()
                        {
                            EmployeeId = employee.Id,
                            Access = newPermission
                        });

                }


                await _unitOfWork.SaveChangeAsync(objectId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<List<string>> GetPermissions(Guid id)
        {
            var permissions = new List<string>();
            var employee = await _unitOfWork._Permission.GetDbSet().
                AsNoTracking().
                FirstOrDefaultAsync(e => e.EmployeeId.Equals(id));

            if (employee != null)
                if (!string.IsNullOrEmpty(employee.Access))
                    permissions.AddRange(employee.Access.Split(',', StringSplitOptions.RemoveEmptyEntries));
            return permissions;
        }

        public async Task<List<PermissionDtoResponse>?> GetUserAccess(Guid id)
        {
            var response = new List<PermissionDtoResponse>();
            var permissions = await _unitOfWork._Permission
                .GetDbSet()
                .AsNoTracking()
                .Include(f => f.Access)
                .Where(f => f.EmployeeId.Equals(id))
                .ToListAsync();

            if (permissions is null)
                return Enumerable.Empty<PermissionDtoResponse>().ToList();

            if (permissions != null && permissions.Any())
            {
                foreach (var item in permissions)
                {
                    var roles = item.Access.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var role in roles)
                    {
                        var split = role.Split('.', StringSplitOptions.RemoveEmptyEntries);
                        response.Add(new PermissionDtoResponse
                        {
                            Id = item.Id,
                            EmployeeId = item.EmployeeId,
                            Module = split[0],
                            Role = split[1]
                        });
                    }
                }
            }
            return response;
        }

        public async Task<PagedResult_<PermissionDtoResponse>> GetAll(PermissionFilter_ filter)
        {
            try
            {
                var response = new List<PermissionDtoResponse>();
                var permissions = _unitOfWork._Permission
                    .GetDbSet()
                    .AsNoTracking()
                    .Include(p => p.Employee)
                    .AsEnumerable()
                        .Where(a => ((!string.IsNullOrEmpty(filter.Search) ? a.Employee.Firstname.Contains(filter.Search, StringComparison.OrdinalIgnoreCase) : true)
                            || (!string.IsNullOrEmpty(filter.Search) && a.Employee.Middlename != null ? a.Employee.Middlename.Contains(filter.Search, StringComparison.OrdinalIgnoreCase) : true)
                            || (!string.IsNullOrEmpty(filter.Search) ? a.Employee.Lastname.Contains(filter.Search, StringComparison.OrdinalIgnoreCase) : true)
                            || (!string.IsNullOrEmpty(filter.Search) ? a.Access.Contains(filter.Search, StringComparison.OrdinalIgnoreCase) : true))
                            && (!string.IsNullOrEmpty(filter.Module) ? a.Access.Contains(filter.Module, StringComparison.OrdinalIgnoreCase) : true)
                            && (!string.IsNullOrEmpty(filter.Role) ? a.Access.Contains(filter.Role, StringComparison.OrdinalIgnoreCase) : true))
                        .ToList();

                if (permissions != null && permissions.Any())
                {
                    foreach (var permission in permissions)
                    {
                        if ((!string.IsNullOrEmpty(filter.Module) && !permission.Access.Contains(filter.Module, StringComparison.OrdinalIgnoreCase))
                            || (!string.IsNullOrEmpty(filter.Role) && !permission.Access.Contains(filter.Role, StringComparison.OrdinalIgnoreCase)))
                            continue;

                        var roles = permission.Access.Split(',', StringSplitOptions.RemoveEmptyEntries);

                        foreach (var role in roles)
                        {
                            var split = role.Split('.', StringSplitOptions.RemoveEmptyEntries);
                            response.Add(new PermissionDtoResponse
                            {
                                Id = permission.Id,
                                EmployeeId = permission.EmployeeId,
                                Employee = permission.Employee.ToInitialEmployeeResponse_(),
                                Module = split[0],
                                Role = split[1]
                            });
                        }
                    }
                }

                return response.ToPagedList_(filter.Page, filter.Limit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<List<PermissionAccessDtoResponse>?> GetUserPermissionAccess(Guid userId)
        {
            var employee = await _unitOfWork._Employees.FindByConditionAsync(f => f.ObjectId.Equals(userId));
            if (employee is null) return null;

            if (employee.ObjectId is null) return null;

            var permissionAccess = GetPermissionsAsync(employee.ObjectId.Value).Result.ToPermissionAccessListReponse();
            if (permissionAccess is null) return Enumerable.Empty<PermissionAccessDtoResponse>().ToList(); ;

            for (int i = 0; i < permissionAccess.Count; i++)
            {
                var access = await _unitOfWork._Access.GetDbSet()
                    .AsNoTracking()
                    .Where(x => x.Module.Equals(permissionAccess[i].Module) && x.Roles.Contains(permissionAccess[i].Role))
                    .ToListAsync();

                if (access != null && access.Any())
                    foreach (var a in access)
                        permissionAccess[i].Paths.Add(a.Path);
            }
            return permissionAccess;
        }

        public async Task<bool> UpdateRights(Guid objectId, Data.Models.Employee.Employee employee, string module, string role, string newModule, string newRole)
        {
            var permission = await _unitOfWork._Permission.FindByConditionAsync(e => e.EmployeeId == employee.Id);
            if (permission != null)
            {
                var permissionToUpdate = $"{module}.{role}";
                var permissionToReplace = $"{newModule}.{newRole}";
                var existingPermissions = await this.GetPermissions(employee.Id);

                existingPermissions.Remove(permissionToUpdate);
                existingPermissions.Add(permissionToReplace);

                permission.Access = string.Join(",", existingPermissions);
                await _unitOfWork._Permission.UpdateAsync(permission);
                return await _unitOfWork.SaveChangeAsync(objectId) > 0 ? true : false;
            }
            else
                throw new Exception();
        }
        public async Task<bool> RemoveRights(Guid userId, Data.Models.Employee.Employee employee, string module, string role)
        {
            var permission = await _unitOfWork._Permission.FindByConditionAsync(e => e.EmployeeId == employee.Id);

            if (permission != null)
            {
                var removedPermission = $"{module}.{role}";
                var existingPermissions = await this.GetPermissions(employee.Id);
                existingPermissions.Remove(removedPermission);
                permission.Access = string.Join(",", existingPermissions);
                await _unitOfWork._Permission.UpdateAsync(permission);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            else
                throw new Exception();
        }


        public async Task SetNewEmployeePermissions(Guid objectId, Guid employeeId)
        {
            var emp = await _unitOfWork._Employees.GetByIdAsync(employeeId);

            await this.ManagePermission(objectId, emp, new Hris.Business.Models.Common.Permission { Module = Modules.Clock, Role = Roles.User },
            new Hris.Business.Models.Common.Permission { Module = Modules.Leave, Role = Roles.User },
            new Hris.Business.Models.Common.Permission { Module = Modules.Payroll, Role = Roles.User });


        }
    }
}
