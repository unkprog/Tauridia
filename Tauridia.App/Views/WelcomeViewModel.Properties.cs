using ReactiveUI;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Tauridia.Core.Models.Connection;

namespace Tauridia.App.Views
{
    public partial class WelcomeViewModel
    {
        [DataMember]
        public ObservableCollection<ConnectionServer> ListServers => App.Settings.ConnectionsServers.ListServers;


        private ConnectionServer _selectedConnectionServer;

        [IgnoreDataMember]
        public ConnectionServer SelectedConnectionServer
        {
            get => _selectedConnectionServer;
            set => this.RaiseAndSetIfChanged(ref _selectedConnectionServer, value);
        }
    }
}
