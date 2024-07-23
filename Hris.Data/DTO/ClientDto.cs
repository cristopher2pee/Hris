using Hris.Data.Models.Clock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class ClientDto
    {
    }

    public class ClientDtoRequest : BaseDtoRequest
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
    }

    public class ClientDtoResponse : BaseDtoResponse
    {
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? ContactPerson { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Contact { get; set; } = string.Empty;
    }

    public static class ClientExtension_
    {
        public static ClientDtoResponse ToClientDtoResponse(this Client e)
        {
            return new ClientDtoResponse
            {
                Id = e.Id,
                Name = e.Name,
                Address = e.Address,
                ContactPerson = e.ContactPerson,
                Email = e.Email,
                Contact = e.Contact,
            };
        }

        public static IEnumerable<ClientDtoResponse> ToClientDtoResponseList(this IEnumerable<Client> entities)
            => entities.Select(e => e.ToClientDtoResponse()).ToList();

    }

}
