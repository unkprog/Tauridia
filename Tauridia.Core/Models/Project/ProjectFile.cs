using System.Collections.Generic;

namespace Tauridia.Core.Models.Project
{
    public partial class ProjectFile : NamedModel
    {
        public ProjectFile()
        {
            Files = new List<ProjectFile>();
        }

        public List<ProjectFile> Files { get; internal set; }
    }
}
