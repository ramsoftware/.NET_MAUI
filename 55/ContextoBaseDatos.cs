
using Microsoft.EntityFrameworkCore;

namespace BaseDatos {
    public class ContextoBaseDatos : DbContext {
        public DbSet<Videojuego> Videojuegos { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Genero> Generos { get; set; }

        private string RutaBaseDatos;

        public ContextoBaseDatos(string rutaBD) {
            RutaBaseDatos = rutaBD;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder opciones) {
            opciones.UseSqlite($"Filename={RutaBaseDatos}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            /*
                Estas líneas están configurando las relaciones entre 
                tablas usando Entity Framework Core.
                En la base de datos se tiene:
                    Tabla videojuegos
                    Tabla plataformas
                    Tabla generos
                
                Y en el modelo se tiene:     
                
                    public int Plataforma { get; set; }   // Llave foránea (FK)
                    public Plataforma? ObjPlataforma { get; set; }   // Navegación

                    public int Genero { get; set; }       // Llave foránea (FK)
                    public Genero? ObjGenero { get; set; }  // Navegación
            */
            modelBuilder.Entity<Videojuego>()
                .HasOne(v => v.ObjPlataforma)
                .WithMany()
                .HasForeignKey(v => v.Plataforma);

            /* .HasOne(v => v.ObjPlataforma) Cada videojuego tiene un objeto relacionado ObjPlataforma
               .WithMany()  Una plataforma puede ser usada por muchos videojuegos.
               .HasForeignKey(v => v.Plataforma)  El campo Plataforma de la tabla videojuegos apunta a la columna Id de la tabla plataformas.
            */

            modelBuilder.Entity<Videojuego>()
                .HasOne(v => v.ObjGenero)
                .WithMany()
                .HasForeignKey(v => v.Genero);

        }
    }
}
