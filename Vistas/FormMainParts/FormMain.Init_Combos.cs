using rknRallySlotApp.Datos;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{
    private void ComboCampeonatos_Init()
    {
        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboCampeonatos.SelectedIndexChanged -= ComboCampeonatos_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de campeonatos desde la base de datos
            var listaCampeonatos = db.Campeonatos
                .Select(c => new { c.Id, c.Nombre })
                .OrderBy(c => c.Nombre)
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaCampeonatos.Add(new { Id = -5, Nombre = "- Añadir nuevo -" });

            // Asignamos la lista al ComboBox
            comboCampeonatos.DataSource = listaCampeonatos;
            comboCampeonatos.DisplayMember = "Nombre";
            comboCampeonatos.ValueMember = "Id";
        }
        finally
        {
            // Reconectamos el evento después de la inicialización
            comboCampeonatos.SelectedIndexChanged += ComboCampeonatos_SelectedIndexChanged;
            // Dejar Selección Vacia
            comboCampeonatos.SelectedIndex = -1;
        }
    }

    private void ComboPruebas_Init()
    {
        if (comboCampeonatos.SelectedValue is not int idCto || idCto <= 0)    //SIN Campeonato válido salir
        {
            comboPruebas.DataSource = null;     // Limpiamos el ComboBox 
            comboPruebas.SelectedIndex = -1;    // Dejar Selección Vacia
            return;
        }

        // Desconectamos el evento para evitar que se dispare durante la inicialización
        comboPruebas.SelectedIndexChanged -= ComboPruebas_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de pruebas desde DB filtrando por el campeonato seleccionado
            var listaPruebas = db.Pruebas
                .Where(p => p.IdCampeonato == idCto)
                .Select(p => new { p.Id, p.Nombre })
                .OrderBy(p => p.Nombre)
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaPruebas.Add(new { Id = -5, Nombre = "- Añadir nuevo -" });

            // Asignamos la lista al ComboBox
            comboPruebas.DataSource = listaPruebas;
            comboPruebas.DisplayMember = "Nombre";
            comboPruebas.ValueMember = "Id";
        }
        finally
        {
            // Reconectamos el evento después de la inicialización
            comboPruebas.SelectedIndexChanged += ComboPruebas_SelectedIndexChanged;
            // Dejar Selección Vacia
            comboPruebas.SelectedIndex = -1;
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
            listaPilotos.Add(new { Id = -5, Nombre = "- Añadir nuevo -" });

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
            listaCoches.Add(new { Id = -5, DescripcionCompleta = "- Añadir nuevo -" });

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
            listaCategorias.Add(new { Id = -5, Nombre = "- Añadir nueva -" });

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
