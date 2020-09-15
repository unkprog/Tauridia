using ReactiveUI;
using System.Reactive;
using System.Runtime.Serialization;

namespace Tauridia.App.Views.Project
{
    public partial class NewProjectViewModel
    {
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> CancelCommand => ReactiveCommand.Create(() => { MainWindowViewModel.This.CurrentContent = new StartViewModel(); });
    }
}
