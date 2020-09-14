using System;
using System.Collections.Generic;
using System.Text;

namespace Tauridia.Core
{
    public class Disposable : IDisposable
    {
        bool disposed = false;
        public void Dispose()
        {
            Disposing(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
          
        }

        private void Disposing(bool disposing)
        {
            if (disposed)
                return;

            Dispose(disposing);

            disposed = true;
        }

    }
}
