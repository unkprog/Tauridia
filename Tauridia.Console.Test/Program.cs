using System;
using System.Net;
using Tauridia.App.Views.Settings;
using Utf8Json;

namespace Tauridia.Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            var cre = CredentialCache.DefaultCredentials;

            SettingsViewModel model = new SettingsViewModel();

            model.Save();

            ConnectionsServersViewModel obj = new ConnectionsServersViewModel() { Name = "Подключения" };

            //    string jsonString = System.Text.Encoding.UTF8.GetString(JsonSerializer.Serialize(model, Utf8Json.Resolvers.StandardResolver.Default)); // StandardResolver.Default);//);
            //System.Console.WriteLine(jsonString);

            string jsonString = System.Text.Encoding.UTF8.GetString(JsonSerializer.Serialize(new TwoModel(), Utf8Json.Resolvers.StandardResolver.Default)); 
            System.Console.WriteLine(jsonString);

            //Utf8Json.Resolvers.
        }
    }
}
