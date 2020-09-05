using ReactiveUI;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml;
using Tauridia.App.Models.Settings;
using Tauridia.Core.Extensions;

namespace Tauridia.App.Views.Settings
{
    public class ServersViewModel : SettingsViewModelBase
    {
        public const string XmlServer = "Server"; 
        public const string XmlServers = "Servers";

       

        [DataMember]
        public ObservableCollection<ServerModel> ListServers { get; } = new ObservableCollection<ServerModel>(
            new ServerModel[]
            {
                new ServerModel(){ Name = "Server 1", Description = "Connection to Server 1", Url = "https://localhost:5001" },
                new ServerModel(){ Name = "Server 2", Description = "Connection to Server 2", Url = "https://localhost:5002" },
                new ServerModel(){ Name = "Server 3", Description = "Connection to Server 3", Url = "https://localhost:5003" },
                new ServerModel(){ Name = "Server 4", Description = "Connection to Server 4", Url = "https://localhost:5004" },
                new ServerModel(){ Name = "Server 5", Description = "Connection to Server 5", Url = "https://localhost:5005" },
                new ServerModel(){ Name = "Server 6", Description = "Connection to Server 6", Url = "https://localhost:5006" }
            });


        private ServerModel _selectedServer;

        [DataMember]
        public ServerModel SelectedServer
        {
            get => _selectedServer;
            set => this.RaiseAndSetIfChanged(ref _selectedServer, value);
        }

        protected override void ReadProperties(XmlReader reader)
        {
            base.ReadProperties(reader);
        }

        protected override void ReadItems(XmlReader reader)
        {
            if (reader.Name == XmlServers)
                ReadServers(reader);
        }

        private void ReadServers(XmlReader reader)
        {
            reader.WhileReadItem((reader) =>
            {
                if (reader.Name == XmlServer)
                {
                    ServerModel server = new ServerModel();
                    //server.Read(reader);
                    this.ListServers.Add(server);
                }

            });
        }
    }
}
