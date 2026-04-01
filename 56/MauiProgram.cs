using Microsoft.Extensions.Logging;

namespace BaseDatos {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            /* Este paso es fundamental, porque aquí se le dice a .NET MAUI:
               “Cada vez que necesites acceder a la base de datos, usa este objeto ContextoBaseDatos.”
               Ese objeto es la conexión a SQLite.
               En Android se crea la BD en: /data/data/tu.app/files/miBD.db
             */
            string RutaBaseDatos = Path.Combine(FileSystem.AppDataDirectory, "miBD.db");

            /* ¿Qué significa “registrar un servicio”?
               Registrar un servicio significa:
               Poner a disposición de toda la app un objeto que se podrá pedir cuando sea necesario.
               Así, en vez de crear la conexión a SQLite en cada página,
               MAUI la crea una sola vez y solo se pide.
              
               Esto significa:
                MAUI creará una sola instancia del objeto ContextoBaseDatos
                Esa instancia vivirá toda la vida de la aplicación
                Cualquier página que lo necesite recibirá el mismo objeto
               
               ¿Por qué Singleton es bueno aquí?
                Porque no se quiere abrir y cerrar SQLite muchas veces
                Porque siempre se trabaja sobre la misma base de datos
                Porque EF Core funciona bien con una instancia global
            */
            builder.Services.AddSingleton<ContextoBaseDatos>(s =>
                new ContextoBaseDatos(RutaBaseDatos));

            //Se agrega esto para usar al adicionar registro
            builder.Services.AddSingleton<NavegacionService>();

            return builder.Build();
        }
    }
}
