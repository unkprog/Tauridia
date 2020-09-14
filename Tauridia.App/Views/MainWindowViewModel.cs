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


        public void ShowError(Exception ex)
        {

        }

    }

}
