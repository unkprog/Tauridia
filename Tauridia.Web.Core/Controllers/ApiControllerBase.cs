using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Tauridia.Web.Core
{
    [ApiController]
    [Authorize]
    public class ApiControllerBase<T> : ControllerBase
    {
        protected readonly ILogger<T> _logger;

        public ApiControllerBase(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
