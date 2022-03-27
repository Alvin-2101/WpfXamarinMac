using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using AppKit;
using CoreGraphics;
using DynamicData.Binding;
using ReactiveUI;
using UI.Model;
using UI.Utils;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace UI
{
    public class StationTableViewDataSource : NSTableViewSource
    {
        private const string StationNameCell = @"StationNameCell";
        private const string StationCodeCell = @"StationCodeCell";
        private List<string> favoriteList;
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
            NSTableCellView cellView;
            switch (tableColumn.Identifier)
            {
                case "StationNameColumn":
                    cell = StationNameCell;
                    text = _stations[(int)row].StationDesc;
                    var makeViewName = (NSTableCellView)tableView.MakeView(cell, this);
                    makeViewName.TextField.StringValue = text;
                    cellView = makeViewName;
                    break;
                case "StationCodeColumn":
                    cell = StationCodeCell;
                    text = _stations[(int)row].StationCode;
                    var makeViewCode = (NSTableCellView)tableView.MakeView(cell, this);
                    makeViewCode.TextField.StringValue = text;
                    cellView = makeViewCode;
                    break;
                case "FavoriteColumn":
                    var view = new NSTableCellView();

                    // Configure the view
                    view.Identifier = tableColumn.Title;

                    var checkbox = new NSButton(new CGRect(0, 0, 20, 20));
                    checkbox.SetButtonType(NSButtonType.Switch);
                    checkbox.Title = string.Empty;
                    checkbox.Tag = row;
                    var favArray = NSUserDefaults.StandardUserDefaults.StringArrayForKey("favoriteList");
                    if (favArray != null)
                        checkbox.State = favArray.Contains(_stations[(int)row].StationCode) ? NSCellStateValue.On : NSCellStateValue.Off;
                    else
                        checkbox.State = NSCellStateValue.Off;

                    // Wireup events
                    checkbox.Activated += (sender, e) =>
                    {
                        // Get button and product
                        var btn = sender as NSButton;
                        
                        var defaults = NSUserDefaults.StandardUserDefaults;
                        var favoriteArray = defaults.StringArrayForKey("favoriteList");
                        favoriteList = new List<string>();
                        if (favoriteArray != null)
                            favoriteList = favoriteArray.ToList();

                        if (btn.State == NSCellStateValue.On)
                            favoriteList.Add(_stations[(int)row].StationCode);
                        else
                            favoriteList.Remove(_stations[(int)row].StationCode);

                        defaults.SetValueForKey(NSArray.FromStrings(favoriteList.ToArray()), new NSString("favoriteList"));
                        defaults.Synchronize();
                        ViewModelBase.Activated?.Invoke();
                    };
                    view.AddSubview(checkbox);
                    cellView = view;
                    break;
                default:
                    cellView = null;
                    break;
            }

            return cellView;
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
