using ReactiveUI;
using System.Runtime.Serialization;

namespace Tauridia.Core.Models
{
    [DataContract]
    public class ModelBase : ReactiveObject
    {
        
    }

    [DataContract]
    public class NamedModel : ModelBase 
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }


}
