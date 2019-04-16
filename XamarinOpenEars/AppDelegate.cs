using Foundation;
using UIKit;
using XamarinOpenEars.Views;

namespace XamarinOpenEars {
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate {
        // class-level declarations

        public override UIWindow Window {
            get;
            set;
        }

        private UINavigationController navigationController;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            navigationController = new UINavigationController(new MainViewController());
            Window.RootViewController = navigationController;
            Window.MakeKeyAndVisible();

            return true;
        }

            
    }
}

