using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Runtime.Serialization;
using ReactiveUI;
using Tauridia.App.ViewModels;
using Tauridia.Core.Extensions;
using Tauridia.Core.Models;

namespace Tauridia.App.Views.Settings
{
    public class SettingsViewModelBase : ViewModelBase
    {
        private string _name = "Настройка";
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
    }

    [DataContract(Name = "Settings")]
    public class SettingsViewModel : ViewModelBase
    {
        internal static readonly string fileSettings = "Settings.config";
        internal static readonly string pathSettings = string.Concat(Environment.CurrentDirectory, @"\Settings");

        public SettingsViewModel()
        {
            SaveCommand = ReactiveCommand.Create(Save);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }


        [DataMember]
        public List<SettingsViewModelBase> ListSettings { get; private set; } = new List<SettingsViewModelBase>(new SettingsViewModelBase[] { 
            new ConnectionsServersViewModel() { Name = "Подключения" }
            //, new AboutViewModel() { Name = "О программе" }
        });

        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

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
