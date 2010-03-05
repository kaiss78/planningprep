using System;

namespace App.Core.Base
{
    public abstract class DisposableBase : IDisposable
    {
        protected bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    DisposeInternal();
                }
            }

            _isDisposed = true;
        }

        protected virtual void DisposeInternal()
        {
            
        }

        ~DisposableBase()
        {
            Dispose(false);
        }
    }
}
