using ReactiveUI;
using System.Reactive;

namespace Tauridia.App.Views
{
    public partial class StartViewModel
    {
        public ReactiveCommand<Unit, Unit> OpenProjectCommand => ReactiveCommand.Create(() => {  });
        public ReactiveCommand<Unit, Unit> CreateProjectCommand => ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit, Unit> OpenInfobaseCommand => ReactiveCommand.Create(() => { });
        public ReactiveCommand<Unit, Unit> CreateInfobaseCommand => ReactiveCommand.Create(() => { });
    }
}
