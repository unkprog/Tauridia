using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tauridia.Web.Core;

namespace Tauridia.Web.Server.Controllers.Api
{
    [Route("api/connection")]
    public class ConnectionController : ApiControllerBase<ConnectionController>
    {
        public ConnectionController(ILogger<ConnectionController> logger) : base(logger)
        {
        }

        [HttpGet]
        public string CheckAuth()
        {
            return Environment.UserDomainName;
        }
    }
}
