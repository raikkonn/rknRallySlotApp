using rknRallySlotApp.Datos;
using rknRallySlotApp.Logica.DTOs;
using rknRallySlotApp.Logica.Servicios;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{
    #region Rellenar Formulario con datos de consulta
    //-------------------------------------------------------------------------
    private async void Rellena_DatosCampeonato()
    {
        if (IdCampeonatoSeleccionado == null)
        {
            Limpia_DatosCampeonato();
            return;
        }

        var campeonato = await ServicioConsulta.ConsultaCampeonatoPorId_Async(IdCampeonatoSeleccionado.Value);

        if (campeonato == null) {
            Limpia_DatosCampeonato();
            return;
        }

        tboxPuntuaciones.Text = string.IsNullOrEmpty(campeonato.SistemaPuntuacion) ? "Sin definir" : campeonato.SistemaPuntuacion;
    }

    private async void Rellena_DatosPrueba()
    {
        using var db = new AppDbContext();

        var prueba = db.Pruebas
                            .Where(p => p.Id == IdPruebaSeleccionada)
                            .Select(p => new
                            {
                                p.NumEtapas,
                                p.TramosPorEtapa,
                                p.TiempoMaximo,
                                p.PowerStage
                            })
                            .FirstOrDefault();

        if (prueba != null)
        {
            tboxEtapas.Text = prueba.NumEtapas.ToString() ?? "NO def.";
            tboxTramos.Text = prueba.TramosPorEtapa.ToString() ?? "NO def.";
            tboxTmax.Text = prueba.TiempoMaximo.ToString() ?? "NO def.";
            tboxPwrStg.Text = prueba.PowerStage ?? string.Empty;
        }
        else
        {
            Limpia_DatosPrueba();
        }
    }

    private async void Rellena_DatosPiloto()
    {
        using var db = new AppDbContext();

        var piloto = db.Pilotos
                            .Where(p => p.Id == IdPilotoSeleccionado)
                            .Select(p => new
                            {
                                p.Alias,
                                p.Escuderia,
                            })
                            .FirstOrDefault();

        if (piloto != null)
        {
            tboxAlias.Text = piloto.Alias ?? String.Empty;
            tboxEscuderia.Text = piloto.Escuderia ?? String.Empty;
        }
        else
        {
            Limpia_DatosPiloto();
        }
    }

    private async void Rellena_DatosCoche()
    {
        using var db = new AppDbContext();

        var marca = db.Coches
                    .Where(c => c.Id == IdCocheSeleccionado)
                    .Select(c => c.Marca)
                    .FirstOrDefault();

        tboxMarca.Text = marca ?? String.Empty;
    }

    private async void Colorear_Categoria()
    {
        using var db = new AppDbContext();

        var colorFondo = db.Categorias
                        .Where(c => c.Id == IdCategoriaSeleccionada)
                        .Select(c => c.ColorHex)
                        .FirstOrDefault();

        comboCategorias.BackColor = ColorTranslator.FromHtml(colorFondo ?? "#FFFFFF");
        comboCategorias.ForeColor = ColorTools.GetBestContrast(comboCategorias.BackColor);
    }
    //-------------------------------------------------------------------------
    #endregion

    #region Limpiar Formulario
    //-------------------------------------------------------------------------
    private void Limpia_DatosCampeonato()
    {
        tboxPuntuaciones.Clear();
    }

    private void Limpia_DatosPrueba()
    {
        tboxEtapas.Clear();
        tboxTramos.Clear();
        tboxTmax.Clear();
        tboxPwrStg.Clear();
    }

    private void Limpia_DatosPiloto()
    {
        tboxAlias.Clear();
        tboxEscuderia.Clear();
    }

    private void Limpia_DatosCoche()
    {
        tboxMarca.Clear();
    }

    private void Limpiar_Color_Categoria()
    {
        comboCategorias.BackColor = SystemColors.Window;
        comboCategorias.ForeColor = SystemColors.WindowText;
    }
    //-------------------------------------------------------------------------
    #endregion
}
