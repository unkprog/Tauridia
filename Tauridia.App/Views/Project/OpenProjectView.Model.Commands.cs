
using ReactiveUI;
using System.Reactive;

namespace Tauridia.App.Views
{
    public partial class OpenProjectViewModel
    {
        public ReactiveCommand<Unit, Unit> OpenProjectCommand => ReactiveCommand.Create(() =>
        {
            if (SelectedProject == null)
            {
                MainWindowViewModel.This.NotifyError("Выберите проект.");
                return;
            }
            MainWindowViewModel.This.CurrentContent = new ProjectViewModel(SelectedProject);
        });

        public ReactiveCommand<Unit, Unit> CancelCommand => ReactiveCommand.Create(() => { MainWindowViewModel.This.CurrentContent = new StartViewModel(); });
    }
}
