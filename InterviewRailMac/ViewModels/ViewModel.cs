using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private readonly ReadOnlyObservableCollection<FavoriteStation> _stationData;
        private readonly SourceList<FavoriteStation> _consentStationDataSourceList;
        IRailService _railService;

        public ViewModel()
        {
            _consentStationDataSourceList = new SourceList<FavoriteStation>();
            _consentStationDataSourceList.Connect()
                .Bind(out _stationData)
                .Subscribe();

            _railService = new RailService();
        }

        public ReadOnlyObservableCollection<FavoriteStation> StationData => _stationData;

        protected override void HandleActivation(CompositeDisposable disposable)
        {
            GetStationDetails();
            Observable.Interval(TimeSpan.FromMinutes(1))
               .Subscribe(interval =>
               {
                   GetStationDetails();
               });
            Activated = GetStationDetails;
        }

        protected override void HandleDeactivation()
        {

        }

        private void GetStationDetails()
        {
            List<StationModel> stationModelList = new List<StationModel>();
            Observable.FromAsync(_railService.GetAllStationsAsync)
                        .Take(1)
                        .ObserveOn(RxApp.MainThreadScheduler)
                        .Subscribe(stations =>
                        {
                            stationModelList.AddRange(stations);

                            _consentStationDataSourceList.Clear();
                            foreach (var stationCode in NSUserDefaults.StandardUserDefaults.StringArrayForKey("favoriteList"))
                            {
                                Observable.FromAsync(() => _railService.GetStationDetailsAsync(stationCode))
                                               .Take(1)
                                               .ObserveOn(RxApp.MainThreadScheduler)
                                               .Subscribe(stationData =>
                                               {
                                                   StationModel model = stationModelList.FindAll(a => a.StationCode == stationCode).FirstOrDefault();
                                                   FavoriteStation favoriteStation = new FavoriteStation();
                                                   favoriteStation.StationCode = model.StationCode;
                                                   favoriteStation.Stationfullname = model.StationDesc;
                                                   favoriteStation.StationData = new List<StationData>();
                                                   favoriteStation.StationData.AddRange(stationData);
                                                   _consentStationDataSourceList.Add(favoriteStation);
                                               });
                            }
                        });
        }
    }
}
