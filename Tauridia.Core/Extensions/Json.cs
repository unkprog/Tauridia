using System.Collections.Generic;
using System.IO;


namespace Tauridia.Core.Extensions
{
    public static partial class Json
    {
        public static object Parse(string json)
        {
            return new JsonParser(json).Decode();
        }

        public static string Serialize(object obj, SerializeOptions options = null)
        {
            return new JsonSerializer(options).ToJson(obj);
        }


        public static T Read<T>(string path)
        {
            T result = default;
            if (File.Exists(path))
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    //result = JsonSerializer.Deserialize<T>(reader.BaseStream);
                }
            }
            return result;
        }


        private static SerializeOptions defaultOptions = new SerializeOptions()
        {
            ExcludeProperties = new Dictionary<string, bool>(new KeyValuePair<string, bool>[]
            {
                new KeyValuePair<string, bool>("Changing", false),
                new KeyValuePair<string, bool>("Changed", false),
                new KeyValuePair<string, bool>("ThrownExceptions", false)
            })
        };

        public static void Write<T>(string path, T obj, SerializeOptions options = null)
        {
            using (StreamWriter streamWriter = File.CreateText(path))
            {
                string jsonString = Serialize(obj, options == null ? defaultOptions : options);
                streamWriter.Write(jsonString);
            }
        }
    }
}
