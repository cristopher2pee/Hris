using Hris.Business.Extensions;
using Hris.Data.Models.Enum;
using Hris.Data.Models.Payroll;
using Hris.Data.Repository;
using Microsoft.IdentityModel.Tokens;

namespace Hris.Business.Service.PayrollModule
{
    public class AllowanceService
    {
        private readonly IRepository<AllowanceType> typeRepository;
        private readonly IRepository<AllowanceEntitlement> entRepository;

        public AllowanceService(IRepository<AllowanceType> typeRepository,
            IRepository<AllowanceEntitlement> entRepository)
        {
            this.typeRepository = typeRepository;
            this.entRepository = entRepository;
        }

        // Type

        public async Task<IEnumerable<AllowanceType>> GetTypeResource(string? search)
            => string.IsNullOrEmpty(search) ? await this.typeRepository.GetAllAsync()
                : await this.typeRepository.FindListByConditionAsync(d => d.Name.ToLower().Contains(search.ToLower()));

        public async Task<int> GetTypeCount()
            => await typeRepository.GetCount();

        public async Task<AllowanceType> GetTypeById(Guid id)
            => await typeRepository.GetByIdAsync(id);

        public async Task<(IEnumerable<AllowanceType> list, int total)> GetType(int? page = null, int? limit = null, string? search = null, PayrollPeriod? period = null)
        {
            var q = (await typeRepository.GetDbSet())
                .AsEnumerable()
                .Where(d => d.Active)
                .Where(d => (!search.IsNullOrEmpty() ? d.Name.Has(search) : true)
                    );

            return (!page.HasValue && !limit.HasValue ? q :
                        q.Skip((page.Value - 1) * limit.Value)
                            .Take(limit.Value), q.Count());
        }

        public async Task<AllowanceType> AddType(AllowanceType d, Guid userId)
        {
            try
            {
                d = await typeRepository.Add(d);
                await SaveTypeChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AllowanceType> Update(AllowanceType d, Guid userId)
        {
            try
            {
                d = await typeRepository.Update(d);
                await SaveTypeChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AllowanceType> DeactivateType(AllowanceType d, Guid userId)
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

        public async Task<AllowanceType> DeleteType(AllowanceType d, Guid userId)
        {
            try
            {
                d = await typeRepository.Delete(d);
                await SaveTypeChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveTypeChangesAsync(Guid id)
            => await typeRepository.SaveChangesAsync(id);

        // Entitlement
    }
}
