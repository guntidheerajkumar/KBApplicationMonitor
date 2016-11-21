

#import "KBPerformanceMonitor.h"

#import "KBPerformanceView.h"

@interface KBPerformanceMonitor ()

@property (nonatomic, strong) KBPerformanceView *perfomanceView;

@end

@implementation KBPerformanceMonitor

#pragma mark -
#pragma mark - Init Methods & Superclass Overriders

+ (instancetype)sharedInstance {
    static id instance;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^ {
        instance =  [[self alloc] init];
    });
    return instance;
}

- (instancetype)init {
    self = [super init];
    if (self) {
        [self subscribeToNotifications];
    }
    return self;
}

- (void)dealloc {
    [[NSNotificationCenter defaultCenter] removeObserver:self];
}

#pragma mark -
#pragma mark - Notifications & Observers

- (void)applicationDidBecomeActiveNotification:(NSNotification *)notification {
    [self.perfomanceView resumeMonitoring];
}

- (void)applicationWillResignActiveNotification:(NSNotification *)notification {
    [self.perfomanceView pauseMonitoring];
}

#pragma mark - 
#pragma mark - Public Methods

- (void)startMonitoringWithConfiguration:(void (^)(UILabel *))configuration {
    if (!self.perfomanceView) {
       [self setupPerfomanceView];
    } else {
        [self.perfomanceView resumeMonitoring];
    }
    
    if (configuration) {
        UILabel *textLabel = [self.perfomanceView textLabel];
        configuration(textLabel);
    }
}

- (void)startMonitoring {
    if (!self.perfomanceView) {
        [self setupPerfomanceView];
    } else {
        [self.perfomanceView resumeMonitoring];
    }
}

- (void)pauseMonitoring {
    [self.perfomanceView pauseMonitoring];
}

- (void)stopMonitoring {
    [self.perfomanceView stopMonitoring];
    self.perfomanceView = nil;
}

- (void)configureWithConfiguration:(void (^)(UILabel *))configuration {
    if (!self.perfomanceView) {
        return;
    }
    
    if (configuration) {
        UILabel *textLabel = [self.perfomanceView textLabel];
        configuration(textLabel);
    }
}

#pragma mark -
#pragma mark - Private Methods

#pragma mark - Default Setups

- (void)subscribeToNotifications {
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(applicationDidBecomeActiveNotification:) name:UIApplicationDidBecomeActiveNotification object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(applicationWillResignActiveNotification:) name:UIApplicationWillResignActiveNotification object:nil];
}

#pragma mark - Monitoring 

- (void)setupPerfomanceView {
    CGRect statusBarFrame = [[UIApplication sharedApplication] statusBarFrame];
    self.perfomanceView = [[KBPerformanceView alloc] initWithFrame:statusBarFrame];
}

#pragma mark -
#pragma mark - Setters & Getters

- (void)setAppVersionHidden:(BOOL)appVersionHidden {
    _appVersionHidden = appVersionHidden;
    
    if (self.perfomanceView) {
        [self.perfomanceView setAppVersionHidden:appVersionHidden];
    }
}

- (void)setDeviceVersionHidden:(BOOL)deviceVersionHidden {
    _deviceVersionHidden = deviceVersionHidden;
    
    if (self.perfomanceView) {
        [self.perfomanceView setDeviceVersionHidden:deviceVersionHidden];
    }
}

@end
