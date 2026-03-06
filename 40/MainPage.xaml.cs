using Microsoft.Maui.Controls.Shapes;

namespace Animacion {
    public partial class MainPage : ContentPage {

        const int Filas = 10;
        const int Columnas = 10;

        // Matriz para llevar el estado encendido/apagado (o seleccionada/no)
        private readonly bool[,] Tablero = new bool[Filas, Columnas];

        // Colores base
        private readonly Color Apagado = Colors.LightGray;
        private readonly Color Encendido = Colors.SteelBlue;

        public MainPage() {
            InitializeComponent();
            GeneraTablero();
        }

        private void GeneraTablero() {
            //Definir filas y columnas
            MatrizGrafica.RowDefinitions.Clear();
            MatrizGrafica.ColumnDefinitions.Clear();

            for (int fila = 0; fila < Filas; fila++)
                MatrizGrafica.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

            for (int columna = 0; columna < Columnas; columna++)
                MatrizGrafica.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            // Crear celdas y cada uno con su bloque
            for (int fila = 0; fila < Filas; fila++) {
                for (int columna = 0; columna < Columnas; columna++) {

                    var bloque = new Border {
                        Padding = 0,
                        Margin = new Thickness(2),
                        Background = Apagado,                 // antes: BackgroundColor
                        Stroke = Colors.Gray,                 // antes: BorderColor
                        StrokeThickness = 1,                  // opcional
                        StrokeShape = new RoundRectangle {    // antes: CornerRadius
                            CornerRadius = new CornerRadius(6)
                        }
                        // Nota: Border no tiene HasShadow
                    };

                    // Guarda coordenadas como tupla en BindingContext
                    bloque.BindingContext = (row: fila, col: columna);

                    //Evento de cada bloque
                    var presionaDedo = new TapGestureRecognizer();
                    presionaDedo.Tapped += CeldaPresionada;
                    bloque.GestureRecognizers.Add(presionaDedo);

                    //El bloque es adicionado a la matriz gráfica
                    Grid.SetRow(bloque, fila);
                    Grid.SetColumn(bloque, columna);
                    MatrizGrafica.Children.Add(bloque);
                }
            }

        }

        private void CeldaPresionada(object? sender, TappedEventArgs e) {
            if (sender is not Border cell) return;
            if (cell.BindingContext is not (int fila, int columna)) return;

            // Alternar estado
            Tablero[fila, columna] = !Tablero[fila, columna];

            // Aplicar color (nota: Border usa Background de tipo Paint)
            cell.Background = Tablero[fila, columna] ? Encendido : Apagado;
        }

    }
}