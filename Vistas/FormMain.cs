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

        // Inicializaciones
        BotonesInit();
        ComboCampeonatosInit();

        //DataGridInscripcionInit();
    }

    private void BotonesInit()
    {
        btnNewCto.Image = Properties.Resources.new_b.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnNewCto.ImageAlign = ContentAlignment.MiddleCenter;

        btnEditCto.Image = Properties.Resources.pencil_b.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnEditCto.ImageAlign = ContentAlignment.MiddleCenter;

        btnDelCto.Image = Properties.Resources.del_r.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnDelCto.ImageAlign = ContentAlignment.MiddleCenter;

        btnNewPrueba.Image = Properties.Resources.new_b.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnNewPrueba.ImageAlign = ContentAlignment.MiddleCenter;

        btnEditPrueba.Image = Properties.Resources.pencil_b.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnEditPrueba.ImageAlign = ContentAlignment.MiddleCenter;

        btnDelPrueba.Image = Properties.Resources.del_r.Zoom(btnEditCto.Width - 5, btnEditCto.Height - 5);
        btnDelPrueba.ImageAlign = ContentAlignment.MiddleCenter;
    }

    private void ControlesEnableDisable()
    {
        if (cboxCto.SelectedValue is int iCto && iCto > 0)
        {
            btnNewCto.Enabled = true;
            btnEditCto.Enabled = true;
            btnDelCto.Enabled = true;

            cboxPrueba.Enabled = true;

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
        else
        {
            tboxPuntos.Clear();

            btnNewCto.Enabled = true;
            btnEditCto.Enabled = false;
            btnDelCto.Enabled = false;

            cboxPrueba.Enabled = false;

            btnNewPrueba.Enabled = false;
            btnEditPrueba.Enabled = false;
            btnDelPrueba.Enabled = false;
        }
    }

    private void ComboCampeonatosInit()
    {
        cboxCto.SelectedIndexChanged -= CboxCto_SelectedIndexChanged;

        try
        {
            using var db = new AppDbContext();

            // Obtenemos la lista de campeonatos desde la base de datos
            var listaCampeonatos = db.Campeonatos
                .Select(c => new { c.Id, c.Nombre })
                .ToList();

            // Agregamos un elemento "comodín" al final de la lista
            listaCampeonatos.Add(new { Id = -5, Nombre = "- Añadir nuevo -" });

            // Asignamos la lista al ComboBox
            cboxCto.DataSource = listaCampeonatos;
            cboxCto.DisplayMember = "Nombre";
            cboxCto.ValueMember = "Id";

            // Dejar Selección Vacia
            cboxCto.SelectedIndex = -1;
            ControlesEnableDisable();
        }
        finally
        {
            cboxCto.SelectedIndexChanged += CboxCto_SelectedIndexChanged;
        }
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
        listaPruebas.Add(new { Id = -5, Nombre = "- Añadir nuevo -" });

        // Asignamos la lista al ComboBox
        cboxPrueba.DataSource = listaPruebas;
        cboxPrueba.DisplayMember = "Nombre";
        cboxPrueba.ValueMember = "Id";

        // Dejar Selección Vacia
        cboxPrueba.SelectedIndex = -1;
        ControlesEnableDisable();
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

    private void CboxCto_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cboxCto.SelectedValue is int idSelected)
        {
            if (idSelected > 0)
            {
                ConsultaPtosCampeonato(idSelected); // (> 0) ID válido, consultar DB
                ComboPruebasInit(idSelected);       // Inicializamos Combo Pruebas para el campeonato seleccionado
            } 
            else if (idSelected == -5)
            {
                cboxCto.SelectedIndex = -1; // Limpiamos la selección para evitar confusión 
                tboxPuntos.Clear();         // Sin selección activa, limpiamos el TextBox
                ControlesEnableDisable();   // Actualizamos los controles después de la operación
                AltaCampeonato();           // Opción "Añadir Nuevo"
            }
            else
            {
                tboxPuntos.Clear();         // Sin selección activa, limpiamos el TextBox
                ControlesEnableDisable();   // Actualizamos los controles después de la operación
            }
        }   
    }

    private void ConsultaPtosCampeonato(int idSelected)
    {
        using var db = new AppDbContext();

        var puntuaciones = db.Campeonatos
                              .Where(c => c.Id == idSelected)
                              .Select(c => c.SistemaPuntuacion)
                              .FirstOrDefault();

        tboxPuntos.Text = string.IsNullOrEmpty(puntuaciones) ? "NO definido" : puntuaciones;
    }

    private void AltaCampeonato()
    {
        using var frmAlta = new FormCto("Nuevo Campeonato");

        if (frmAlta.ShowDialog() == DialogResult.OK)
        {
            ComboCampeonatosInit();                             // Si el usuario guardó con éxito, refrescamos este combo
            cboxCto.SelectedValue = frmAlta.IdCampeonatoCreado; // seleccionamos el nuevo campeonato creado
            ControlesEnableDisable();                           // Actualizamos los controles después de la operación
        }
        else
        {
            cboxCto.SelectedIndex = -1; // Si canceló, vaciamos el combo
            ControlesEnableDisable();   // Actualizamos los controles después de la operación
        }
    }

    private void BtnNewCto_Click(object sender, EventArgs e)
    {
        cboxCto.SelectedIndex = -1; // Limpiamos la selección para evitar confusión 
        tboxPuntos.Clear();         // Sin selección activa, limpiamos el TextBox
        ControlesEnableDisable();   // Actualizamos los controles después de la operación
        AltaCampeonato();           // Opción "Añadir Nuevo"
    }

    private void BtnDelCto_Click(object sender, EventArgs e)
    {
        // Validar ID campeonato seleccionado en ComboBox
        if (cboxCto.SelectedValue is int idSelected && idSelected > 0)
        {
            // Confirmación usuario 
            DialogResult confirmacion = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar este campeonato?\n\nEsta acción no se podrá deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    using var db = new AppDbContext();  // Contexto DB

                    var ctoParaBorrado = db.Campeonatos.Find(idSelected);    // DB, buscar por ID

                    if (ctoParaBorrado != null)
                    {
                        db.Campeonatos.Remove(ctoParaBorrado);  // DB, marcar para borrado
                        db.SaveChanges();                       // SQLite, guardar cambios 
                        ComboCampeonatosInit();                 // Actualizar interfaz

                        MostrarMsgEstado("Campeonato eliminado OK");
                    }
                    else
                    {
                        MostrarMsgEstado("Campeonato NO existe");
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
            }
        }
        else
        {
            MostrarMsgEstado("Selecciona campeonato válido");
        }
    }

    private CancellationTokenSource? _ctsMensaje;

    private async void MostrarMsgEstado(string msg, int ms = 4000)
    {
        // Cancela la espera del mensaje anterior si aún estaba corriendo
        _ctsMensaje?.Cancel();
        _ctsMensaje = new CancellationTokenSource();

        lblStatusMain.Text = msg;

        try
        {
            // Pasa el Token de cancelación a Task.Delay
            await Task.Delay(ms, _ctsMensaje.Token);
            lblStatusMain.Text = string.Empty; // Limpia al terminar el tiempo
        }
        catch (TaskCanceledException)
        {
            // Ocurre cuando un nuevo mensaje interrumpe la espera actual
        }
    }

}
