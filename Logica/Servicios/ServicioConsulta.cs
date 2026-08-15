using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Logica.DTOs;

namespace rknRallySlotApp.Logica.Servicios;

public class ServicioConsulta
{
    #region Consultas para ComboBox
    //-------------------------------------------------------------------------

    // Consulta CAMPEONATOS para ComboBox
    public static async Task<List<ComboDTO>> LeerCampeonatosParaCombo_Async()
    {
        using var db = new AppDbContext();

        var listaCampeonatos = await db.Campeonatos
            .AsNoTracking()
            .OrderBy(c => c.Nombre)
            .Select(c => new ComboDTO
            {
                Id = c.Id,
                Descripcion = c.Nombre
            })
            .ToListAsync();

        return listaCampeonatos;
    }

    // Consulta PRUEBAS de UN CAMPEONATO para ComboBox
    public static async Task<List<ComboDTO>> LeerPruebasParaCombo_Async(int idCampeonato)
    {
        using var db = new AppDbContext();

        var listaPruebas = await db.Pruebas
            .AsNoTracking()
            .Where(p => p.IdCampeonato == idCampeonato)
            .OrderBy(p => p.Nombre)
            .Select(p => new ComboDTO
            {
                Id = p.Id,
                Descripcion = p.Nombre
            })
            .ToListAsync();

        return listaPruebas;
    }

    // Consulta PILOTOS para ComboBox
    public static async Task<List<ComboDTO>> LeerPilotosParaCombo_Async()
    {
        using var db = new AppDbContext();

        var listaPilotos = await db.Pilotos
            .AsNoTracking()
            .OrderBy(p => p.Nombre)
            .Select(p => new ComboDTO
            {
                Id = p.Id,
                Descripcion = p.Nombre
            })
            .ToListAsync();

        return listaPilotos;
    }

    // Consulta COCHES para ComboBox
    public static async Task<List<ComboDTO>> LeerCochesParaCombo_Async()
    {
        using var db = new AppDbContext();

        // Obtenemos la tabla de la BD de forma asíncrona
        var listaCochesTmp = await db.Coches
            .AsNoTracking()
            .OrderBy(c => c.Modelo)
            .ThenBy(c => c.Marca)
            .ToListAsync();

        // Proyectamos en memoria para poder usar la propiedad calculada/NotMapped
        var listaCoches = listaCochesTmp
            .Select(c => new ComboDTO
            {
                Id = c.Id,
                Descripcion = c.DescripcionCompleta
            })
            .ToList();

        return listaCoches;
    }

    // Consulta CATEGORIAS para ComboBox
    public static async Task<List<ComboDTO>> LeerCategoriasParaCombo_Async()
    {
        using var db = new AppDbContext();

        var listaCategorias = await db.Categorias
            .AsNoTracking()
            .OrderBy(c => c.Nombre)
            .Select(c => new ComboDTO
            {
                Id = c.Id,
                Descripcion = c.Nombre
            })
            .ToListAsync();

        return listaCategorias;
    }

    //-------------------------------------------------------------------------
    #endregion

    #region Consultas por ID
    //-------------------------------------------------------------------------
    
    // Consulta CAMPEONATO por Id
    public static async Task<CampeonatoDTO?> ConsultaCampeonatoPorId_Async(int idCampeonato)
    {
        using var db = new AppDbContext();

        var campeonato = await db.Campeonatos
            .AsNoTracking()
            .Where(c => c.Id == idCampeonato)
            .Select (c => new CampeonatoDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                SistemaPuntuacion = c.SistemaPuntuacion
            })
            .FirstOrDefaultAsync();

        return campeonato;
    }
   
    //-------------------------------------------------------------------------
    #endregion 


    // Consulta para DataGridView de Inscripciones (provisional pte revision)
    public static async Task<List<InscripcionGridDTO>> ObtenerInscripcionesPorPruebaAsync(int idPrueba)
    {
        using var db = new AppDbContext();

        return await db.Inscripciones
            .AsNoTracking() // Desactiva el rastreo de EF Core para consultas de solo lectura (más rápido)
            .Where(i => i.IdPrueba == idPrueba)
            .OrderBy(i => i.Dorsal)
            .Select(i => new InscripcionGridDTO
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
