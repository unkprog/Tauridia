using System;

namespace Tauridia.Core
{
    public class ModelBase
    {
    }

    public class NamedModel : ModelBase 
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

}
