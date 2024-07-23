using Microsoft.AspNetCore.Identity;

namespace Hris.Api.Models.Response
{
    public class ApiResponse
    {
        public ApiResponse()
        {

        }
        public ApiResponse(object objct)
        {
            this.Data = objct;
        }
        public object? Data { get; set; }
    }


    public class Error
    {
        public List<ErrorDetails> Messages { get; private set; }
        public Error()
        {
            Messages = new List<ErrorDetails>();
        }

        public Error(string key, string message)
        {
            Messages = new List<ErrorDetails>();
            Messages.Add(new ErrorDetails(key, message));
        }

        public void Add(string key, string message)
        {
            Messages.Add(new ErrorDetails(key, message));
        }
        public void Remove(string key)
        {
            var errD = Messages.Where(e => e.Code.Contains(key)).FirstOrDefault();

            if (errD != null)
            {
                Messages.Remove(errD);
            }
        }

        public class ErrorDetails
        {

            public ErrorDetails(string code, string description)
            {
                this.Code = code;
                this.Description = description;
            }

            public string Code { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
        }
    }

    public static class ErrorExtension
    {
        public static Error.ErrorDetails ToErrorDetail(this IdentityError error)
        {
            return new Error.ErrorDetails
                (error.Code, error.Description);
        }

        public static IEnumerable<Error.ErrorDetails> ToErrorDetailList(this IEnumerable<IdentityError> error)
            => error.Select(e => e.ToErrorDetail());
    }
}
