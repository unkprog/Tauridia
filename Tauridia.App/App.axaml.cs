using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Tauridia.App.ViewModels;
using Tauridia.App.Views;

namespace Tauridia.App
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new ViewModels.MainWindow.ViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
