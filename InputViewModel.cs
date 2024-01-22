using System.Collections.ObjectModel;

namespace MauiLearning
{
    public class InputViewModel : ObservableCollection<InputData>
    {
        public static InputViewModel Instance { get; set; }

        public InputViewModel() : base() { Instance = this; }

        public void AddInputData(string deviceName, string value)
        {
            Add(new InputData { DeviceName = deviceName, Value = value });
        }
    }

}
