using System;
using System.Reactive.Disposables;
using ReactiveUI;

namespace UI.Utils
{
    public abstract class ViewBase<T> : ReactiveView<T> where T : class, IReactiveObject
    {
        protected CompositeDisposable Bindings { get; } = new CompositeDisposable();

        protected ViewBase(IntPtr intPtr) : base(intPtr)
        {
        }

        protected abstract void BindControls();
    }
}
