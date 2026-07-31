using System.ComponentModel.DataAnnotations.Schema;

namespace rknRallySlotApp.Modelos
{
    public class Inscripcion
    {
        public int Id { get; set; }

        // Claves foráneas escalares
        public int IdPrueba { get; set; }
        public int IdPiloto { get; set; }
        public int IdCoche { get; set; }

        public int Dorsal { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Verificado { get; set; }

        // Propiedades de navegación anotadas sobre el objeto
        [ForeignKey(nameof(IdPrueba))]
        public Prueba? Prueba { get; set; }

        [ForeignKey(nameof(IdPiloto))]
        public Piloto? Piloto { get; set; }

        [ForeignKey(nameof(IdCoche))]
        public Coche? Coche { get; set; }

        public ICollection<TiempoTramo> Tiempos { get; set; } = new List<TiempoTramo>();

        // Propiedades calculadas no mapeadas
        [NotMapped] public string NombrePiloto => Piloto?.Nombre ?? string.Empty;
        [NotMapped] public string Escuderia => Piloto?.Escuderia ?? string.Empty;
        [NotMapped] public string DescripcionCoche => Coche?.DescripcionCompleta ?? string.Empty;
    }
}