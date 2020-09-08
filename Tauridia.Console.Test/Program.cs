using System;
using Tauridia.App.Views.Settings;
using Utf8Json;

namespace Tauridia.Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            SettingsViewModel model = new SettingsViewModel();
            ConnectionsServersViewModel obj = new ConnectionsServersViewModel() { Name = "Подключения" };

                string jsonString = System.Text.Encoding.UTF8.GetString(JsonSerializer.Serialize(model.ListSettings[0].li, Utf8Json.Resolvers.StandardResolver.Default)); // StandardResolver.Default);//);
            System.Console.WriteLine(jsonString);

            //jsonString = System.Text.Encoding.UTF8.GetString(JsonSerializer.Serialize(new TwoModel(), Utf8Json.Resolvers.StandardResolver.Default)); // StandardResolver.Default);//);
            //System.Console.WriteLine(jsonString);

            //Utf8Json.Resolvers.
        }
    }
}
