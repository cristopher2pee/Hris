using Azure;
using Hris.Business.Extensions;
using Hris.Data.Models.Clock;
using Hris.Data.Repository;
using Microsoft.Graph.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Business.Service.Clock
{
    public class ClientService
    {
        private readonly IRepository<Client> repository;
        public ClientService(IRepository<Client> repository)
        {
            this.repository = repository;
        }

        public async Task<int> GetCount()
            => await repository.GetCount();

        public async Task<Client> GetById(Guid id)
            => await repository.GetByIdAsync(id);

        public async Task<(IEnumerable<Client> list, int total)> Get(int? page = null, int? limit = null, string? search = null)
        {
            var q = (await repository.GetDbSet())
                .AsEnumerable()
                .Where(d => d.Active)
                .Where(d => !search.IsNullOrEmpty() ?
                        d.Name.Has(search)
                        || !d.ContactPerson.IsNullOrEmpty() && d.ContactPerson.Has(search)
                        || !d.Address.IsNullOrEmpty() && d.Address.Has(search)
                        || !d.Contact.IsNullOrEmpty() && d.Contact.Has(search)
                        || !d.Email.IsNullOrEmpty() && d.Email.Has(search)
                    : true);

            return (!page.HasValue && !limit.HasValue ? q :
                        q.Skip((page.Value - 1) * limit.Value)
                            .Take(limit.Value), q.Count());
        }

        public async Task<Client> Add(Client d, Guid userId)
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

        public async Task<Client> Update(Client d, Guid userId)
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

        public async Task<Client> Deactivate(Client d, Guid userId)
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

        public async Task<Client> Delete(Client d, Guid userId)
        {
            try
            {
                d = await repository.Delete(d);
                await SaveChangesAsync(userId);
                return d;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveChangesAsync(Guid id)
            => await repository.SaveChangesAsync(id);
    }
}
