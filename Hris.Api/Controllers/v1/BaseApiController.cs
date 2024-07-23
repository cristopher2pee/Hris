using Hris.Api.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Graph.Models;
using System;

namespace Hris.Api.Controllers.v1
{
    [ApiController, Route("api/v1/[controller]")]
    public class BaseApiController<T> : ControllerBase where T : BaseApiController<T>
    {
        protected readonly ILogger<BaseApiController<T>> _logger;
        public BaseApiController(ILogger<T> logger)
        {
            _logger = logger;
        }

        protected HrisOk HrisOk()
            => new HrisOk();

        protected HrisOk HrisOk(object objt)
        {
            // _logger.LogInformation("Starting Request {@DateTimeUTC}", DateTime.UtcNow);
            return new HrisOk(objt);
        }

        protected HrisError HrisError(string key, string message)
        {
            _logger.LogError("Request Failed - {@DateTimeUTC} - {@Error} - {@Details} ", DateTime.UtcNow, key, message);
            return new HrisError(key, message);
        }
        protected static HrisError HrisError(List<Error.ErrorDetails> error)
            => new HrisError(error);

        protected HrisErrorNotFound HrisErrorNotFound(string key, string message)
        {
            _logger.LogError("Request Failed - {@DateTimeUTC} - {@Error} - {@Details} ", DateTime.UtcNow, key, message);
            return new HrisErrorNotFound($"{key}", message);
        }

        protected HrisErrorBadRequest HrisErrorBadRequest(List<Error.ErrorDetails> error)
        {
            // _logger.LogError()
            foreach (var item in error)
            {
                _logger.LogError("Request Failed - {@DateTimeUTC} - {@Error} - {@Details} ", DateTime.UtcNow, item.Code, item.Description);
            }
            return new HrisErrorBadRequest(error);
        }

    }
}
