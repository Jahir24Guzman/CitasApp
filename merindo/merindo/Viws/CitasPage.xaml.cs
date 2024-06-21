using merindo.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace merindo.Views
{
    public partial class CitasPage : ContentPage
    {
        public ObservableCollection<Cita> Citas { get; set; }
        public DateTime SelectedDate { get; set; } = DateTime.Today;
        public TimeSpan SelectedTime { get; set; } = DateTime.Now.TimeOfDay;

        public CitasPage()
        {
            InitializeComponent();
            Citas = new ObservableCollection<Cita>();
            BindingContext = this;
        }

        private async void OnAgregarCitaClicked(object sender, EventArgs e)
        {
            var descripcion = await DisplayPromptAsync("Nueva Cita", "Descripción:");
            var nombreCliente = await DisplayPromptAsync("Nueva Cita", "Nombre del Cliente:");
            var direccion = await DisplayPromptAsync("Nueva Cita", "Dirección:");
            var telefono = await DisplayPromptAsync("Nueva Cita", "Teléfono:");

            if (!string.IsNullOrEmpty(descripcion) && !string.IsNullOrEmpty(nombreCliente) &&
                !string.IsNullOrEmpty(direccion) && !string.IsNullOrEmpty(telefono))
            {
                DateTime fechaHoraSeleccionada = SelectedDate.Date + SelectedTime;

                var nuevaCita = new Cita
                {
                    Fecha = fechaHoraSeleccionada,
                    Descripcion = descripcion,
                    NombreCliente = nombreCliente,
                    Direccion = direccion,
                    Telefono = telefono
                };
                Citas.Add(nuevaCita);
            }
        }

        private async void OnEditarCitaClicked(object sender, EventArgs e)
        {
            if (citasCollectionView.SelectedItem is Cita citaSeleccionada)
            {
                var descripcion = await DisplayPromptAsync("Editar Cita", "Descripción:", initialValue: citaSeleccionada.Descripcion);
                var nombreCliente = await DisplayPromptAsync("Editar Cita", "Nombre del Cliente:", initialValue: citaSeleccionada.NombreCliente);
                var direccion = await DisplayPromptAsync("Editar Cita", "Dirección:", initialValue: citaSeleccionada.Direccion);
                var telefono = await DisplayPromptAsync("Editar Cita", "Teléfono:", initialValue: citaSeleccionada.Telefono);

                if (!string.IsNullOrEmpty(descripcion) && !string.IsNullOrEmpty(nombreCliente) &&
                    !string.IsNullOrEmpty(direccion) && !string.IsNullOrEmpty(telefono))
                {
                    DateTime fechaHoraSeleccionada = SelectedDate.Date + SelectedTime;

                    citaSeleccionada.Fecha = fechaHoraSeleccionada;
                    citaSeleccionada.Descripcion = descripcion;
                    citaSeleccionada.NombreCliente = nombreCliente;
                    citaSeleccionada.Direccion = direccion;
                    citaSeleccionada.Telefono = telefono;

                    // Actualizar la colección de citas en la vista
                    citasCollectionView.ItemsSource = null;
                    citasCollectionView.ItemsSource = Citas;
                }
            }
            else
            {
                await DisplayAlert("Editar Cita", "Selecciona una cita primero.", "OK");
            }
        }

        private async void OnEliminarCitaClicked(object sender, EventArgs e)
        {
            if (citasCollectionView.SelectedItem is Cita citaSeleccionada)
            {
                var confirm = await DisplayAlert("Eliminar Cita", "¿Estás seguro de eliminar esta cita?", "Sí", "No");
                if (confirm)
                {
                    Citas.Remove(citaSeleccionada);
                }
            }
            else
            {
                await DisplayAlert("Eliminar Cita", "Selecciona una cita primero.", "OK");
            }
        }
    }
}