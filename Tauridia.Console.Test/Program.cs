using System;
using System.Net;
using System.Net.Http;
using Tauridia.App.Views;
using Tauridia.App.Views.Settings;
using Tauridia.Core.Extensions;
using Utf8Json;

namespace Tauridia.Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.GetCurrentUser();

            using (HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true })
            {
                handler.UseDefaultCredentials = false;
                handler.Credentials = new NetworkCredential("usr5282797", "4dc3qnfA", "KROST");
                //myHttpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                string result = Json.Get<string>("https://localhost:44331", "api/connection", handler);
            }

        }
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
