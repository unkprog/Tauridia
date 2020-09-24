using ReactiveUI;
using System.Reactive;

namespace Tauridia.App.Views
{
    partial class AboutViewModel
    {
        public ReactiveCommand<Unit, Unit> CloseCommand => ReactiveCommand.Create(() => { MainWindowViewModel.This.CurrentContent = new OpenProjectViewModel(); });
    }
}
