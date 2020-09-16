using Tauridia.Core.Models;
using Tauridia.Core.Models.Project;

namespace Tauridia.App.Views
{
    public partial class NewProjectViewModel : ViewModelBase
    {
        public void CreateProject()
        {
            string result = App.Session.Api.Post<string, Project>("/project/save", Project);
            if(result == "Ok")
            {
                MainWindowViewModel.This.CurrentContent = new ProjectViewModel();
            }

        }
    }
}
