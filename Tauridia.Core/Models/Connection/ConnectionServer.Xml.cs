using System.Xml;
using Tauridia.Core.Extensions;
using Tauridia.Core.Interfaces;

namespace Tauridia.Core.Models.Connection
{
    public partial class ConnectionServerModel : ISerializableXml
    {
 

        public void Read(XmlReader reader)
        {
            this.ReadProperties(reader);
            reader.WhileReadItem((reader) =>
            {
                this.ReadItems(reader);
            });
        }

        protected virtual void ReadProperties(XmlReader reader)
        {
            Name = reader.GetAttribute("Name");
            Url = reader.GetAttribute("Url");
            Description = reader.GetAttribute("Description");
        }

        protected virtual void ReadItems(XmlReader reader)
        {

        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(XmlName);

            this.WriteProperties(writer);
            this.WriteItems(writer);

            writer.WriteEndElement();
        }

        protected virtual void WriteProperties(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", this.Name);
        }

        protected virtual void WriteItems(XmlWriter writer)
        {
            WriteFiles(writer);
        }

        private void WriteFiles(XmlWriter writer)
        {
            if (Files.Count == 0) return;

            writer.WriteStartElement(XmlFiles);
            for (int i = 0, icount = Files.Count; i < icount; i++)
                Files[i].Write(writer);
            writer.WriteEndElement();
        }
    }
}
