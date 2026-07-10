using System.ComponentModel.DataAnnotations.Schema;

namespace rknRallySlotApp.Modelos
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int IdPrueba { get; set; }
        public int IdPiloto { get; set; }
        public int IdCoche { get; set; }
        public int Dorsal { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Verificado { get; set; }

        // Propiedades de navegación de EF Core (conectan las tablas)
        public Prueba? Prueba { get; set; }
        public Piloto? Piloto { get; set; }
        public Coche? Coche { get; set; }
        public ICollection<TiempoTramo> Tiempos { get; set; } = new List<TiempoTramo>();

        // [NotMapped] le dice a EF Core: "No crees columnas para esto en la BD, se calcula en memoria"
        [NotMapped] public string NombrePiloto => Piloto?.Nombre ?? string.Empty;
        [NotMapped] public string Escuderia => Piloto?.Escuderia ?? string.Empty;
        [NotMapped] public string DescripcionCoche => Coche?.DescripcionCompleta ?? string.Empty;
    }
}
