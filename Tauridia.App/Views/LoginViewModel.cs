using System;
using System.Runtime.Serialization;
using Tauridia.Core.Models;

namespace Tauridia.App.Views
{
    [DataContract]
    public partial class LoginViewModel : ViewModelBase
    {

        public void GetCurrentUser()
        {
            UserName = string.Concat(Environment.UserDomainName, "\\", Environment.UserName);
            //Environment.
        }

        public void Ok()
        {
        }

   

        public void Cancel()
        {
            MainWindowViewModel.This.CurrentContent = new ConnectViewModel();
        }

    }
}
