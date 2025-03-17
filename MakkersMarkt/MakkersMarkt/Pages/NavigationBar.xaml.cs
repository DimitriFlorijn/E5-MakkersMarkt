using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
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
                Type pageType = Type.GetType($"MakkersMarkt.Pages.{pageName}");

                if (pageType != null)
                {
                    var frame = FindParentFrame(this);
                    if (frame != null)
                    {
                        frame.Navigate(pageType);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Frame not found.");
                    }
                }
            }
        }

        private Frame FindParentFrame(DependencyObject current)
        {
            while (current != null)
            {
                if (current is Frame frame)
                {
                    return frame;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            return null;  
        }
    }
}
