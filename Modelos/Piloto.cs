namespace rknRallySlotApp.Modelos
{
    public class Piloto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string Escuderia { get; set; } = string.Empty;

        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

        public Piloto() { }

        public Piloto(string nombre, string alias = "", string escuderia = "")
        {
            Nombre = nombre;
            Alias = alias;
            Escuderia = escuderia;
        }
    }
}
