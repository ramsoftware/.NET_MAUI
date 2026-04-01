using Microsoft.EntityFrameworkCore;

namespace BaseDatos {

    public partial class MainPage : ContentPage {

        private readonly ContextoBaseDatos BaseDatos;
        
        public MainPage(ContextoBaseDatos BaseDatos) {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
        }

        async private void AlDarClic(object? sender, EventArgs e) {
            var lista = await BaseDatos.Colores.ToListAsync();
            Resultado.Text = "";
            for (int Cont = 0; Cont < lista.Count; Cont++) {
                Resultado.Text += $"Código: {lista[Cont].Id} - Nombre: {lista[Cont].Nombre}\n";
            }
        }
    }
}
    