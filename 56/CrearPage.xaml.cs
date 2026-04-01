using Microsoft.EntityFrameworkCore;

namespace BaseDatos {
    public partial class CrearPage : ContentPage {
        private readonly ContextoBaseDatos BaseDatos;

        public CrearPage() {
            InitializeComponent();
            BaseDatos = IPlatformApplication.Current.Services.GetService<ContextoBaseDatos>();
            CargarListas();
        }

        private async void CargarListas() {
            PickerPlataforma.ItemsSource = await BaseDatos.Plataformas.ToListAsync();
            PickerGenero.ItemsSource = await BaseDatos.Generos.ToListAsync();
        }

        private async void Guardar_Clicked(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                string.IsNullOrWhiteSpace(TxtAnyo.Text) ||
                PickerPlataforma.SelectedItem is not Plataforma plataformaSel ||
                PickerGenero.SelectedItem is not Genero generoSel) {
                await DisplayAlertAsync("Error", "Debe llenar todos los campos.", "OK");
                return;
            }

            var nuevo = new Videojuego {
                Nombre = TxtNombre.Text,
                Anyo = int.Parse(TxtAnyo.Text),
                Plataforma = plataformaSel.Id,
                Genero = generoSel.Id
            };

            BaseDatos.Videojuegos.Add(nuevo);
            await BaseDatos.SaveChangesAsync();

            // Guardamos el ID del nuevo registro (lo usará MainPage)
            var nav = IPlatformApplication.Current.Services.GetService<NavegacionService>();
            nav.NuevoID = nuevo.Id;


            await Navigation.PopToRootAsync();
        }
    }
}