using System;
using System.Runtime.Serialization;
using Tauridia.Core.Models;

namespace Tauridia.App.Views
{
    [DataContract]
    public partial class LoginViewModel : ViewModelBase
    {
        public void Login()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                MainWindowViewModel.This.NotifyError("Укажите имя пользователя");
                return;
            }

        }



        public void Cancel()
        {
            MainWindowViewModel.This.CurrentContent = new ConnectViewModel();
        }

    }
}
