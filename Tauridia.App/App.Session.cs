using System;
using System.Net.Http;
using Tauridia.App.Core.Net.Api;
using Tauridia.App.Views;
using Tauridia.Core;
using Tauridia.Core.Exceptions;
using Tauridia.Core.Models.Connection;

namespace Tauridia.App
{
    public class Session : Disposable
    {
        public ConnectionServer _connectionServer = null;
        public ConnectionServer ConnectionServer
        {
            get => _connectionServer;
            set { _connectionServer = value; }
        }

        public ApiController Api { get; private set; } = null;

        public void InitApi()
        {
            DisposeApi();
            if (ConnectionServer != null)
            {
                Api = new ApiController(ConnectionServer.Url, "/api");
                Api.OnException += Api_OnException;
            }
        }

        private void Api_OnException(object sender, HttpException e)
        {
            if (e.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                MainWindowViewModel.This.CurrentContent = new LoginViewModel();
            else
                MainWindowViewModel.This.NotifyError(e);
        }

#region Connection
        public void Connect()
        {
            string str = Api.Get<string>("/connection");
            if(str == "Ok")
                MainWindowViewModel.This.CurrentContent = new StartViewModel();
            else
                MainWindowViewModel.This.CurrentContent = new LoginViewModel();
        }

        public void Disconnect()
        {
            MainWindowViewModel.This.CurrentContent = new OpenProjectViewModel();
        }

#endregion

#region IDisposable
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                DisposeApi();
            }

            base.Dispose(disposing);
        }

        private void DisposeApi()
        {
            if (Api != null)
            {
                Api.OnException -= Api_OnException;
                Api.Dispose();
                Api = null;
            }
        }
#endregion

    }
}
