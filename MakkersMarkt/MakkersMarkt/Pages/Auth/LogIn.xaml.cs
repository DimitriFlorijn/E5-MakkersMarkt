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
using BCrypt.Net;

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
            ErrorMessageTextBlock.Visibility = Visibility.Collapsed;

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
                var user = await db.Users.FirstOrDefaultAsync(u => u.Name == username);

                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password)) //Corrected call
                {
                    Frame.Navigate(typeof(StorePage));
                }
                else
                {
                    ErrorMessageTextBlock.Text = "Invalid username or password.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }
    }
}