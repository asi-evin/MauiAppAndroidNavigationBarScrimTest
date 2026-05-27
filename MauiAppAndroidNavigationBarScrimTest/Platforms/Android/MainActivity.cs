using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Activity;

namespace MauiAppAndroidNavigationBarScrimTest
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Enable edge to edge
            var systemBarStyle = SystemBarStyle.Dark(Android.Graphics.Color.Transparent.ToArgb());
            EdgeToEdge.Enable(this, systemBarStyle, systemBarStyle);
        }
    }
}
