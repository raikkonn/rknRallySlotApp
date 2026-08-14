using rknRallySlotApp.Logica.DTOs;

namespace rknRallySlotApp.Utilidades;

public static class ComboBoxExtensions
{
    // Constante global reutilizable en toda la app
    public const int ID_ANADIR_NUEVO = -5;
    public const string TEXTO_ANADIR_NUEVO = "- Añadir nuevo -";

    /// <summary>
    /// Agrega el elemento especial "- Añadir nuevo -" a una lista de ComboDto.
    /// </summary>
    public static List<ComboDto> AgregarOpcionNuevo(
        this List<ComboDto> lista,
        string textoOpcion = TEXTO_ANADIR_NUEVO,
        int id = ID_ANADIR_NUEVO)
    {
        if (lista == null)
        {
            lista = new List<ComboDto>();
        }

        lista.Add(new ComboDto
        {
            Id = id,
            Descripcion = textoOpcion
        });

        return lista;
    }

    /// <summary>
    /// Configura y enlaza un ComboBox de Windows Forms de forma segura suspendiendo el evento SelectedIndexChanged.
    /// </summary>
    public static void CargarDatosSafely(
        this ComboBox comboBox, 
        List<ComboDto> datos, 
        EventHandler eventHandler)
    {
        // 1. Desconectamos temporalmente el evento para evitar disparos accidentales durante la carga
        if (eventHandler != null)
        {
            comboBox.SelectedIndexChanged -= eventHandler;
        }

        try
        {
            // 2. Asignamos la lista al origen de datos
            comboBox.DataSource = datos;
            comboBox.DisplayMember = nameof(ComboDto.Descripcion);
            comboBox.ValueMember = nameof(ComboDto.Id);

            // 3. Establecemos la selección por defecto
            comboBox.SelectedIndex = -1; // Dejar selección vacía
        }
        finally
        {
            // 4. Reconectamos siempre el evento al finalizar
            if (eventHandler != null)
                comboBox.SelectedIndexChanged += eventHandler;
        }
    }
}
