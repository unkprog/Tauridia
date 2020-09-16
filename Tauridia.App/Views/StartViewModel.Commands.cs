using ReactiveUI;
using System.Reactive;
using System.Runtime.Serialization;

namespace Tauridia.App.Views
{
    public partial class StartViewModel
    {
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> CancelCommand => ReactiveCommand.Create(() => { MainWindowViewModel.This.CurrentContent = new ConnectViewModel(); });
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> OpenProjectCommand => ReactiveCommand.Create(() => { });
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> CreateProjectCommand => ReactiveCommand.Create(() => { MainWindowViewModel.This.CurrentContent = new NewProjectViewModel(); });
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> OpenInfobaseCommand => ReactiveCommand.Create(() => { });
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> CreateInfobaseCommand => ReactiveCommand.Create(() => { });
    }
}
