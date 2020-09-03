using System.Runtime.Serialization;


namespace Tauridia.App.Models.Settings
{
    public class ServerModel : ModelBase
    {
        [DataMember]
        public string Url { get; set; }
    }
}
