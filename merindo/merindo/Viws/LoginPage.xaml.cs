using System;
using Xamarin.Forms;

namespace merindo.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = await App.Database.GetUserAsync(usernameEntry.Text, passwordEntry.Text);
            if (user != null)
            {
                await DisplayAlert("Hecho", "Sesión iniciada", "OK");
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}