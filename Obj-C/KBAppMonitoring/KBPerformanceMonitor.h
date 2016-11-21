

#import <Foundation/Foundation.h>

@class UILabel;

@interface KBPerformanceMonitor : NSObject

/**
 Change it to hide or show application version from monitoring view. Default is NO.
 */
@property (nonatomic, getter=isAppVersionHidden) BOOL appVersionHidden;

/**
 Change it to hide or show device iOS version from monitoring view. Default is NO.
 */
@property (nonatomic, getter=isDeviceVersionHidden) BOOL deviceVersionHidden;


/**
 Creates and returns instance of KBPerfomanceMonitor, as singleton.
 */
+ (instancetype)sharedInstance;

/**
 Creates and returns instance of KBPerfomanceMonitor.
 */
- (instancetype)init NS_DESIGNATED_INITIALIZER;

/**
 Starts or resumes performance monitoring, initialize monitoring view if not initialized and shows monitoring view. Use configuration block to change appearance as you like.
 */
- (void)startMonitoringWithConfiguration:(void (^)(UILabel *textLabel))configuration;

/**
 Starts or resumes performance monitoring, initialize monitoring view if not initialized and shows monitoring view.
 */
- (void)startMonitoring;

/**
 Pauses performance monitoring and hides monitoring view.
 */
- (void)pauseMonitoring;

/**
 Stops and removes monitoring view. Call when you're done with performance monitoring.
 */
- (void)stopMonitoring;

/**
 Use configuration block to change appearance as you like.
 */
- (void)configureWithConfiguration:(void (^)(UILabel *textLabel))configuration;

@end
