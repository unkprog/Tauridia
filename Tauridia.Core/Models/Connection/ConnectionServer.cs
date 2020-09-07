using System.Runtime.Serialization;


namespace Tauridia.Core.Models.Connection
{
    public partial class ConnectionServerModel : SerializableXml
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
