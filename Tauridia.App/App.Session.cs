using System.Net.Http;
using Tauridia.App.Core.Net.Api;
using Tauridia.App.Views;
using Tauridia.Core;
using Tauridia.Core.Models.Connection;

namespace Tauridia.App
{
    public class Session : Disposable
    {
        public HttpClientHandler ClientHandler { get; set; } = new HttpClientHandler() { UseDefaultCredentials = true };

        public ConnectionServer _connectionServer = null;
        public ConnectionServer ConnectionServer
        {
            get => _connectionServer;
            set { _connectionServer = value; InitApi(); }
        }


        public ApiController Api { get; private set; } = null;

        private void InitApi()
        {
            DisposeApi();
            if (ConnectionServer != null)
            {
                Api = new ApiController(ConnectionServer.Url, "/api");

                Api.OnException += Api_OnException;
            }
        }

        private void Api_OnException(object sender, System.Exception e)
        {
            if (e.HResult == -2146233088)
                MainWindowViewModel.This.CurrentContent = new LoginViewModel();
            else
                MainWindowViewModel.This.ShowError(e);
        }

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
    }
}
