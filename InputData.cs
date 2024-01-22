using System.ComponentModel;

namespace MauiLearning
{
    public class InputData : INotifyPropertyChanged
    {
        private string deviceName;
        private string value;

        public string DeviceName
        {
            get => deviceName;
            set
            {
                if (deviceName != value)
                {
                    deviceName = value;
                    OnPropertyChanged(nameof(DeviceName));
                }
            }
        }

        public string Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
