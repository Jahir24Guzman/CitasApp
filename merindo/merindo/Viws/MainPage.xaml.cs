using System;
using Xamarin.Forms;

namespace merindo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCitasTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CitasPage());
        }

        private async void OnAcercaDeTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AcercaDePage());
        }

        private async void OnUsuarioTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsuarioPage());
        }

        private async void OnInfoTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }
    }
}