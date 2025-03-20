using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using BCrypt.Net;
using MakkersMarkt.Data;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MakkersMarkt.Pages.Auth
    {
        public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            NameError.Visibility = Visibility.Collapsed;
            PasswordError.Visibility = Visibility.Collapsed;
            ConfirmPasswordError.Visibility = Visibility.Collapsed;
            ErrorMessageTextBlock.Visibility = Visibility.Collapsed;

            string username = NameBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string confirmPassword = ConfirmPasswordBox.Password.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                NameError.Visibility = Visibility.Visible;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                PasswordError.Visibility = Visibility.Visible;
                isValid = false;
            }

            if (password != confirmPassword)
            {
                ConfirmPasswordError.Visibility = Visibility.Visible;
                isValid = false;
            }

            if (!isValid) return;

            try
            {
                using (var db = new MakkersMarktContext())
                {
                    if (db.Users.Any(u => u.Name == username))
                    {
                        ErrorMessageTextBlock.Text = "Username already exists.";
                        ErrorMessageTextBlock.Visibility = Visibility.Visible;
                        return;
                    }

                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    var newUser = new User
                    {
                        Name = username,
                        Password = hashedPassword,
                        CreatedAt = DateTime.UtcNow
                    };

                    db.Users.Add(newUser);
                    await db.SaveChangesAsync();

                    Frame.Navigate(typeof(StorePage)); // Navigeer naar de store page na registratie.
                }
            }
            catch (Exception ex)
            {
                ErrorMessageTextBlock.Text = $"An error occurred: {ex.Message}";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}