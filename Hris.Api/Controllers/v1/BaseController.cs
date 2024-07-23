using Hris.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Hris.Api.Controllers.v1
{
    [ApiController, Route("api/v1/[controller]")]
    public class BaseController<T> : ControllerBase where T : BaseController<T>
    {
        protected HrisOk HrisOk()
            => new HrisOk();

        protected HrisOk HrisOk(object objt)
            => new HrisOk(objt);

        protected  HrisError HrisError(string key, string message)
            => new HrisError(key, message);
        protected static HrisError HrisError(List<Error.ErrorDetails> error)
            => new HrisError(error);



        protected  HrisErrorNotFound HrisErrorNotFound(string key, string message)
            => new HrisErrorNotFound($"{key}", message);

        protected  HrisErrorBadRequest HrisErrorBadRequest(List<Error.ErrorDetails> error)
            => new HrisErrorBadRequest(error);

    }
}
