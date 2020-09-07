﻿using System.Xml;
using Tauridia.Core.Extensions;
using Tauridia.Core.Interfaces;

namespace Tauridia.App.ViewModels
{
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
            string name = this.GetType().FullName;
            writer.WriteStartElement(name.Substring(name.LastIndexOf('.') + 1));

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
