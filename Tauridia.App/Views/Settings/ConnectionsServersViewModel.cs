using ReactiveUI;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml;
using Tauridia.Core.Extensions;
using Tauridia.Core.Models.Connection;

namespace Tauridia.App.Views.Settings
{
    public class ConnectionsServersViewModel : SettingsViewModelBase
    {
        public const string XmlConnectionServer = "ConnectionServer"; 
        public const string XmlConnectionsServers = "ConnectionsServers";

       

        [DataMember]
        public ObservableCollection<ConnectionServerModel> ListServers { get; } = new ObservableCollection<ConnectionServerModel>(
            new ConnectionServerModel[]
            {
                new ConnectionServerModel(){ Name = "Server 1", Description = "Connection to Server 1", Url = "https://localhost:5001" },
                new ConnectionServerModel(){ Name = "Server 2", Description = "Connection to Server 2", Url = "https://localhost:5002" },
                new ConnectionServerModel(){ Name = "Server 3", Description = "Connection to Server 3", Url = "https://localhost:5003" },
                new ConnectionServerModel(){ Name = "Server 4", Description = "Connection to Server 4", Url = "https://localhost:5004" },
                new ConnectionServerModel(){ Name = "Server 5", Description = "Connection to Server 5", Url = "https://localhost:5005" },
                new ConnectionServerModel(){ Name = "Server 6", Description = "Connection to Server 6", Url = "https://localhost:5006" }
            });


        private ConnectionServerModel _selectedConnectionServer;

        [DataMember]
        public ConnectionServerModel SelectedConnectionServer
        {
            get => _selectedConnectionServer;
            set => this.RaiseAndSetIfChanged(ref _selectedConnectionServer, value);
        }

        protected override void ReadProperties(XmlReader reader)
        {
            base.ReadProperties(reader);
        }

        protected override void ReadItems(XmlReader reader)
        {
            if (reader.Name == XmlConnectionsServers)
                ReadConnectionsServers(reader);
        }

        private void ReadConnectionsServers(XmlReader reader)
        {
            reader.WhileReadItem((reader) =>
            {
                if (reader.Name == XmlConnectionServer)
                {
                    ConnectionServerModel server = new ConnectionServerModel();
                    //server.Read(reader);
                    this.ListServers.Add(server);
                }

            });
        }
    }
}
