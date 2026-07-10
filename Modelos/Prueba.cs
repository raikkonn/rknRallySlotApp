namespace rknRallySlotApp.Modelos
{
    public class Prueba
    {
        public int Id { get; set; }
        public int IdCampeonato { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int NumEtapas { get; set; }
        public int TramosPorEtapa { get; set; }
        public decimal TiempoMaximo { get; set; } = 300;

        // Relaciones
        public Campeonato? Campeonato { get; set; }
        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}

