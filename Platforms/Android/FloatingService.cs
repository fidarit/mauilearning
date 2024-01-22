using Android.App;
using Android.Content;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using View = Android.Views.View;


namespace MauiLearning.Platforms.Android
{
    [Service]
    public class FloatingService : Service
    {
        private WindowManagerLayoutParams layoutParams;
        IWindowManager windowManager;
        View floatView;

        public override void OnCreate()
        {
            base.OnCreate();
        }


        public override bool OnUnbind(Intent? intent)
        {
            return base.OnUnbind(intent);
        }


        public override StartCommandResult OnStartCommand(Intent? intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {

            //showFloatingWindow();
            return StartCommandResult.NotSticky;
        }



        private void showFloatingWindow()
        {
            windowManager = GetSystemService(WindowService).JavaCast<IWindowManager>();
            LayoutInflater mLayoutInflater = LayoutInflater.From(ApplicationContext);
            floatView = mLayoutInflater.Inflate(Resource.Layout.floatview, null);
            ImageView iv1 = floatView.FindViewById<ImageView>(Resource.Id.iv1);
            ImageView iv2 = floatView.FindViewById<ImageView>(Resource.Id.iv2);
            ImageView iv3 = floatView.FindViewById<ImageView>(Resource.Id.iv3);
            iv1.Click += delegate { Toast.MakeText(ApplicationContext, "The first Image Click", ToastLength.Short).Show(); };
            iv2.Click += delegate { Toast.MakeText(ApplicationContext, "The second Image Click", ToastLength.Short).Show(); };
            iv3.Click += delegate { Toast.MakeText(ApplicationContext, "The third Image Click", ToastLength.Short).Show(); };


            // set LayoutParam
            layoutParams = new WindowManagerLayoutParams
            {
                Width = 1,
                Height = 1,
                Alpha = 0f,
                Type = WindowManagerTypes.ApplicationOverlay,
                Flags = WindowManagerFlags.NotFocusable 
                | WindowManagerFlags.NotTouchable 
                | WindowManagerFlags.NotTouchModal 
                | WindowManagerFlags.LayoutNoLimits
            };

            windowManager.AddView(floatView, layoutParams);
        }

        public override IBinder? OnBind(Intent? intent)
        {
            return null;
        }
    }
}
