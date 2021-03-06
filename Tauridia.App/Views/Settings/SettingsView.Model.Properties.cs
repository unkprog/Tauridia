﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ReactiveUI;

namespace Tauridia.App.Views.Settings
{
    partial class SettingsViewModel
    {
        internal static readonly string fileSettings = "Settings.config";
        internal static readonly string pathSettings = string.Concat(Environment.CurrentDirectory, @"\Settings");

        internal void InitProperties(SettingsViewModel loadedSettings = null)
        {
            if (loadedSettings != null)
            {
                if (loadedSettings.ConnectionsServers != null)
                    ConnectionsServers = loadedSettings.ConnectionsServers;
            }
            
            ListSettings = new List<SettingsViewModelBase>(new SettingsViewModelBase[] { ConnectionsServers, ProgramSettings });
            this.RaisePropertyChanged("ListSettings");
        }

        [IgnoreDataMember]
        public List<SettingsViewModelBase> ListSettings { get; private set; } 


        private ConnectionsServersViewModel connectionsServers = new ConnectionsServersViewModel() { Name = "Подключения" };

        [DataMember]
        public ConnectionsServersViewModel ConnectionsServers
        {
            get => connectionsServers;
            set => this.RaiseAndSetIfChanged(ref connectionsServers, value);
        }


        private ProgramSettingsViewModel programSettings = new ProgramSettingsViewModel() { Name = "Программа" };

        [DataMember]
        public ProgramSettingsViewModel ProgramSettings
        {
            get => programSettings;
            set => this.RaiseAndSetIfChanged(ref programSettings, value);
        }

    }
}
