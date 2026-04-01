using Microsoft.EntityFrameworkCore;

namespace BaseDatos {
    public partial class MainPage : ContentPage {
        private readonly ContextoBaseDatos BaseDatos;
        private List<Videojuego> Registros = new();
        private const int TamañoPagina = 10;
        private int PaginaActual = 0;

        public MainPage(ContextoBaseDatos baseDatos) {
            InitializeComponent();
            BaseDatos = baseDatos;
            CargarDatos();
        }

        private async void CargarDatos() {
            /* Sirve para cargar videojuegos junto con sus tablas relacionadas
             * (plataformas y géneros) en una sola consulta.
             * Esta instrucción le dice a Entity Framework Core:
             * “Tráeme todos los videojuegos y, además, incluye los datos de la plataforma y del género relacionados.”
             * Es decir, hace un JOIN automático sin tener que escribir SQL. */
            Registros = await BaseDatos.Videojuegos
                .Include(v => v.ObjPlataforma)
                .Include(v => v.ObjGenero)
                .ToListAsync();
            /* .Include(v => v.ObjPlataforma) equivale a 
                    SELECT * 
                    FROM videojuegos v
                    LEFT JOIN plataformas p ON v.plataforma = p.id; */

            MostrarPagina();
        }

        private void MostrarPagina() {
            GridDatos.Children.Clear();
            GridDatos.RowDefinitions.Clear();

            var datos = Registros
                .Skip(PaginaActual * TamañoPagina)
                .Take(TamañoPagina)
                .ToList();

            int fila = 0;

            foreach (var item in datos) {
                GridDatos.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                // Columna: nombre
                GridDatos.Add(new Label {
                    Text = item.Nombre,
                    VerticalOptions = LayoutOptions.Center
                }, 0, fila);

                // Columna: plataforma
                GridDatos.Add(new Label {
                    Text = item.ObjPlataforma?.Nombre
                }, 1, fila);

                // Columna: género
                GridDatos.Add(new Label {
                    Text = item.ObjGenero?.Nombre
                }, 2, fila);

                // Columna: botón detalle
                // Cada botón “Ver” tiene guardado adentro un Videojuego completo
                var boton = new Button {
                    Text = "Ver",
                    CommandParameter = item,
                    FontSize = 12
                };
                boton.Clicked += Detalle_Clicked;

                GridDatos.Add(boton, 3, fila);

                fila++;
            }
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

        private async void Detalle_Clicked(object sender, EventArgs e) {
            //Cada botón “Ver” tiene guardado adentro un Videojuego completo
            if (sender is Button btn && btn.CommandParameter is Videojuego item) {
                await Navigation.PushAsync(new DetallePage(item));
            }
        }

        //Refresca el contenido del grid. Útil cuando se borra un registro
        protected override void OnAppearing() {
            base.OnAppearing();
            CargarDatos();
        }

    }
}