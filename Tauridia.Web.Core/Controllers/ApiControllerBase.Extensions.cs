using System;
using System.Threading.Tasks;

namespace Tauridia.Web.Core.Controllers
{
    public static class ApiControllerBaseExtensions
    {
        public static P TryCatch<T, P>(this ApiControllerBase<T> controller, Func<P> func)
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception ex)
            {
                controller.WriteError(ex);
            }
            return default(P);
        }

        public static async Task<P> TryCatchAsync<T, P>(this ApiControllerBase<T> controller, Func<Task<P>> func)
        {
            try
            {
                Task<P> taskInvoke = func?.Invoke();
                return await taskInvoke;
            }
            catch (Exception ex)
            {
                controller.WriteError(ex);
            }
            return default(P);
        }

    }
}
