namespace rknRallySlotApp.Logica.DTOs;

public class InscripcionGridDto
{
    public int IdInscripcion { get; set; }
    public int Dorsal { get; set; }
    public string NombrePiloto { get; set; } = string.Empty;
    public string Escuderia { get; set; } = string.Empty;
    public string Coche { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string ColorCategoriaHex { get; set; } = "#FFFFFF";
}
