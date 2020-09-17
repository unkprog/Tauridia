using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;

namespace Tauridia.Core.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var dataAsString = await content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(dataAsString);
        }

        //public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient httpClient, string url, T data)
        //{
        //    //var dataAsString = JsonSerializer.ToJsonString(data);
        //    //var content = new StringContent(dataAsString, Encoding.UTF8, "application/json");
        //    //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    //return httpClient.PostAsync(url, content);

        //    var dataAsString = JsonSerializer.ToJsonString(data);
        //    var message = new HttpRequestMessage
        //    {
        //        RequestUri = new Uri(httpClient.BaseAddress.OriginalString + url),
        //        Method = HttpMethod.Post,
        //        Content = new StringContent(dataAsString, Encoding.UTF8, "application/json") { Headers = { ContentType = new MediaTypeHeaderValue("application/json") } }
        //    };
        //    return httpClient.SendAsync(message);
        //}
    }
}
