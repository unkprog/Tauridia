using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tauridia.App;
using Tauridia.App.Views;
using Tauridia.App.Views.Settings;
using Tauridia.Core.Extensions;
using Tauridia.Core.Models.Project;
using Utf8Json;

namespace Tauridia.Console.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {


            using (HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true })
            {
                handler.UseDefaultCredentials = false;
                handler.Credentials = new NetworkCredential("usr5282797", "4dc3qnfA", "KROST");

                using (HttpClient client = (handler == null ? new HttpClient() : new HttpClient(handler)))
                {
                    client.BaseAddress = new Uri("https://localhost:44331");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res1 = await client.GetAsync("api/connection");
                    var sss = JsonSerializer.ToJsonString(new Project() { Name = "ТестовыйПроект", Description = "Description" });
                    var res2 = await client.PostAsJsonAsync("api/project/create", new Project() { Name = "ТестовыйПроект", Description = "Description" });


                    //string result = Json.Get<string>("https://localhost:44331", "api/connection", handler);
                    //string str = Json.Post<string, Project>("https://localhost:44331", "/project/create", new Project() { Name = "ТестовыйПроект", Description = "Description" }, handler);
                }
            
            }


        }

        //internal static async Task<TResult> HttpClientInvoke<TResult>(string server, HttpClientHandler handler, Action<Exception> onError, Func<HttpClient, Task<HttpResponseMessage>> func)
        //{
        //    TResult result = default(TResult);
        //    HttpResponseMessage response = null;
        //    try
        //    {
        //        using (HttpClient client = (handler == null ? new HttpClient() : new HttpClient(handler)))
        //        {
        //            client.BaseAddress = new Uri(server);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    
        //            response = await func.Invoke(client);
        //            response.EnsureSuccessStatusCode();

        //            if (response != null)
        //                result = await response.Content.ReadAsJsonAsync<TResult>();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        onError?.Invoke(ex);
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }

        //    return result;
        //}

        //static void Main(string[] args)
        //{
        //    ConnectionsServersViewModel cn = new ConnectionsServersViewModel();
        //    Session session = new Session();
        //    session.ConnectionServer = cn.ListServers[0];
        //    session.InitApi();
        //    session.Connect();
        //    session.Api.UseCredentials("usr5282797", "4dc3qnfA", "KROST");
        //    string str = session.Api.Post<string, Project>("/project/create", new Project() { Name = "ТестовыйПроект", Description= "Description" });
        //    //string str = session.Api.Post<string, Project>("/project/create", new Project() { Name = "ТестовыйПроект" });

        //    //str = session.Api.Get<string>("/project");
        //}

        //static void Main(string[] args)
        //{
        //    ConnectionsServersViewModel cn = new ConnectionsServersViewModel();
        //    Session session = new Session();
        //    session.ConnectionServer = cn.ListServers[0];
        //    session.InitApi();
        //    session.Connect();
        //    string str = session.Api.Get<string>("/connection");

        //    str = session.Api.Get<string>("/project");
        //}


        //static void Main(string[] args)
        //{
        //    LoginViewModel viewModel = new LoginViewModel();
        //    viewModel.GetCurrentUser();

        //    using (HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true })
        //    {
        //        handler.UseDefaultCredentials = false;
        //        handler.Credentials = new NetworkCredential("usr5282797", "4dc3qnfA", "KROST");
        //        //myHttpWebRequest.Credentials = CredentialCache.DefaultCredentials;
        //        string result = Json.Get<string>("https://localhost:44331", "api/connection", handler);
        //    }

        //}
        //    static void Main(string[] args)
        //{
        //    System.Console.WriteLine("Hello World!");

        //    var cre = CredentialCache.DefaultCredentials;

        //    SettingsViewModel model = new SettingsViewModel();

        //    model.Save();

        //    ConnectionsServersViewModel obj = new ConnectionsServersViewModel() { Name = "Подключения" };

        //    //    string jsonString = System.Text.Encoding.UTF8.GetString(JsonSerializer.Serialize(model, Utf8Json.Resolvers.StandardResolver.Default)); // StandardResolver.Default);//);
        //    //System.Console.WriteLine(jsonString);

        //    string jsonString = System.Text.Encoding.UTF8.GetString(JsonSerializer.Serialize(new TwoModel(), Utf8Json.Resolvers.StandardResolver.Default)); 
        //    System.Console.WriteLine(jsonString);

        //    //Utf8Json.Resolvers.
        //}
    }
}
