using rknRallySlotApp.Logica.Servicios;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{
    private async Task ComboCampeonatos_Init()
    {
        try
        {
            var listaCampeonatos = await ServicioConsulta.LeerCampeonatosParaCombo_Async();
            listaCampeonatos.AgregarOpcionNuevo();
            comboCampeonatos.CargarDatosSafely(listaCampeonatos, ComboCampeonatos_SelectedIndexChanged);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar campeonatos: {ex.Message}",
                            "Error de carga",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }

    private async Task ComboPruebas_Init()
    {
        if (comboCampeonatos.SelectedValue is not int idCto || idCto <= 0)    //SIN Campeonato válido salir
        {
            comboPruebas.DataSource = null;     // Limpiamos el ComboBox 
            comboPruebas.SelectedIndex = -1;    // Dejar Selección Vacia
            return;
        }

        try
        {
            var listaPruebas = await ServicioConsulta.LeerPruebasParaCombo_Async(idCto);
            listaPruebas.AgregarOpcionNuevo();
            comboPruebas.CargarDatosSafely(listaPruebas, ComboPruebas_SelectedIndexChanged);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar pruebas: {ex.Message}",
                            "Error de carga",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }

    private async Task ComboPilotos_Init()
    {
        try
        {
            var listaPilotos = await ServicioConsulta.LeerPilotosParaCombo_Async();
            listaPilotos.AgregarOpcionNuevo();
            comboPilotos.CargarDatosSafely(listaPilotos, ComboPilotos_SelectedIndexChanged);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar pilotos: {ex.Message}",
                            "Error de carga",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }

    private async Task ComboCoches_Init()
    {
        try
        {
            var listaCoches = await ServicioConsulta.LeerCochesParaCombo_Async();
            listaCoches.AgregarOpcionNuevo();
            comboCoches.CargarDatosSafely(listaCoches, ComboCoches_SelectedIndexChanged);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar coches: {ex.Message}",
                            "Error de carga",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }

    private async Task ComboCategorias_Init()
    {
        try
        {
            var listaCategorias = await ServicioConsulta.LeerCategoriasParaCombo_Async();
            listaCategorias.AgregarOpcionNuevo("- Añadir Nueva -");
            comboCategorias.CargarDatosSafely(listaCategorias, ComboCategorias_SelectedIndexChanged);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar categorías: {ex.Message}",
                            "Error de carga",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}
