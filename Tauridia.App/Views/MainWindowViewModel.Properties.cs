using System.Runtime.Serialization;
using Avalonia.Controls.Notifications;
using ReactiveUI;
using Tauridia.Core.Models;

namespace Tauridia.App.Views
{
    public partial class MainWindowViewModel
    {
        private static MainWindowViewModel _this = null;
        public static MainWindowViewModel This
        {
            get { if (_this == null) _this = new MainWindowViewModel(); return _this; }
        }

        private ViewModelBase _currentContent;
        [DataMember]
        public ViewModelBase CurrentContent
        {
            get => _currentContent;
            set => this.RaiseAndSetIfChanged(ref _currentContent, value);
        }

        internal WindowNotificationManager _notificationManager { get; set; }
    }
}
