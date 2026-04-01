namespace BaseDatos {
    public partial class DetallePage : ContentPage {
        public DetallePage(Videojuego item) {
            InitializeComponent();

            LblId.Text = item.Id.ToString();
            LblNombre.Text = item.Nombre;
            LblPlataforma.Text = item.ObjPlataforma?.Nombre;
            LblGenero.Text = item.ObjGenero?.Nombre;
            LblAnyo.Text = item.Anyo.ToString();
        }
    }
}