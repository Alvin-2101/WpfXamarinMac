// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace UI.ViewControllers
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		AppKit.NSTableView _stationTableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (_stationTableView != null) {
				_stationTableView.Dispose ();
				_stationTableView = null;
			}

		}
	}
}
