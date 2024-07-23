using Hris.Api.Models.Response;
using Hris.Api.Models.Response.ClockWork;
using Hris.Data.Models.Clock;

namespace Hris.Api.Extensions.Clock
{
    public static class ClientExtension
    {
        public static ClientResponse ToResponse(this Client d)
            => new ClientResponse
            {
                Id = d.Id,
                Active = d.Active,
                Name = d.Name,
                Address = d.Address,
                ContactPerson = d.ContactPerson,
                Contact = d.Contact,
                Email = d.Email,
            };

        public static IEnumerable<ClientResponse> ToList(this IEnumerable<Client> d)
            => d.Select(d => d.ToResponse());
    }
}
