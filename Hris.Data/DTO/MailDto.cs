using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    internal class MailDto
    {
    }

    public class MailDtoRequest
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
    }
}
