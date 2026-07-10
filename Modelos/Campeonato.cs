namespace rknRallySlotApp.Modelos
{
    public class Campeonato
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? SistemaPuntuacion { get; set; }

        // Propiedad de navegación: Un campeonato tiene muchas pruebas
        public ICollection<Prueba> Pruebas { get; set; } = new List<Prueba>();
    }
}

