// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MiniSoccerPro.iOS
{
	[Register ("ManageTeamController")]
	partial class ManageTeamController
	{
		[Outlet]
		UIKit.UIButton Button1 { get; set; }

		[Outlet]
		UIKit.UIButton Button2 { get; set; }

		[Outlet]
		UIKit.UIButton Button3 { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint ConstViewWidthContainer1 { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint ConstWidthTopBarButtons { get; set; }

		[Outlet]
		UIKit.UIScrollView ScrollViewContainers { get; set; }

		[Outlet]
		UIKit.UIView View1 { get; set; }

		[Outlet]
		UIKit.UIView View2 { get; set; }

		[Outlet]
		UIKit.UIView View3 { get; set; }

		[Outlet]
		UIKit.UIView ViewTopBar { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ConstWidthTopBarButtons != null) {
				ConstWidthTopBarButtons.Dispose ();
				ConstWidthTopBarButtons = null;
			}

			if (ViewTopBar != null) {
				ViewTopBar.Dispose ();
				ViewTopBar = null;
			}

			if (Button1 != null) {
				Button1.Dispose ();
				Button1 = null;
			}

			if (View1 != null) {
				View1.Dispose ();
				View1 = null;
			}

			if (Button2 != null) {
				Button2.Dispose ();
				Button2 = null;
			}

			if (View2 != null) {
				View2.Dispose ();
				View2 = null;
			}

			if (Button3 != null) {
				Button3.Dispose ();
				Button3 = null;
			}

			if (View3 != null) {
				View3.Dispose ();
				View3 = null;
			}

			if (ConstViewWidthContainer1 != null) {
				ConstViewWidthContainer1.Dispose ();
				ConstViewWidthContainer1 = null;
			}

			if (ScrollViewContainers != null) {
				ScrollViewContainers.Dispose ();
				ScrollViewContainers = null;
			}
		}
	}
}
