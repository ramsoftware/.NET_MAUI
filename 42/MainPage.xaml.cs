namespace Animacion {
    public partial class MainPage : ContentPage {
        //Usa el objeto timer para actualizar la posición del rectángulo y redibujar la pantalla
        IDispatcherTimer timer;

        public MainPage() {
            InitializeComponent();

            timer = Application.Current?.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromMilliseconds(40);
            if (timer is null) return;
            timer.Tick += OnTick;
            timer.Start();
        }


        //Cada vez que hace tick el timer, se actualizan las
        //posiciones del rectángulo y se redibuja la pantalla
        void OnTick(object? sender, EventArgs e) {
            Rectangulo.Logica(); //Lógica de la animación
            CanvasView.Invalidate();
        }
    }
}