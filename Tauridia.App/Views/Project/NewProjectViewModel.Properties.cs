using ReactiveUI;
using System.Reactive;
using System.Runtime.Serialization;
using Tauridia.Core.Models.Project;

namespace Tauridia.App.Views
{
    public partial class NewProjectViewModel
    {
        private Project _project = new Project() { Name = "Новый проект" };

        [IgnoreDataMember]
        public Project Project
        {
            get => _project;
            set => this.RaiseAndSetIfChanged(ref _project, value);
        }

    }
}
