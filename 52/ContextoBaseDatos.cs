using Microsoft.EntityFrameworkCore;

namespace BaseDatos {
    public class ContextoBaseDatos : DbContext {

        /* Le dice a EF Core que existe una tabla llamada Estudiantes
           Y que esa tabla está basada en la clase Estudiante
           Sin esto, EF Core no crea ninguna tabla.
        */ 
        public DbSet<Colores> Colores { get; set; }

        private string RutaBaseDatos;

        /* Solo guarda la ruta donde va a quedar el archivo SQLite
           Esa ruta se envía desde MauiProgram.cs */
        public ContextoBaseDatos(string RutaBD) {
            RutaBaseDatos = RutaBD;
        }

        /* Aquí se le dice a EF Core: “Usa SQLite y guarda la base de datos en esta ruta”.
           Sin este método, EF Core no sabría dónde crear la base de datos. */
        protected override void OnConfiguring(DbContextOptionsBuilder Opciones) {
            Opciones.UseSqlite($"Filename={RutaBaseDatos}");
        }
    }
}
