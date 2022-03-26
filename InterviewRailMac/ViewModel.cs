using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using DynamicData;
using Foundation;
using ReactiveUI;
using UI.Model;
using UI.Utils;

namespace UI
{
    public class ViewModel : ViewModelBase
    {
        private readonly ReadOnlyObservableCollection<StationData> _stations;
        private readonly SourceList<StationData> _consentSourceList;
        IRailService _railService;

        public ViewModel()
        {
            _consentSourceList = new SourceList<StationData>();
            _consentSourceList.Connect()
                .Bind(out _stations)
                .Subscribe();
            _railService = new RailService();
        }
        public ReadOnlyObservableCollection<StationData> Stations => _stations;

        protected override void HandleActivation(CompositeDisposable disposable)
        {
            GetStationDetails();
        }

        protected override void HandleDeactivation()
        {
            
        }

        private void GetStationDetails()
        {
            foreach (var stationCode in NSUserDefaults.StandardUserDefaults.StringArrayForKey("favoriteList"))
            {
                Observable.FromAsync(() => _railService.GetStationDetailsAsync(stationCode))
                            .Take(1)
                            .ObserveOn(RxApp.MainThreadScheduler)
                            .Subscribe(stations =>
                            {
                                _consentSourceList.AddRange(stations);
                            });
            }
        }
    }
}
