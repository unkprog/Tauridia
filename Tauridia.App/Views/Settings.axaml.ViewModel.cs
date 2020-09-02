using System;
using System.IO;
using System.Runtime.Serialization;
using ReactiveUI;

namespace Tauridia.App.ViewModels.Settings
{
    public class ViewModel : ViewModelBase
    {
        internal static readonly string fileSettings = "Settings.config";
        internal static readonly string pathSettings = string.Concat(Environment.CurrentDirectory, @"\Settings");

        public ViewModel()
        {
            //CurrentContent = new ViewModels.WelcomeSreen.ViewModel();
        }

        private string _server = "https://localhost:44331";

        [DataMember]
        public string Server
        {
            get => _server;
            set => this.RaiseAndSetIfChanged(ref _server, value);
        }

        public void Load()
        {
            CheckDirectorySettings();
        }

        public void Save()
        {
            CheckDirectorySettings();
        }

        private string CheckDirectorySettings()
        {
            string result = pathSettings;
            if (!Directory.Exists(pathSettings))
                Directory.CreateDirectory(pathSettings);
            return result;
        }
    }
}
