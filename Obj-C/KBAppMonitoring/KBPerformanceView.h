
#import <UIKit/UIKit.h>

@interface KBPerformanceView : UIWindow

/**
 Change it to hide or show application version from monitoring view. Default is NO.
 */
@property (nonatomic, getter=isAppVersionHidden) BOOL appVersionHidden;

/**
 Change it to hide or show device iOS version from monitoring view. Default is NO.
 */
@property (nonatomic, getter=isDeviceVersionHidden) BOOL deviceVersionHidden;


/**
 Returns weak monitoring text label.
 */
- (UILabel *)textLabel;

/**
 Pauses performance monitoring and hides monitoring view.
 */
- (void)pauseMonitoring;

/**
 Resumes performance monitoring and shows monitoring view.
 */
- (void)resumeMonitoring;

/**
 Stops and removes monitoring view. Call when you're done with performance monitoring.
 */
- (void)stopMonitoring;

@end
