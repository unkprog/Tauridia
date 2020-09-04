using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml;
using Tauridia.App.Models.Settings;
using Tauridia.Core.Extensions;

namespace Tauridia.App.ViewModels.Settings.Servers
{
    public class ViewModel : SettingsViewModelBase
    {
        public const string XmlServer = "Server"; 
        public const string XmlServers = "Servers";

       

        [DataMember]
        public ObservableCollection<ServerModel> ListServers { get; } = new ObservableCollection<ServerModel>();

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
