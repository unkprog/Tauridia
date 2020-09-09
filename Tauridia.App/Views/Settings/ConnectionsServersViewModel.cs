using ReactiveUI;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Tauridia.Core.Models.Connection;

namespace Tauridia.App.Views.Settings
{
    [DataContract]
    public class ConnectionsServersViewModel : SettingsViewModelBase
    {

       [DataMember]
       public ObservableCollection<ConnectionServer> ListServers { get; set; } = new ObservableCollection<ConnectionServer>(
            new ConnectionServer[]
            {
                new ConnectionServer(){ Name = "Server (Debug)", Description = "Отладочный сервер", Url = "https://localhost:44331" },
                new ConnectionServer(){ Name = "Server (Release)", Description = "Продуктовый сервер", Url = "https://localhost:5001" }
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
