using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Tauridia.Core.Models.Project;

namespace Tauridia.Core.Managers
{
    public class ProjectManager
    {
        internal static readonly string pathProjects = string.Concat(Environment.CurrentDirectory, @"\Projects");

        public Project ReadProject(string name)
        {
            Project result = null;
            string path = string.Concat(CheckDirectoryProject(name), @"\", name, ".tpj");
            if (File.Exists(path))
            {
                result = new Project();
                using (XmlReader reader = XmlReader.Create(path))
                {
                    while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == result.XmlName)
                            result.Read(reader);
                    }
                }
            }
            return result;
        }

        private string CheckDirectoryProject(string name)
        {
            string result = string.Concat(pathProjects, @"\", name);

            if (!Directory.Exists(result))
                Directory.CreateDirectory(result);

            return result;
        }

        public void Save(Project prj)
        {
            string path = string.Concat(CheckDirectoryProject(prj.Name), @"\", prj.Name, ".tpj");

            using (TextWriter textWriter = File.CreateText(path))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, new XmlWriterSettings() { Indent = true, IndentChars = "\t", NewLineChars = System.Environment.NewLine }))
                {
                    xmlWriter.WriteStartDocument();
                    prj.Write(xmlWriter);
                    xmlWriter.WriteEndDocument();
                }
            }
        }
    }
}
