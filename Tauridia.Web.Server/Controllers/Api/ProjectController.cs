using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Tauridia.Core.Managers;
using Tauridia.Core.Models.Project;
using Tauridia.Web.Core;

namespace Tauridia.Web.Server.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ApiControllerBase<ProjectController>
    {
        public ProjectController(ILogger<ProjectController> logger) : base(logger)
        {
        }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return new ProjectManager().ListProjects();
        }
    }
}
