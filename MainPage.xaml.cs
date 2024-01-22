using Microsoft.Maui.Accessibility;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;

namespace MauiLearning
{
    public partial class MainPage : ContentPage
    {
        private InputViewModel viewModel;

        int count = 0;
        public MainPage()
        {
            InitializeComponent();

            viewModel = new InputViewModel();
            inputListView.ItemsSource = viewModel;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count += Math.Max(1, count + 1);

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
