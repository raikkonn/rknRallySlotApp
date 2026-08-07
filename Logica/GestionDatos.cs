using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;
using Microsoft.EntityFrameworkCore;

namespace rknRallySlotApp.Logica;

public static class GestionDatos
{
    // ==========================================
    // Puebla la tabla Cronos de la prueba seleccionada, eliminando los registros obsoletos si es necesario
    public static async Task PoblarCronosAsync(int? idPruebaSelected)
    {
        if (idPruebaSelected == null) return; 

        using var db = new AppDbContext();

        // 1. Obtener la prueba actual
        var prueba = await db.Pruebas.FindAsync(idPruebaSelected);
        if (prueba == null)
        {
            MessageBox.Show("La prueba seleccionada no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        int nEtapas = prueba.NumEtapas;
        int nTramos = prueba.TramosPorEtapa;
        int tmaxMs = prueba.TiempoMaximo * 1000;        // TiempoMaximo se almacena en segundos en DB

        // 2. Obtener los registros de Cronos de esta prueba
        var cronosDeLaPrueba = await db.Cronos
            .Include(c => c.Inscripcion)
            .Where(c => c.Inscripcion != null && c.Inscripcion.IdPrueba == idPruebaSelected)
            .ToListAsync();

        // 3. Comprobar registros obsoletos (nº etapas o tramos superiores a la config de la Prueba)
        var cronosObsoletos = cronosDeLaPrueba
            .Where(c => c.Etapa > nEtapas || c.Tramo > nTramos)
            .ToList();

        if (cronosObsoletos.Count > 0)
        {
            DialogResult resultado = MessageBox.Show(
                $"El nº de Etapas o el nº de Tramos Cronometrados de la prueba ha cambiado\n" +
                $"Se eliminarán los registros de cronometraje inecesarios\n" +
                $"Esta operacion no se puede revertir\n\n" +
                $"¿Desea continuar?",
                "Advertencia de Borrado de Registros",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (resultado == DialogResult.Yes)
            {
                db.Cronos.RemoveRange(cronosObsoletos);
                await db.SaveChangesAsync();

                foreach (var crono in cronosObsoletos)
                {
                    cronosDeLaPrueba.Remove(crono);
                }
            }
            else
            {
                return; // Cancela si el usuario dice que no
            }
        }

        // 4. Obtener inscripciones de la prueba
        var inscripcionesDePrueba = await db.Inscripciones
            .Where(i => i.IdPrueba == idPruebaSelected)
            .ToListAsync();

        bool cambiosRealizados = false;

        // 5. Recorrer matriz y rellenar faltantes
        foreach (var inscripcion in inscripcionesDePrueba)
        {
            for (int E = 1; E <= nEtapas; E++)
            {
                for (int T = 1; T <= nTramos; T++)
                {
                    var cronoExistente = cronosDeLaPrueba
                        .FirstOrDefault(c => c.IdInscripcion == inscripcion.Id && c.Etapa == E && c.Tramo == T);

                    if (cronoExistente == null)
                    {
                        var nuevoCrono = new Crono
                        {
                            IdInscripcion = inscripcion.Id,
                            Etapa = E,
                            Tramo = T,
                            CronoMS = tmaxMs // Milisegundos
                        };

                        db.Cronos.Add(nuevoCrono);
                        cambiosRealizados = true;
                    }
                }
            }
        }

        // 6. Guardar cambios
        if (cambiosRealizados)
        {
            await db.SaveChangesAsync();
        }
    }
}
