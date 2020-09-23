using Avalonia.Controls.Notifications;
using System;
using Tauridia.Core.Models;

namespace Tauridia.App.Views
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _this = this;
            CurrentContent = new ConnectViewModel();
        }

        public void NotifyError(Exception ex)
        {
            if (_notificationManager != null)
                _notificationManager.Show(new Notification("Ошибка", ex.Message, NotificationType.Error));
        }

        public void NotifyError(string message)
        {
            if (_notificationManager != null)
                _notificationManager.Show(new Notification("Ошибка", message, NotificationType.Error));
        }

        public void NotifyInfo(string message)
        {
            if (_notificationManager != null)
                _notificationManager.Show(new Notification("Инфо", message, NotificationType.Information));
        }

    }

}
