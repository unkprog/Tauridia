using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Tauridia.Core.Extensions;
using Tauridia.Core.Models.Project;

namespace Tauridia.Core.Managers
{
    public class ProjectManager
    {
        internal static readonly string pathProjects = string.Concat(Environment.CurrentDirectory, @"\Projects");

        public List<Project> ListProjects()
        {
            List<Project> result = new List<Project>();
            string path = CheckDirectoryProject();

            string[] dirs = Directory.GetDirectories(path);

            foreach(var dir in dirs)
            {
                string[] prjs = Directory.GetFiles(dir, "*.tpj");
                if (prjs != null && prjs.Length > 0 && !string.IsNullOrEmpty(prjs[0]))
                {
                    string name = prjs[0].Replace(dir, string.Empty).Replace(".tpj", string.Empty);
                    if (!string.IsNullOrEmpty(name))
                        result.Add(ReadProject(name));
                }
            }

            return result;
        }

        public Project ReadProject(string name)
        {
            Project result = new Project();
            string path = string.Concat(CheckDirectoryProject(name), @"\", name, ".tpj");
            XmlExtensions.XmlRead(path, result.XmlName, (reader) =>
            {
                result.Read(reader);
            });
            return result;
        }

        private string CheckDirectoryProject(string name = null)
        {
            string result = pathProjects;
            if (!Directory.Exists(pathProjects))
                Directory.CreateDirectory(pathProjects);

            if (!string.IsNullOrEmpty(name))
            {
                result = string.Concat(result, @"\", name);

                if (!Directory.Exists(result))
                    Directory.CreateDirectory(result);
            }

            return result;
        }

        public void Save(Project prj)
        {
            string path = string.Concat(CheckDirectoryProject(prj.Name), @"\", prj.Name, ".tpj");

            XmlExtensions.XmlWrite(path, (writer) =>
            {
                prj.Write(writer);
            });
        }
    }
}
