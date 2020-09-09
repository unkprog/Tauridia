using ReactiveUI;
using System.Runtime.Serialization;

namespace Tauridia.Core.Models
{
    [DataContract]
    public class ModelBase : ReactiveObject
    {
        
    }

    public class ViewModelBase : ModelBase
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
