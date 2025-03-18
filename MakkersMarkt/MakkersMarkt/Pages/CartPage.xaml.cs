using Microsoft.UI.Xaml.Controls;
using MakkersMarkt.Services;

namespace MakkersMarkt.Pages
{
    public sealed partial class CartPage : Page
    {
        public CartPage()
        {
            this.InitializeComponent();
            this.DataContext = CartService.CartItems;
        }
    }
}
