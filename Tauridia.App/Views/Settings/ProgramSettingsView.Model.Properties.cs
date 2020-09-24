using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using ReactiveUI;

namespace Tauridia.App.Views.Settings
{
    partial class ProgramSettingsViewModel
    {
        [IgnoreDataMember] 
        public ObservableCollection<string> ListThemes { get; set; } = new ObservableCollection<string>(
            new string[]
            {
                "По умолчанию"
            });

        private string _theme = "По умолчанию";

        [DataMember]
        public string Theme
        {
            get => _theme;
            set => this.RaiseAndSetIfChanged(ref _theme, value);
        }
    }
}
