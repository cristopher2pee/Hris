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
    public interface IProjectTaskServices
    {
        Task<TaskDtoResponse> GetById(Guid id);
        Task<ProjectTask> UpdateTask(ProjectTask d, Guid userId);
        Task<TaskDtoResponse> DeactivateTask(Guid id, Guid userId);

        Task<TaskDtoResponse?> Add(ProjectTaskDtoRequest request,Guid projectId, Guid userId);
        Task<TaskDtoResponse?> Update(ProjectTaskDtoRequest request, Guid projectId, Guid userId);
        Task<TaskDtoResponse?> Delete(Guid id, Guid userId);
        Task<IEnumerable<TaskDtoResponse>> GetTasksByProjectId(Guid id);
        Task<IEnumerable<TaskDtoResponse>> GetSubTaskByTaskId(Guid id, Guid taskId);

        Task<IEnumerable<TaskDtoResponse>> GetTask(Guid id, string search);
    }
    internal class ProjectTaskServices : IProjectTaskServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectTaskServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskDtoResponse?> Add(ProjectTaskDtoRequest request,Guid projectId, Guid userId)
        {
            try
            {
                var toAdd = await _unitOfWork._ProjectTask.AddAsync(new ProjectTask
                {
                    ProjectId = projectId,
                    Name = request.Name,
                    IsBillable = request.IsBillable,
                    ParentTaskId = request.ParentTaskId,
                    Active = true,
                    Amount = request.Amount,
                    IsCustom = request.IsCustom,
                    Rate = request.Rate,
                });

                if (toAdd is null) return null;
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toAdd.ToTaskDtoResponse() : null;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<TaskDtoResponse> DeactivateTask(Guid id, Guid userId)
        {
            try
            {
                var d = await _unitOfWork._ProjectTask.GetByIdAsync(id);
                d.Active = false;
                var result =  await UpdateTask(d, userId);
                return result.ToTaskDtoResponse();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<TaskDtoResponse?> Delete(Guid id, Guid userId)
        {
            try
            {
                var toDelete = await _unitOfWork._ProjectTask.GetByIdAsync(id);
                if (toDelete is null) return null;
                await _unitOfWork._ProjectTask.DeleteAsync(toDelete);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toDelete.ToTaskDtoResponse() : null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<TaskDtoResponse> GetById(Guid id)
        {
            var result = await _unitOfWork._ProjectTask.GetByIdAsync(id);
            return result.ToTaskDtoResponse();
        }

        public async Task<IEnumerable<TaskDtoResponse>> GetSubTaskByTaskId(Guid id, Guid taskId)
        {
            var result = await _unitOfWork._ProjectTask.FindListByConditionAsync(d => d.Active && d.ProjectId.Equals(id)
                && (d.ParentTaskId != null && d.ParentTaskId.Equals(taskId)));

            if(result is null) return Enumerable.Empty<TaskDtoResponse>();
            return result.ToTaskDtoResponseList();
        }

        public async Task<IEnumerable<TaskDtoResponse>> GetTask(Guid id, string search)
        {
            var result = await _unitOfWork._ProjectTask.FindListByConditionAsync(f => f.ProjectId.Equals(id));
            if(result is null) Enumerable.Empty<TaskDtoResponse>();
            return result!.AsEnumerable().Where(t => search != null ? t.Name.Contains(search, StringComparison.OrdinalIgnoreCase) : true)
                .ToList().ToTaskDtoResponseList();
        }

        public async Task<IEnumerable<TaskDtoResponse>> GetTasksByProjectId(Guid id)
        {
            var result = await _unitOfWork._ProjectTask
                .FindListByConditionAsync(d => d.Active && d.ProjectId.Equals(id) 
                    && d.ParentTaskId == null);

            if(result is null) Enumerable.Empty<TaskDtoResponse>();
            return result.ToTaskDtoResponseList();
        }

        public async Task<TaskDtoResponse?> Update(ProjectTaskDtoRequest request, Guid projectId, Guid userId)
        {
            try
            {
                var toEdit = await _unitOfWork._ProjectTask.GetByIdAsync(request.Id);
                if (toEdit is null) return null;

                toEdit.Name = request.Name;
                toEdit.IsBillable = request.IsBillable;
                toEdit.ParentTaskId = request.ParentTaskId;
                toEdit.ProjectId = projectId;

                await _unitOfWork._ProjectTask.UpdateAsync(toEdit);
                return await _unitOfWork.SaveChangeAsync(userId) > 0 ? toEdit.ToTaskDtoResponse() : null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ProjectTask> UpdateTask(ProjectTask d, Guid userId)
        {
            try
            {
                d = await _unitOfWork._ProjectTask.UpdateAsync(d);
               
                var subTasks = await _unitOfWork._ProjectTask.FindListByConditionAsync(f => f.ParentTaskId.Equals(d.Id));
                if(subTasks != null)
                {
                    foreach (var subTask in subTasks)
                    {
                        subTask.ParentTaskId = d.ParentTaskId;
                        await _unitOfWork._ProjectTask.UpdateAsync(subTask);
                    }
                }

                await _unitOfWork.SaveChangeAsync(userId);
                return d;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


    }
}
