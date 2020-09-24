using System.Runtime.Serialization;
using ReactiveUI;
using System.Reactive;

namespace Tauridia.App.Views.Settings
{
    partial class ConnectionsServersViewModel
    {
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> AddConnectionCommand => ReactiveCommand.Create(AddConnection);
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> RemoveConnectionCommand => ReactiveCommand.Create(RemoveConnection);
    }
}
