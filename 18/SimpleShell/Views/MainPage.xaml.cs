namespace SimpleShell.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void IrSegundaVentana(object sender, EventArgs e)
    {
        /*
        Shell.Current
        Es la instancia activa de Shell (el AppShell). Desde ahí se controla la navegación basada en rutas en .NET MAUI.

        GoToAsync(...) Es un método asíncrono que navega hacia una ruta registrada en Shell.

        "segunda" es el nombre de la ruta que se registro antes con: 
                Routing.RegisterRoute("segunda", typeof(Views.SegundaPagina));
        Al ejecutarlo, MAUI crea una instancia de Views.SegundaPagina y la empuja al stack de navegación (como un “Push”).

        await Indica que espera a que finalice la navegación antes de continuar. Si no se usa await,
        la navegación se dispara en segundo plano y el método sigue; con await, se asegura de que
        cualquier código que venga después ocurra después de completar la navegación (y su animación).          
         
        */
        await Shell.Current.GoToAsync("segunda");
    }
}
