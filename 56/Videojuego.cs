namespace BaseDatos {
    public class Videojuego {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Plataforma { get; set; }
        public int Genero { get; set; }
        public int Anyo { get; set; }

        // Relaciones
        public Plataforma? ObjPlataforma { get; set; }
        public Genero? ObjGenero { get; set; }
    }
}
