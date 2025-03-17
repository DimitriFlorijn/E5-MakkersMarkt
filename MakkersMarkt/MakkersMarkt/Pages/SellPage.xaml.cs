using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using MakkersMarkt.Data;
using System;
using System.IO;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Linq;
using System.Threading.Tasks;

namespace MakkersMarkt.Pages
{
    public sealed partial class SellPage : Page
    {
        private string _imagePath = null;

        public SellPage()
        {
            this.InitializeComponent();
        }

        private async void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.MainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                _imagePath = file.Path;
                var bitmapImage = new BitmapImage();
                using (var stream = await file.OpenReadAsync())
                {
                    await bitmapImage.SetSourceAsync(stream);
                }
                ProductImage.Source = bitmapImage;
                ProductImage.Visibility = Visibility.Visible;
            }
        }


        // ... other code ...

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(PriceBox.Text, out double price);

            using (var db = new MakkersMarktContext())
            {
                var newProduct = new Product
                {
                    Name = NameBox.Text,
                    Description = DescriptionBox.Text,
                    Price = price,
                    ImageUrl = _imagePath != null ? $"ms-appdata:///local/{Path.GetFileName(_imagePath)}" : null,
                    CreatedAt = DateTime.UtcNow
                };

                db.Products.Add(newProduct);
                db.SaveChanges();

                if (_imagePath != null)
                {
                    var localFolder = ApplicationData.Current.LocalFolder;
                    var imageFile = await localFolder.CreateFileAsync(Path.GetFileName(_imagePath), CreationCollisionOption.ReplaceExisting);
                    var sourceFile = await StorageFile.GetFileFromPathAsync(_imagePath);
                    await sourceFile.CopyAndReplaceAsync(imageFile);
                }

                Frame.Navigate(typeof(StorePage));
            }
        }

    }
}
