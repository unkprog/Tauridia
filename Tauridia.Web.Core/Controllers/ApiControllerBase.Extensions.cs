using System;
using System.Threading.Tasks;
using Tauridia.Core.Http;

namespace Tauridia.Web.Core.Controllers
{
    public static class ApiControllerBaseExtensions
    {
        public static HttpMessage<P> TryCatch<T, P>(this ApiControllerBase<T> controller, Func<P> func)
        {
            HttpMessage<P> result;
            try
            {
                result = new HttpMessage<P>() { Data = func.Invoke() };
            }
            catch (Exception ex)
            {
                result = new HttpMessage<P>() { Data = default(P), Result = -1, Error = ex.Message };
                controller.WriteError(ex);
            }
            return result;
        }

        //public static async Task<HttpMessage<P>> TryCatchAsync<T, P>(this ApiControllerBase<T> controller, Func<Task<HttpMessage<P>>> func)
        //{
        //    Task<HttpMessage<P>> result;
        //    try
        //    {
        //        Task<HttpMessage<P>> taskInvoke = func?.Invoke();
        //        return await taskInvoke;
        //    }
        //    catch (Exception ex)
        //    {
        //        result = new Task<HttpMessage<P>>(async (o) => return new HttpMessage<P>() { Data = default(P), Result = -1, Error = ex.Message });
        //        controller.WriteError(ex);
        //    }
        //    return default(P);
        //}

    }
}
