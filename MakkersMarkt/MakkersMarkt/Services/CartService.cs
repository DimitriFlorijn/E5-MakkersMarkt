using System.Collections.ObjectModel;
using MakkersMarkt.Data;

namespace MakkersMarkt.Services
{
    public static class CartService
    {
        public static ObservableCollection<Product> CartItems { get; } = new();
    }
}
