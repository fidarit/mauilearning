using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Provider;
using Android.Widget;
using Uri = Android.Net.Uri;

namespace MauiLearning.Platforms.Android
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public static int ACTION_MANAGE_OVERLAY_PERMISSION_REQUEST_CODE = 2323;

        private Intent? intent;

        protected override void OnStart()
        {
            base.OnStart();
                        
            if (!Settings.CanDrawOverlays(this))
            {
                Toast.MakeText(this, "Can't get permissions. Add it manually", ToastLength.Long)?.Show();

                var uri = Uri.Parse($"package: {PackageName}");
                var newIntent = new Intent(Settings.ActionManageOverlayPermission, uri);

                StartActivityForResult(newIntent, ACTION_MANAGE_OVERLAY_PERMISSION_REQUEST_CODE);
            }
            else
                StartService();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == ACTION_MANAGE_OVERLAY_PERMISSION_REQUEST_CODE && resultCode != Result.Canceled)
                StartService();
        }

        public bool StartService()
        {
            intent = new Intent(this, typeof(FloatingService));
            return StartService(intent) != null;
        }
    }
}
