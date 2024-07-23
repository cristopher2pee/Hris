using Hris.Business.Extensions;
using Hris.Data.DTO;
using Hris.Data.Models.Clock;
using Hris.Data.UnitOfWork;
using Hris.Resource.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignedProject = Hris.Data.Models.Clock.AssignedProject;
using Project = Hris.Data.Models.Clock.Project;

namespace Hris.Business.Service.v1.ClockModule
{
    public interface IAssignedProjectServices
    {
        Task<bool> Delete(Guid assignedProjectId, Guid id);
        Task<Data.Models.Clock.AssignedProject> GetById(Guid id);
        Task<IEnumerable<Data.Models.Clock.AssignedProject>> GetAll();
        Task<Data.Models.Clock.AssignedProject?> Add(AssignedProjectDtoRequest entity, Guid id);
        Task<Data.Models.Clock.AssignedProject?> Update(AssignedProjectDtoRequest entity, Guid id);
        Task<IEnumerable<AssignedProjectDtoResponse>> GetAssignedProjects(BaseFilter_ filter);
        Task<IEnumerable<AssignedProjectDtoResponse>> GetAssignedProjectAndTaskById(Guid id, string search);
        Task<IEnumerable<AssignedProjectDtoResponse>> GetAvailableProjectAndTask(Guid id, string search);

        Task<AssignedProject> AssignTask(Guid id, Guid taskId, Guid userId);

        Task<AssignedProject> UnassignTask(Guid id, Guid taskId, Guid userId);


