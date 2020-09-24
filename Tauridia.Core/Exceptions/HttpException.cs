using System;
using System.Net;

namespace Tauridia.Core.Exceptions
{
    public class HttpException : Exception
    {
        public HttpException(HttpStatusCode? statusCode, string message = null, Exception innerException = null) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode? StatusCode { get; private set; }
    }
}
