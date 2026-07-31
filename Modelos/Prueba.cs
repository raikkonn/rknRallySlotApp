using System.ComponentModel.DataAnnotations.Schema;

namespace rknRallySlotApp.Modelos
{
    public class Prueba
    {
        public int Id { get; set; }

        // Tu clave foránea escalar explícita
        public int IdCampeonato { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public int NumEtapas { get; set; }
        public int TramosPorEtapa { get; set; }
        public int TiempoMaximo { get; set; } = 300;

        // Relaciones
        // Indicar a EF Core que esta relación usa "IdCampeonato"
        [ForeignKey(nameof(IdCampeonato))]
        public Campeonato? Campeonato { get; set; }
        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}

