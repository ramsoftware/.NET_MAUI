using Microsoft.EntityFrameworkCore;

namespace BaseDatos {
    public partial class MainPage : ContentPage {
        private readonly ContextoBaseDatos BaseDatos;

        private List<Colores> Registros = new();
        private const int TamañoPagina = 10;
        private int PaginaActual = 0;

        public MainPage(ContextoBaseDatos BaseDatos) {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            CargarDatos();
        }

        private async void CargarDatos() {
            Registros = await BaseDatos.Colores.ToListAsync();
            MostrarPagina();
        }

        private void MostrarPagina() {
            var datos = Registros
                .Skip(PaginaActual * TamañoPagina)
                .Take(TamañoPagina)
                .ToList();

            GridDatos.ItemsSource = datos;
        }

        private void IrInicio_Clicked(object sender, EventArgs e) {
            PaginaActual = 0;
            MostrarPagina();
        }

        private void Atras_Clicked(object sender, EventArgs e) {
            if (PaginaActual > 0)
                PaginaActual--;
            MostrarPagina();
        }

        private void Adelante_Clicked(object sender, EventArgs e) {
            if ((PaginaActual + 1) * TamañoPagina < Registros.Count)
                PaginaActual++;
            MostrarPagina();
        }

        private void IrFinal_Clicked(object sender, EventArgs e) {
            PaginaActual = (Registros.Count - 1) / TamañoPagina;
            MostrarPagina();
        }
    }
}