namespace BaseDatos {

    public partial class MainPage : ContentPage {

        private readonly ContextoBaseDatos BaseDatos;
        
        public MainPage(ContextoBaseDatos BaseDatos) {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
        }

        async private void AlDarClic(object? sender, EventArgs e) {

            var estudiante = new Estudiante {
                Nombre = "Liliana María Guzman",
                Edad = 22
            };

            //Agrega y guarda el nuevo estudiante en la base de datos
            BaseDatos.Estudiantes.Add(estudiante);
            await BaseDatos.SaveChangesAsync();

            Resultado.Text = $"Estudiante agregado: {estudiante.Nombre}, Edad: {estudiante.Edad}";
        }
    }
}
