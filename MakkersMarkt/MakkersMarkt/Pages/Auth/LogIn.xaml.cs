using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MakkersMarkt.Data;
using Microsoft.EntityFrameworkCore;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MakkersMarkt.Pages.Auth
{
    public sealed partial class LogIn : Page
    {
        public LogIn()
        {
            this.InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessageTextBlock.Visibility = Visibility.Collapsed; // Reset error message

            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ErrorMessageTextBlock.Text = "Username and password are required.";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                return;
            }

            using (var db = new MakkersMarktContext())
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.Name == Name  && u.Password == password);// Zorg ervoor dat je wachtwoorden hashed opslaat in productie!

                if (user != null)
                {
                    // Login succesvol. Navigeer naar de volgende pagina of doe iets anders.
                    Frame.Navigate(typeof(StorePage));
                }
                else
                {
                    ErrorMessageTextBlock.Text = "Invalid username or password.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Optioneel: code bij het navigeren naar de pagina.
        }
    }
}
