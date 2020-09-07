using System;
using System.Collections.Generic;
using System.Text;
using Tauridia.Core.Interfaces;

namespace Tauridia.Core.Extensions
{
    public static class ISerializableXmlExtensions
    {
        public static string XmlElementName(this ISerializableXml serializable)
        {
            return serializable.GetType().FullName;
        }
    }
}
