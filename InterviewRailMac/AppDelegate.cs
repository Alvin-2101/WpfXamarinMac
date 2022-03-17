using AppKit;
using Foundation;

namespace UI
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }
        public static AppDelegate Self { get; private set; }
        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
            AppDelegate.Self = this;
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
