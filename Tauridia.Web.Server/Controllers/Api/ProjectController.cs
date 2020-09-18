using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Tauridia.Core.Managers;
using Tauridia.Core.Models.Project;
using Tauridia.Web.Core;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Tauridia.Core.Http;
using Tauridia.Web.Core.Controllers;
using System;

namespace Tauridia.Web.Server.Controllers.Api
{
    [Route("api/project")]
    public class ProjectController : ApiControllerBase<ProjectController>
    {
        public ProjectController(ILogger<ProjectController> logger) : base(logger)
        {
        }

        [HttpGet]
        public HttpMessage<IEnumerable<Project>> Get()
        {
            return this.TryCatch<ProjectController, IEnumerable<Project>>(() =>
            {
                return new ProjectManager().ListProjects();
            });
        }

        [HttpPost]
        [Route("create")]
        public HttpMessage<IEnumerable<Project>> Create([FromBody] Project project)
        {
            return this.TryCatch(() =>
            {
                new ProjectManager().Save(project);
                return Get().Data;
            });
           
        }
    }
}
