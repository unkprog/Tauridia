using System;

using System.Xml;

namespace Tauridia.Core.Extensions
{
    public static class Xml
    {
        public static void WhileReadItem(this XmlReader reader, Action<XmlReader> readerAction)
        {
            if (!reader.IsEmptyElement)
            {
                while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        readerAction?.Invoke(reader);
                    }
                }
            }
        }
    }
}
