using Microsoft.Maui.Controls;

#if ANDROID
using Android.OS;
using Android.Views;
using Microsoft.Maui.Platform;
#endif

#if IOS
using UIKit;
using CoreGraphics;
#endif

namespace PASMAN
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            SetStatusBarBlack();
        }
        private void SetStatusBarBlack()
        {
#if ANDROID
        var activity = Platform.CurrentActivity;

        if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
        {
            // Set Android status bar background to black
            activity.Window.SetStatusBarColor(Android.Graphics.Color.Black);

            // Light icons (white)
            activity.Window.DecorView.SystemUiVisibility = 0;
        }
#endif

#if IOS
        // Set iOS status bar style to light (white text/icons)
        UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

        // Optional: black background behind status bar
        var statusBarFrame = UIApplication.SharedApplication.StatusBarFrame;
        var statusBarView = new UIView(statusBarFrame)
        {
            BackgroundColor = UIColor.Black
        };

        // Add the view to the main window
        UIApplication.SharedApplication.KeyWindow?.AddSubview(statusBarView);
#endif
        }
    }
}
