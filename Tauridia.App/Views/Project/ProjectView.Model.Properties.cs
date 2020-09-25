using Dock.Model;
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

        private IFactory _factory;
        private IDock _layout;
        private string _currentView;

        public IFactory Factory
        {
            get => _factory;
            set => this.RaiseAndSetIfChanged(ref _factory, value);
        }

        public IDock Layout
        {
            get => _layout;
            set => this.RaiseAndSetIfChanged(ref _layout, value);
        }

        public string CurrentView
        {
            get => _currentView;
            set => this.RaiseAndSetIfChanged(ref _currentView, value);
        }
    }
}
