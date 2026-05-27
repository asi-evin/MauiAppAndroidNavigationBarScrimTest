using Android.Content.Res;

namespace MauiAppAndroidNavigationBarScrimTest;

public partial class MainPage : ContentPage
{
    private DisplayOrientation _previousDisplayOrientation;

    public MainPage()
    {
        InitializeComponent();

        DeviceDisplay.MainDisplayInfoChanged += (sender, args) =>
        {
            if (_previousDisplayOrientation != args.DisplayInfo.Orientation)
            {
                _previousDisplayOrientation = args.DisplayInfo.Orientation;
                InvalidateNavBarContrast(args.DisplayInfo.Orientation);
            }
        };

        Appearing += async (sender, args) =>
        {
            //hack: needs some startup time if starting in landscape
            await Task.Delay(1000);
            InvalidateNavBarContrast(DeviceDisplay.MainDisplayInfo.Orientation);
        };
    }

    private static void InvalidateNavBarContrast(DisplayOrientation args)
    {
#if ANDROID
        switch (args)
        {
            case DisplayOrientation.Unknown:
            case DisplayOrientation.Portrait:

                Static.AndroidNavigationBar.SetSCrimContrast(false);

                break;
            case DisplayOrientation.Landscape:

                Static.AndroidNavigationBar.SetSCrimContrast(true);

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
#endif
    }
}