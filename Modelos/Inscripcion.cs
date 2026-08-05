using System.ComponentModel.DataAnnotations.Schema;

namespace rknRallySlotApp.Modelos;

public class Inscripcion
{
    public int Id { get; set; }     // PK

    // FK escalares
    public int IdPrueba { get; set; }
    public int IdPiloto { get; set; }
    public int IdCoche { get; set; }
    public int IdCategoria { get; set; }

    public int Dorsal { get; set; }
    public bool Verificado { get; set; }
    public int PenalizacionSEG { get; set; } = 0;

    // Propiedades de navegación anotadas sobre el objeto
    [ForeignKey(nameof(IdPrueba))]
    public Prueba? Prueba { get; set; }

    [ForeignKey(nameof(IdPiloto))]
    public Piloto? Piloto { get; set; }

    [ForeignKey(nameof(IdCoche))]
    public Coche? Coche { get; set; }

    [ForeignKey(nameof(IdCategoria))]
    public Categoria? Categoria { get; set; }

    public ICollection<Crono> Cronos { get; set; } = new List<Crono>();

    // Propiedades calculadas no mapeadas
    [NotMapped] public string NombrePiloto => Piloto?.Nombre ?? string.Empty;
    [NotMapped] public string AliasPiloto => Piloto?.Alias ?? string.Empty;
    [NotMapped] public string Escuderia => Piloto?.Escuderia ?? string.Empty;
    [NotMapped] public string DescripcionCoche => Coche?.DescripcionCompleta ?? string.Empty;
}
