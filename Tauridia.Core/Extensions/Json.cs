using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Utf8Json;

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

        internal static async Task<TResult> HttpClientInvoke<TResult>(string server, HttpClientHandler handler, Action<Exception> onError, Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            TResult result = default(TResult);
            HttpResponseMessage response = null;
            try
            {
                using (HttpClient client = (handler == null ? new HttpClient() : new HttpClient(handler)))
                {
                    client.BaseAddress = new Uri(server);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    response = await func.Invoke(client);
                    response.EnsureSuccessStatusCode();

                    if (response != null)
                        result = await response.Content.ReadAsJsonAsync<TResult>();
                }
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return result;
        }


        public static TResult Get<TResult>(string server, string url, HttpClientHandler handler = null, Action<Exception> onError = null)
        {
            Task<TResult> taskResult = Task.Run(async () =>
            {
                return await GetAsync<TResult>(server, url, handler, onError);
            });
            taskResult.Wait();
            return taskResult.Result;
        }

        public static async Task<TResult> GetAsync<TResult>(string server, string url, HttpClientHandler handler = null, Action<Exception> onError = null)
        {
            return await HttpClientInvoke<TResult>(server, handler, onError, (client) =>
            {
                return client.GetAsync(url);
            });
        }

        public static TResult Post<TResult, TParam>(string server, string url, TParam data, HttpClientHandler handler = null, Action<Exception> onError = null)
        {
            Task<TResult> taskResult = Task.Run(async () =>
            {
                return await PostAsync<TResult, TParam>(server, url, data, handler, onError);
            });
            taskResult.Wait();
            return taskResult.Result;
        }

        public static async Task<TResult> PostAsync<TResult, TParam>(string server, string url, TParam data, HttpClientHandler handler = null, Action<Exception> onError = null)
        {
            return await HttpClientInvoke<TResult>(server, handler, onError, (client) =>
            {
                return client.PostAsJsonAsync(url, data);
            });
        }

    }
}
