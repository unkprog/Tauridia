using ReactiveUI;
using System.Reactive;
using Tauridia.App.ViewModels;

namespace Tauridia.App.Views
{
    public class WelcomeViewModel : ViewModelBase
    {
        public WelcomeViewModel()
        {

        }

        public ReactiveCommand<Unit, Unit> SettingsCommand => ReactiveCommand.Create(() =>  { MainWindowViewModel.This.CurrentContent = new Settings.SettingsViewModel(); });
    }
}
