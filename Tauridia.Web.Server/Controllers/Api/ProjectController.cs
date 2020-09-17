using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Tauridia.Core.Managers;
using Tauridia.Core.Models.Project;
using Tauridia.Web.Core;
using Microsoft.AspNetCore.Authorization;

namespace Tauridia.Web.Server.Controllers.Api
{
    [Route("api/[controller]/[action]")]
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


        [HttpPost]
        [Route("api/project/create")]
        [AllowAnonymous]
        [Produces("application/json")]
        public string Create([FromBody] Project project)
        {
            new ProjectManager().Save(project);
            return "Ok";
        }
    }
}
