using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using AppKit;
using DynamicData.Binding;

namespace UI.Utils
{
    /// <summary>
    /// Implementation is very similar to MvvmCross bindable table source
    /// https://github.com/MvvmCross/MvvmCross/blob/develop/MvvmCross/Platforms/Mac/Binding/Views/MvxTableViewSource.cs
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public abstract class DynamicReactiveTableDataSource<TSource> : NSTableViewSource
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        private readonly ReadOnlyObservableCollection<TSource> _items;

        protected DynamicReactiveTableDataSource(NSTableView tableView, ReadOnlyObservableCollection<TSource> source)
        {
            TableView = tableView ?? throw new ArgumentNullException(nameof(tableView));
            _items = source ?? throw new ArgumentNullException(nameof(source));

            _items.ToObservableChangeSet()
                .Subscribe(_ => TableView.ReloadData())
                .DisposeWith(_disposable);
        }

        protected NSTableView TableView { get; }

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            return GetOrCreateViewFor(tableView, tableColumn, GetItemAt(row));
        }

        protected abstract NSView GetOrCreateViewFor(NSTableView tableView, NSTableColumn tableColumn, TSource item);

        public override nint GetRowCount(NSTableView tableView)
        {
            return _items.Count;
        }
        
        private  TSource GetItemAt(nint row)
        {
            return _items[(int) row];
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposable.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}