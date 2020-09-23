using System;
using System.Net;
using System.Net.Http;
using Tauridia.Core;
using Tauridia.Core.Exceptions;
using Tauridia.Core.Extensions;
using Tauridia.Core.Http;

namespace Tauridia.App.Core.Net.Api
{
    public class ApiController : Disposable
    {
        public ApiController(string url, string controller)
        {
            this.url = url;
            this.controller = controller;
            UseDefaultCredentials();
        }

        private string url, controller;
      
        public event EventHandler<HttpException> OnException;

        public void EmptyCredentials()
        {
            getHandler = () => null;
        }

        Func<HttpClientHandler> getHandler = null;
        public void UseDefaultCredentials()
        {
            getHandler = () => new HttpClientHandler() { UseDefaultCredentials = true };
        }


        public void UseCredentials(string userName, string password, string domain)
        {
            getHandler = () => new HttpClientHandler() { Credentials = new NetworkCredential(userName, password, domain) };
        }

        private void DisposeHandler()
        {
            getHandler = null;
        }

        public T Get<T>(string command)
        {
            return Json.Get<T>(url, string.Concat(this.controller, command), getHandler?.Invoke(), OnError);
        }

        public void HttpMessageGet<T>(string command, Action<T> successAction)
        {
            HttpMessage<T> result = Json.Get<HttpMessage<T>>(url, string.Concat(this.controller, command), getHandler?.Invoke(), OnError);
            if (result.Result == -1)
                OnError(new HttpException(result.Error));
            else
                successAction?.Invoke(result.Data);
        }

        public T Post<T, P>(string command, P data)
        {
            return Json.Post<T, P>(url, string.Concat(this.controller, command), data, getHandler?.Invoke(), OnError);
        }

        public void HttpMessagePost<T, P>(string command, P data, Action<T> successAction)
        {
            HttpMessage<T> result = Json.Post<HttpMessage<T>, P>(url, string.Concat(this.controller, command), data, getHandler?.Invoke(), OnError);
            if(result.Result == -1)
                OnError(new HttpException(result.Error));
            else 
                successAction?.Invoke(result.Data);
        }

        private void OnError(HttpException exception)
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
