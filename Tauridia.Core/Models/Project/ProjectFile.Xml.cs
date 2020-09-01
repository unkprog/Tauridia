using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Tauridia.Core.Models.Project
{
    partial class ProjectFile
    {
        public virtual string XmlName => XmlFile;

        public const string XmlFile = "File";
        public const string XmlFiles = "Files";

        protected void WhileReadItem(XmlReader reader, Action<XmlReader> readerAction)
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

        public void Read(XmlReader reader)
        {
            this.ReadProperties(reader);
            WhileReadItem(reader, (reader) =>
            {
                this.ReadItems(reader);
            });
        }

        protected virtual void ReadProperties(XmlReader reader)
        {
            Name = reader.GetAttribute("Name");
        }

        protected virtual void ReadItems(XmlReader reader)
        {
            if (reader.Name == XmlFiles) 
                ReadFiles(reader);
        }

        private void ReadFiles(XmlReader reader)
        {
            WhileReadItem(reader, (reader) =>
            {
                if (reader.Name == XmlFile)
                {
                    ProjectFile projectFile = new ProjectFile();
                    projectFile.Read(reader);
                    this.Files.Add(projectFile);
                }

            });
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
