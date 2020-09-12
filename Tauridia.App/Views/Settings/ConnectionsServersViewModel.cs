using ReactiveUI;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Tauridia.Core.Models.Connection;

namespace Tauridia.App.Views.Settings
{
    [DataContract]
    public partial class ConnectionsServersViewModel : SettingsViewModelBase
    {
        public void AddConnection()
        {
            ConnectionServer connectionServer = new ConnectionServer() { Name = "Новое подключение" };
            ListServers.Add(connectionServer);
            SelectedConnectionServer = connectionServer;
            this.RaisePropertyChanged("ListServers");
        }

        public void RemoveConnection()
        {
            if (SelectedConnectionServer != null)
            {
                ListServers.Remove(SelectedConnectionServer);
                SelectedConnectionServer = null;
                this.RaisePropertyChanged("ListServers");
            }
        }
    }
}