        //  Task<IEnumerable<Assign>>
    }
    internal class AssignedProjectServices : IAssignedProjectServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public AssignedProjectServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Data.Models.Clock.AssignedProject?> Add(AssignedProjectDtoRequest entity, Guid id)
        {
            try
            {
                var res = await _unitOfWork._AssignedProject.AddAsync(new Data.Models.Clock.AssignedProject
                {
                    EmployeeId = entity.EmployeeId,
                    ClientId = entity.ClientId,
                    ProjectId = entity.ProjectId,
                    TaskId = entity.TaskId,
                    Active = true
                });

                if (res is null) return null;
                return await _unitOfWork.SaveChangeAsync(id) > 0 ? res : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> Delete(Guid assignedProjectId, Guid id)
        {
            try
            {
                var entity = await GetById(assignedProjectId);
                await _unitOfWork._AssignedProject.DeleteAsync(entity);
                return await _unitOfWork.SaveChangeAsync(id) > 0 ? true : false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<IEnumerable<Data.Models.Clock.AssignedProject>> GetAll()
        {
            var projects = await _unitOfWork._AssignedProject.GetAllAsync();
            if(projects is null) return Enumerable.Empty<Data.Models.Clock.AssignedProject>();
            return projects;
        }

        public async Task<Data.Models.Clock.AssignedProject> GetById(Guid id)
        {
            return await _unitOfWork._AssignedProject.GetByIdAsync(id);
        }

        public async Task<Data.Models.Clock.AssignedProject?> Update(AssignedProjectDtoRequest req, Guid id)
        {
            try
            {
                var entity = await _unitOfWork._AssignedProject.GetByIdAsync(req.Id);
                if (entity == null) return null;

                entity.EmployeeId = req.EmployeeId;
                entity.ClientId = req.ClientId;
                entity.ProjectId = req.ProjectId;
                entity.TaskId = req.TaskId;

                var res = await _unitOfWork._AssignedProject.UpdateAsync(entity);
                if (res is null) return null;

                return await _unitOfWork.SaveChangeAsync(id) > 0 ? res : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            //throw new NotImplementedException();
        }

        private async Task<(IEnumerable<IGrouping<Hris.Data.Models.Employee.Employee, AssignedProject>> list, int total)> processGetAssignedProject
            (int? page = null, int? limit = null, string? search = null, Guid? clientId = null, Guid? projectId = null, Guid? taskId = null)
        {

            var dataList = await _unitOfWork._AssignedProject.GetDbSet()
                .Include(d => d.Employee)
                .Include(d => d.Project)
                .Include(d => d.Task)
                                .Where(d => (!search.IsNullOrEmpty() ?
                        d.Employee != null ?
                            d.Employee.Firstname.Contains(search.ToLower())
                            || (d.Employee.Middlename != null ? d.Employee.Middlename.ToLower().Contains(search.ToLower()) : false)
                            || d.Employee.Lastname.ToLower().Contains(search.ToLower())
                        : false
                    : true))
                .GroupBy(d => d.Employee)
                .ToListAsync();

            return (!page.HasValue && !limit.HasValue ? dataList :
                dataList.Skip((page.Value - 1) * limit.Value).Take(limit.Value), dataList.Count());
        }

        public async Task<IEnumerable<AssignedProjectDtoResponse>> GetAssignedProjects(BaseFilter_ filter)
        {
            var processData = await processGetAssignedProject(filter.Page, filter.Limit, filter.Search);

            var assinedPrjList = processData.list.Select(e =>
            {
                var groupProj = e.GroupBy(d => d.Project);
                return new AssignedProjectDtoResponse
                {
                    Id = e.Key.Id,
                    EmployeeId = e.Key.Id,
                    Employee = e.Key.ToResponse_(),
                    ProjectsStr = string.Join(',', groupProj.Take(3).Select(d => d.Key.Name))
                        + (groupProj.Count() > 3 ? "..." : null),
                    TasksStr = string.Join(",", groupProj.Take(3)
                        .Select(p => p.Select(d => d.Task.Name).First()))
                };
            });

            return assinedPrjList;
        }

        public async Task<IEnumerable<AssignedProjectDtoResponse>> GetAssignedProjectAndTaskById(Guid id, string search)
        {
            try
            {
                var processData = await processAssignedProjectAndTaskById(id, search);
                var resultData = processData.AsEnumerable().Select(item =>
                {
                    return new AssignedProjectDtoResponse
                    {
                        Project = item.First().Project.ToProjectDtoResponse(),
                        Tasks = item.Where(t => t.Task.ParentTaskId == null)
                            .OrderBy(f => f.Task.Name)
                            .Select(f =>
                            {
                                var sub = item.Where(st => st.Task.ParentTaskId.Equals(f.Task.Id))
                                    .Select(st => st.Task.ToTaskDtoResponse()).ToList();
                                return new TaskDtoResponse
                                {
                                    Id = f.Task.Id,
                                    Name = f.Task.Name,
                                    SubTasks = sub
                                };
                            })
                    };

                });

                return resultData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task<IQueryable<IGrouping<Project, AssignedProject>>> processAssignedProjectAndTaskById(Guid id, string? search = null)
        {
            var resultTask = _unitOfWork._AssignedProject.GetDbSet()
                .AsNoTracking()
                .Include(d => d.Project)
                .Include(d => d.Task)
                .Where(d => d.EmployeeId.Equals(id) && (search != null
                    && !string.IsNullOrEmpty(search) ? d.Task.Name.ToLower().Contains(search.ToLower()) : true));

            if (search == null)
                return resultTask.GroupBy(d => d.Project);


            var resultParentTask = _unitOfWork._AssignedProject.GetDbSet()
                .AsNoTracking()
                .Include(d => d.Project)
                .Include(d => d.Task)
                .Where(d => d.EmployeeId.Equals(id) && resultTask.Any(e => e.Task.ParentTaskId.Equals(d.Task.Id)));


            return resultTask.Union(resultParentTask).GroupBy(d => d.Project); ;
        }

        private async Task<IQueryable<IGrouping<Data.Models.Clock.Project, Data.Models.Clock.ProjectTask>>> processAvailableProjectAndTask(Guid id, string? search = null)
        {
            var assigProject = _unitOfWork._AssignedProject.GetDbSet()
                    .AsNoTracking()
                    .Include(d => d.Project)
                    .Include(d => d.Task)
                    .Where(d => d.EmployeeId.Equals(id));

            var returnData = _unitOfWork._ProjectTask.GetDbSet()
                     .AsNoTracking()
                     .Include(d => d.Project)
                     .Where(d => !assigProject.Any(a => a.TaskId.Equals(d.Id)) || assigProject.Any(a => a.Task.ParentTaskId.Equals(d.Id)))
                     .Where(d => search != null && !string.IsNullOrEmpty(search)
                            ? d.Name.ToLower().Contains(search.ToLower()) : true)
                      .GroupBy(d => d.Project);

            return returnData;
        }

        public async Task<IEnumerable<AssignedProjectDtoResponse>> GetAvailableProjectAndTask(Guid id, string search)
        {
            var x = await processAvailableProjectAndTask(id, search);
            var y = x.AsEnumerable().Select(d =>
            {

                return new AssignedProjectDtoResponse
                {
                    Project = d.First().Project.ToProjectDtoResponse(),
                    Tasks = d.Where(t => t.ParentTaskId == null)
                        .OrderBy(t => t.Name)
                        .Select(t =>
                        {
                            var sub = d.Where(st => st.ParentTaskId.Equals(t.Id)).Select(st => st.ToTaskDtoResponse()).ToList();
                            return new TaskDtoResponse
                            {
                                Id = t.Id,
                                Name = t.Name,
                                SubTasks = sub
                            };
                        })
                        .ToList()
                };
            });

            return y;
        }

        private async Task<AssignedProject?> GetAssignedTask(Guid id, Guid taskId)
            => _unitOfWork._AssignedProject.GetDbSet()
                .AsNoTracking()
                .Where(d => d.EmployeeId.Equals(id) && d.TaskId.Equals(taskId))
                .FirstOrDefault();

        public async Task<AssignedProject> AssignTask(Guid id, Guid taskId, Guid userId)
        {
            try
            {
               var a = await GetAssignedTask(id, taskId);

                if (a != null)
                    throw new Exception("Task already assigned to Employee.");

                var t = await _unitOfWork._ProjectTask.GetDbSet()
                    .AsNoTracking()
                    .Include(d => d.Project)
                    .Where(d => d.Id.Equals(taskId))
                    .FirstOrDefaultAsync();

                if (t == null)
                    throw new NullReferenceException();

                if (t.ParentTaskId != null)
                {
                    var aP = await GetAssignedTask(id, t.ParentTaskId.Value);
                    if(aP == null)
                    {
                        await _unitOfWork._AssignedProject.AddAsync(new AssignedProject
                        {
                            EmployeeId = id,
                            ClientId = t.Project.ClientId,
                            ProjectId = t.Project.Id,
                            TaskId = t.ParentTaskId.Value
                        });
                        await _unitOfWork.SaveChangeAsync(userId);
                    }
                }
                else
                {
                    var sTs = _unitOfWork._ProjectTask.GetDbSet()
                         .AsNoTracking()
                         .Include(d => d.Project)
                         .Where(d => d.ParentTaskId.Equals(taskId));

                    foreach (var sT in sTs)
                    {
                        var sTa = await GetAssignedTask(id, sT.Id);

                        if (sTa == null)
                        {
                            await _unitOfWork._AssignedProject.AddAsync(new AssignedProject
                            {
                                EmployeeId = id,
                                ClientId = t.Project.ClientId,
                                ProjectId = t.Project.Id,
                                TaskId = sT.Id
                            });
                            await _unitOfWork.SaveChangeAsync(userId);
                        }
                    }
                }

                var result = await _unitOfWork._AssignedProject.AddAsync(new AssignedProject
                {
                    EmployeeId = id,
                    ClientId = t.Project.ClientId,
                    ProjectId = t.ProjectId.Value,
                    TaskId = t.Id
                });

                await _unitOfWork.SaveChangeAsync(userId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task<AssignedProject> RemoveAssignedProject(AssignedProject d, Guid userId)
        {
            try
            {
                d = await _unitOfWork._AssignedProject.DeleteAsync(d);
                await _unitOfWork.SaveChangeAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<AssignedProject> UnassignTask(Guid id, Guid taskId, Guid userId)
        {
            try
            {
                var a = await GetAssignedTask(id, taskId);

                if (a == null)
                    throw new NullReferenceException();

                // Check Sub Task
                var t = _unitOfWork._ProjectTask.GetDbSet()
                    .AsNoTracking()
                    .Where(d => d.ParentTaskId.Equals(a.TaskId));

                if (t != null && t.Any())
                {
                    var subA = _unitOfWork._AssignedProject.GetDbSet()
                        .AsNoTracking()
                        .Where(d => d.EmployeeId.Equals(id) && t.Any(t => t.Id.Equals(d.TaskId)));
                    foreach (var s in subA)
                        await RemoveAssignedProject(s, userId);
                }
                //

                return await RemoveAssignedProject(a, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
