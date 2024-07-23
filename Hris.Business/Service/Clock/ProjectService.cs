using Hris.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hris.Data.Models.Clock;
using System.Linq.Expressions;
using Hris.Business.Extensions;
using Microsoft.IdentityModel.Tokens;
using Hris.Data.Models.Employee;

namespace Hris.Business.Service.Clock
{
    public class ProjectService
    {
        private readonly IRepository<Project> repository;
        private readonly IRepository<ProjectTask> taskRepository;
        private readonly IRepository<AssignedProject> assignRepository;

        public ProjectService(IRepository<Project> repository,
            IRepository<ProjectTask> taskRepository,
            IRepository<AssignedProject> assignRepository)
        {
            this.repository = repository;
            this.taskRepository = taskRepository;
            this.assignRepository = assignRepository;
        }

        public async Task<int> GetCount()
            => await repository.GetCount();

        public async Task<Project?> GetById(Guid id)
            => (await repository.GetDbSet())
                .Where(d => d.Id.Equals(id))
                .FirstOrDefault();

        public async Task<IEnumerable<Project>> GetByClientId(Guid id)
            => (await repository.GetDbSet())
                .Where(d => d.ClientId.Equals(id))
                .ToList();

        public async Task<(IEnumerable<Project> list, int total)> Get(int? page = null, int? limit = null, string? search = null, Guid? clientId = null)
        {
            var q = (await repository.GetDbSet())
                .Include(d => d.Client)
                .AsEnumerable()
                .Where(d => d.Active)
                .Where(d => (!search.IsNullOrEmpty() ? d.Name.Has(search) : true)
                    && (clientId != null ? clientId.Equals(d.ClientId) : true));

            return (!page.HasValue && !limit.HasValue ? q :
                        q.Skip((page.Value - 1) * limit.Value)
                            .Take(limit.Value), q.Count());
        }

