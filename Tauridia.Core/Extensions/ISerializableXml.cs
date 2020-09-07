using System;
using System.Collections.Generic;
using System.Text;
using Tauridia.Core.Interfaces;

namespace Tauridia.Core.Extensions
{
    public static class ISerializableXmlExtensions
    {
        public static string XmlElementFullName(this ISerializableXml serializable)
        {
            return serializable.GetType().FullName;
        }

        public static string XmlElementShortName(this ISerializableXml serializable)
        {
            string result = serializable.XmlElementFullName();
            result = result.Substring(result.LastIndexOf('.'));
            return result;
        }
    }
}
