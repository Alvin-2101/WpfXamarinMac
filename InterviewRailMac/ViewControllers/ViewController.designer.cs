// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace UI
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSOutlineView _favoriteOutlineView { get; set; }

		[Outlet]
		AppKit.NSTableColumn DestinationColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn EstimatedArrivalTimeColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn StationNameColumn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_favoriteOutlineView != null) {
				_favoriteOutlineView.Dispose ();
				_favoriteOutlineView = null;
			}

			if (StationNameColumn != null) {
				StationNameColumn.Dispose ();
				StationNameColumn = null;
			}

			if (DestinationColumn != null) {
				DestinationColumn.Dispose ();
				DestinationColumn = null;
			}

			if (EstimatedArrivalTimeColumn != null) {
				EstimatedArrivalTimeColumn.Dispose ();
				EstimatedArrivalTimeColumn = null;
			}
		}
	}
}
