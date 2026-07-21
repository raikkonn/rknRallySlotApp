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
        tboxPuntos.Clear();
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
                ConsultaPtosCampeonato(idCtoSeleccionado);
                ComboPruebasInit(idCtoSeleccionado);
                ControlesEnableDisable();
            }
        }
        else
        {
            // Si SelectedIndex == -1 o no hay selección activa, limpiamos el TextBox
            tboxPuntos.Clear();
        }

    }

    private void ConsultaPtosCampeonato(int idCtoSeleccionado)
    {
        using var db = new AppDbContext();
        var puntuaciones = db.Campeonatos
                              .Where(c => c.Id == idCtoSeleccionado)
                              .Select(c => c.SistemaPuntuacion)
                              .FirstOrDefault();

        tboxPuntos.Text = string.IsNullOrEmpty(puntuaciones) ? "NO definido" : puntuaciones;
    }

    private void AltaCampeonato()
    {
        using var frmAlta = new FormCto();

        if (frmAlta.ShowDialog() == DialogResult.OK)
        {
            // Si el usuario guardó con éxito, refrescamos este combo
            ComboCampeonatosInit();
            cboxCto.SelectedValue = frmAlta.IdCampeonatoCreado;
        }
        else
        {
            // Si canceló, vaciamos el combo
            cboxCto.SelectedIndex = -1;
        }

        ControlesEnableDisable();
    }

    private void BtnNewCto_Click(object sender, EventArgs e)
    {
        // Abrimos el formulario de alta 
        AltaCampeonato();
    }

    private void ControlesEnableDisable()
    {
        if (cboxCto.SelectedValue is int iCto && iCto > 0)
        {
            btnNewCto.Enabled = true;
            btnEditCto.Enabled = true;
            btnDelCto.Enabled = true;

            cboxPrueba.Enabled = true;
            btnNewPrueba.Enabled = true;
            btnEditPrueba.Enabled = false;
            btnDelPrueba.Enabled = false;
        }
        else
        {
            btnNewCto.Enabled = true;
            btnEditCto.Enabled = false;
            btnDelCto.Enabled = false;

            cboxPrueba.Enabled = false;
            btnNewPrueba.Enabled = false;
            btnEditPrueba.Enabled = false;
            btnDelPrueba.Enabled = false;
        }

        if (cboxPrueba.SelectedValue is int iPrueba && iPrueba > 0)
        {
            btnNewPrueba.Enabled = true;
            btnEditPrueba.Enabled = true;
            btnDelPrueba.Enabled = true;
        }
        else
        {
            btnNewPrueba.Enabled = true;
            btnEditPrueba.Enabled = false;
            btnDelPrueba.Enabled = false;
        }
    }

    private void BtnDelCto_Click(object sender, EventArgs e)
    {
        // 1. Obtener y validar el ID del campeonato seleccionado en el ComboBox
        if (cboxCto.SelectedValue is not int idCampeonato || idCampeonato <= 0)
        {
            lblStatusMain.Text = "Selecciona campeonato válido";
            return;
        }

        // 2. Pedir confirmación al usuario antes de borrar
        DialogResult confirmacion = MessageBox.Show(
            $"¿Estás seguro de que deseas eliminar este campeonato?\n\nEsta acción no se podrá deshacer.",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmacion != DialogResult.Yes)
        {
            return; // El usuario canceló la operación
        }

        try
        {
            // 3. Abrir un contexto de base de datos fresco
            using var db = new AppDbContext();

            // 4. Buscar la entidad en la base de datos por su ID
            var campeonatoAborrar = db.Campeonatos.Find(idCampeonato);

            if (campeonatoAborrar != null)
            {
                // 5. Marcar para eliminación y guardar cambios en SQLite
                db.Campeonatos.Remove(campeonatoAborrar);
                db.SaveChanges();

                lblStatusMain.Text = "Campeonato eliminado OK";
            }
            else
            {
                lblStatusMain.Text = "Campeonato NO existe";
            }
        }
        catch (DbUpdateException)
        {
            // Control de integridad referencial
            MessageBox.Show("No se puede eliminar el campeonato porque tiene pruebas o inscripciones asociadas.\n" +
                            "Elimina primero las pruebas vinculadas a este campeonato.",
                            "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocurrió un error inesperado al eliminar: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // 6. Actualizar la interfaz
        ComboCampeonatosInit();
        ControlesEnableDisable();
    }
}
