using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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

        public void WriteError(Exception ex)
        {
            _logger?.Log(LogLevel.Error, ex.Message);
        }

    }
}
