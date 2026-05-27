using Android.Content.Res;

namespace MauiAppAndroidNavigationBarScrimTest;

public partial class MainPage : ContentPage
{
    private DisplayRotation _previousDisplayRotation;

    public MainPage()
    {
        InitializeComponent();

        DeviceDisplay.MainDisplayInfoChanged += (sender, args) =>
        {
            if (_previousDisplayRotation != args.DisplayInfo.Rotation)
            {
                _previousDisplayRotation = args.DisplayInfo.Rotation;
                InvalidateNavBarContrast(args.DisplayInfo.Rotation);
            }
        };

        Appearing += async (sender, args) =>
        {
            //hack: needs some startup time if starting in landscape
            await Task.Delay(1000);
            InvalidateNavBarContrast(DeviceDisplay.MainDisplayInfo.Rotation);
        };
    }

    private static void InvalidateNavBarContrast(DisplayRotation args)
    {
#if ANDROID
        switch (args)
        {
            case DisplayRotation.Rotation0:
            case DisplayRotation.Rotation180:

                Static.AndroidNavigationBar.SetSCrimContrast(false);

                break;
            case DisplayRotation.Rotation270:
            case DisplayRotation.Rotation90:

                Static.AndroidNavigationBar.SetSCrimContrast(true);

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
#endif
    }
}