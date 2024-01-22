using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Provider;
using Android.Views;
using Android.Widget;
using Android.Util;
using Uri = Android.Net.Uri;
using Android.Hardware.Input;
using Android.Views.InputMethods;

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

            var input = InputMethodManager.FromContext(this);
            
            input.

            foreach (var id in InputDevice.GetDeviceIds()!)
            {
                var device = InputDevice.GetDevice(id);
                
                if (device?.MotionRanges == null)
                    continue;

                foreach (var item in device!.MotionRanges)
                {
                    var data = new InputData();
                    data.DeviceName = $"{device.Name} {item.Axis}";

                    Task.Run(() =>
                    {
                        while(true)
                        {
                            item.Wait();

                            data.Value = $"{item.Flat} \t {item.Fuzz}";
                        }
                    });

                    InputViewModel.Instance.Add(data);
                }
            }




            return;

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
