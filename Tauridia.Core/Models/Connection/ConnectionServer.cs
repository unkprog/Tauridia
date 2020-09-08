using System.Runtime.Serialization;
using ReactiveUI;

namespace Tauridia.Core.Models.Connection
{
    [DataContract]
    public partial class ConnectionServer : ModelBase
    {
        private string name;
        private string url;
        private string description;

        [DataMember]
        public string Name { get => name; set => this.RaiseAndSetIfChanged(ref name, value); }
        [DataMember]
        public string Url { get => url; set => this.RaiseAndSetIfChanged(ref url, value); }
        [DataMember]
        public string Description { get => description; set => this.RaiseAndSetIfChanged(ref description, value);  }
    }
}
