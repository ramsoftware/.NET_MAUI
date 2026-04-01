namespace BaseDatos {
    public partial class DetallePage : ContentPage {
        public DetallePage(Colores item) {
            InitializeComponent();

            LblId.Text = item.Id.ToString();
            LblNombre.Text = item.Nombre;
        }
    }
}