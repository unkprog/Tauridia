
using ReactiveUI;
using System.Reactive;

namespace Tauridia.App.Views
{
    public partial class ConnectViewModel
    {
        public ReactiveCommand<Unit, Unit> SettingsCommand => ReactiveCommand.Create(() => { MainWindowViewModel.This.CurrentContent = App.Settings; });
        public ReactiveCommand<Unit, Unit> AboutCommand => ReactiveCommand.Create(() => { MainWindowViewModel.This.CurrentContent = new AboutViewModel(); });

        public ReactiveCommand<Unit, Unit> ConnectCommand => ReactiveCommand.Create(() => { MainWindowViewModel.This.CurrentContent = new LoginViewModel(); });
        
    }
}
