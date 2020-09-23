using System.Collections.Generic;
using Tauridia.Core.Http;
using Tauridia.Core.Models;
using Tauridia.Core.Models.Project;

namespace Tauridia.App.Views
{
    public partial class OpenProjectViewModel : ViewModelBase
    {
        public OpenProjectViewModel()
        {
            LoadProjects();
        }

        public void LoadProjects()
        {
            App.Session.Api.HttpMessageGet<List<Project>>("/project", (result) => ListProjects = result);
        }


    }
}
