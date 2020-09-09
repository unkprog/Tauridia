using System.Runtime.Serialization;
using ReactiveUI;
using Tauridia.Core.Models;

namespace Tauridia.App.Views.Settings
{
    [DataContract]
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
