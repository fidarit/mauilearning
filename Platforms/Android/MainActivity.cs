using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace MauiLearning.Platforms.Android
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        Intent intent;

        protected override void OnStop()
        {
            if (OperatingSystem.IsAndroidVersionAtLeast(23))
            {
                intent = new Intent(this, typeof(FloatingService));

                Permissions.
                if (!Settings.CanDrawOverlays(this))
                {
                    StartActivityForResult(new Intent(Settings.ActionManageOverlayPermission, Android.Net.Uri.Parse("package:" + PackageName)), 0);
                }
                else
                {
                    StartService(intent);
                }
            }

            base.OnStop();
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (OperatingSystem.IsAndroidVersionAtLeast(23) && requestCode == 0)
            {
                StartService(new Intent(this, typeof(FloatingService)));
            }
        }
    }
}
