namespace SimpleShell;

/*
(Android/iOS/Windows) 
Paso 1: EntryPoint (MainActivity/AppDelegate/Program)
Paso 2: MauiProgram.CreateMauiApp()
Paso 3: Se crea el MauiApp (DI, servicios, handlers, fuentes)
Paso 4: Se instancia App
Paso 5: App.xaml.cs ejecuta InitializeComponent()
Paso 6: App establece MainPage = new AppShell()
Paso 7: Se muestra la UI
*/

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        /* Crea un builder (patrón host builder) que permite configurar:
            Servicios de Dependency Injection (DI)
            Handlers de controles
            Recursos (temas, estilos, fuentes)
            Logging, Essentials, etc. */
        var builder = MauiApp.CreateBuilder();

        /*
            .UseMauiApp<App>()
            Le indica a MAUI cuál es la clase principal de aplicación (App), que normalmente hereda de
            Application y define MainPage.
            En App.xaml.cs es donde se suele establecer MainPage = new AppShell(); o algún ContentPage.

            .ConfigureFonts(...)
            Registra fuentes embebidas en el proyecto para usarlas por nombre “amigable” (alias).
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            Luego, en XAML/C#, se puede usar FontFamily="OpenSansRegular".

            return builder.Build();
            Construye un MauiApp final con todo lo configurado. Eso devuelve el contenedor DI,
            recursos, handlers, etc., listos para que el bootstrap de la plataforma lo ejecute. */
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}
