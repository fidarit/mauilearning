using Microsoft.Maui.Controls;

namespace MauiLearning
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
