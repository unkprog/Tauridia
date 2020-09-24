using ReactiveUI;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Tauridia.Core.Models.Project;

namespace Tauridia.App.Views
{
    public partial class OpenProjectViewModel
    {
        List<Project> _listProjects = new List<Project>();
        [DataMember]
        public List<Project> ListProjects
        {
            get => _listProjects;
            set => this.RaiseAndSetIfChanged(ref _listProjects, value);
        }

        private Project _selectedProject;

        [IgnoreDataMember]
        public Project SelectedProject
        {
            get => _selectedProject;
            set => this.RaiseAndSetIfChanged(ref _selectedProject, value);
        }


    }
}
