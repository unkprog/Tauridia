using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Tauridia.Core.Models.Project
{

    public static class ProjectModelXmlExtensions
    {
        //public void Read(XmlReader Reader)
        //{
        //    Code = Reader.GetAttribute("Code");
        //    Name = Reader.GetAttribute("Name");
        //    Description = Reader.GetAttribute("Description");

        //    while (Reader.Read() && Reader.NodeType != XmlNodeType.EndElement)
        //    {
        //        if (Reader.NodeType == XmlNodeType.Element && !Reader.IsEmptyElement)
        //        {
        //            if (Reader.Name == "ProjectDependencies") ReadProjectDependencies(Reader);
        //            else if (Reader.Name == "Items") ProjectItemExtensions.ReadItems(this, Reader);
        //        }
        //    }
        //}

        //public void ReadProjectDependencies(XmlReader Reader)
        //{
        //    while (Reader.Read() && Reader.NodeType != XmlNodeType.EndElement)
        //    {
        //        if (Reader.NodeType == XmlNodeType.Element && !Reader.IsEmptyElement)
        //        {
        //            if (Reader.Name == "Project")
        //            {
        //                IProject project = new Project(ProjectManager.Manager);
        //                project.Read(Reader);
        //                _ProjectDependencies.Add(project);
        //            }
        //        }
        //    }
        //}

        //public void ReadProjectItems(XmlReader Reader)
        //{
        //    while (Reader.Read() && Reader.NodeType != XmlNodeType.EndElement)
        //    {
        //        if (Reader.Name == "ProjectItem")
        //        {
        //            IProjectItem projectItem = new ProjectItem(ProjectManager.Manager);
        //            projectItem.Read(Reader);
        //            Items.Add(projectItem);
        //        }
        //    }
        //}

        //public void Read(string path)
        //{
        //    string pathProject = path;
        //    pathProject = string.Concat(pathProject, @"\\", Name, ".dpj");
        //    if (File.Exists(pathProject))
        //    {
        //        using (XmlReader xmlReader = XmlReader.Create(pathProject))
        //        {
        //            while (xmlReader.Read())
        //            {
        //                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Project")
        //                    Read(xmlReader);
        //            }
        //        }
        //    }
        //}

        public static void Write(XmlWriter Writer)
        {
            Writer.WriteStartElement("Project");
            Writer.WriteAttributeString("Code", Code);
            Writer.WriteAttributeString("Name", Name);
            Writer.WriteAttributeString("Description", Description);

            Writer.WriteStartElement("ProjectDependencies");
            for (int i = 0, icount = _ProjectDependencies.Count; i < icount; i++)
            {
                Writer.WriteStartElement("Project");
                Writer.WriteAttributeString("Code", _ProjectDependencies[i].Code);
                Writer.WriteAttributeString("Name", _ProjectDependencies[i].Name);
                Writer.WriteAttributeString("Description", _ProjectDependencies[i].Description);
                Writer.WriteEndElement();
            }
            Writer.WriteEndElement();

            ProjectItemExtensions.WriteItems(this, Writer);

            Writer.WriteEndElement();
        }

        public static void Save(this ProjectModel prj, string path)
        {
            string pathProject = path;
            if (pathProject == null) pathProject = string.Empty;

            CheckProjectDirectory(pathProject);

            pathProject = string.Concat(pathProject, @"\\", prj.Name, ".tpj");
            using (TextWriter textWriter = File.CreateText(pathProject))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, new XmlWriterSettings() { Indent = true, IndentChars = "\t", NewLineChars = System.Environment.NewLine }))
                {
                    xmlWriter.WriteStartDocument();
                    Write(xmlWriter);
                    xmlWriter.WriteEndDocument();
                }
            }
        }

    }
}