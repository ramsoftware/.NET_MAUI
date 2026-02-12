namespace SimpleShell;

/* ¿Por qué se usa AppShell como MainPage?
Porque Shell permite:

Navegación simple mediante rutas
Un solo archivo para definir toda la estructura visual de navegación
Flyout / Tabs sin necesidad de escribir mucho código */

public partial class AppShell : Shell
{
    public AppShell()
    {
        //Carga todo lo definido en AppShell.xaml (secciones, ShellContent, estilos, recursos, etc.).
        InitializeComponent();

        //Registra una ruta llamada "segunda" que apunta al tipo Views.SegundaPagina.
        Routing.RegisterRoute("segunda", typeof(Views.SegundaPagina));
    }
}
