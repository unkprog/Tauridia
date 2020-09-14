using System.Runtime.Serialization;
using ReactiveUI;
using System.Reactive;

namespace Tauridia.App.Views
{
    public partial class LoginViewModel
    {
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> SaveCommand => ReactiveCommand.Create(Login);

        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> CancelCommand => ReactiveCommand.Create(Cancel);
    }
}
