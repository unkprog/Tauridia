using System;
using System.Collections.Generic;
using System.Text;
using Tauridia.Core.Models;
using Tauridia.Core.Models.Project;

namespace Tauridia.App.Views
{
    public partial class ProjectViewModel : ViewModelBase
    {
        public ProjectViewModel(Project project)
        {
            _project = project;
        }
    }
}
