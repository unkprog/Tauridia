using System.Collections.Generic;

namespace Tauridia.Core.Models.Project
{
    public partial class ProjectModel : NamedModel
    {
        public List<ProjectItem> Items { get; internal set; }
    }

    public class ProjectItem
    {
        
    }
}
