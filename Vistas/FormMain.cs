using Microsoft.EntityFrameworkCore;
using rknRallySlotApp.Datos;
using rknRallySlotApp.Utilidades;

namespace rknRallySlotApp.Vistas;

public partial class FormMain : Form
{
    public FormMain()
    {
        InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
        using (var db = new AppDbContext())
        {
            // Migracion de la base de datos para asegurarnos de que la estructura está actualizad
            db.Database.Migrate();
        }

        // Asignacion de imagenes a los botones
        BotonesInit();
        ComboCampeonatosInit();
        DataGridInscripcionInit();
    }

    private void BotonesInit()
    {
        btnNewCto.Image = Properties.Resources.new_b.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnNewCto.ImageAlign = ContentAlignment.MiddleCenter;
        btnNewCto.Enabled = true;

        btnEditCto.Image = Properties.Resources.pencil_b.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnEditCto.ImageAlign = ContentAlignment.MiddleCenter;
        btnEditCto.Enabled = false;

        btnDelCto.Image = Properties.Resources.del_r.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnDelCto.ImageAlign = ContentAlignment.MiddleCenter;
        btnDelCto.Enabled = false;

        btnNewPrueba.Image = Properties.Resources.new_b.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnNewPrueba.ImageAlign = ContentAlignment.MiddleCenter;
        btnNewPrueba.Enabled = false;

        btnEditPrueba.Image = Properties.Resources.pencil_b.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnEditPrueba.ImageAlign = ContentAlignment.MiddleCenter;
        btnEditPrueba.Enabled = false;

        btnDelPrueba.Image = Properties.Resources.del_r.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnDelPrueba.ImageAlign = ContentAlignment.MiddleCenter;
        btnDelPrueba.Enabled = false;
    }

    private void ComboCampeonatosInit()
    {
        using var db = new AppDbContext();
        // Obtenemos la lista de campeonatos desde la base de datos
        var listaCampeonatos = db.Campeonatos
            .Select(c => new { c.Id, c.Nombre })
            .ToList();
        // Agregamos un elemento "comodín" al final de la lista
        listaCampeonatos.Add(new { Id = -9, Nombre = "- Añadir nuevo -" });
        // Asignamos la lista al ComboBox
        cboxCto.DataSource = listaCampeonatos;
        cboxCto.DisplayMember = "Nombre";
        cboxCto.ValueMember = "Id";
        // Dejar Selección Vacia
        cboxCto.SelectedIndex = -1;
    }

    private void ComboPruebasInit(int idCtoSeleccionado)
    {
        using var db = new AppDbContext();

        // Obtenemos la lista de pruebas desde la base de datos
        var listaPruebas = db.Pruebas
            .Where(p => p.IdCampeonato == idCtoSeleccionado)
            .Select(p => new { p.Id, p.Nombre })
            .ToList();
        // Agregamos un elemento "comodín" al final de la lista
        listaPruebas.Add(new { Id = -9, Nombre = "- Añadir nuevo -" });
        // Asignamos la lista al ComboBox
        cboxPrueba.DataSource = listaPruebas;
        cboxPrueba.DisplayMember = "Nombre";
        cboxPrueba.ValueMember = "Id";
        // Dejar Selección Vacia
        cboxPrueba.SelectedIndex = -1;
    }

    private void DataGridInscripcionInit()
    {
        using var db = new AppDbContext();
        // Hacemos la consulta trayendo datos de ambas tablas gracias a la relación
        var listaGrid = db.Inscripciones
            .Select(i => new
            {
                i.Dorsal,
                Piloto = i.NombrePiloto,
                i.Coche,
                Cat = i.Categoria,
                Verif = i.Verificado
            })
            .ToList();

        // Vinculamos el resultado al DataGridView
        dgvCtoPrueba.DataSource = listaGrid;
    }

    private void CboxCto_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 1. Extraemos y validamos el ID usando Pattern Matching seguro
        if (cboxCto.SelectedValue is int idCtoSeleccionado)
        {
            // 2. Controlamos la opción especial de "Añadir Nuevo"
            if (idCtoSeleccionado == -9)
            {
                // Abrimos el formulario de alta
                AltaCampeonato();
                return;
            }

            // 3. Si es un ID válido de la base de datos (> 0), consultamos la DB
            if (idCtoSeleccionado > 0)
            {
                ConsultaCampeonato(idCtoSeleccionado);
                btnEditCto.Enabled = true;
                btnDelCto.Enabled = true;
                ComboPruebasInit(idCtoSeleccionado);
                cboxPrueba.Enabled = true;
                btnNewPrueba.Enabled = true;    
            }
        }
        else
        {
            // Si SelectedIndex == -1 o no hay selección activa, limpiamos el TextBox
            tboxPuntos.Clear();
        }

    }

    private void ConsultaCampeonato(int idCtoSeleccionado)
    {
        using var db = new AppDbContext();
        var puntuaciones = db.Campeonatos
                              .Where(c => c.Id == idCtoSeleccionado)
                              .Select(c => c.SistemaPuntuacion)
                              .FirstOrDefault();

        tboxPuntos.Text = puntuaciones ?? "NO definido";
    }

    private void AltaCampeonato()
    {
        using var frmAlta = new FormCto();
        if (frmAlta.ShowDialog() == DialogResult.OK)
        {
            // Si el usuario guardó con éxito, refrescamos este combo
            // RecargarComboCampeonatos();
        }
        else
        {
            // Si canceló, volvemos a seleccionar el primer elemento para no dejar el "- Añadir nuevo -" marcado
            cboxCto.SelectedIndex = -1;
        }
    }

    private void BtnNewCto_Click(object sender, EventArgs e)
    {
        // Abrimos el formulario de alta como Modal (ShowDialog)
        AltaCampeonato();
    }

}
