namespace rknRallySlotApp.Modelos
{
    public class Piloto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Abreviado { get; set; } = string.Empty;
        public string Escuderia { get; set; } = string.Empty;
        public string Palmares { get; set; } = string.Empty;

        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

        public Piloto() { }

        public Piloto(string nombre, string abreviado = "", string escuderia = "", string palmares = "")
        {
            Nombre = nombre;
            Abreviado = abreviado;
            Escuderia = escuderia;
            Palmares = palmares;
        }
    }
}
