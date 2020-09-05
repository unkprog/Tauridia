using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Runtime.Serialization;
using ReactiveUI;
using Tauridia.App.ViewModels;

namespace Tauridia.App.Views.Settings
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
        public List<SettingsViewModelBase> ListSettings { get; } = new List<SettingsViewModelBase>(new SettingsViewModelBase[] { 
            new ServersViewModel() { Name = "Подключения" },
            new AboutViewModel() { Name = "О программе" }
        });

        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public void Load()
        {
            CheckDirectorySettings();
        }

        public void Save()
        {
            CheckDirectorySettings();
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
    }
}
