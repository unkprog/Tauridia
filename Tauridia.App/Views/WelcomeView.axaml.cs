using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Tauridia.App.Views
{
    public class WelcomeView : UserControl
    {
        public WelcomeView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
