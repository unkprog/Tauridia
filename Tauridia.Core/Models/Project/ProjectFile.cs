using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tauridia.Core.Models.Project
{
    [DataContract]
    public partial class ProjectFile : NamedModel
    {
        public ProjectFile()
        {
            Files = new List<ProjectFile>();
        }

        [DataMember]
        public List<ProjectFile> Files { get; internal set; }
    }
}
