using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Modelos;

namespace rknRallySlotApp.Logica;

public static class GestionDatos
{
    // ==========================================
    // Puebla la tabla Cronos de la prueba seleccionada, eliminando los registros obsoletos si es necesario
    public static async Task<DialogResult> PoblarCronosAsync(int? idPruebaSelected)
    {
        if (idPruebaSelected == null) return DialogResult.Cancel; 

        using var db = new AppDbContext();

        // 1. Obtener la prueba actual
        var prueba = await db.Pruebas.FindAsync(idPruebaSelected);
        if (prueba == null)
        {
            MessageBox.Show("La prueba seleccionada no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return DialogResult.Cancel;
        }

        int nEtapas = prueba.NumEtapas;
        int nTramos = prueba.TramosPorEtapa;
        int tmaxMs = prueba.TiempoMaximo * 1000;    // TiempoMaximo se almacena en segundos en DB

        // 2.1. Obtener IDs de inscripciones 
        var idsInscripcionesDeLaPrueba = await db.Inscripciones
            .Where(i => i.IdPrueba == idPruebaSelected)
            .Select(i => i.Id)
            .ToListAsync();

        // 2.2. Obtener los registros de Cronos de esta prueba
        var cronosDeLaPrueba = await db.Cronos
                .Where(c => idsInscripcionesDeLaPrueba.Contains(c.IdInscripcion))
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
                $"Esta operacion NO se puede revertir\n\n" +
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
                return DialogResult.Cancel; // Cancela si el usuario dice que no
            }
        }

        bool cambiosRealizados = false;

        // 5. Recorrer matriz y rellenar faltantes
        foreach (var idInscripcionDeLaPrueba in idsInscripcionesDeLaPrueba)
        {
            for (int E = 1; E <= nEtapas; E++)
            {
                for (int T = 1; T <= nTramos; T++)
                {
                    var cronoExistente = cronosDeLaPrueba
                        .FirstOrDefault
                        (c => c.IdInscripcion == idInscripcionDeLaPrueba && c.Etapa == E && c.Tramo == T);

                    if (cronoExistente == null)
                    {
                        var nuevoCrono = new Crono
                        {
                            IdInscripcion = idInscripcionDeLaPrueba,
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
        return DialogResult.OK;
    }
}
