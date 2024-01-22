using Android.Hardware;
using Android.Runtime;

namespace MauiLearning.Platforms.Android
{
    internal class SensorListener : Java.Lang.Object, ISensorEventListener
    {
        private InputData dataContainer = new();

        public SensorListener()
        {
            InputViewModel.Instance.Add(dataContainer);
        }

        public void OnAccuracyChanged(Sensor? sensor, [GeneratedEnum] SensorStatus accuracy)
        {

        }

        public void OnSensorChanged(SensorEvent? e)
        {
            if (e?.Values == null)
                return;

            var sensor = e.Sensor;
            if (sensor == null) 
                return;

            dataContainer.DeviceName = sensor.Name;
            dataContainer.Value = string.Join(" ", e.Values.Select(t => t.ToString()));
            //Log.Info("woow2", $"{sensor.Name} \t {val}");

        }
    }
}
