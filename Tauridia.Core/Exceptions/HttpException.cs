using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Tauridia.Core.Exceptions
{
    public class HttpException : Exception
    {
        public HttpException()
        {

        }
      
        public HttpException(string? message) : base(message)
        {

        }

        public HttpException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

        public HttpException(HttpStatusCode? statusCode, string? message) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode? StatusCode { get; private set; }
    }
}
