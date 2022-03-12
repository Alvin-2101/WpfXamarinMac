using System;
using System.Reactive.Disposables;
using ReactiveUI;

namespace UI.Utils
{
    public abstract class ViewControllerBase<T> : ReactiveViewController<T> where T : class
    {
        protected ViewControllerBase(IntPtr intPtr) : base(intPtr)
        {
        }
    }
}
