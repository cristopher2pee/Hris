using Hris.Api.Middleware;
using Hris.Api.Models.Response;
using Hris.Api.Security;
using Hris.Business.Service;
using Hris.Data.Models;
using Hris.Data.Models.Employee;
using Hris.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Hris.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<T> : ControllerBase where T:BaseController<T>
    {
        protected HrisOk HrisOk()
            => new HrisOk();

        protected  HrisOk HrisOk(object objt)
            => new HrisOk(objt);

        protected static HrisError HrisError(string key, string message)
            => new HrisError(key, message);

        protected static HrisError HrisError(List<Error.ErrorDetails> error)
            => new HrisError(error);
    }
}
