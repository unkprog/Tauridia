using Tauridia.Core.Http;
using Tauridia.Core.Models;
using Tauridia.Core.Models.Project;

namespace Tauridia.App.Views
{
    public partial class NewProjectViewModel : ViewModelBase
    {
        public void CreateProject()
        {
            App.Session.Api.HttpMessagePost<Project, Project>("/project/create", Project, (result) => MainWindowViewModel.This.CurrentContent = new ProjectViewModel(result));
        }
    }
}
