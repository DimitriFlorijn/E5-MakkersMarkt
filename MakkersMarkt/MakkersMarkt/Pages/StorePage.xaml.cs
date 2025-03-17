using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MakkersMarkt.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MakkersMarkt.Pages
{
    public sealed partial class StorePage : Page
    {
        public ObservableCollection<Product> Products { get; set; } = new();

        public StorePage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            await Task.Run(() =>
            {
                using (var db = new MakkersMarktContext())
                {
                    var products = db.Products.ToList();
                    foreach (var product in products)
                    {
                        _ = DispatcherQueue.TryEnqueue(() => Products.Add(product));
                    }
                }
            });
        }
    }
}
