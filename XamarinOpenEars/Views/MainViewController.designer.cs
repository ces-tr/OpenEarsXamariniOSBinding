// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamarinOpenEars.Views
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		UIKit.UIButton btnStart { get; set; }

		[Outlet]
		UIKit.UIButton btnStop { get; set; }

		[Outlet]
		UIKit.UITextView txtCommand { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnStart != null) {
				btnStart.Dispose ();
				btnStart = null;
			}

			if (btnStop != null) {
				btnStop.Dispose ();
				btnStop = null;
			}

			if (txtCommand != null) {
				txtCommand.Dispose ();
				txtCommand = null;
			}
		}
	}
}
