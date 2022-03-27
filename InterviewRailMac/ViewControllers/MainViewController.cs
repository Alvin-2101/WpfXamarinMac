using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using UI.Utils;
using System.Linq;

namespace UI
{

    public partial class MainViewController : ViewControllerBase<MainViewModel>
    {
        public MainViewController(IntPtr handle) : base(handle)
        {
            ViewModel = new MainViewModel();
            this.WhenActivated(disposables =>
            {
                this.WhenAnyValue(x => x.ViewModel)
                    .Where(x => x != null)
                    .Do(PopulateFromViewModel)
                    .Subscribe()
                    .DisposeWith(disposables);
            });
        }

        private void PopulateFromViewModel(MainViewModel viewModel)
        {
            _stationTableView.Source = new StationTableViewDataSource(_stationTableView, viewModel.Stations);
        }
    }
}
