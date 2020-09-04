using System;

namespace Tauridia.Core.Models
{
    public class ModelBase
    {
        
    }

    public class NamedModel : ModelBase 
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }


}
