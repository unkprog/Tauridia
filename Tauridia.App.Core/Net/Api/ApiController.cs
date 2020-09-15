using System;
using System.Net;
using System.Net.Http;
using Tauridia.Core;
using Tauridia.Core.Extensions;

namespace Tauridia.App.Core.Net.Api
{
    public class ApiController : Disposable
    {
        public ApiController(string url, string controller)
        {
            this.url = url;
            this.controller = controller;
        }

        private string url, controller;
        private HttpClientHandler handler = null;

        public event EventHandler<Exception> OnException;

        public void EmptyCredentials()
        {
            DisposeHandler();
        }

        public void UseDefaultCredentials()
        {
            DisposeHandler();
            handler = new HttpClientHandler() { UseDefaultCredentials = true };
        }

        public void UseCredentials(string userName, string password, string domain)
        {
            DisposeHandler();
            handler = new HttpClientHandler() { Credentials = new NetworkCredential(userName, password, domain) };
        }

        private void DisposeHandler()
        {
            if (handler != null)
                handler.Dispose();

            handler = null;
        }

        public T Get<T>(string command)
        {
            return Json.Get<T>(url, string.Concat(this.controller, command), handler, OnError);
        }

        public T Post<T, P>(string command, P data)
        {
            return Json.Post<T, P>(url, string.Concat(this.controller, command), data, handler, OnError);
        }

        private void OnError(Exception exception)
        {
            OnException?.Invoke(this, exception);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                OnException = null;
                DisposeHandler();
            }
            base.Dispose(disposing);
        }
    }
}
