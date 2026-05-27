using Android.Views;

namespace MauiAppAndroidNavigationBarScrimTest.Static;

public static class AndroidNavigationBar
{
    public enum NavigationBarScrimStyle
    {
        None,
        Light,
        Dark,
    }

    public enum NavigationBarContentStyle
    {
        Light,
        Dark
    }

    public static void SetSCrimContrast(bool showScrim)
    {
        if (OperatingSystem.IsAndroidVersionAtLeast(30))
        {
            var window = Platform.CurrentActivity?.Window;

            if (window == null)
                return;

            //todo: handle whether navbar content is light or dark

            window.NavigationBarContrastEnforced = showScrim;
        }
        else if (OperatingSystem.IsAndroidVersionAtLeast(26))
        {
            var window = Platform.CurrentActivity?.Window;

            if (window == null)
                return;

            //todo: handle whether navbar content is light or dark

            window.SetNavigationBarColor(showScrim ? new Android.Graphics.Color(0x7f000000) : Android.Graphics.Color.Transparent);
        }
        else if (OperatingSystem.IsAndroidVersionAtLeast(23))
        {
            var window = Platform.CurrentActivity?.Window;

            if (window == null)
                return;

            //cannot set navbar content to light or dark here, can only set scrim.

            window.SetNavigationBarColor(showScrim ? new Android.Graphics.Color(0x7f000000) : Android.Graphics.Color.Transparent);
        }
        else
        {
            // do nothing, we are not edge to edge
        }
    }
}