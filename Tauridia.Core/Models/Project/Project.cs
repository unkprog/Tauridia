using System.Collections.Generic;

namespace Tauridia.Core.Models.Project
{
    public partial class Project : ProjectFile
    {
        public Project()
        {
            Dependencies = new List<Project>();
        }
        
        public List<Project> Dependencies { get; internal set; }
    }


}
