using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Tauridia.Core.Models.Project
{

    public partial class Project
    {
        public override string XmlName => XmlProject;

        public const string XmlProject = "Project";
        public const string XmlDependencies = "Dependencies";

        protected override void ReadProperties(XmlReader reader)
        {
            base.ReadProperties(reader);
        }

        protected override void ReadItems(XmlReader reader)
        {
            if (reader.Name == XmlDependencies) ReadDependencies(reader);
            else base.ReadItems(reader);
        }

        private void ReadDependencies(XmlReader reader)
        {
            WhileReadItem(reader, (reader) =>
            {
                if (reader.Name == XmlProject)
                {
                    Project project = new Project();
                    project.Read(reader);
                    this.Dependencies.Add(project);
                }
            });
        }

        protected override void WriteItems(XmlWriter writer)
        {
            base.WriteItems(writer);
            WriteDependencies(writer);
        }

        private void WriteDependencies(XmlWriter writer)
        {
            if (Dependencies.Count == 0) return;

            writer.WriteStartElement(XmlDependencies);
            for (int i = 0, icount = this.Dependencies.Count; i < icount; i++)
            {
                this.Dependencies[i].Write(writer);
            }
            writer.WriteEndElement();
        }

    }
}