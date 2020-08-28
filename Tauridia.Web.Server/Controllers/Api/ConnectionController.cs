using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tauridia.Web.Core;

namespace Tauridia.Web.Server.Controllers.Api
{
    [Route("api/[controller]")]
    public class ConnectionController : ApiControllerBase<ConnectionController>
    {
        public ConnectionController(ILogger<ConnectionController> logger) : base(logger)
        {
        }
    }
}
