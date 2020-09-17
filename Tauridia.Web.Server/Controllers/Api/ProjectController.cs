using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Tauridia.Core.Managers;
using Tauridia.Core.Models.Project;
using Tauridia.Web.Core;
using Microsoft.AspNetCore.Authorization;

namespace Tauridia.Web.Server.Controllers.Api
{
    [Route("api/project")]
    public class ProjectController : ApiControllerBase<ProjectController>
    {
        public ProjectController(ILogger<ProjectController> logger) : base(logger)
        {
        }

        [HttpGet]
        public string Get()
        {
            return "OK"; // new ProjectManager().ListProjects();
        }
        //[HttpGet]
        //public IEnumerable<Project> Get()
        //{
        //    return "OK"; // new ProjectManager().ListProjects();
        //}


        [HttpPost]
        [Route("create")]
        public Project Create([FromBody] Project project)
        {
           // new ProjectManager().Save(project);
            return project;
        }
    }
}
