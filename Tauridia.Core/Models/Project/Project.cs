using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tauridia.Core.Models.Project
{
    [DataContract]
    public partial class Project : ProjectFile
    {
        public Project()
        {
            Dependencies = new List<Project>();
        }

        [DataMember]
        public List<Project> Dependencies { get; internal set; }
    }


}
