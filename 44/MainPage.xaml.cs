namespace Animacion {
    public partial class MainPage : ContentPage {
        //Usa el objeto timer para actualizar la posición del rectángulo y redibujar la pantalla
        IDispatcherTimer timer;

        public MainPage() {
            InitializeComponent();

            Rectangulo.IniciarParametros();

            timer = Application.Current?.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromMilliseconds(40);
            if (timer is null) return;
            timer.Tick += OnTick;
            timer.Start();
        }


        async void OnTick(object? sender, EventArgs e) {
            Rectangulo.Logica();
            CanvasView.Invalidate();
        }
    }
}