using System.IO;
using System.Runtime.Serialization;
using Tauridia.Core.Models;
using Tauridia.Core.Extensions;
using System.ComponentModel;

namespace Tauridia.App.Views.Settings
{
    [DataContract]
    public partial class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel()
        {
            InitProperties();
        }

        public void Load()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    CheckDirectorySettings();
                    SettingsViewModel loadedSettings = Json.Read<SettingsViewModel>(GetFileNameSettings());
                    InitProperties(loadedSettings);
                }
                catch { }
            }
        }

        public void Save()
        {
            Json.Write(GetFileNameSettings(), this);
            MainWindowViewModel.This.CurrentContent = new ConnectViewModel();
        }

        public void Cancel()
        {
            Load();
            MainWindowViewModel.This.CurrentContent = new ConnectViewModel();
        }

        private string CheckDirectorySettings()
        {
            string result = pathSettings;
            if (!Directory.Exists(pathSettings))
                Directory.CreateDirectory(pathSettings);
            return result;
        }

        private string GetFileNameSettings()
        {
            return string.Concat(CheckDirectorySettings(), @"\settings.config");
        }
    }
}
