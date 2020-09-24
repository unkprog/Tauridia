using ReactiveUI;
using System.Reactive;
using System.Runtime.Serialization;

namespace Tauridia.App.Views
{
    public partial class NewProjectViewModel
    {
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> CreateCommand => ReactiveCommand.Create(CreateProject);

        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> CancelCommand => ReactiveCommand.Create(() => { MainWindowViewModel.This.CurrentContent = new StartViewModel(); });
    }
}
