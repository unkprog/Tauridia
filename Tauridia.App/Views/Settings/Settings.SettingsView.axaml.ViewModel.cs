using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using ReactiveUI;
using Tauridia.App.Models.Settings;

namespace Tauridia.App.ViewModels.Settings
{
    public class SettingsViewModelBase : SerializableXmlViewModel
    {
        public string _name = "Настройка";
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
    }
    public class ViewModel : ViewModelBase
    {
        internal static readonly string fileSettings = "Settings.config";
        internal static readonly string pathSettings = string.Concat(Environment.CurrentDirectory, @"\Settings");

        public ViewModel()
        {
        }


        [DataMember]
        public List<ViewModelBase> ListSettings { get; } = new List<ViewModelBase>(new ViewModelBase[] { 
            new ViewModels.Settings.Servers.ViewModel() { Name = "Серверы" }
        });

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
