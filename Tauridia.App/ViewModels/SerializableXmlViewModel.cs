using System.Xml;
using Tauridia.Core.Extensions;

namespace Tauridia.App.ViewModels
{
    public interface ISerializableXml
    {
        void Read(XmlReader reader);
        void Write(XmlWriter writer);
    }

    public class SerializableXmlViewModel : ViewModelBase, ISerializableXml
    {
        public void Read(XmlReader reader)
        {
            ReadProperties(reader);
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
            throw new System.NotImplementedException();
        }
    }
}
