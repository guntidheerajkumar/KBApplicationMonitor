# KBApplicationMonitor

Simply start monitoring. Performance view will be added above the status bar automatically. Also, you can configure appearance as you like.

This is a binding project based on https://github.com/dani-gavrilov/GDPerformanceView.

###Usage

```
KBPerformanceMonitor.SharedInstance().StartMonitoringWithConfiguration((obj) => {
	obj.Frame = new CGRect(10, 50, this.View.Frame.Width - 20, 24);
});

KBPerformanceMonitor.SharedInstance().AppVersionHidden = true;
KBPerformanceMonitor.SharedInstance().DeviceVersionHidden = true;
```

###Output

![](https://github.com/guntidheerajkumar/KBApplicationMonitor/blob/master/Output.gif)
