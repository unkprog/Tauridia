using ReactiveUI;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Tauridia.Core.Models.Connection;

namespace Tauridia.App.Views.Settings
{
    [DataContract]
    public class ConnectionsServersViewModel : SettingsViewModelBase
    {

        [DataMember]
        [System.Text.Json.Serialization.JsonPropertyName("servers")]
        public List<ConnectionServer> ListServers { get; set; } = new List<ConnectionServer>(
            new ConnectionServer[]
            {
                new ConnectionServer(){ Name = "Server 1", Description = "Connection to Server 1", Url = "https://localhost:5001" },
                new ConnectionServer(){ Name = "Server 2", Description = "Connection to Server 2", Url = "https://localhost:5002" },
                new ConnectionServer(){ Name = "Server 3", Description = "Connection to Server 3", Url = "https://localhost:5003" },
                new ConnectionServer(){ Name = "Server 4", Description = "Connection to Server 4", Url = "https://localhost:5004" },
                new ConnectionServer(){ Name = "Server 5", Description = "Connection to Server 5", Url = "https://localhost:5005" },
                new ConnectionServer(){ Name = "Server 6", Description = "Connection to Server 6", Url = "https://localhost:5006" }
            });


        private ConnectionServer _selectedConnectionServer;

        [IgnoreDataMember]
        public ConnectionServer SelectedConnectionServer
        {
            get => _selectedConnectionServer;
            set => this.RaiseAndSetIfChanged(ref _selectedConnectionServer, value);
        }


    }
}
