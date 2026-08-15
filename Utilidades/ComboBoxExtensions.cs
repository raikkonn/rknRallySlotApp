using rknRallySlotApp.Logica.DTOs;

namespace rknRallySlotApp.Utilidades;

public static class ComboBoxExtensions
{
    // Constante global reutilizable en toda la app
    public const int ANADIR_NUEVO_ID = -5;
    public const string ANADIR_NUEVO_TEXTO = "- Añadir nuevo -";

    /// <summary>
    /// Agrega el elemento especial "- Añadir nuevo -" a una lista de ComboDto.
    /// </summary>
    public static List<ComboDTO> AgregarOpcionNuevo(
        this List<ComboDTO> lista,
        string textoOpcion = ANADIR_NUEVO_TEXTO,
        int id = ANADIR_NUEVO_ID)
    {
        if (lista == null)
        {
            lista = new List<ComboDTO>();
        }

        lista.Add(new ComboDTO
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
        List<ComboDTO> datos, 
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
            comboBox.DisplayMember = nameof(ComboDTO.Descripcion);
            comboBox.ValueMember = nameof(ComboDTO.Id);

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
