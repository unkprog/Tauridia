using System.Collections.Generic;
using System.Reactive;
using System.Runtime.Serialization;
using ReactiveUI;

namespace Tauridia.App.Views.Settings
{
    partial class SettingsViewModel
    {

        internal void InitProperties()
        {
            ListSettings = new List<SettingsViewModelBase>(new SettingsViewModelBase[] { ConnectionsServers });
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


    }
}
