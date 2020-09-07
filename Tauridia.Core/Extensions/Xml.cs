using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Tauridia.Core.Extensions
{
    public static class XmlExtensions
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

        //public static string GetAttribute(this XmlReader reader, string name)
        //{
        //    Name = reader.GetAttribute("Name");
        //}

        public static void XmlRead(string path, string xmlName, Action<XmlReader> action)
        {
            if (File.Exists(path))
            {
                using (XmlReader reader = XmlReader.Create(path))
                {
                    while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == xmlName)
                            action.Invoke(reader);
                    }
                }
            }
        }

        public static void XmlWrite(string path, Action<XmlWriter> action)
        {
            using (TextWriter textWriter = File.CreateText(path))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, new XmlWriterSettings() { Indent = true, IndentChars = "\t", NewLineChars = System.Environment.NewLine, Encoding = new UTF8Encoding(true) }))
                {
                    xmlWriter.WriteStartDocument();
                    action?.Invoke(xmlWriter);
                    xmlWriter.WriteEndDocument();
                }
            }
        }
    }
}
