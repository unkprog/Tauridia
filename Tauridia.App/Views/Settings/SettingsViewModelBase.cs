using System.Runtime.Serialization;
using ReactiveUI;
using Tauridia.App.ViewModels;

namespace Tauridia.App.Views.Settings
{
    public class SettingsViewModelBase : ViewModelBase
    {
        private string _name = "Настройка";

        [DataMember]
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
    }
}
