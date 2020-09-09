using System.Reactive;
using System.Runtime.Serialization;
using ReactiveUI;

namespace Tauridia.App.Views.Settings
{
    partial class SettingsViewModel
    {
        internal void InitCommands()
        {
            SaveCommand = ReactiveCommand.Create(Save);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> SaveCommand { get; private set; }

        [IgnoreDataMember]
        public ReactiveCommand<Unit, Unit> CancelCommand { get; private set; }


    }
}
