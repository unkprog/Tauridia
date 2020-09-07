using System.Xml;
using Tauridia.Core.Extensions;
using Tauridia.Core.Interfaces;

namespace Tauridia.Core.Models
{
    public class SerializableXml : ModelBase, ISerializableXml
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
        }

        protected virtual void ReadItems(XmlReader reader)
        {

        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(this.XmlElementShortName());

            this.WriteProperties(writer);
            this.WriteItems(writer);

            writer.WriteEndElement();
        }

        protected virtual void WriteProperties(XmlWriter writer)
        {
        }

        protected virtual void WriteItems(XmlWriter writer)
        {

        }
    }
}
