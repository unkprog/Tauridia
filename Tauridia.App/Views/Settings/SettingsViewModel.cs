using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Runtime.Serialization;
using System.Xml;
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
            new ConnectionsServersViewModel() { Name = "Подключения" }
            //, new AboutViewModel() { Name = "О программе" }
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

            string path = string.Concat(CheckDirectorySettings(), @"\settings.config");

            using (TextWriter textWriter = File.CreateText(path))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, new XmlWriterSettings() { Indent = true, IndentChars = "\t", NewLineChars = System.Environment.NewLine }))
                {
                    xmlWriter.WriteStartDocument();
                    foreach (var setting in ListSettings)
                    {
                        setting.Write(xmlWriter);
                    }
                    xmlWriter.WriteEndDocument();
                }
            }

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
