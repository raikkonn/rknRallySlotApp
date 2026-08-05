using System.ComponentModel.DataAnnotations.Schema;

namespace rknRallySlotApp.Modelos
{
    public class Crono
    {
        // Clave Foránea escalar
        public int IdInscripcion { get; set; }

        public int Etapa { get; set; }
        public int Tramo { get; set; }
        public int CronoMS { get; set; }

        // Propiedad de navegación de EF Core
        // Se indica sobre el objeto cuál es su propiedad escalar FK relacionada
        [ForeignKey(nameof(IdInscripcion))]
        public Inscripcion? Inscripcion { get; set; }
    }
}

