namespace SimpleShell;

/*
Esta es la clase principal de la aplicación MAUI. Aquí es donde se define:

Estilos globales (vienen desde App.xaml)
Recursos
Tema
Cuál será la página inicial cuando se abra la app
*/

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        //Cuando arranque, la primera pantalla será AppShell
        MainPage = new AppShell();
    }
}
