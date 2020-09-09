using System.Reactive;
using System.Runtime.Serialization;
using ReactiveUI;

namespace Tauridia.App.Views.Settings
{
    partial class SettingsViewModel
    {
        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> SaveCommand => ReactiveCommand.Create(Save);

        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> CancelCommand => ReactiveCommand.Create(Cancel);


    }
}
