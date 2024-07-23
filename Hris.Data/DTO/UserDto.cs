using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hris.Data.DTO
{
    public class UserDtoRequest
    {
        public Guid EmployeeId { get; set; }
        public string newPassword { get; set; } = string.Empty;
    }

    public class CreateAccountRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class ResetPasswordRequest
    {
        public string email { get; set; }
        public string token { get; set; }
        public string password { get; set; }
    }

    public class ChangeEmailRequest
    {
        public string OldEmail { get; set; }
        public string NewEmail { get; set; }
    }
    public class ChangePasswordRequest
    {
        public string email { get; set; }
        public string oldPassword { get; set; } = string.Empty;
        public string newPassword { get; set; } = string.Empty;
    }
    public class RegisterDtoRequest
    {
        //public UserDtoRequest UserDtoRequest { get; set; }
        public string Password { get; set; }
        public EmployeeDtoRequest EmployeeDtoRequest { get; set; }
    }
}
