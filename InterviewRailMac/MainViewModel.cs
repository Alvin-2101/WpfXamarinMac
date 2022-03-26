using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using DynamicData;
using UI.Model;
using UI.Utils;

namespace UI
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ReadOnlyObservableCollection<StationModel> _stations;
        private readonly SourceList<StationModel> _consentSourceList;
        IRailService _railService;
        public MainViewModel()
        {
            _consentSourceList = new SourceList<StationModel>();
            _consentSourceList.Connect()
                .Bind(out _stations)
                .Subscribe();
            _railService = new RailService();
        }
        
        public ReadOnlyObservableCollection<StationModel> Stations => _stations;

        protected override void HandleActivation(CompositeDisposable disposable)
        {
            Observable.FromAsync(_railService.GetAllStationsAsync)
                .Take(1)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(stations =>
                {
                   _consentSourceList.AddRange(stations);
                });
        }

        protected override void HandleDeactivation()
        {
            // NA
        }
    }
}