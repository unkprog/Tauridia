using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Runtime.Serialization;
using ReactiveUI;
using Tauridia.App.ViewModels;
using Tauridia.Core.Extensions;

namespace Tauridia.App.Views.Settings
{
    [DataContract]
    public partial class SettingsViewModel : ViewModelBase
    {
        internal static readonly string fileSettings = "Settings.config";
        internal static readonly string pathSettings = string.Concat(Environment.CurrentDirectory, @"\Settings");

        public SettingsViewModel()
        {
            InitCommands();
        }

        public void Load()
        {
            CheckDirectorySettings();

            ListSettings = Json.Read<List<SettingsViewModelBase>>(GetFileNameSettings());
            this.RaisePropertyChanged("ListSettings");
        }

        public void Save()
        {
            Json.Write(GetFileNameSettings(), this);
            MainWindowViewModel.This.CurrentContent = new WelcomeViewModel();
        }

        public void Cancel()
        {
            Load();
            MainWindowViewModel.This.CurrentContent = new WelcomeViewModel();
        }

        private string CheckDirectorySettings()
        {
            string result = pathSettings;
            if (!Directory.Exists(pathSettings))
                Directory.CreateDirectory(pathSettings);
            return result;
        }

        private string GetFileNameSettings()
        {
            return string.Concat(CheckDirectorySettings(), @"\settings.config");
        }
    }
}
