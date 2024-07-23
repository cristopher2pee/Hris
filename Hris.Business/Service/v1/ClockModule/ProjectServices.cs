using Hris.Business.Extensions;
using Hris.Business.Models.Common;
using Hris.Data.DTO;
using Hris.Data.Models.Clock;
using Hris.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.v1.ClockModule
{
    public interface IProjectServices
    {
        Task<IEnumerable<Project>> GetResources();
        Task<IEnumerable<ProjectTask>> GetTaskResources();

        Task<ProjectDtoResponse> GetByClientId(Guid id);
        Task<PagedResult_<ProjectDtoResponse>> GetAll(ProjectFilter_ filter);
        Task<ProjectDtoResponse> GetById(Guid id);

        Task<ProjectDtoResponse?> Add(ProjectDtoRequest req, Guid userId);
        Task<ProjectDtoResponse?> Update(ProjectDtoRequest req, Guid userId);

        Task<ProjectDtoResponse?> Delete(Guid id, Guid userId);

        Task<bool> DuplicateProject(Guid projectId, Guid userId);

        Task<bool> DeleteProject(Guid projectId, Guid userId);

    }
    internal class ProjectServices : IProjectServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ProjectDtoResponse?> Add(ProjectDtoRequest request, Guid userId)
        {
            try
            {
                var toAddEntity = await _unitOfWork._Project.AddAsync(new Data.Models.Clock.Project
                {
                    Name = request.Name,
                    ClientId = request.ClientId,
                    Description = request.Description,
                    Active = true,
                    Tasks = request.Tasks != null ? request.Tasks.Select(t => new Data.Models.Clock.ProjectTask
                    {
                        Name = t.Name,
                        IsBillable = t.IsBillable,
                        ParentTaskId = t.ParentTaskId,
                        Active = true
                    }).ToList() : null
                });

                if (toAddEntity == null) return null;
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toAddEntity.ToProjectDtoResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ProjectDtoResponse?> Delete(Guid id, Guid userId)
        {
            try
            {
                var toDelete = await _unitOfWork._Project.GetByIdAsync(id);
                if (toDelete == null) return null;
                await _unitOfWork._Project.DeleteAsync(toDelete);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toDelete.ToProjectDtoResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagedResult_<ProjectDtoResponse>> GetAll(ProjectFilter_ filter)
        {
            var result = await _unitOfWork._Project.GetDbSet().Include(d => d.Client)
                .AsNoTracking()
                .Where(f => (filter.Search != string.Empty ? f.Name.ToLower().Contains(filter.Search.ToLower()) : true)
                    && (filter.ClientId != null && filter.ClientId != Guid.Empty ? f.ClientId.Equals(filter.ClientId) : true))
                .OrderBy(f => f.Name)
                .ToListAsync();
            return result.ToProjectDtoResponseList().ToPagedList_(filter.Page, filter.Limit);
        }

        public async Task<ProjectDtoResponse> GetByClientId(Guid id)
        {
            var result = await _unitOfWork._Project.FindByConditionAsync(f => f.ClientId.Equals(id));
            return result.ToProjectDtoResponse();
        }

        public async Task<ProjectDtoResponse> GetById(Guid id)
        {
            var result = await _unitOfWork._Project.GetByIdAsync(id);
            return result.ToProjectDtoResponse();
        }

        public async Task<IEnumerable<Project>> GetResources()
        {
            var project = await _unitOfWork._Project.GetDbSet()
             .AsNoTracking()
             .ToListAsync();

            if (project is null) return Enumerable.Empty<Project>();
            return project;
        }

        public async Task<IEnumerable<ProjectTask>> GetTaskResources()
        {
            var task = await _unitOfWork._ProjectTask.GetDbSet()
             .AsNoTracking()
             .ToListAsync();

            if (task is null) return Enumerable.Empty<ProjectTask>();
            return task;
        }

        public async Task<ProjectDtoResponse?> Update(ProjectDtoRequest req, Guid userId)
        {
            try
            {
                var toUpdate = await _unitOfWork._Project.GetByIdAsync(req.Id);
                if (toUpdate is null) return null;
                toUpdate.Name = req.Name;
                toUpdate.Description = req.Description;
                toUpdate.ClientId = req.ClientId;

                await _unitOfWork._Project.UpdateAsync(toUpdate);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toUpdate.ToProjectDtoResponse() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeleteProject(Guid projectId, Guid userId)
        {
            try
            {
                var resultProject = await _unitOfWork._Project.GetByIdAsync(projectId);
                if (resultProject is null) return false;

                await _unitOfWork._Project.DeleteAsync(resultProject);

                var projectTask = await _unitOfWork._ProjectTask.GetDbSet()
                    .Where(f => f.ProjectId.Equals(projectId))
                    .ToListAsync();

                if (projectTask is not null && projectTask.Any())
                {
                    await _unitOfWork._ProjectTask.DeleteRange(projectTask.ToArray());
                }

                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            // return false;
        }
        public async Task<bool> DuplicateProject(Guid projectId, Guid userId)
        {
            try
            {
                var result = await _unitOfWork._Project.GetDbSet()
                    .AsNoTracking()
                    .Include(f => f.Tasks)
                    .Where(f => f.Id.Equals(projectId))
                    .FirstOrDefaultAsync();

                if (result is null) return false;

                var resProject = await SaveProject(new Project
                {
                    Name = result.Name + " - copy",
                    Description = result.Description,
                    ClientId = result.ClientId,
                    Active = result.Active,
                }, userId);

                if (resProject is null) return false;

                if (result.Tasks.Any())
                {
                    var parentTask = result.Tasks.Where(f => f.ParentTaskId is null).ToList();
                    if (parentTask is not null && parentTask.Any())
                    {

                        foreach (var item in parentTask)
                        {
                            var resTaskParent = await SaveProjectTask(new ProjectTask
                            {
                                Name = item.Name,
                                IsBillable = item.IsBillable,
                                ProjectId = resProject.Id,
                                Active = true
                            }, userId);

                            var childTask = result.Tasks.Where(f => f.ParentTaskId.Equals(item.Id)).ToList();

                            if (resTaskParent is not null && childTask is not null && childTask.Any())
                            {
                                foreach (var childItem in childTask)
                                {
                                    var resChildTask = await SaveProjectTask(new ProjectTask
                                    {
                                        Name = childItem.Name,
                                        IsBillable = childItem.IsBillable,
                                        ProjectId = resProject.Id,
                                        ParentTaskId = resTaskParent.Id,
                                        Active = true
                                    }, userId);
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task<Project?> SaveProject(Project project, Guid userId)
        {
            try
            {
                var entity = await _unitOfWork._Project.AddAsync(project);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? entity : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task<ProjectTask?> SaveProjectTask(ProjectTask project, Guid userId)
        {
            try
            {
                var result = await _unitOfWork._ProjectTask.AddAsync(project);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? result : null;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


    }
}
