namespace MauiAppAndroidNavigationBarScrimTest
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

#if ANDROID
            DeviceDisplay.MainDisplayInfoChanged += (sender, args) =>
            {
                switch (args.DisplayInfo.Orientation)
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
            };
#endif
        }
    }
}
