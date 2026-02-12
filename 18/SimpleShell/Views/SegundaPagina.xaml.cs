namespace SimpleShell.Views;

public partial class SegundaPagina : ContentPage
{
    public SegundaPagina()
    {
        InitializeComponent();
    }

    private async void Retrocede(object sender, EventArgs e)
    {
        //await Shell.Current.GoToAsync(".."); //No hay animación
        await Shell.Current.GoToAsync("..", animate: true);
    }
}
