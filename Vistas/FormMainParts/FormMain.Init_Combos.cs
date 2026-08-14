using rknRallySlotApp.Datos;
using rknRallySlotApp.Logica.Servicios;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{
    private readonly ServicioConsulta consultaDb = new();

    private async Task ComboCampeonatos_Init()
    {
        try
        {
            // 1. Obtenemos los datos desde el servicio
            var listaCampeonatos = await consultaDb.LeerCampeonatosParaCombo_Async();

            // 2. Encadenamos el método de extensión para agregar "- Añadir nuevo -"
            listaCampeonatos.AgregarOpcionNuevo();

            // 3. Cargamos el combo de forma segura en una sola línea
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
            // 1. Obtenemos los datos desde el servicio
            var listaPruebas = await consultaDb.LeerPruebasParaCombo_Async(idCto);

            // 2. Encadenamos el método de extensión para agregar "- Añadir nuevo -"
            listaPruebas.AgregarOpcionNuevo();

            // 3. Cargamos el combo de forma segura en una sola línea
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

    private void ComboPilotos_Init()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboPilotos.SelectedIndexChanged -= ComboPilotos_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de pilotos desde DB
            var listaPilotos = db.Pilotos
                .Select(p => new { p.Id, p.Nombre })
                .OrderBy(p => p.Nombre)
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaPilotos.Add(new { Id = ComboBoxExtensions.ID_ANADIR_NUEVO, Nombre = ComboBoxExtensions.TEXTO_ANADIR_NUEVO });

            // Asignamos la lista al ComboBox
            comboPilotos.DataSource = listaPilotos;
            comboPilotos.DisplayMember = "Nombre";
            comboPilotos.ValueMember = "Id";
        }
        finally
        {
            // Reconectamos el evento después de la inicialización
            comboPilotos.SelectedIndexChanged += ComboPilotos_SelectedIndexChanged;
            // Dejar Selección Vacia
            comboPilotos.SelectedIndex = -1;
        }
    }

    private void ComboCoches_Init()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboCoches.SelectedIndexChanged -= ComboCoches_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de coches desde DB
            var listaCoches = db.Coches
                .OrderBy(c => c.Modelo)
                .ThenBy(c => c.Marca)
                .AsEnumerable()             // Pasamos a memoria para poder usar propiedades [NotMapped] si es necesario
                .Select(c => new { c.Id, c.DescripcionCompleta })
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaCoches.Add(new { Id = ComboBoxExtensions.ID_ANADIR_NUEVO, DescripcionCompleta = ComboBoxExtensions.TEXTO_ANADIR_NUEVO });

            // Asignamos la lista al ComboBox
            comboCoches.DataSource = listaCoches;
            comboCoches.DisplayMember = "DescripcionCompleta";
            comboCoches.ValueMember = "Id";
        }
        finally
        {
            // Reconectamos el evento después de la inicialización
            comboCoches.SelectedIndexChanged += ComboCoches_SelectedIndexChanged;
            // Dejar Selección Vacia
            comboCoches.SelectedIndex = -1;
        }
    }

    private void ComboCategorias_Init()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboCategorias.SelectedIndexChanged -= ComboCategorias_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de coches desde DB
            var listaCategorias = db.Categorias
                .Select(c => new { c.Id, c.Nombre })
                .OrderBy(c => c.Nombre)
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaCategorias.Add(new { Id = ComboBoxExtensions.ID_ANADIR_NUEVO, Nombre = ComboBoxExtensions.TEXTO_ANADIR_NUEVO });

            // Asignamos la lista al ComboBox
            comboCategorias.DataSource = listaCategorias;
            comboCategorias.DisplayMember = "Nombre";
            comboCategorias.ValueMember = "Id";
        }
        finally
        {
            // Reconectamos el evento después de la inicialización
            comboCategorias.SelectedIndexChanged += ComboCategorias_SelectedIndexChanged;
            // Dejar Selección Vacia
            comboCategorias.SelectedIndex = -1;
        }
    }
}
