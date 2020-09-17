using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tauridia.Web.Core;
using Tauridia.Web.Core.Controllers;

namespace Tauridia.Web.Server.Controllers.Api
{
    [Route("api/connection")]
    public class ConnectionController : ApiControllerBase<ConnectionController>
    {
        public ConnectionController(ILogger<ConnectionController> logger) : base(logger)
        {
        }

        [HttpGet]
        public string CheckConnect()
        {
            return "Ok";
            //return this.TryCatch(() => { return "Ok"; }); ;
        }

        //[HttpPost]
        //public string CheckConnect()
        //{
        //    return "Ok";
        //    //return this.TryCatch(() => { return "Ok"; }); ;
        //}
    }
}
