namespace BaseDatos {
    public partial class App : Application {
        public App(ContextoBaseDatos db) {
            InitializeComponent();

            /* Esa línea es la responsable de crear:
                el archivo miBD.db
                las tablas definidas en tu modelo (Estudiantes)
                la estructura interna de SQLite que EF Core necesita
                Todo eso sucede automáticamente cuando la aplicación arranca.
             
                EnsureCreated() le dice a Entity Framework Core:
                “Si la base de datos no existe, créala. Si existe, no hagas nada.”

                Es una forma sencilla de crear la base sin usar migraciones.
                Esto significa:
                    Si corre la app por primera vez → crea la base
                    Si ya existe miBD.db → la deja intacta
                    Si falta una tabla → EF Core la crea
                    No borra datos existentes
             * */
            db.Database.EnsureCreated();
        }

        protected override Window CreateWindow(IActivationState? activationState) {
            return new Window(new AppShell());
        }
    }
}