namespace Animacion {
    public partial class MainPage : ContentPage {
        //Usa el objeto timer para actualizar la posición del rectángulo y redibujar la pantalla
        IDispatcherTimer timer;
        int Tiempo = 18;

        int IncrementoX, IncrementoY; //Desplazamiento del cuadrado relleno

        public MainPage() {
            InitializeComponent();

            //Velocidad con que se desplaza el cuadrado relleno
            IncrementoX = 5;
            IncrementoY = 5;

            timer = Application.Current?.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromMilliseconds(Tiempo);
            if (timer is null) return;
            timer.Tick += OnTick;
            timer.Start();
        }


        //Cada vez que hace tick el timer, se actualizan las
        //posiciones del rectángulo y se redibuja la pantalla
        void OnTick(object? sender, EventArgs e) {
            Logica(); //Lógica de la animación
            CanvasView.Invalidate();
        }

        void Logica() {
            //Si colisiona con alguna pared cambia el incremento
            if (Rectangulo.PosXb > CanvasView.Width || Rectangulo.PosXa < 0)
                IncrementoX *= -1;

            if (Rectangulo.PosYc > CanvasView.Height || Rectangulo.PosYa < 0)
                IncrementoY *= -1;

            //Cambia la posición de X y Y 
            Rectangulo.PosXa += IncrementoX;
            Rectangulo.PosXb += IncrementoX;
            Rectangulo.PosXc += IncrementoX;
            Rectangulo.PosXd += IncrementoX;

            Rectangulo.PosYa += IncrementoY;
            Rectangulo.PosYb += IncrementoY;
            Rectangulo.PosYc += IncrementoY;
            Rectangulo.PosYd += IncrementoY;
        }

    }
}