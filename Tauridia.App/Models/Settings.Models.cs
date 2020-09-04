using System.Runtime.Serialization;


namespace Tauridia.App.Models.Settings
{
    public class ServerModel : Tauridia.Core.Models.ModelBase
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
