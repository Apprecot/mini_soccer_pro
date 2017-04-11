using Foundation;
using System;
using UIKit;
using System.Drawing;
using CoreGraphics;

namespace MiniSoccerPro.iOS
{
	public partial class ManageTeamController : UIViewController
	{
		public ManageTeamController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ScrollViewContainers.ClipsToBounds = true;
			ScrollViewContainers.ScrollEnabled = true;
			ScrollViewContainers.PagingEnabled = true;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			View1.Alpha = 1;
			View2.Alpha = 0;
			View3.Alpha = 0;
			Button1.TouchUpInside += Button1_TouchUpInside;
			Button2.TouchUpInside += Button2_TouchUpInside;
			Button3.TouchUpInside += Button3_TouchUpInside;
			ScrollViewContainers.Scrolled += ScrollViewContainers_ScrollAnimationEnded;
			//ScrollViewContainers.ScrollAnimationEnded += ScrollViewContainers_ScrollAnimationEnded;
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
			Button1.TouchUpInside -= Button1_TouchUpInside;
			Button2.TouchUpInside -= Button2_TouchUpInside;
			Button3.TouchUpInside -= Button3_TouchUpInside;
			ScrollViewContainers.Scrolled -= ScrollViewContainers_ScrollAnimationEnded;
			//ScrollViewContainers.ScrollAnimationEnded -= ScrollViewContainers_ScrollAnimationEnded;
		}

		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
			ConstWidthTopBarButtons.Constant = ViewTopBar.Bounds.Width / 3;
			ConstViewWidthContainer1.Constant = View.Bounds.Width;
			ScrollViewContainers.ContentSize = new SizeF((float)UIScreen.MainScreen.Bounds.Width * 3, (float)ScrollViewContainers.Bounds.Height);
		}

		void Button1_TouchUpInside(object sender, EventArgs e)
		{
			GoToTab1();
			View1.Alpha = 1;
			View2.Alpha = 0;
			View3.Alpha = 0;
		}

		void Button2_TouchUpInside(object sender, EventArgs e)
		{
            GoToTab2();
			View1.Alpha = 0;
			View2.Alpha = 1;
			View3.Alpha = 0;
		}

		void Button3_TouchUpInside(object sender, EventArgs e)
		{
            GoToTab3();
			View1.Alpha = 0;
			View2.Alpha = 0;
			View3.Alpha = 1;
		}

		void ScrollViewContainers_ScrollAnimationEnded(object sender, EventArgs e)
		{
			if (ScrollViewContainers.ContentOffset.X == 0)
			{
				View1.Alpha = 1;
				View2.Alpha = 0;
				View3.Alpha = 0;
			}
			else if (ScrollViewContainers.ContentOffset.X == View.Bounds.Width)
			{
				View1.Alpha = 0;
				View2.Alpha = 1;
				View3.Alpha = 0;
			}
			else if (ScrollViewContainers.ContentOffset.X == View.Bounds.Width * 2)
			{
				View1.Alpha = 0;
				View2.Alpha = 0;
				View3.Alpha = 1;
			}
		}

		public void GoToTab1()
		{
			ScrollViewContainers.SetContentOffset(new CGPoint(0, 0), true);
		}

		public void GoToTab2()
		{
			ScrollViewContainers.SetContentOffset(new CGPoint(View.Bounds.Width, 0), true);
		}

		public void GoToTab3()
		{
			ScrollViewContainers.SetContentOffset(new CGPoint(View.Bounds.Width * 2, 0), true);
		}
	}
}