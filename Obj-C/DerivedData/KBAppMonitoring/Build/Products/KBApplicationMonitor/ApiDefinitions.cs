using System;
using Foundation;
using UIKit;

namespace KBApplicationMonitor
{
	// @interface KBMarginLabel : UILabel
	[BaseType (typeof(UILabel))]
	interface KBMarginLabel
	{
	}

	// @interface KBPerformanceMonitor : NSObject
	[BaseType (typeof(NSObject))]
	interface KBPerformanceMonitor
	{
		// @property (getter = isAppVersionHidden, nonatomic) BOOL appVersionHidden;
		[Export ("appVersionHidden")]
		bool AppVersionHidden { [Bind ("isAppVersionHidden")] get; set; }

		// @property (getter = isDeviceVersionHidden, nonatomic) BOOL deviceVersionHidden;
		[Export ("deviceVersionHidden")]
		bool DeviceVersionHidden { [Bind ("isDeviceVersionHidden")] get; set; }

		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		KBPerformanceMonitor SharedInstance ();

		// -(void)startMonitoringWithConfiguration:(void (^)(UILabel *))configuration;
		[Export ("startMonitoringWithConfiguration:")]
		void StartMonitoringWithConfiguration (Action<UILabel> configuration);

		// -(void)startMonitoring;
		[Export ("startMonitoring")]
		void StartMonitoring ();

		// -(void)pauseMonitoring;
		[Export ("pauseMonitoring")]
		void PauseMonitoring ();

		// -(void)stopMonitoring;
		[Export ("stopMonitoring")]
		void StopMonitoring ();

		// -(void)configureWithConfiguration:(void (^)(UILabel *))configuration;
		[Export ("configureWithConfiguration:")]
		void ConfigureWithConfiguration (Action<UILabel> configuration);
	}

	// @interface KBPerformanceView : UIWindow
	[BaseType (typeof(UIWindow))]
	interface KBPerformanceView
	{
		// @property (getter = isAppVersionHidden, nonatomic) BOOL appVersionHidden;
		[Export ("appVersionHidden")]
		bool AppVersionHidden { [Bind ("isAppVersionHidden")] get; set; }

		// @property (getter = isDeviceVersionHidden, nonatomic) BOOL deviceVersionHidden;
		[Export ("deviceVersionHidden")]
		bool DeviceVersionHidden { [Bind ("isDeviceVersionHidden")] get; set; }

		// -(UILabel *)textLabel;
		[Export ("textLabel")]
		[Verify (MethodToProperty)]
		UILabel TextLabel { get; }

		// -(void)pauseMonitoring;
		[Export ("pauseMonitoring")]
		void PauseMonitoring ();

		// -(void)resumeMonitoring;
		[Export ("resumeMonitoring")]
		void ResumeMonitoring ();

		// -(void)stopMonitoring;
		[Export ("stopMonitoring")]
		void StopMonitoring ();
	}
}
