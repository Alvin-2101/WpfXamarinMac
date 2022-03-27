using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using DynamicData;
using UI.Model;
using UI.Utils;
using UI.Services;

namespace UI.ViewModels
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
            GetAllStation();

            Observable.Interval(TimeSpan.FromMinutes(4))
                .Subscribe(interval =>
                {
                    GetAllStation();
                });
        }

        protected override void HandleDeactivation()
        {
            // NA
        }

        private void GetAllStation()
        {
            Observable.FromAsync(_railService.GetAllStationsAsync)
                        .Take(1)
                        .ObserveOn(RxApp.MainThreadScheduler)
                        .Subscribe(stations =>
                        {
                            _consentSourceList.Clear();
                            _consentSourceList.AddRange(stations);
                        });
        }
    }
}