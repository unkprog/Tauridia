using Tauridia.App.Views.Settings;

namespace Tauridia.App
{
    public partial class App 
    {
        public static SettingsViewModel Settings { get; } = new SettingsViewModel();
    }
}
