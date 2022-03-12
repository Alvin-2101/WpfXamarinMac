﻿using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using AppKit;
using DynamicData.Binding;
using ReactiveUI;
using UI.Model;
using UI.Utils;

namespace UI
{
    public class StationTableViewDataSource : NSTableViewSource
    {
        private const string StationNameCell = @"StationNameCell";
        private const string StationCodeCell = @"StationCodeCell";

        private readonly ReadOnlyObservableCollection<StationModel> _stations;

        public StationTableViewDataSource(ReadOnlyObservableCollection<StationModel> stations, NSTableView tableView)
        {
            _stations = stations;
            _stations
                .ToObservableChangeSet()
                .Subscribe(_ => tableView.ReloadData());
        }

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            var cell = string.Empty;
            var text = string.Empty;
            
            switch (tableColumn.Identifier) {
                case "StationNameColumn":
                    cell = StationNameCell;
                    text = _stations [(int)row].StationDesc;
                    break;
                case "StationCodeColumn":
                    cell = StationCodeCell;
                    text = _stations [(int)row].StationCode;
                    break;
            }
            
            var makeView = (NSTableCellView)tableView.MakeView (cell, this);
            makeView.TextField.StringValue = text;
            
            return makeView;
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return _stations.Count;
        }
        
    }
    
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
            _stationTableView.Source = new StationTableViewDataSource(viewModel.Stations, _stationTableView);
        }
    }
}