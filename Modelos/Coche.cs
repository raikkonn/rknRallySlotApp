namespace rknRallySlotApp.Modelos
{
    public class Coche
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;

        public string DescripcionCompleta => $"[{Marca}] {Modelo}";

        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}
