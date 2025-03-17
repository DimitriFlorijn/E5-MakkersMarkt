using System;
using Microsoft.UI.Xaml;

namespace MakkersMarkt
{
    public partial class App : Application
    {
        // Expose MainWindow globally
        public static MainWindow MainWindow { get; private set; }

        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            // Initialize the MainWindow and assign it to the static property
            MainWindow = new MainWindow();
            MainWindow.Activate();
        }
    }
}
