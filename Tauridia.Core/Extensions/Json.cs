﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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

        public static TResult Post<TResult, TParam>(string server, string url, TParam data)
        {
            Task<TResult> getResult = PostAsync<TResult, TParam>(server, url, data);
            getResult.Wait();
            return getResult.Result;
        }

        public static async Task<TResult> PostAsync<TResult, TParam>(string server, string url, TParam data)
        {
            TResult result = default(TResult);
            HttpResponseMessage response = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(server);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    response = await client.PostAsJsonAsync(url, data);
                    response.EnsureSuccessStatusCode();


                    if (response != null)
                        result = await response.Content.ReadAsJsonAsync<TResult>();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }

            return result;
        }

        public static TResult Get<TResult>(string server, string url)
        {
            Task<TResult> getResult = GetAsync<TResult>(server, url);
            getResult.Wait();
            return getResult.Result;
        }

        public static async Task<TResult> GetAsync<TResult>(string server, string url)
        {
            TResult result = default(TResult);
            HttpResponseMessage response = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(server);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
            }

            if (response != null)
                result = await response.Content.ReadAsJsonAsync<TResult>();

            return result;
        }
    }

    //public static class HttpContentExt
    //{

    //    public static async Task<T> ReadAsAsync<T>(this HttpContent content)
    //    {
    //        return Json.Parse<T>(await content.ReadAsStringAsync());
    //        //return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await content.ReadAsStringAsync());
    //    }
    //}

    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.ToJsonString(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return httpClient.PostAsync(url, content);
        }

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var dataAsString = await content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(dataAsString);
        }
    }
}
