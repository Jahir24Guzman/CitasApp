using merindo.Models;
using System;
using Xamarin.Forms;

namespace merindo.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            await App.Database.SaveUserAsync(user);
            await DisplayAlert("Hecho", "Usuario registrado correctamente", "OK");
            await Navigation.PopAsync();
        }
    }
}