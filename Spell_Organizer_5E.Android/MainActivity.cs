using Android.App;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;

namespace Spell_Organizer_5E.Droid
{
    [Activity(Label = "Spell_Organizer_5E", Icon = "@mipmap/icon", Theme = "@style/splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 0, 0, 0));
            UserDialogs.Init(this);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}
