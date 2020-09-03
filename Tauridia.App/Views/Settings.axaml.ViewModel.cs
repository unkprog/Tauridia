using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using ReactiveUI;
using Tauridia.App.Models.Settings;

namespace Tauridia.App.ViewModels.Settings
{
    public class ViewModel : ModelBase
    {
        internal static readonly string fileSettings = "Settings.config";
        internal static readonly string pathSettings = string.Concat(Environment.CurrentDirectory, @"\Settings");

        public ViewModel()
        {
            
        }

        [DataMember]
        public ObservableCollection<ServerModel> ListServers { get; } = new ObservableCollection<ServerModel>();

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
