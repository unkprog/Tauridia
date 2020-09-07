using System.Xml;

namespace Tauridia.Core.Interfaces
{
    public interface ISerializableXml
    {
        void Read(XmlReader reader);
        void Write(XmlWriter writer);
    }


}
