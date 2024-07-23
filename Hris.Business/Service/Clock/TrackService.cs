using Hris.Business.Extensions;
using Hris.Data.Models.Clock;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Enum;
using Hris.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Hris.Business.Service.Clock
{
    public class TrackService
    {
        private readonly IRepository<Track> repository;

        public TrackService()
        {
            
        }

        public TrackService(IRepository<Track> repository)
            => this.repository = repository;

        public async Task<Track?> GetById(Guid id)
            => await (await GetDbSet())
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

        public async Task<Track?> GetCurrent(Guid objId)
            => await (await GetDbSet())
                .AsNoTracking()
                .Include(d => d.Employee)
                .Where(d => d.Employee.ObjectId.Equals(objId) && d.End == null)
                .FirstOrDefaultAsync();

        public async Task<Track> Add(Track d, Guid userId)
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

        public async Task<Track> Update(Track d, Guid userId)
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


        // SAVE
        public async Task SaveChangesAsync(Guid userId)
            => await repository.SaveChangesAsync(userId);

        public async Task<(IEnumerable<Track> list, int total)> GetRequest(int? page = null, int? limit = null, string? search = null, ChangeStatus? status = null)
        {
            var q = (await repository.GetDbSet())
                .AsNoTracking()
                .Include(d => d.Project)
                .Include(d => d.Task)
                .Include(d => d.Employee)
                .Include(d => d.ParentTrack)
                    .ThenInclude(d => d.Project)
                .AsEnumerable()
                .Where(d => (!search.IsNullOrEmpty() && d.Employee != null ? d.Employee.Firstname.Has(search)
                            || (d.Employee.Middlename != null && d.Employee.Middlename.Has(search))
                            || d.Employee.Lastname.Has(search)
                        : true)
                    && d.ParentTrackId != null
                    && (status != null ? d.ChangeStatus.Equals(status) : d.ChangeStatus == ChangeStatus.Pending));

            return (!page.HasValue && !limit.HasValue ? q :
                        q.Skip((page.Value - 1) * limit.Value)
                            .Take(limit.Value), q.Count());
        }

        public async Task<Track> ManageRequest(Employee e, Track d, Track t, bool isApproved, Guid userId)
        {
            t.IsPending = d.IsPending = false;
            t.ApproverId = d.ApproverId = e.Id;

            if (isApproved)
            {
                t.Type = TrackType.Clock;
                t.Start = d.Start;
                t.End = d.End;
                t.ProjectId = d.ProjectId;
                t.TaskId = d.TaskId;
                t.ChangeStatus = ChangeStatus.Approved;
            }
            else
            {
                t.ChangeStatus = d.ChangeStatus = ChangeStatus.Declined;
                if (t.Type == TrackType.Manual)
                    t.IsPending = true;
            }

            await Update(t, userId);
            await Update(d, userId);
            return d;
        }

        // Old

        // GET
        public async Task<DbSet<Track>> GetDbSet()
            => await repository.GetDbSet();

        public async Task<IEnumerable<Track>> GetAll()
            => await repository.GetAllAsync();

        public async Task<IEnumerable<Track>> GetByCondition(Expression<Func<Track, bool>> whereExp)
            => await (await GetDbSet())
                .Where(whereExp)
                .ToListAsync();

        public async Task<IEnumerable<Track>> GetReports(
            DateTime start,
            DateTime end,
            IEnumerable<Guid>? employeeIds,
            IEnumerable<Guid>? clientIds,
            IEnumerable<Guid>? projectIds,
            IEnumerable<Guid>? taskIds)
            => (await GetDbSet())
                .AsNoTracking()
                .Include(t => t.Employee)
                .Include(t => t.Project)
                    .ThenInclude(p => p.Client)
                .Include(t => t.Task)
                .AsEnumerable()
                .Where(t => t.Status == Data.Models.Enum.TrackStatus.Stop && (t.IsPending == null || t.IsPending == false) && t.ParentTrackId == null
                    && t.Start.Date >= start.ToUniversalTime().Date && t.End.Value.Date <= end.ToUniversalTime().Date
                    && (employeeIds != null && employeeIds.Any() ? t.Employee != null ? employeeIds.Where(c => c.Equals(t.Employee.Id)).Any() : false : true)
                    && (clientIds != null && clientIds.Any() ? t.Project != null && t.Project.ClientId != Guid.Empty ? clientIds.Where(c => c.Equals(t.Project.ClientId)).Any() : false : true)
                    && (projectIds != null && projectIds.Any() ? t.ProjectId != null ? projectIds.Where(g => g.Equals(t.ProjectId.Value)).Any() : false : true)
                    && (taskIds != null && taskIds.Any() ? t.TaskId != null ? taskIds.Where(g => g.Equals(t.TaskId.Value)).Any() : false : true))
                .OrderByDescending(t => t.Start);

        // ADD
        public async Task Add(Track entity)
            => await repository.Add(entity);

        // UPDATE
        public async Task Update(Track entity)
            => await repository.Update(entity);

        // DELETE
        public async Task Delete(Track entity)
            => await repository.Delete(entity);
    }
}
