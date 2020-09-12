using System.Collections.Generic;
using System.IO;
using Utf8Json;
using Utf8Json.Resolvers;

namespace Tauridia.Core.Extensions
{
    public static partial class Json
    {
       
    
        public static T Read<T>(string path)
        {
            T result = default;
            if (File.Exists(path))
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    result = JsonSerializer.Deserialize<T>(reader.BaseStream);
                }
            }
            return result;
        }

        public static void Write<T>(string path, T obj)
        {
            using (StreamWriter streamWriter = File.CreateText(path))
            {
                string jsonString = System.Text.Encoding.UTF8.GetString(JsonSerializer.Serialize(obj, Utf8Json.Resolvers.StandardResolver.Default)); // StandardResolver.Default);//);
                streamWriter.Write(jsonString);
            }
        }
    }
}
