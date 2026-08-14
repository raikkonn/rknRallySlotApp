using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Logica.DTOs;

namespace rknRallySlotApp.Logica.Servicios;

public class ServicioConsulta
{
    // Consulta Campeonatos para ComboBox
    public async Task<List<ComboDto>> LeerCampeonatosParaCombo_Async()
    {
        using var db = new AppDbContext();

        return await db.Campeonatos
            .AsNoTracking()
            .OrderBy(c => c.Nombre)
            .Select(c => new ComboDto
            {
                Id = c.Id,
                Descripcion = c.Nombre
            })
            .ToListAsync();
    }

    // Consulta Pruebas de UN CAMPEONATO para ComboBox
    public async Task<List<ComboDto>> LeerPruebasParaCombo_Async(int idCampeonato)
    {
        using var db = new AppDbContext();

        return await db.Pruebas
            .AsNoTracking()
            .Where(p => p.IdCampeonato == idCampeonato)
            .OrderBy(p => p.Nombre)
            .Select(p => new ComboDto
            {
                Id = p.Id,
                Descripcion = p.Nombre
            })
            .ToListAsync();
    }


    // Consulta para DataGridView de Inscripciones (provisional pte revision)
    public async Task<List<InscripcionGridDto>> ObtenerInscripcionesPorPruebaAsync(int idPrueba)
    {
        using var db = new AppDbContext();

        return await db.Inscripciones
            .AsNoTracking() // Desactiva el rastreo de EF Core para consultas de solo lectura (más rápido)
            .Where(i => i.IdPrueba == idPrueba)
            .OrderBy(i => i.Dorsal)
            .Select(i => new InscripcionGridDto
            {
                IdInscripcion = i.Id,
                Dorsal = i.Dorsal,
                NombrePiloto = i.Piloto != null ? i.Piloto.Nombre : string.Empty,
                Escuderia = i.Piloto != null ? i.Piloto.Escuderia : string.Empty,
                Coche = i.Coche != null ? i.Coche.DescripcionCompleta : string.Empty,
                Categoria = i.Categoria != null ? i.Categoria.Nombre : string.Empty,
                ColorCategoriaHex = i.Categoria != null ? i.Categoria.ColorHex : "#FFFFFF"
            })
            .ToListAsync();
    }
}
