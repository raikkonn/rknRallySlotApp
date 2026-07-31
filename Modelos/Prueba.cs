using System.ComponentModel.DataAnnotations.Schema;

namespace rknRallySlotApp.Modelos
{
    public class Prueba
    {
        public int Id { get; set; }                 // PK
        public int IdCampeonato { get; set; }       // FK escalar explícita

        public string Nombre { get; set; } = string.Empty;
        public int NumEtapas { get; set; }
        public int TramosPorEtapa { get; set; }
        public int TiempoMaximo { get; set; } = 300;
        public string? PowerStage { get; set; }     // Opcional (nullable)

        // Relaciones
        [ForeignKey(nameof(IdCampeonato))]
        public Campeonato? Campeonato { get; set; }

        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}
