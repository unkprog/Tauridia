using System.Xml;
using Tauridia.Core.Extensions;

namespace Tauridia.Core.Models.Connection
{
    public partial class ConnectionServerModel 
    {

        protected override void ReadProperties(XmlReader reader)
        {
            Name = reader.GetAttribute("Name");
            Url = reader.GetAttribute("Url");
            Description = reader.GetAttribute("Description");
        }

        protected override void WriteProperties(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", this.Name);
            writer.WriteAttributeString("Url", this.Url);
            writer.WriteAttributeString("Description", this.Description);
        }

    }
}
