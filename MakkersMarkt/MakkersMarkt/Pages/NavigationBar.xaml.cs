using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

namespace MakkersMarkt.Pages
{
    public sealed partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            this.InitializeComponent();
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer is NavigationViewItem item)
            {
                string pageName = item.Tag.ToString();
                var frame = (Window.Current.Content as Frame);

                if (frame != null)
                {
                    frame.Navigate(Type.GetType($"MakkersMarkt.Pages.{pageName}"));
                }
            }
        }
    }
}