        public async Task<Project> Add(Project d, Guid userId)
        {
            try
            {
                d = await repository.Add(d);
                await SaveChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Project> Update(Project d, Guid userId)
        {
            try
            {
                d = await repository.Update(d);
                await SaveChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Project> Deactivate(Project d, Guid userId)
        {
            try
            {
                d.Active = false;
                return await Update(d, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveChangesAsync(Guid projectId)
            => await repository.SaveChangesAsync(projectId);

        // Task

        public async Task<ProjectTask?> GetTaskById(Guid taskId)
            => (await taskRepository.GetDbSet())
                .Where(d => d.Id.Equals(taskId))
                .FirstOrDefault();

        public async Task<IEnumerable<ProjectTask>> GetTasksByCondition(Expression<Func<ProjectTask, bool>> whereExp)
            => await (await taskRepository.GetDbSet())
                .Where(whereExp)
                .ToListAsync();

        public async Task<ProjectTask> AddTask(ProjectTask d, Guid userId)
        {
            try
            {
                d = await taskRepository.Add(d);
                await SaveTaskChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProjectTask> UpdateTask(ProjectTask d, Guid userId)
        {
            try
            {
                d = await taskRepository.Update(d);

                // Check Sub Tasks
                var subTasks = await GetTasksByCondition(t => t.ParentTaskId.Equals(d.Id));
                if (subTasks != null) 
                { 
                    foreach (var subTask in subTasks)
                    {
                        subTask.ParentTaskId = d.ParentTaskId;
                        await taskRepository.Update(subTask);
                    }
                }

                await SaveTaskChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProjectTask>> GetTasksByProjectId(Guid id)
             => (await taskRepository.GetDbSet())
                .Where(d => d.Active)
                .Where(d => d.ProjectId.Equals(id) && d.ParentTaskId == null);

        public async Task<IEnumerable<ProjectTask>> GetSubTaskByTaskId(Guid id, Guid taskId)
             => (await taskRepository.GetDbSet())
                .Where(d => d.Active)
                .Where(d => d.ProjectId.Equals(id) && (d.ParentTaskId != null && d.ParentTaskId.Equals(taskId)));

        public async Task<ProjectTask> DeactivateTask(ProjectTask d, Guid userId)
        {
            try
            {
                d.Active = false;
                return await UpdateTask(d, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveTaskChangesAsync(Guid projectId)
            => await taskRepository.SaveChangesAsync(projectId);

        // Assign

        public async Task<(IEnumerable<IGrouping<Employee, AssignedProject>> list, int total)> GetAssignedProjects(int? page = null, int? limit = null, string? search = null, Guid? clientId = null, Guid? projectId = null, Guid? taskId = null)
        {

            var q = (await assignRepository.GetDbSet())
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
                .ToList();


            return (!page.HasValue && !limit.HasValue ? q :
                q.Skip((page.Value - 1) * limit.Value)
                    .Take(limit.Value), q.Count());
        }

        public async Task<IQueryable<IGrouping<Project, AssignedProject>>> GetAssignedProjectAndTaskById(Guid id, string? search = null)
            => (await assignRepository.GetDbSet())
                .AsNoTracking()
                .Include(d => d.Project)
                .Include(d => d.Task)
                .Where(d => d.EmployeeId.Equals(id) && (search != null 
                    && !string.IsNullOrEmpty(search) ? d.Task.Name.ToLower().Contains(search.ToLower()) : true))
                .GroupBy(d => d.Project);

        public async Task<IQueryable<IGrouping<Project, ProjectTask>>> GetAvailableProjectAndTask(Guid id, string? search = null)
        {
            var x = (await assignRepository.GetDbSet())
                .AsNoTracking()
                .Include(d => d.Project)
                .Include(d => d.Task)
                .Where(d => d.EmployeeId.Equals(id));

            return (await taskRepository.GetDbSet())
                .AsNoTracking()
                .Include(d => d.Project)
                .Where(d => !x.Any(a => a.TaskId.Equals(d.Id)) || x.Any(a => a.Task.ParentTaskId.Equals(d.Id)))
                .Where(d => search != null && !string.IsNullOrEmpty(search) 
                    ? d.Name.ToLower().Contains(search.ToLower()) : true)
                .GroupBy(d => d.Project);
        }

        private async Task<AssignedProject?> GetAssignedTask(Guid id, Guid taskId)
            => (await assignRepository.GetDbSet())
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

                var t = (await taskRepository.GetDbSet())
                    .AsNoTracking()
                    .Include(d => d.Project)
                    .Where(d => d.Id.Equals(taskId))
                    .FirstOrDefault();

                if (t == null)
                    throw new NullReferenceException();

                // Check & Add Parent Task
                if(t.ParentTaskId != null)
                {
                    var aP = await GetAssignedTask(id, t.ParentTaskId.Value);

                    if(aP == null)
                        await AddAssignedProject(new AssignedProject
                        {
                            EmployeeId = id,
                            ClientId = t.Project.ClientId,
                            ProjectId = t.Project.Id,
                            TaskId = t.ParentTaskId.Value
                        }, userId);
                }
                else // Check and Add Sub Tasks
                {
                    var sTs = (await taskRepository.GetDbSet())
                        .AsNoTracking()
                        .Include(d => d.Project)
                        .Where(d => d.ParentTaskId.Equals(taskId));

                    foreach(var sT in sTs)
                    {
                        var sTa = await GetAssignedTask(id, sT.Id);

                        if (sTa == null)
                            await AddAssignedProject(new AssignedProject
                            {
                                EmployeeId = id,
                                ClientId = t.Project.ClientId,
                                ProjectId = t.Project.Id,
                                TaskId = sT.Id
                            }, userId);
                    }
                }

                return await AddAssignedProject(new AssignedProject
                {
                    EmployeeId = id,
                    ClientId = t.Project.ClientId,
                    ProjectId = t.ProjectId.Value,
                    TaskId = t.Id
                }, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                var t = (await taskRepository.GetDbSet())
                    .AsNoTracking()
                    .Where(d => d.ParentTaskId.Equals(a.TaskId));
                
                if(t != null && t.Any())
                {
                    var subA = (await assignRepository.GetDbSet())
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
                throw new Exception(ex.Message);
            }
        }

        public async Task<AssignedProject?> GetAssignedProjectById(Guid id)
         => (await assignRepository.GetDbSet())
             .Where(d => d.Id.Equals(id))
             .FirstOrDefault();

        public async Task<AssignedProject> AddAssignedProject(AssignedProject d, Guid userId)
        {
            try
            {
                d = await assignRepository.Add(d);
                await SaveTaskChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AssignedProject> UpdateAssignedProject(AssignedProject d, Guid userId)
        {
            try
            {
                d = await assignRepository.Update(d);
                await SaveAssignedProjectChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AssignedProject> RemoveAssignedProject(AssignedProject d, Guid userId)
        {
            try
            {
                d = await assignRepository.Delete(d);
                await SaveAssignedProjectChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveAssignedProjectChangesAsync(Guid projectId)
            => await assignRepository.SaveChangesAsync(projectId);

        // Old

        public async Task<DbSet<Project>> GetDbSet()
        {
            return await repository.GetDbSet();
        }

        public async Task<IEnumerable<Project>> GetByCondition(Expression<Func<Project, bool>> whereExp)
            => await (await repository.GetDbSet())
                .Where(whereExp)
                .ToListAsync();

        public async Task<IEnumerable<Project>> GetAll()
        {
            var projectDb = await repository.GetDbSet();
            var project = await projectDb.Include(p => p.Client)
                    .Include(p => p.Tasks)
                    .ToListAsync();

            return project;
        }

        public async Task<Project> GetProjectById(Guid projectId)
        {
            var project = (await repository.GetDbSet()).Include(p => p.Client)
                    .Include(p => p.Tasks)
                    .Where(p => p.Id == projectId)
                    .FirstOrDefault();
            return project;
        }
        public async Task Delete(Project project)
        {
            await repository.Delete(project);
        }
    }
}
