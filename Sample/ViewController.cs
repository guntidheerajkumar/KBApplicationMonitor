using System;
using KBApplicationMonitor;
using CoreGraphics;
using UIKit;

namespace Sample
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			KBPerformanceMonitor.SharedInstance().StartMonitoringWithConfiguration((obj) => {
				obj.Frame = new CGRect(10, 50, this.View.Frame.Width - 20, 24);
			});

			KBPerformanceMonitor.SharedInstance().AppVersionHidden = true;
			KBPerformanceMonitor.SharedInstance().DeviceVersionHidden = true;
		}
	}
}
