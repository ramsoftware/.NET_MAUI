using Microsoft.EntityFrameworkCore;

namespace BaseDatos {
    public partial class EditarPage : ContentPage {
        private readonly ContextoBaseDatos BaseDatos;
        private readonly Videojuego Item;

        public EditarPage(Videojuego item) {
            InitializeComponent();

            Item = item;
            BaseDatos = IPlatformApplication.Current.Services.GetService<ContextoBaseDatos>();

            CargarDatos();
        }

        private async void CargarDatos() {
            // Cargar listas relacionadas
            var plataformas = await BaseDatos.Plataformas.ToListAsync();
            var generos = await BaseDatos.Generos.ToListAsync();

            PickerPlataforma.ItemsSource = plataformas;
            PickerGenero.ItemsSource = generos;

            // Mostrar valores existentes
            TxtNombre.Text = Item.Nombre;
            TxtAnyo.Text = Item.Anyo.ToString();

            // Seleccionar los valores actuales
            PickerPlataforma.SelectedItem =
                plataformas.FirstOrDefault(p => p.Id == Item.Plataforma);

            PickerGenero.SelectedItem =
                generos.FirstOrDefault(g => g.Id == Item.Genero);
        }

        private async void Guardar_Clicked(object sender, EventArgs e) {
            // Validaciones básicas
            if (PickerPlataforma.SelectedItem is not Plataforma plataformaSel ||
                PickerGenero.SelectedItem is not Genero generoSel) {
                await DisplayAlertAsync("Error", "Debe seleccionar plataforma y género.", "OK");
                return;
            }

            // Asignar nuevos valores
            Item.Nombre = TxtNombre.Text;
            Item.Anyo = int.Parse(TxtAnyo.Text);
            Item.Plataforma = plataformaSel.Id;
            Item.Genero = generoSel.Id;

            // Guardar en BD
            BaseDatos.Videojuegos.Update(Item);
            await BaseDatos.SaveChangesAsync();

            await DisplayAlertAsync("Éxito", "El videojuego fue actualizado.", "OK");

            await Navigation.PopToRootAsync(); // volver a la página del grid
        }
    }
}