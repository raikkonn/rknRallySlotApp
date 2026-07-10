namespace rknRallySlotApp.Modelos
{
    public class TiempoTramo
    {
        public int IdInscripcion { get; set; }
        public int Etapa { get; set; }
        public int Tramo { get; set; }
        public decimal Tiempo { get; set; }

        public Inscripcion? Inscripcion { get; set; }
    }
}
