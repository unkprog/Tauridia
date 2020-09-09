using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Tauridia.App.Views.Settings
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
           
        }

    }
}
