using ReactiveUI;
using System.Reactive;

namespace Tauridia.App.ViewModels.Welcome
{
    public class ViewModel : ModelBase
    {
        public ViewModel()
        {

        }

        public ReactiveCommand<Unit, Unit> SettingsCommand => ReactiveCommand.Create(() =>  { MainWindow.ViewModel.This.CurrentContent = new Settings.ViewModel(); });
    }
}
