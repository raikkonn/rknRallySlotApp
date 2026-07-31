namespace rknRallySlotApp.Modelos;

public class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    // Propiedad de navegación inversa:
    // Una categoría puede estar asignada a muchas inscripciones
    public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
}
