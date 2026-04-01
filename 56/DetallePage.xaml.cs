namespace BaseDatos {
    public partial class DetallePage : ContentPage {
        private readonly Videojuego Item;
        private readonly ContextoBaseDatos BaseDatos;

        public DetallePage(Videojuego item) {
            InitializeComponent();

            // Guardamos el videojuego
            Item = item;

            // Obtenemos la BD desde Dependency Injection
            BaseDatos = IPlatformApplication.Current.Services.GetService<ContextoBaseDatos>();

            // Mostrar los datos
            LblId.Text = item.Id.ToString();
            LblNombre.Text = item.Nombre;
            LblPlataforma.Text = item.ObjPlataforma?.Nombre;
            LblGenero.Text = item.ObjGenero?.Nombre;
            LblAnyo.Text = item.Anyo.ToString();
        }

        private async void Borrar_Clicked(object sender, EventArgs e) {
            bool respuesta = await DisplayAlertAsync(
                "Confirmar borrado",
                "¿Usted está seguro de borrar este videojuego?",
                "Sí",
                "No"
            );

            if (!respuesta)
                return; // No hace nada, solo cierra el aviso.

            // Si presionó "Sí", borramos
            BaseDatos.Remove(Item);
            await BaseDatos.SaveChangesAsync();

            // Regresamos al grid
            await Navigation.PopAsync();
        }


        private async void Editar_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new EditarPage(Item));
        }

    }
}