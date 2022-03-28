using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;

namespace UI.Utils
{
    public abstract class ViewModelBase : ReactiveObject, IActivatableViewModel
    {
        protected ViewModelBase()
        {
            Activator = new ViewModelActivator();
            
            this.WhenActivated(disposables =>
            {
                HandleActivation(disposables);

                Disposable
                    .Create(HandleDeactivation)
                    .DisposeWith(disposables);
            });
        }

        protected abstract void HandleActivation(CompositeDisposable disposable);

        protected abstract void HandleDeactivation();

        public ViewModelActivator Activator { get; }
    }
}