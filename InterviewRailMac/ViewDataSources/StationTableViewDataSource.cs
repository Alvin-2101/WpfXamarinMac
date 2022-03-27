using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using AppKit;
using CoreGraphics;
using DynamicData.Binding;
using UI.Model;
using UI.Utils;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace UI.ViewDataSources
{
    public class StationTableViewDataSource : DynamicReactiveTableDataSource<StationModel>
    {
        private const string StationNameCell = @"StationNameCell";
        private const string StationCodeCell = @"StationCodeCell";
        private List<string> favoriteList;
        private readonly ReadOnlyObservableCollection<StationModel> _stations;

        public StationTableViewDataSource(NSTableView tableView, ReadOnlyObservableCollection<StationModel> stations): base(tableView, stations)
        {
            _stations = stations;
            _stations
                .ToObservableChangeSet()
                .Subscribe(_ => tableView.ReloadData());
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return _stations.Count;
        }

        protected override NSView GetOrCreateViewFor(NSTableView tableView, NSTableColumn tableColumn, StationModel item)
        {
            var cell = string.Empty;
            var text = string.Empty;
            NSTableCellView cellView;
            switch (tableColumn.Identifier)
            {
                case "StationNameColumn":
                    cell = StationNameCell;
                    text = item.StationDesc;
                    var makeViewName = (NSTableCellView)tableView.MakeView(cell, this);
                    makeViewName.TextField.StringValue = text;
                    cellView = makeViewName;
                    break;
                case "StationCodeColumn":
                    cell = StationCodeCell;
                    text = item.StationCode;
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
                    
                    var favArray = NSUserDefaults.StandardUserDefaults.StringArrayForKey("favoriteList");
                    if (favArray != null)
                        checkbox.State = favArray.Contains(item.StationCode) ? NSCellStateValue.On : NSCellStateValue.Off;
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
                            favoriteList.Add(item.StationCode);
                        else
                            favoriteList.Remove(item.StationCode);

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
    }
}
