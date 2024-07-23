using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Hris.Api.Models.Response
{
    public class HrisError : JsonResult
    {
        public HrisError(string key, string message) : base(new Error(key, message))
        {
            this.StatusCode = StatusCodes.Status500InternalServerError;

        }
        public HrisError(Error error) : base(error)
        {
            this.StatusCode = StatusCodes.Status500InternalServerError;

        }
        public HrisError(List<Error.ErrorDetails> error) : base(new ApiResponse(error))
        {
            this.StatusCode = StatusCodes.Status500InternalServerError;

        }
    }

    public class HrisErrorUnAuthorized : JsonResult
    {
        public HrisErrorUnAuthorized(string key, string message) : base(new Error(key, message))
        {
            this.StatusCode = StatusCodes.Status401Unauthorized;
        }
    }

    public class HrisErrorNotFound : JsonResult
    {
        public HrisErrorNotFound(string key, string message) : base(new Error(key, message))
        {
            this.StatusCode = StatusCodes.Status404NotFound;
        }
    }

    public class HrisErrorBadRequest : JsonResult
    {
        public HrisErrorBadRequest(List<Error.ErrorDetails> error) : base(new ApiResponse(error))
        {
            this.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
