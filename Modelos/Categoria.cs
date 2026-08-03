namespace rknRallySlotApp.Modelos;

public class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;
    public string ColorHex { get; set; } = "#FFFFFF"; // Valor por defecto: blanco

    // Propiedad de navegación inversa:
    // Una categoría puede estar asignada a muchas inscripciones
    public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
}
