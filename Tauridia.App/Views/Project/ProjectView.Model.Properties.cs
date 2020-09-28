using ReactiveUI;
using System.Runtime.Serialization;
using Tauridia.Core.Models.Project;

namespace Tauridia.App.Views
{
    public partial class ProjectViewModel
    {
        private Project _project;

        [IgnoreDataMember]
        public Project Project
        {
            get => _project;
            set => this.RaiseAndSetIfChanged(ref _project, value);
        }

     
    }
}
